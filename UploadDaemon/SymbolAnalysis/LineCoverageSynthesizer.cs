using Common;
using Cqse.ConQAT.Dotnet.Bummer;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualStudio.CodeCoverage;
using System.Diagnostics;
using System.Xml;

namespace UploadDaemon.SymbolAnalysis
{
    /// <summary>
    /// Converts a trace file to a line coverage report with the help of PDB files.
    /// </summary>
    public class LineCoverageSynthesizer : ILineCoverageSynthesizer
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <inheritdoc/>
        public Dictionary<string, FileCoverage> ConvertToLineCoverage(ParsedTraceFile traceFile, string symbolDirectory, GlobPatternList assemblyPatterns)
        {
            SymbolCollection symbolCollection = SymbolCollection.CreateFromPdbFiles(symbolDirectory, assemblyPatterns);
            if (symbolCollection.IsEmpty)
            {
                throw new LineCoverageConversionFailedException($"Failed to convert {traceFile.FilePath} to line coverage." +
                    $" Found no symbols in {symbolDirectory} matching {assemblyPatterns.Describe()}");
            }

            Dictionary<string, FileCoverage> lineCoverage = ConvertToLineCoverage(traceFile, symbolCollection, symbolDirectory, assemblyPatterns);
            if (lineCoverage.Count == 0 || lineCoverage.Values.All(fileCoverage => fileCoverage.CoveredLineRanges.Count() == 0))
            {
                return null;
            }

            return lineCoverage;
        }

        public Dictionary<string, FileCoverage> ConvertToLineCoverageAndUncoverage(ParsedTraceFile traceFile, string symbolDirectory, GlobPatternList assemblyPatterns)
        {
            SymbolCollection symbolCollection = SymbolCollection.CreateFromPdbFiles(symbolDirectory, assemblyPatterns);
            if (symbolCollection.IsEmpty)
            {
                throw new LineCoverageConversionFailedException($"Failed to convert {traceFile.FilePath} to line coverage." +
                    $" Found no symbols in {symbolDirectory} matching {assemblyPatterns.Describe()}");
            }

            Dictionary<string, FileCoverage> lineCoverage = ConvertToLineCoverageAndUncoverage(traceFile, symbolCollection, symbolDirectory, assemblyPatterns);
            if (lineCoverage.Count == 0 || lineCoverage.Values.All(fileCoverage => fileCoverage.CoveredLineRanges.Count() == 0))
            {
                return null;
            }

            return lineCoverage;
        }

        /// <summary>
        /// Converts the given line coverage (covered line ranges per file) into a SIMPLE format report for Teamscale.
        /// </summary>
        public static string ConvertToLineCoverageReport(Dictionary<string, FileCoverage> lineCoverage)
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("# isMethodAccurate=true");
            foreach (string file in lineCoverage.Keys)
            {
                report.AppendLine(file);
                foreach ((uint startLine, uint endLine) in lineCoverage[file].CoveredLineRanges)
                {
                    report.AppendLine($"{startLine}-{endLine}");
                }
            }
            return report.ToString();
        }

        /// <summary>
        /// Converts the given line coverage (covered line ranges per file) into a SIMPLE format report for Teamscale.
        /// </summary>
        public static string ConvertToSonarQubeGenericReport(Dictionary<string, FileCoverage> lineCoverage)
        {
            XmlSerializer s = new XmlSerializer(typeof(SonarQubeGenericReport));
            var report = new SonarQubeGenericReport() { Version = 1 };
            var listFiles = new List<SonarQubeFileCoverage>();
            foreach (string filePath in lineCoverage.Keys)
            {
                var sonarQubeFileCoverage = new SonarQubeFileCoverage() { Path = filePath };
                var listLineToCover = new List<LineToCover>();
                foreach ((uint startLine, uint endLine) in lineCoverage[filePath].CoveredLineRanges)
                {
                    var arrCoveredInt = listLineToCover.Select(ltc => ltc.LineNumber).ToList();
                    var range = Enumerable.Range((int)startLine, (int)(endLine - startLine))
                        .Select(x => (uint)x)
                        .Where(x => !arrCoveredInt.Contains(x))
                        .Select(x => new LineToCover() { LineNumber = x, Covered = true });
                    listLineToCover.AddRange(range);
                }
                sonarQubeFileCoverage.LineToCovers = listLineToCover.ToArray();
                listFiles.Add(sonarQubeFileCoverage);
            }
            report.Files = listFiles.ToArray();
            using (StringWriter textWriter = new StringWriter())
            {
                s.Serialize(textWriter, report);
                return textWriter.ToString();
            }
        }

        public static string ConvertToVisualStudioCoverageReport(Dictionary<string, FileCoverage> lineCoverage)
        {
            var report = new VsCoverageResults()
            {
                modules = lineCoverage
                       .GroupBy(e => e.Value.AssemblyName)
                       .Select((g) =>
                       {
                           var mappingSourceIds = g.Select((gv, i) => new resultsModuleSource_file()
                           {
                               id = i,
                               checksum = string.Empty,
                               checksum_type = string.Empty,
                               path = gv.Key
                           }).ToDictionary(x => x.path, x => x);

                           return new resultsModule()
                           {
                               blocks_covered = 0,
                               blocks_not_covered = 0,
                               block_coverage = 0,
                               lines_covered = 0,
                               lines_not_covered = 0,
                               line_coverage = 0,
                               lines_partially_covered = 0,
                               id = Guid.NewGuid().ToString(),
                               name = g.Key,
                               path = g.Key,
                               functions = g.Select(gv =>
                               {
                                   return gv.Value.DetailLineRanges.Select(gvvdlr => new resultsModuleFunction()
                                   {
                                       blocks_covered = 0,
                                       blocks_not_covered = 0,
                                       block_coverage = 0,
                                       lines_covered = 0,
                                       lines_not_covered = 0,
                                       line_coverage = 0,
                                       lines_partially_covered = 0,
                                       id = gvvdlr.methodToken,
                                       name = gvvdlr.methodToken.ToString(),
                                       token = string.Format("0x{0:x}", gvvdlr.methodToken),
                                       type_name = string.Empty,
                                       ranges = Enumerable.Range((int)gvvdlr.lineStart, (int)(gvvdlr.lineEnd - gvvdlr.lineStart + 1))
                                           .Select(ln => new resultsModuleFunctionRange()
                                           {
                                               end_line = (ushort)ln,
                                               start_line = (ushort)ln,
                                               covered = gvvdlr.isCovered ? "yes" : "no",
                                               start_column = 0,
                                               end_column = 0,
                                               source_id = mappingSourceIds[gv.Key].id
                                           }).ToArray()
                                   });
                               }).SelectMany(x => x).ToArray(),
                               source_files = mappingSourceIds.Select((e) => e.Value).ToArray()
                           };
                       }).ToArray()
            };

            foreach (var resultModule in report.modules)
            {
                foreach (var function in resultModule.functions)
                {
                    function.lines_covered = function.ranges.Count(r => r.covered == "yes");
                    function.lines_not_covered = function.ranges.Count(r => r.covered == "no");
                    function.line_coverage = (decimal)function.lines_covered / (decimal)(function.lines_covered + function.lines_partially_covered + function.lines_not_covered) * 100;
                }

                resultModule.lines_covered = resultModule.functions.Sum(f => f.lines_covered);
                resultModule.lines_not_covered = resultModule.functions.Sum(f => f.lines_not_covered);
                resultModule.line_coverage = (decimal)resultModule.lines_covered / (decimal)(resultModule.lines_covered + resultModule.lines_partially_covered + resultModule.lines_not_covered) * 100;
            }

            return Helper.XmlSerialize(report);
        }

        public static string ConvertToJacocoGenericReport(Dictionary<string, FileCoverage> lineCoverage)
        {
            XmlSerializer s = new XmlSerializer(typeof(JacocoReport));
            var report = new JacocoReport() { Name = Guid.NewGuid().ToString() };
            var listPackages = new List<JacocoPackage>();
            foreach (string filePath in lineCoverage.Keys)
            {
                var parts = filePath.Split('\\');
                (string packageName, string sourceFileName) =
                (
                    parts.Where((e, i) => i < (parts.Length - 1)).Aggregate((a, b) => $"{a}\\{b}"),
                    parts[parts.Length - 1]
                );

                var coveredLines = lineCoverage[filePath]
                    .CoveredLineRanges
                    .Select((x) => Enumerable.Range((int)x.Item1, (int)x.Item2 - (int)x.Item1))
                    .SelectMany(x => x)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToArray();

                var existPackage = listPackages.FirstOrDefault(p => p.Name == packageName);
                if (existPackage != null)
                {
                    var existedSourceFile = existPackage.SourceFiles.FirstOrDefault(sf => sf.Name == sourceFileName);
                    if (existedSourceFile != null)
                    {
                        var existedLines = existedSourceFile.Lines.Select(l => l.Nr).ToArray();
                        var availableLines = coveredLines.Where(cl => !existedLines.Contains(cl)).Select(acl => new JacocoLine() { Nr = acl });
                        existedSourceFile.Lines.AddRange(availableLines);
                    }
                    else
                    {
                        existPackage.SourceFiles.Add(new JacocoSourceFile()
                        {
                            Name = sourceFileName,
                            Lines = coveredLines.Select(acl => new JacocoLine() { Nr = acl }).ToList()
                        });
                    }
                }
                else
                {
                    listPackages.Add(new JacocoPackage()
                    {
                        Name = packageName,
                        SourceFiles = new List<JacocoSourceFile>()
                        {
                            new JacocoSourceFile()
                            {
                                Name = sourceFileName,
                                Lines = coveredLines.Select(acl => new JacocoLine() { Nr = acl }).ToList()
                            }
                        }
                    });
                }
            }

            report.Packages = listPackages.ToArray();
            using (StringWriter textWriter = new StringWriter())
            {
                s.Serialize(textWriter, report);
                return textWriter.ToString();
            }
        }

        private class AssemblyResolutionCount
        {
            public int resolvedMethods = 0;
            public int unresolvedMethods = 0;
            public int methodsWithoutSourceFile = 0;
            public int methodsWithCompilerHiddenLines = 0;
            public int TotalMethods => resolvedMethods + unresolvedMethods;
            public string UnresolvedPercentage => string.Format("{0:F1}%", unresolvedMethods * 100 / (double)TotalMethods);
            public string WithoutSourceFilePercentage => string.Format("{0:F1}%", methodsWithoutSourceFile * 100 / (double)TotalMethods);
            public string WithCompilerHiddenLinesPercentage => string.Format("{0:F1}%", methodsWithCompilerHiddenLines * 100 / (double)TotalMethods);
        }

        /// <summary>
        /// Converts the given trace file to a dictionary containing all covered lines of each source file for which
        /// coverage could be resolved with the PDB files in the given symbol directory.
        ///
        /// Public for testing.
        /// </summary>
        public static Dictionary<string, FileCoverage> ConvertToLineCoverage(ParsedTraceFile traceFile, SymbolCollection symbolCollection,
            string symbolDirectory, GlobPatternList assemblyPatterns)
        {
            Dictionary<string, AssemblyResolutionCount> resolutionCounts = new Dictionary<string, AssemblyResolutionCount>();
            Dictionary<string, FileCoverage> lineCoverage = new Dictionary<string, FileCoverage>();

            foreach ((string assemblyName, uint methodId) in traceFile.CoveredMethods)
            {
                if (!assemblyPatterns.Matches(assemblyName))
                {
                    continue;
                }

                SymbolCollection.SourceLocation sourceLocation = symbolCollection.Resolve(assemblyName, methodId);
                if (!resolutionCounts.TryGetValue(assemblyName, out AssemblyResolutionCount count))
                {
                    count = new AssemblyResolutionCount();
                    resolutionCounts[assemblyName] = count;
                }

                if (sourceLocation == null)
                {
                    count.unresolvedMethods += 1;
                    logger.Debug("Could not resolve method ID {methodId} from assembly {assemblyName} in trace file {traceFile}" +
                        " with symbols from {symbolDirectory} with {assemblyPatterns}", methodId, assemblyName,
                        traceFile.FilePath, symbolDirectory, assemblyPatterns.Describe());
                    continue;
                }
                else if (string.IsNullOrEmpty(sourceLocation.SourceFile))
                {
                    count.methodsWithoutSourceFile += 1;
                    logger.Debug("Could not resolve source file of method ID {methodId} from assembly {assemblyName} in trace file {traceFile}" +
                        " with symbols from {symbolDirectory} with {assemblyPatterns}", methodId, assemblyName,
                        traceFile.FilePath, symbolDirectory, assemblyPatterns.Describe());
                    continue;
                }
                else if (sourceLocation.StartLine == PdbFile.CompilerHiddenLine || sourceLocation.EndLine == PdbFile.CompilerHiddenLine)
                {
                    count.methodsWithCompilerHiddenLines += 1;
                    logger.Debug("Resolved lines of method ID {methodId} from assembly {assemblyName} contain compiler hidden lines in trace file {traceFile}" +
                        " with symbols from {symbolDirectory} with {assemblyPatterns}", methodId, assemblyName,
                        traceFile.FilePath, symbolDirectory, assemblyPatterns.Describe());
                    continue;
                }

                count.resolvedMethods += 1;
                AddToLineCoverage(lineCoverage, sourceLocation);
            }

            foreach (string assemblyName in resolutionCounts.Keys)
            {
                AssemblyResolutionCount count = resolutionCounts[assemblyName];
                // Log warning ugly method
                if (count.unresolvedMethods > 0)
                {
                    logger.Warn("{count} of {total} ({percentage}) method IDs from assembly {assemblyName} could not be resolved in trace file {traceFile} with symbols from" +
                        " {symbolDirectory} with {assemblyPatterns}. Turn on debug logging to get the exact method IDs." +
                        " This may happen if the corresponding PDB file either could not be found or could not be parsed. Ensure the PDB file for this assembly is" +
                        " in the specified PDB folder where the Upload Daemon looks for it and it is included by the PDB file include/exclude patterns configured for the UploadDaemon. " +
                        " You can exclude this assembly from the coverage analysis to suppress this warning.",
                        count.unresolvedMethods, count.TotalMethods, count.UnresolvedPercentage,
                        assemblyName, traceFile.FilePath, symbolDirectory, assemblyPatterns.Describe());
                }
                if (count.methodsWithoutSourceFile > 0)
                {
                    logger.Warn("{count} of {total} ({percentage}) method IDs from assembly {assemblyName} do not have a source file in the corresponding PDB file." +
                        " Read from trace file {traceFile} with symbols from" +
                        " {symbolDirectory} with {assemblyPatterns}. Turn on debug logging to get the exact method IDs." +
                        " This sometimes happens and may be an indication of broken PDB files. Please make sure your PDB files are correct." +
                        " You can exclude this assembly from the coverage analysis to suppress this warning.",
                        count.methodsWithoutSourceFile, count.TotalMethods, count.WithoutSourceFilePercentage,
                        assemblyName, traceFile.FilePath, symbolDirectory, assemblyPatterns.Describe());
                }
                if (count.methodsWithoutSourceFile > 0)
                {
                    logger.Warn("{count} of {total} ({percentage}) method IDs from assembly {assemblyName} contain compiler hidden lines in the corresponding PDB file." +
                        " Read from trace file {traceFile} with symbols from" +
                        " {symbolDirectory} with {assemblyPatterns}. Turn on debug logging to get the exact method IDs." +
                        " This is usually not a problem as the compiler may generate additional code that does not correspond to any source code." +
                        " You can exclude this assembly from the coverage analysis to suppress this warning.",
                        count.methodsWithCompilerHiddenLines, count.TotalMethods, count.WithCompilerHiddenLinesPercentage,
                        assemblyName, traceFile.FilePath, symbolDirectory, assemblyPatterns.Describe());
                }
            }

            return lineCoverage;
        }

        public static Dictionary<string, FileCoverage> ConvertToLineCoverageAndUncoverage(ParsedTraceFile traceFile, SymbolCollection symbolCollection,
            string symbolDirectory, GlobPatternList assemblyPatterns)
        {
            var lineCoverage = ConvertToLineCoverage(traceFile, symbolCollection, symbolDirectory, assemblyPatterns);
            var notCoveredLines = lineCoverage.Select(l => symbolCollection.DetectUnCoverageLines(l.Value.AssemblyName, l.Value.CoveredLineRanges.ToArray()))
                .Where(ncls => ncls != null && ncls.Length > 0)
                .SelectMany(ncls => ncls)
                .ToList();

            foreach (var ncl in notCoveredLines)
            {
                AddToLineCoverage(lineCoverage, ncl, false);
            }

            return lineCoverage;
        }   

        private static void AddToLineCoverage(Dictionary<string, FileCoverage> lineCoverage, SymbolCollection.SourceLocation sourceLocation, bool isCovered = true)
        {
            if (!lineCoverage.TryGetValue(sourceLocation.SourceFile, out FileCoverage fileCoverage))
            {
                fileCoverage = new FileCoverage();
                fileCoverage.AssemblyName = sourceLocation.AssemblyName;
                lineCoverage[sourceLocation.SourceFile] = fileCoverage;
            }

            if (isCovered)
            {
                fileCoverage.CoveredLineRanges.Add((sourceLocation.StartLine, sourceLocation.EndLine));
            }
            fileCoverage.DetailLineRanges.Add((isCovered, sourceLocation.MethodToken, sourceLocation.StartLine, sourceLocation.EndLine));
        }

        public class LineCoverageConversionFailedException : Exception
        {
            public LineCoverageConversionFailedException(string message) : base(message)
            {
            }
        }
    }
}

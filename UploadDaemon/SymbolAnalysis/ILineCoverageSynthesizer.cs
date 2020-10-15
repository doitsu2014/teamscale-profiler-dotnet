﻿using Common;
using NLog;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text;

namespace UploadDaemon.SymbolAnalysis
{
    /// <summary>
    /// Converts a trace file to a line coverage report with the help of PDB files.
    /// </summary>
    public interface ILineCoverageSynthesizer
    {
        /// <summary>
        /// Converts the given trace file to line coverage with the PDB files
        /// in the given symbol directory.
        ///
        /// The assembly patterns are used to select both the assemblies from the trace files for which
        /// coverage should be generated and the PDB files which should be searched for mappings.
        ///
        /// May throw exceptions if converting the trace file fails completely. Partial failures (e.g. missing
        /// PDB) are logged and no exception is thrown.
        ///
        /// Returns either the line coverage to upload or null in case the conversion resulted in an
        /// empty report.
        /// </summary>
        Dictionary<string, FileCoverage> ConvertToLineCoverage(ParsedTraceFile traceFile, string symbolDirectory, GlobPatternList assemblyPatterns);
        Dictionary<string, FileCoverage> ConvertToLineCoverageAndUncoverage(ParsedTraceFile traceFile, string symbolDirectory, GlobPatternList assemblyPatterns);
    }
}

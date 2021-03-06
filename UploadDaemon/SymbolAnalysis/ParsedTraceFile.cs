﻿using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UploadDaemon.SymbolAnalysis
{
    /// <summary>
    /// Parses the text of a trace file into a list of assembly names and method IDs that can be translated to line coverage
    /// with the help of PDB files.
    /// </summary>
    public class ParsedTraceFile
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// All assembly names mentioned in the trace file.
        /// </summary>
        public List<string> AssemblyNames { get; } = new List<string>();

        /// <summary>
        /// Path to this trace file.
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// All methods that are reported as covered. A method is identified by the name of its assembly
        /// (first elment in the tuple) and its ID (second element in the tuple).
        /// </summary>
        public List<(string, uint)> CoveredMethods { get; } = new List<(string, uint)>();

        private static readonly Regex AssemblyLineRegex = new Regex(@"^Assembly=([^:]+):(\d+)");
        private static readonly Regex CoverageLineRegex = new Regex(@"^(?:Inlined|Jitted)=(\d+):(?:\d+:)?(\d+)");

        public ParsedTraceFile(string[] lines, string filePath)
        {
            this.FilePath = filePath;

            Dictionary<uint, string> assemblyTokens = lines.Select(line => AssemblyLineRegex.Match(line))
                .Where(match => match.Success)
                .ToDictionary(match => Convert.ToUInt32(match.Groups[2].Value), match => match.Groups[1].Value);
            this.AssemblyNames = assemblyTokens.Values.ToList();

            IEnumerable<Match> coverageMatches = lines.Select(line => CoverageLineRegex.Match(line))
                            .Where(match => match.Success);
            foreach (Match match in coverageMatches)
            {
                uint assemblyId = Convert.ToUInt32(match.Groups[1].Value);
                if (!assemblyTokens.TryGetValue(assemblyId, out string assemblyName))
                {
                    logger.Warn("Invalid trace file {traceFile}: could not resolve assembly ID {assemblyId}. This is a bug in the profiler." +
                        " Please report it to CQSE. Coverage for this assembly will be ignored.", filePath, assemblyId);
                    continue;
                }
                CoveredMethods.Add((assemblyName, Convert.ToUInt32(match.Groups[2].Value)));
            }
        }
    }
}
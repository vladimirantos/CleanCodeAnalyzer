﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cleaner.Utils.Extensions;

namespace Cleaner.Analyzer
{
    public class CodeLengthMetric
    {
        /// <summary>
        /// Vrací celkový počet řádků.
        /// </summary>
        public int CountLines(string code) => code.CountLines();

        /// <summary>
        /// Vrací počet prázdných řádků.
        /// </summary>
        public int CountLinesWithoutSpace(string code) => (from line in code.Lines() where string.IsNullOrWhiteSpace(line) select line).Count();

        /// <summary>
        /// Vrací počet komentářových řádků.
        /// </summary>
        public int CountCommentsLines(string code) => (from line in code.Lines() where Regex.IsMatch(line, @"^\s*//|///|/\*|\*/") select line).Count();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Utils.Extensions;

namespace Cleaner.Analyzer.Helpers 
{
    public class CodeLength : IAnalyzerHelper<BaseStatistic>
    {
        private string _code;

        /// <summary>
        /// Vrací celkový počet řádků.
        /// </summary>
        public int CountLines => _code.CountLines();

        /// <summary>
        /// Vrací počet prázdných řádků.
        /// </summary>
        public int CountWhitespaceLines => (from line in _code.Lines() where string.IsNullOrWhiteSpace(line) select line).Count();

        /// <summary>
        /// Vrací počet komentářových řádků.
        /// </summary>
        public int CountCommentLines => (from line in _code.Lines() where Regex.IsMatch(line, @"^\s*//|///|/\*|\*/") select line).Count();

        public CodeLength(string code)
        {
            _code = code;
        }

        public BaseStatistic Analyze()
        {
            return new CodeLengthStatistics(CountLines, CountCommentLines, CountWhitespaceLines);
        }

        public static BaseStatistic Analyze(string code)
        {
            return new CodeLength(code).Analyze();
        }
    }
}

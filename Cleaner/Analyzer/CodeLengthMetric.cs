using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cleaner.Utils;

namespace Cleaner.Analyzer
{
    public class CodeLengthMetric
    {
        /// <summary>
        /// Vrací celkový počet řádků
        /// </summary>
        public int CountLines(string code) => code.CountLines();

        /// <summary>
        /// Vrací počet řádků bez prázdných znaků.
        /// </summary>
        public int CountLinesWithoutSpace(string code) => (from line in code.Lines() where !string.IsNullOrWhiteSpace(line) select line).Count();

        public int CountLinesWithoutSpaceComments(string code)
        {
            List<string> forbiddenCharacters = new List<string>() {"//", "///", "/\\*", "\\*/"};
            string[] lines = code.Lines();
            int count = 0;
            foreach (var line in lines)
            {
                forbiddenCharacters.ForEach(x =>
                {
                    var ax = line.IndexOf(x);
                    if (Regex.IsMatch(line, "^" + x + ".*"))
                        count++;
                });
            }
            return count;
        }
    }
}

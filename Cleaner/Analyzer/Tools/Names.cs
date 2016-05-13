using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Entity;
using Cleaner.Utils.Extensions;

namespace Cleaner.Analyzer.Tools
{
    /// <summary>
    /// Obsahuje metody pro kontrolu názvů.
    /// </summary>
    internal static class Names
    {
        private const string CamelCaseFirstUpper = @"\b[A-Z]+[a-z]+([A-Z]+[a-z]+)*";
        private const string CamelCaseFirstLower = @"\b[a-z]+[a-z]+([A-Z]+[a-z]+)*";
        private static readonly List<string> Keywords = new List<string>()
        {
            "string", "char", "long", "int", "integer", "float", "double", "array", "list", "dictionary", "stack"
        };

        /// <summary>
        /// Kontroluje jestli název neobsahuje klíčová slova a začíná velkým písmenem.
        /// </summary>
        public static bool IsCorrect(string name) => !ContainsKeyword(name) && IsUpperCamelCase(name);//char.IsUpper(name[0]);

        /// <summary>
        /// Kontroluje, jestli název proměnné neobsahuje informaci o datovém typu a začíná podtržítkem.
        /// </summary>
        /// <param name="dataType">Datový typ proměnné</param>
        public static bool IsCorrectVariableName(string name, string dataType)
            => !name.Contains(dataType) && IsLowerCamelCase(name) && name.Contains("_");

        /// <summary>
        /// Kontroluje, jestli název vlastnosti neobsahuje datový typ a začíná velkým písmenem.
        /// </summary>
        /// <param name="dataType">Datový typ vlastnosti</param>
        public static bool IsCorrectPropertyName(string name, string dataType)
            => !name.Contains(dataType) && IsUpperCamelCase(name) && !name.Contains("_");

        /// <summary>
        /// Kontroluje, jestli název neobsahuje nějaké klíčové slovo.
        /// </summary>
        private static bool ContainsKeyword(string name) => Keywords.Any(x => name.ToLower().Contains(x));

        private static bool IsUpperCamelCase(string name) => Regex.IsMatch(name, CamelCaseFirstUpper);

        private static bool IsLowerCamelCase(string name) => Regex.IsMatch(name, CamelCaseFirstLower);
    }
}

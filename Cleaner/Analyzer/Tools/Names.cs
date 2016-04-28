﻿using System;
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
    static class Names
    {
        private static readonly List<string> _keywords = new List<string>()
        {
            "string", "char", "long", "int", "integer", "float", "double", "array", "list", "dictionary", "stack"
        }; 

        public static bool IsCorrect(string name) => !ContainsKeyword(name) && char.IsUpper(name[0]);

        public static bool IsCorrectVariableName(string name, string dataType) 
            => !name.Contains(dataType) && name.StartsLower();

        public static bool IsCorrectPropertyName(string name, string dataType)
            => !name.Contains(dataType) && name.StartsUpper();

        /// <summary>
        /// Kontroluje, jestli název neobsahuje nějaké klíčové slovo.
        /// </summary>
        private static bool ContainsKeyword(string name) => _keywords.Any(x => name.ToLower().Contains(x));
    }
}

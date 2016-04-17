using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner
{
    static class Config
    {
        public static readonly string FilePattern = "*.cs";

        /// <summary>
        /// Složky, které se nemají prohledávat.
        /// </summary>
        public static readonly List<string> ForbiddenDirs = new List<string>() {"Properties", "Debug"};

        /// <summary>
        /// Určuje kolik stejných argumentů dvou metod je potřeba aby mohly být prohlášeny za stejné.
        /// Defaultně 2/3 argumentů musí být stejné.
        /// </summary>
        public static float SameArgumentsRate { get; } = 2/3f;
    }
}
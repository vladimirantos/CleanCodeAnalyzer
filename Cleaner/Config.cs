using System;
using System.Collections.Generic;
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
    }
}
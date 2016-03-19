using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner.Utils
{
    /// <summary>
    /// Pomáhá s určováním, jestli je hodnota členem výčtového typu.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Vrací true pokud je value členem výčtového typu zadaného pomocí generiky.
        /// </summary>
        public static bool IsEnumItem<T>(string value)
        {
            return EnumToList<T>().Any(x => x.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Převede výčtový typ T na seznam řetězců daných názvy prvků výčtového typu.
        /// </summary>
        public static List<string> EnumToList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(v => v.ToString()).ToList();
        } 
    }
}

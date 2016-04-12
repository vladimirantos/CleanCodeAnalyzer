using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Utils.Extensions
{
    static class ListExtension
    {
        /// <summary>
        /// Vrací řetězec hodnot seznamu oddělených zadaným oddělovačem.
        /// </summary>
        public static string Join<T>(this List<T> list, string separator = ", ") => string.Join(separator, list);

        /// <summary>
        /// Vrací kolekci vzniklou z hodnot mezi start a end. Hodnoty start a end ve výsledku nebudou. 
        /// Pokud v kolekci není hodnota start nebo end, metoda vrací prázdnou kolekci.
        /// </summary>
        public static IEnumerable<T> Between<T>(this List<T> data, T start, T end)
        {
            int startIndex = data.IndexOf(start);
            int endIndex = data.IndexOf(end);
            return startIndex < 0 || endIndex < 0 ? new List<T>() : data.GetRange(startIndex + 1, endIndex - startIndex - 1);
            //  return data.Skip(startIndex + 1).Take(data.IndexOf(end) - startIndex - 1);
        }

        /// <summary>
        /// Kontroluje jestli je obecná kolekce IEnumerabele prázdná.
        /// </summary>
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable) => !enumerable.Any();
    }
}

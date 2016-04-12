﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Utils
{
    static class StringUtils
    {
        /// <summary>
        /// Kontrola, jestli je řetězec napsán velkými písmeny.
        /// </summary>
        public static bool IsUpper(this string text) => text.All(char.IsUpper);

        /// <summary>
        /// Pokusí se převést řetězec na hodnotu výčtového typu. 
        /// V případě, že hodnota není členem výčtového typu vyvolá výjimku ArgumentException.
        /// </summary>
        public static T ToEnum<T>(this string value) => (T)Enum.Parse(typeof(T), value, true);

        /// <summary>
        /// Vrací pole řádků vzniklých ze zadaného textu.
        /// </summary>
        public static string[] Lines(this string text) => text.Split('\n');

        /// <summary>
        /// Vrací počet řádků v textu.
        /// </summary>
        public static int CountLines(this string text) => Lines(text).Length;
    }

    static class ListUtils
    {
        /// <summary>
        /// Vrací řetězec hodnot seznamu oddělených zadaným oddělovačem.
        /// </summary>
        public static string Join<T>(this List<T> list, string separator)
        {
            return string.Join(separator, list);
        }

        /// <summary>
        /// Vrací řetězec hodnot ze seznamu oddělených čárkou.
        /// </summary>
        public static string Join<T>(this List<T> list)
        {
            return Join(list, ", ");
        }

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
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return !enumerable.Any();
        }
    }
}

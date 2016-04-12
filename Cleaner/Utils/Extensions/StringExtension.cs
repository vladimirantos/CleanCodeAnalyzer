using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Utils.Extensions
{
    static class StringExtension
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
}

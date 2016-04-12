using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;
using Cleaner.Utils.Extensions;

namespace Cleaner.Utils
{
    public static class ModifiersHelper
    {
        /// <summary>
        /// Kontroluje jestli je parametr value přístupovým modifikátorem.
        /// </summary>
        public static bool IsAccessModifier(string value) => EnumHelper.IsEnumItem<AccessModifiers>(value);

        /// <summary>
        /// Kontroluje jestli je parametr value modifikátorem třídy.
        /// </summary>
        public static bool IsClassModifier(string value) => EnumHelper.IsEnumItem<ClassModifiers>(value);

        /// <summary>
        /// Kontroluje jestli je parametr value modifikátorem metody.
        /// </summary>
        public static bool IsMethodModifier(string value) => EnumHelper.IsEnumItem<MethodModifiers>(value);

        /// <summary>
        /// Převede řetězec na modifikátor přístupu. Vyvolává výjimku ArgumentException.
        /// Nutno předtím ověřit, jestli je hodnota členem výčtového typu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AccessModifiers AccessModifier(string value) => value.ToEnum<AccessModifiers>();

        /// <summary>
        /// Převede řetězec na modifikátor třídy. Vyvolává výjimku ArgumentException. 
        /// Nutno předtím ověřit, jestli je hodnota členem výčtového typu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ClassModifiers ClassModifier(string value) => value.ToEnum<ClassModifiers>();

        /// <summary>
        /// Převede řetězec na modifikátor vlastnosti. Vyvolává výjimku ArgumentException. 
        /// Nutno předtím ověřit, jestli je hodnota členem výčtového typu.
        /// </summary>
        public static PropertyModifiers PropertyModifier(string value) => value.ToEnum<PropertyModifiers>();

        /// <summary>
        /// Převede řetězec na modifikátor metody. Vyvolává výjimku ArgumentException. 
        /// Nutno předtím ověřit, jestli je hodnota členem výčtového typu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MethodModifiers MethodModifier(string value) => value.ToEnum<MethodModifiers>();

    }
}

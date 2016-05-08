using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;
using Cleaner.Utils.Extensions;

namespace Cleaner.Utils
{
    internal static class ModifiersHelper
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
        /// Kontroluje jestli je parametr value modifikátorem třídní proměnné.
        /// </summary>
        public static bool IsFieldModifier(string value) => EnumHelper.IsEnumItem<FieldModifiers>(value);

        /// <summary>
        /// Kontroluje, jestli je parametr value modifikátorem vlastnosti
        /// </summary>
        public static bool IsPropertyModifier(string value) => EnumHelper.IsEnumItem<PropertyModifiers>(value);

        /// <summary>
        /// Převede řetězec na modifikátor přístupu. Vyvolává výjimku ArgumentException.
        /// Nutno předtím ověřit, jestli je hodnota členem výčtového typu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AccessModifiers AccessModifier(string value, string message = null) => (AccessModifiers)Enum.Parse(typeof(AccessModifiers), value, true);

        /// <summary>
        /// Převede řetězec na modifikátor třídy. Vyvolává výjimku ArgumentException. 
        /// Nutno předtím ověřit, jestli je hodnota členem výčtového typu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ClassModifiers ClassModifier(string value) => (ClassModifiers)Enum.Parse(typeof(ClassModifiers), value, true);

        /// <summary>
        /// Převede řetězec na modifikátor vlastnosti. Vyvolává výjimku ArgumentException. 
        /// Nutno předtím ověřit, jestli je hodnota členem výčtového typu.
        /// </summary>
        public static PropertyModifiers PropertyModifier(string value) => (PropertyModifiers)Enum.Parse(typeof(PropertyModifiers), value, true);

        /// <summary>
        /// Převede řetězec na modifikátor metody. Vyvolává výjimku ArgumentException. 
        /// Nutno předtím ověřit, jestli je hodnota členem výčtového typu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MethodModifiers MethodModifier(string value) => (MethodModifiers)Enum.Parse(typeof(MethodModifiers), value, true);

        /// <summary>
        /// Převede řetězec na modifikátor třídní proměnné. Vyvolává výjimku ArgumentException. 
        /// Nutno předtím ověřit, jestli je hodnota členem výčtového typu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static FieldModifiers FieldModifier(string value) => (FieldModifiers)Enum.Parse(typeof(FieldModifiers), value, true);

    }
}

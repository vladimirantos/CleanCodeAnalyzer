using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cleaner.Entity
{
    interface IMember
    {
        string Name { get; set; }
        string DataType { get; set; }
    }
    interface IClassMember : IMember
    {
        AccessModifiers AccessModifier { get; set; }
        bool IsStatic { get; }
    }

    abstract class ClassMember : IClassMember
    {
        public AccessModifiers AccessModifier { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool IsStatic { get; set; }

        protected ClassMember(AccessModifiers accessModifier, string dataType, string name, bool isStatic)
        {
            AccessModifier = accessModifier;
            DataType = dataType;
            Name = name;
            IsStatic = isStatic;
        }

        protected ClassMember(AccessModifiers accessModifier, string dataType, string name)
        {
            AccessModifier = accessModifier;
            DataType = dataType;
            Name = name;
        }
    }

    /// <summary>
    /// TODO: zjistit naming convention pro konstanty
    /// </summary>
    class CcaConstant : ClassMember
    {
        public bool IsUpperCase => Name.IsUpper();

        public CcaConstant(AccessModifiers accessModifier, string dataType, string name, bool isStatic = false) 
            : base(accessModifier, dataType, name, isStatic) { }
    }

    class CcaClassVariable : ClassMember
    {
        /// <summary>
        /// Kontroluje, jestli název proměnné začíná podtržítkem
        /// </summary>
        public bool StartWithUnderScore => Name.StartsWith("_");

        public CcaClassVariable(AccessModifiers accessModifier, string dataType, string name, bool isStatic = false) 
            : base(accessModifier, dataType, name, isStatic) { }
    }

    class CcaProperty : ClassMember
    {
        public bool IsAutoProperty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasExpressionBody
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public CcaProperty(AccessModifiers accessModifier, string dataType, string name, bool isStatic = false) 
            : base(accessModifier, dataType, name, isStatic) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Entity
{
    /// <summary>
    /// Definuje vlastnosti třídních proměnných, vlastností a konstant
    /// </summary>
    public abstract class ClassMember : IClassElement, IVariable
    {
        public AccessModifiers AccessModifier { get; set; }
        public string DataType { get; set; }
        public string Name { get; set; }
        public bool IsStatic { get; private set; }

        protected ClassMember(AccessModifiers accessModifier, string dataType, string name, bool isStatic)
        {
            AccessModifier = accessModifier;
            DataType = dataType;
            Name = name;
            IsStatic = isStatic;
        }
    }
}

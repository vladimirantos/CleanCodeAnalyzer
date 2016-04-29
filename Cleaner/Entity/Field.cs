using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Entity
{
    public class Field : ClassMember
    {
        public List<FieldModifiers> Modifiers { get; set; }

        /// <summary>
        /// Kontroluje, jestli proměnná začíná podtržítkem.
        /// </summary>
        public bool StartWithUnderScore => Name.StartsWith("_");

        public Field(AccessModifiers accessModifier, string dataType, string name, bool isStatic) : base(accessModifier, dataType, name, isStatic)
        {
        }

        public Field(AccessModifiers accessModifiers, string dataType, string name) : this(accessModifiers, dataType, name, false)
        {
        }

        public override string ToString()
        {
            string access = AccessModifier != AccessModifiers.None ? AccessModifier.ToString() : null;
            return $"{access} {DataType} {Name}";
        }
    }
}

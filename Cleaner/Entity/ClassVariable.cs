using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Entity
{
    class ClassVariable : ClassMember
    {
        /// <summary>
        /// Kontroluje, jestli proměnná začíná podtržítkem.
        /// </summary>
        public bool StartWithUnderScore => Name.StartsWith("_");

        public ClassVariable(AccessModifiers accessModifier, string dataType, string name, bool isStatic) : base(accessModifier, dataType, name, isStatic)
        {
        }

        public ClassVariable(AccessModifiers accessModifiers, string dataType, string name) : this(accessModifiers, dataType, name, false)
        {
        }
    }
}

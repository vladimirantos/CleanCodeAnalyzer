using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Utils;

namespace Cleaner.Entity
{
    class CcaConstant : ClassMember
    {
        public bool IsUpperCase => Name.IsUpper();
        public CcaConstant(AccessModifiers accessModifier, string dataType, string name, bool isStatic) : base(accessModifier, dataType, name, isStatic)
        {
        }

        public CcaConstant(AccessModifiers accessModifiers, string dataType, string name) : this(accessModifiers, dataType, name, false)
        {
        }
    }
}

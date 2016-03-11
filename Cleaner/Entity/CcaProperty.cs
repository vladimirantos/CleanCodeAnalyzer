using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Entity
{
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
        public CcaProperty(AccessModifiers accessModifier, string dataType, string name, bool isStatic) : base(accessModifier, dataType, name, isStatic)
        {
        }

        public CcaProperty(AccessModifiers accessModifiers, string dataType, string name) : this(accessModifiers, dataType, name, false)
        {
        }
    }
}

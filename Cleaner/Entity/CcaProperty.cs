using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Utils;
using Cleaner.Utils.Extensions;

namespace Cleaner.Entity
{
    public class CcaProperty : ClassMember
    {
        public List<PropertyModifiers> Modifiers { get; set; }
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

        public bool IsVirtual => Modifiers.Any(x => x.Equals(PropertyModifiers.Virtual));

        public override bool? IsStatic => Modifiers.Any(x => x.Equals(PropertyModifiers.Static));

        public CcaProperty(AccessModifiers accessModifier, string dataType, string name, bool isStatic) : base(accessModifier, dataType, name, isStatic)
        {
        }

        public CcaProperty(AccessModifiers accessModifiers, string dataType, string name) : this(accessModifiers, dataType, name, false)
        {
        }

        public override string ToString() => $"{AccessModifier} {Modifiers.Join()} {DataType} {Name}";
    }
}

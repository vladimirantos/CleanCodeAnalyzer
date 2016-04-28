using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Entity
{
#pragma warning disable CS0659 // 'CcaVariable' overrides Object.Equals(object o) but does not override Object.GetHashCode()
    class CcaVariable : IVariable
#pragma warning restore CS0659 // 'CcaVariable' overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool StartWithUnderScore => Name.StartsWith("_");
        public CcaVariable(string name, string dataType)
        {
            Name = name;
            DataType = dataType;
        }

        public override bool Equals(object obj) => Equals(obj as CcaVariable);
        public override string ToString() => $"{DataType} {Name}";

        private bool Equals(CcaVariable variable) => DataType == variable.DataType;
    }
}

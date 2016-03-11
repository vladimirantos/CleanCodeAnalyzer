using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Entity
{
    class CcaClass
    {
        public ClassHeader Header { get; }
        public List<ClassMember> Members { get; }
        public List<CcaMethod> Methods { get; } 
    }

    class ClassHeader : IClassElement
    {
        public AccessModifiers AccessModifier { get; set; }
        public string Name { get; set; }
        public List<ClassModifiers> ClassModifiers { get; set; }
        public bool IsStatic { get; }
        public List<CcaClass> HeredityClasses { get; private set; }
    }
}

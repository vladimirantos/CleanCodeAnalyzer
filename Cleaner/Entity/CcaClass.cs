using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cleaner.Entity
{
    class CcaClass
    {
        public CcaClassHeader ClassHeader { get; private set; }
        public List<IClassMember> Members { get; set; } 
        public List<IMethod> Methods { get; set; } 
    }

    class CcaClassHeader
    {
        public string Name { get; private set; }
        public List<ClassModifiers> Modifiers { get; private set; }
        public List<string> HeredityClasses { get; private set; } 
    }
}

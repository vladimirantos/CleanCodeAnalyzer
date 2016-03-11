using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cleaner.Entity
{
    interface IMethod
    {
        MethodHeader Header { get; set; }
        MethodBody Body { get; set; }
    }

    class CcaMethod : IMethod
    {
       public MethodHeader Header { get; set; }
       public MethodBody Body { get; set; }
    }

    class MethodHeader : IClassMember
    {
        public AccessModifiers AccessModifier { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool IsStatic { get;}
        public List<MethodModifiers> Modifiers { get; set; }
        public List<CcaVariable> Arguments { get; set; }
        public CcaVariable ReturnType { get; set; }
    }

    class MethodBody
    {
        public string Content { get; set; }
        public int CountLines { get; }
    }
}

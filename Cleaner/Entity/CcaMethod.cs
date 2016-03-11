using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Entity
{
    /// <summary>
    /// Třída reprezentující metodu.
    /// </summary>
    class CcaMethod : IClassElement
    {
        public AccessModifiers AccessModifier { get; set; }
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public List<MethodModifiers> Modifiers { get; set; } 
        public List<IVariable> Arguments { get; set; } 
        public bool IsStatic { get; }
        public MethodBody Body { get; set; }
    }

    class MethodBody
    {
        public string Content { get; set; }
        public int CountLines { get; }
    }
}

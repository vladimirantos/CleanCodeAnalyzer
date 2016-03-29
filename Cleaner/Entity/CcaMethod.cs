using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Entity
{
    /// <summary>
    /// Třída reprezentující metodu.
    /// </summary>
    public class CcaMethod : IClassElement
    {
        public AccessModifiers AccessModifier { get; set; }
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public List<MethodModifiers> Modifiers { get; set; } 
        public List<IVariable> Arguments { get; set; }
        public bool? IsStatic
        {
            get { return Modifiers?.Any(x => x.Equals(MethodModifiers.Static)); }
        }
        public BlockSyntax Body { get; set; }

        public CcaMethod(AccessModifiers modifiers, List<MethodModifiers> methodModifiers, string name, List<IVariable> arguments)
        {
            AccessModifier = modifiers;
            Modifiers = Modifiers;
            Name = name;
            Arguments = arguments;
        }

        public CcaMethod(AccessModifiers modifiers, List<MethodModifiers> methodModifiers, string name)
            : this(modifiers, methodModifiers, name, new List<IVariable>())
        {
            
        }

        public override string ToString()
        {
            return $"{AccessModifier} {Name}";
        }
    }
}

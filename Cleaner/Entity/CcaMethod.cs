using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Entity
{
#pragma warning disable CS0659 // 'CcaMethod' overrides Object.Equals(object o) but does not override Object.GetHashCode()
    /// <summary>
    /// Třída reprezentující metodu.
    /// </summary>
    public class CcaMethod : IClassElement
#pragma warning restore CS0659 // 'CcaMethod' overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        public AccessModifiers AccessModifier { get; set; }
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public List<MethodModifiers> Modifiers { get; set; } 
        public List<IVariable> Arguments { get; set; }
        public bool? IsStatic => Modifiers?.Any(x => x.Equals(MethodModifiers.Static));
        public BlockSyntax Body { get; set; }
        public string Source { get; set; }
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

        public override string ToString() => $"{AccessModifier} {Name}";

        public override bool Equals(object obj) => Equals(obj as CcaMethod);

        public bool Equals(CcaMethod method)
        {
            foreach (var argument in Arguments)
            {
                foreach (var arg in method.Arguments)
                {
                    if (!argument.Equals(arg))
                        return false;
                }
            }
            return true;
        }
    }
}

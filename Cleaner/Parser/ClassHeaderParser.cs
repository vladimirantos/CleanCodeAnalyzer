using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;
using Cleaner.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Parser
{
    class ClassHeaderParser : IParser<ClassHeader>
    {
        private ClassDeclarationSyntax _syntax;

        public ClassHeaderParser(ClassDeclarationSyntax syntax)
        {
            _syntax = syntax;
        }

        public ClassHeader Parse()
        {
            AccessModifiers accessModifier = AccessModifiers.None;
            ClassModifiers classModifier = ClassModifiers.None;
            Modifiers(_syntax.Modifiers, ref accessModifier, ref classModifier);
            List<ClassModifiers> classModifiersList = new List<ClassModifiers> {classModifier};
            return new ClassHeader(accessModifier, _syntax.Identifier.ToString(), classModifiersList, GetBase());
        }

        /// <summary>
        /// Vrací modifikátor přístupu a modifikátory třídy
        /// </summary>
        private void Modifiers(SyntaxTokenList modifiersList, ref AccessModifiers accessModifier, ref ClassModifiers classModifier)
        {
            foreach (var syntaxToken in modifiersList)
            {
                string value = syntaxToken.ValueText;
                if (ModifiersHelper.IsAccessModifier(value))
                    accessModifier = ModifiersHelper.AccessModifier(value);
                else if (ModifiersHelper.IsClassModifier(value))
                    classModifier = ModifiersHelper.ClassModifier(value);
            }
        }

        /// <summary>
        /// Vrací seznam tříd ze kterých daná třída dědí.
        /// </summary>
        private List<string> GetBase()
        {
            List<string> result = new List<string>();
            _syntax.BaseList?.Types.ToList().ForEach(x => result.Add(x.ToString()));
            return result;
        }
    }
}

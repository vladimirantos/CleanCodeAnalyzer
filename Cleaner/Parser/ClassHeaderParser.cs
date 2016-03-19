using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;
using Cleaner.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Parser
{
    class ClassHeaderParser : BaseParser
    {
        public ClassHeader Result { get; private set; }
        public ClassHeaderParser(SyntaxTree syntaxTree, Assembly assembly) : base(syntaxTree, assembly)
        {

        }

        public override void Parse()
        {
            string className = null;
            AccessModifiers accessModifier = AccessModifiers.None;
            ClassModifiers classModifier = ClassModifiers.None;
            List<ClassModifiers> classModifiersList = new List<ClassModifiers>();
            List<CcaClass> heredityClasses = new List<CcaClass>();
            IEnumerable<ClassDeclarationSyntax> enumerator = Root.DescendantNodes().OfType<ClassDeclarationSyntax>();
            
            foreach (var classDeclarationSyntax in enumerator)
            {
                className = classDeclarationSyntax.Identifier.ToString();
                SyntaxTokenList syntaxTokenList = classDeclarationSyntax.Modifiers;
                Modifiers(syntaxTokenList, ref accessModifier, ref classModifier);
                classModifiersList.Add(classModifier);
            }
            Result = new ClassHeader(accessModifier, className, classModifiersList, heredityClasses);
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
                    accessModifier = AccessModifier(value);
                else if (ModifiersHelper.IsClassModifier(value))
                    classModifier = ClassModifier(value);
            }
        }
    }
}

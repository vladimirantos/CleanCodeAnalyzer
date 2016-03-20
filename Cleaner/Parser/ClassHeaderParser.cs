using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
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

        public ClassHeaderParser(ClassDeclarationSyntax declarationSyntax) : base(declarationSyntax)
        {
            
        }

        public override void Parse()
        {
            AccessModifiers accessModifier = AccessModifiers.None;
            ClassModifiers classModifier = ClassModifiers.None;
            List<ClassModifiers> classModifiersList = new List<ClassModifiers>();
            Modifiers(DeclarationSyntax.Modifiers, ref accessModifier, ref classModifier);
            classModifiersList.Add(classModifier);
            Result = new ClassHeader(accessModifier, DeclarationSyntax.Identifier.ToString(), classModifiersList, GetInheritingClasses());
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

        /// <summary>
        /// Vrací seznam tříd od kterých daná třída dědí.
        /// </summary>
        private List<string> GetInheritingClasses()
        {
            List<string> result = new List<string>();
            List<string> tokens = DeclarationSyntax.DescendantTokens().Select(x => x.ToString()).ToList();
            result = tokens.Between(":", "{").ToList();
            result.RemoveAll(x => x == ",");
            RemoveGenerics(ref result);
            return result;
        }

        /// <summary>
        /// Odstraní vše mezi špičatými závorkami. Slouží k odstranění generik např IEnumerable<string>
        /// </summary>
        private void RemoveGenerics(ref List<string> data)
        {
            int start = data.IndexOf("<");
            int end = data.IndexOf(">");
            if(start > 0 && end > 0)
                data.RemoveRange(start, end - start + 1);
        }
    }
}

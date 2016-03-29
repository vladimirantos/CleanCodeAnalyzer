using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;
using Cleaner.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Parser1
{
    public class MethodParser : BaseParser
    {
        private readonly MethodDeclarationSyntax _syntax;

        public CcaMethod Result { get; private set; }

        public MethodParser(MethodDeclarationSyntax syntax)
        {
            _syntax = syntax;
        }

        public override void Parse()
        {
            AccessModifiers accessModifier = AccessModifiers.None;
            MethodModifiers methodModifier = MethodModifiers.None;
            List<MethodModifiers> modifiers = new List<MethodModifiers>();
            Modifiers(_syntax.Modifiers, ref accessModifier, ref methodModifier);
            modifiers.Add(methodModifier);
            CcaMethod method = new CcaMethod(accessModifier, modifiers, _syntax.Identifier.ToString())
            {
                ReturnType = _syntax.ReturnType.ToString(),
                Body = _syntax.Body,
                Arguments = _syntax.ParameterList.Parameters.Select(
                    parameterSyntax => new CcaVariable(parameterSyntax.Identifier.ToString(), parameterSyntax.Type.ToString())).Cast<IVariable>().ToList()
            };
            Result = method;
        }

        /// <summary>
        /// Vrací modifikátor přístupu a modifikátory třídy
        /// </summary>
        private void Modifiers(SyntaxTokenList modifiersList, ref AccessModifiers accessModifier, ref MethodModifiers methodModifier)
        {
            foreach (var syntaxToken in modifiersList)
            {
                string value = syntaxToken.ValueText;
                if (ModifiersHelper.IsAccessModifier(value))
                    accessModifier = AccessModifier(value);
                else if (ModifiersHelper.IsClassModifier(value))
                    methodModifier = MethodModifier(value);
            }
        }
    }
}

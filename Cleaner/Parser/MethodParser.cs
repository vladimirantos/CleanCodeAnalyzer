using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;
using Cleaner.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Parser
{
    internal class MethodParser : IParser<IEnumerable<CcaMethod>>
    {
        private readonly List<MethodDeclarationSyntax> _syntax;

        public MethodParser(List<MethodDeclarationSyntax> syntax)
        {
            _syntax = syntax;
        }

        public IEnumerable<CcaMethod> Parse()
        {
            List<MethodModifiers> modifiers = new List<MethodModifiers>();
            foreach (var methodDeclaration in _syntax)
            {
                AccessModifiers accessModifier = AccessModifiers.None;
                MethodModifiers methodModifier = MethodModifiers.None;
                Modifiers(methodDeclaration.Modifiers, ref accessModifier, ref methodModifier);
                modifiers.Add(methodModifier);
                yield return new CcaMethod(accessModifier, modifiers, methodDeclaration.Identifier.ToString())
                {
                    ReturnType = methodDeclaration.ReturnType.ToString(),
                    Body = methodDeclaration.Body,
                    Source = methodDeclaration.ToFullString(),
                    Arguments = methodDeclaration.ParameterList.Parameters.Select(
                                  parameterSyntax => new CcaVariable(parameterSyntax?.Identifier.ToString(), parameterSyntax?.Type?.ToString())
                                ).Cast<IVariable>().ToList()
                };
            }
        }

        /// <summary>
        /// Vrací modifikátor přístupu a modifikátory třídy.
        /// </summary>
        private void Modifiers(SyntaxTokenList modifiersList, ref AccessModifiers accessModifier, ref MethodModifiers methodModifier)
        {
            foreach (var syntaxToken in modifiersList)
            {
                string value = syntaxToken.ValueText;
                if (ModifiersHelper.IsAccessModifier(value))
                    accessModifier = ModifiersHelper.AccessModifier(value);
                else if (ModifiersHelper.IsClassModifier(value))
                    methodModifier = ModifiersHelper.MethodModifier(value);
            }
        }

    }
}

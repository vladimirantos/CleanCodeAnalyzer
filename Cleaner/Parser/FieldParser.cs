using System;
using System.Activities;
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
    internal class FieldParser : IParser<IEnumerable<Field>>
    {
        private readonly List<FieldDeclarationSyntax> _variableDeclarationList;

        public FieldParser(List<FieldDeclarationSyntax> variableDeclarationList)
        {
            _variableDeclarationList = variableDeclarationList;
        }

        /// <summary>
        /// Vrací seznam datových členů třídy.
        /// </summary>
        public IEnumerable<Field> Parse()
        {
            List<FieldModifiers> modifiers = new List<FieldModifiers>();
            foreach (var variableDeclaration in _variableDeclarationList)
            {
                AccessModifiers accessModifier = AccessModifiers.None;
                FieldModifiers modifier = FieldModifiers.None;
                Modifiers(variableDeclaration.Modifiers, ref accessModifier, ref modifier);
                modifiers.Add(modifier);
                yield return new Field(accessModifier, variableDeclaration.Declaration.Type.ToString(),
                    GetName(variableDeclaration.Declaration.Variables.ToString()))
                {
                    Modifiers = modifiers,
                    Content = variableDeclaration.ToString()
                };
            }
        }

        /// <summary>
        /// Vrací název proměnné. Pokud je proměnná inicializovaná, její název obsahuje i hodnotu za rovnítkem. Metoda tuto část odstraní.
        /// </summary>
        private string GetName(string name) => name.Split('=').First().Trim();

        /// <summary>
        /// Vrací modifikátor přístupu a modifikátory třídy.
        /// </summary>
        private void Modifiers(SyntaxTokenList modifiersList, ref AccessModifiers accessModifier, ref FieldModifiers methodModifier)
        {
            foreach (var syntaxToken in modifiersList)
            {
                string value = syntaxToken.ValueText;
                if (ModifiersHelper.IsAccessModifier(value))
                    accessModifier = ModifiersHelper.AccessModifier(value);
                else if (ModifiersHelper.IsFieldModifier(value))
                    methodModifier = ModifiersHelper.FieldModifier(value);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Parser
{
    internal class ClassVariableParser : IParser<IEnumerable<ClassVariable>>
    {
        private readonly List<VariableDeclarationSyntax> _variableDeclarationList;

        public ClassVariableParser(List<VariableDeclarationSyntax> variableDeclarationList)
        {
            _variableDeclarationList = variableDeclarationList;
        }

        public IEnumerable<ClassVariable> Parse()
        {
            foreach (var variableDeclaration in _variableDeclarationList)
            {
                yield return new ClassVariable(AccessModifiers.None, variableDeclaration.Type.ToString(), GetName(variableDeclaration.Variables.ToString()))
                {
                    Content = variableDeclaration.ToString()
                };
            }
        }

        /// <summary>
        /// Vrací název proměnné. Pokud je proměnná inicializovaná, její název obsahuje i hodnotu za rovnítkem. Metoda tuto část odstraní.
        /// </summary>
        private string GetName(string name) => name.Split('=').First().Trim();
    }
}

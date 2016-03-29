using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Parser1
{
    class ClassVariableParser
    {
        private readonly VariableDeclarationSyntax _syntax;
        public ClassVariable Result { get; private set; }

        public ClassVariableParser(VariableDeclarationSyntax syntax)
        {
            _syntax = syntax;
        }
        
        public void Parse()
        {
            AccessModifiers accessModifiers = AccessModifiers.None; //todo přístupový modifikátor, isStatic
            string name = GetName(_syntax.Variables.ToString());
            bool isStatic = false;
            Result = new ClassVariable(accessModifiers, _syntax.Type.ToString(), name, isStatic);
        }

        /// <summary>
        /// Vrací název proměnné. Pokud je proměnná inicializovaná, její název obsahuje i hodnotu za rovnítkem. Metoda tuto část odstraní.
        /// </summary>
        private string GetName(string name)
        {
            return name.Split('=').First().Trim();
        }
    }
}

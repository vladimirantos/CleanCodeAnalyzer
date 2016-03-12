using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Cleaner.Entity;
using Cleaner.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Parser
{
    /// <summary>
    /// Hlavní parser, má za úkol zjistit všechny informace o třídě.
    /// </summary>
    public class CcaParser : BaseParser
    {
        public CcaClass Result { get; private set; }
        
        /// <param name="text">Obsah cs souboru.</param>
        public CcaParser(string text) : base(text)
        {
        }

        public override void Parse()
        {
            IEnumerable classes = Root.DescendantNodes().OfType<ClassDeclarationSyntax>();
            foreach (ClassDeclarationSyntax @class in classes)
            {
               // @class.Modifiers.ToList().ForEach(x => Enum.Parse(typeof(AccessModifiers), x.ToString()).Equals(AccessModifiers.Public) ? Console.WriteLine(x));
               GetAccessModifier(@class.Modifiers);
                Console.WriteLine();
                //GetAccessModifier(@class.Modifiers);
            }
        }

        private void GetAccessModifier(SyntaxTokenList modifiers)
        {
            foreach (var modifier in modifiers)
            {
                Console.WriteLine(modifier);
            }
        }
    }
}
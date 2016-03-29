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
    public class PropertyParser : BaseParser
    {
        private readonly PropertyDeclarationSyntax _syntax;
        public CcaProperty Result { get; private set; }

        public PropertyParser(PropertyDeclarationSyntax syntax)
        {
            _syntax = syntax;
        }
        
        public override void Parse()
        {
            AccessModifiers accessModifier = AccessModifiers.None;
            Modifiers(_syntax.Modifiers, ref accessModifier);
            
            Result = new CcaProperty(accessModifier, _syntax.Type.ToString(), _syntax.Identifier.Text)
            {
                Modifiers = (from m in _syntax.Modifiers
                            where m.ToString().ToUpper() != accessModifier.ToString().ToUpper() select m)
                            .ToList().ConvertAll(x => PropertyModifier(x.ToString())),
                Content = _syntax.ToString()
            };
        }
        
        private void Modifiers(SyntaxTokenList modifiers, ref AccessModifiers accessModifier)
        {
            foreach (var modifier in modifiers)
            {
                string value = modifier.ToString();
                if (ModifiersHelper.IsAccessModifier(value))
                    accessModifier = AccessModifier(value);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Cleaner.Entity;
using Cleaner.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Parser
{
    internal class PropertyParser : IParser<IEnumerable<CcaProperty>>
    {
        private readonly List<PropertyDeclarationSyntax> _syntax;

        public PropertyParser(List<PropertyDeclarationSyntax> syntax)
        {
            _syntax = syntax;
        }

        /// <summary>
        /// Vrací seznam vlastností v dané třídě.
        /// </summary>
        public IEnumerable<CcaProperty> Parse()
        {
            foreach (var propertyDeclaration in _syntax)
            {
                AccessModifiers accessModifier = AccessModifiers.None;
                Modifiers(propertyDeclaration.Modifiers, ref accessModifier);
                yield return new CcaProperty(accessModifier, propertyDeclaration.Type.ToString(), propertyDeclaration.Identifier.Text)
                {
                    Modifiers = (from m in propertyDeclaration.Modifiers
                                 where m.ToString().ToUpper() != accessModifier.ToString().ToUpper()
                                 select m)
                            .ToList()
                            .ConvertAll(x => (PropertyModifiers)Enum.Parse(typeof(PropertyModifiers), x.ToString(), true)),
                    Content = _syntax.ToString()
                };
            }
        }

        private void Modifiers(SyntaxTokenList modifiers, ref AccessModifiers accessModifier)
        {
            foreach (var modifier in modifiers)
            {
                string value = modifier.ToString();
                if (ModifiersHelper.IsAccessModifier(value))
                    accessModifier = ModifiersHelper.AccessModifier(value);
            }
        }
    }
}

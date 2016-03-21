using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;
using Cleaner.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Parser
{
    public abstract class BaseParser
    {
        protected SyntaxTree SyntaxTree { get; }
        protected Assembly Assembly { get; }
        protected CompilationUnitSyntax Root => (CompilationUnitSyntax)SyntaxTree.GetRoot();
        protected TypeDeclarationSyntax DeclarationSyntax { get; }
        protected Type Type => Assembly.GetType();
        
        protected BaseParser(SyntaxTree syntaxTree, Assembly assembly)
        {
            SyntaxTree = syntaxTree;
            Assembly = assembly;
        }

        protected BaseParser(TypeDeclarationSyntax declarationSyntax)
        {
            DeclarationSyntax = declarationSyntax;
        }

        /// <summary>
        /// Převede řetězec na modifikátor přístupu. Vyvolává výjimku ArgumentException.
        /// Nutno předtím ověřit, jestli je hodnota členem výčtového typu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected AccessModifiers AccessModifier(string value)
        {
            return value.ToEnum<AccessModifiers>();
        }

        /// <summary>
        /// Převede řetězec na modifikátor třídy. Vyvolává výjimku ArgumentException. 
        /// Nutno předtím ověřit, jestli je hodnota členem výčtového typu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected ClassModifiers ClassModifier(string value)
        {
            return value.ToEnum<ClassModifiers>();
        }

        /// <summary>
        /// Převede řetězec na modifikátor metody. Vyvolává výjimku ArgumentException. 
        /// Nutno předtím ověřit, jestli je hodnota členem výčtového typu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected MethodModifiers MethodModifier(string value)
        {
            return value.ToEnum<MethodModifiers>();
        }

        public abstract void Parse();
    }
}

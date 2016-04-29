using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public abstract CcaProject Parse();

        protected virtual IParser<ClassHeader> ClassHeaderParser(ClassDeclarationSyntax syntax) => new ClassHeaderParser(syntax);
        protected virtual IParser<IEnumerable<ClassVariable>> ClassVariableParser(List<FieldDeclarationSyntax> syntax) => new ClassVariableParser(syntax); 
        protected virtual IParser<IEnumerable<CcaProperty>> PropertyParser(List<PropertyDeclarationSyntax> syntax) => new PropertyParser(syntax); 
        protected virtual IParser<IEnumerable<CcaMethod>> MethodParser(List<MethodDeclarationSyntax> syntax) => new MethodParser(syntax); 

        /// <summary>
        /// Načte kód ze souboru a vytvoří syntaktický strom. 
        /// </summary>
        protected SyntaxTree CreateSyntaxTree(FileInfo file) => CreateSyntaxTree(FileUtils.ReadFile(file.FullName));

        /// <summary>
        /// Vytvoří nový syntax tree ze zadaného řetězce.
        /// </summary>
        protected SyntaxTree CreateSyntaxTree(string content) => CSharpSyntaxTree.ParseText(content);

        protected CompilationUnitSyntax GetRoot(FileInfo fileInfo) => (CompilationUnitSyntax)CreateSyntaxTree(fileInfo).GetRoot();

        /// <summary>
        /// Vrací seznam uzlů ze zadaného souboru.
        /// </summary>
        protected IEnumerable<SyntaxNode> GetNodes(FileInfo fileInfo) => GetRoot(fileInfo).DescendantNodes();
    }
}

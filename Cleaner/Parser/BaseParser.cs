using Cleaner.Entity;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Cleaner.Parser
{
    abstract class BaseParser : IParser
    {
        protected SyntaxTree SyntaxTree { get; private set; }

        protected BaseParser(string text)
        {
            SyntaxTree = CSharpSyntaxTree.ParseText(text);
        }
        
        public abstract CcaClass Parse();
    }
}

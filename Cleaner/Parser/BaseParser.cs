using Cleaner.Entity;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Cleaner.Parser
{
    interface IParser
    {
        void Parse();
    }
    /// <summary>
    /// Společný předek všech parserů.
    /// </summary>
    public abstract class BaseParser : IParser
    {
        protected SyntaxTree SyntaxTree { get; private set; }

        protected SyntaxNode Root => SyntaxTree.GetRoot();

        protected BaseParser(string text)
        {
            SyntaxTree = CSharpSyntaxTree.ParseText(text);
        }

        public abstract void Parse();
    }
}

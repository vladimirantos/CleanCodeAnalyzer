using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Analyzer.Tools
{
    class CyclomaticComplexity : IAnalyzerHelper<int>
    {
        private string _content;

        private CyclomaticComplexity(string content)
        {
            _content = content;
        }

        public static int Analyze(string content) => content != null ? new CyclomaticComplexity(content).Analyze() : 0;

        public int Analyze()
        {
            var tree = CreateTree(_content);
            var model = Compile(tree)?.GetSemanticModel(tree, true);
            var syntaxNode = tree
                .GetRoot()
                .DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .First();
            return CalculateCyclomatic(syntaxNode, model);
        }

        private int CalculateCyclomatic(SyntaxNode node, SemanticModel semanticModel) => new CyclomaticCalculator(node, semanticModel).Calculate();

        private SyntaxTree CreateTree(string code) => CSharpSyntaxTree.ParseText(code);

        private CSharpCompilation Compile(SyntaxTree tree)
        {
            if (tree == null)
                return null;
            return CSharpCompilation.Create(
                "x",
                syntaxTrees: new[] { tree },
                references: new MetadataReference[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location), MetadataReference.CreateFromFile(typeof(Task).Assembly.Location) },
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, usings: new[] { "System", "System.Threading.Tasks" }));
        }
    }

    class CyclomaticCalculator : CSharpSyntaxWalker
    {
        private static readonly SyntaxKind[] Statements = new[]{SyntaxKind.CaseSwitchLabel, SyntaxKind.CoalesceExpression, SyntaxKind.ConditionalExpression,
                                                                SyntaxKind.LogicalAndExpression, SyntaxKind.LogicalOrExpression, SyntaxKind.LogicalNotExpression};
        private readonly SyntaxNode _syntaxNode;
        private readonly SemanticModel _semanticModel;
        private int _counter = 1;
        public CyclomaticCalculator(SyntaxNode syntaxNode, SemanticModel semanticModel)
        {
            _semanticModel = semanticModel;
            _syntaxNode = syntaxNode;
        }

        public int Calculate()
        {
            if (_syntaxNode != null)
            {
                Visit(_syntaxNode);
            }

            return _counter;
        }

        public override void Visit(SyntaxNode node)
        {
            base.Visit(node);
            if (Statements.Contains(node.Kind()))
            {
                _counter++;
            }
        }

        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            base.VisitWhileStatement(node);
            _counter++;
        }

        public override void VisitForStatement(ForStatementSyntax node)
        {
            base.VisitForStatement(node);
            _counter++;
        }

        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            base.VisitForEachStatement(node);
            _counter++;
        }

        public override void VisitArgument(ArgumentSyntax node)
        {
            switch (node.Expression.Kind())
            {
                case SyntaxKind.ParenthesizedLambdaExpression:
                    {
                        var lambda = (ParenthesizedLambdaExpressionSyntax)node.Expression;
                        Visit(lambda.Body);
                    }

                    break;
                case SyntaxKind.SimpleLambdaExpression:
                    {
                        var lambda = (SimpleLambdaExpressionSyntax)node.Expression;
                        Visit(lambda.Body);
                    }

                    break;
            }

            base.VisitArgument(node);
        }

        public override void VisitDefaultExpression(DefaultExpressionSyntax node)
        {
            base.VisitDefaultExpression(node);
            _counter++;
        }

        public override void VisitContinueStatement(ContinueStatementSyntax node)
        {
            base.VisitContinueStatement(node);
            _counter++;
        }

        public override void VisitGotoStatement(GotoStatementSyntax node)
        {
            base.VisitGotoStatement(node);
            _counter++;
        }

        public override void VisitIfStatement(IfStatementSyntax node)
        {
            base.VisitIfStatement(node);
            _counter++;
        }

        public override void VisitCatchClause(CatchClauseSyntax node)
        {
            base.VisitCatchClause(node);
            _counter++;
        }
    }
}

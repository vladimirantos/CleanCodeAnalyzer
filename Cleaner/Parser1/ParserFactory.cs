using System;
using System.Collections;
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

namespace Cleaner.Parser1
{
    /// <summary>
    /// Hlavní parser pro jazyk C#. Prochází kód a sestavuje objekty tříd.
    /// </summary>
    public class ParserFactory
    {
        private readonly CcaProject _project = new CcaProject();
        protected List<FileInfo> Files { get; }


        public ParserFactory(List<FileInfo> files)
        {
            Files = files;
        }

        public CcaProject Parse()
        {
            Files.ForEach(x => _project.Classes.AddRange(ParseFile(x)));
            return _project;
        }

        /// <summary>
        /// Vrací seznam tříd z fileInfo.
        /// </summary>
        private List<CcaClass> ParseFile(FileInfo fileInfo)
        {
            CompilationUnitSyntax syntaxTree = (CompilationUnitSyntax) CreateSyntaxTree(fileInfo).GetRoot();
            IEnumerable<SyntaxNode> nodes = syntaxTree.DescendantNodes(); 
            List<ClassDeclarationSyntax> classDeclaration = nodes.OfType<ClassDeclarationSyntax>().ToList(); //třídy v souboru
            
            List<CcaClass> classes = new List<CcaClass>();
            classDeclaration.ForEach(classDeclarationSyntax =>
            {
                CcaClass ccaClass = new CcaClass(fileInfo.Directory.Name, fileInfo.Name,CreateClassHeader(classDeclarationSyntax))
                {
                    Namespace = nodes.OfType<NamespaceDeclarationSyntax>().First().Name.ToString(),
                };

                IEnumerable<MemberDeclarationSyntax> memberDeclarationSyntax = classDeclarationSyntax.Members;
                memberDeclarationSyntax.ToList().ForEach(declarationSyntax =>
                {
                    IEnumerable<SyntaxNode> memberNodes = declarationSyntax.DescendantNodes();
                    var variableDeclaration = memberNodes.OfType<VariableDeclarationSyntax>().ToList();
                    ccaClass.Variables.AddRange(CreateClassVariables(variableDeclaration));
                });

                var propertiesDeclaration = classDeclarationSyntax.Members.OfType<PropertyDeclarationSyntax>().ToList();
                ccaClass.Properties.AddRange(CreateProperties(propertiesDeclaration));

                var methodDeclaration = classDeclarationSyntax.Members.OfType<MethodDeclarationSyntax>().ToList();
                ccaClass.Methods = CreateCcaMethods(methodDeclaration);
                classes.Add(ccaClass);
            });
            return classes;
        }

        private ClassHeader CreateClassHeader(ClassDeclarationSyntax declarationSyntax)
        {
            ClassHeaderParser parser = new ClassHeaderParser(declarationSyntax);
            parser.Parse();
            return parser.Result;
        }

        private ClassVariable CreateClassVariable(VariableDeclarationSyntax declarationSyntax)
        {
            ClassVariableParser classVariableParser = new ClassVariableParser(declarationSyntax);
            classVariableParser.Parse();
            return classVariableParser.Result;
        }

        private List<ClassVariable> CreateClassVariables(List<VariableDeclarationSyntax> declarationSyntax)
        {
            List<ClassVariable> result = new List<ClassVariable>();
            declarationSyntax.ForEach(x =>
            {
                result.Add(CreateClassVariable(x));
            });
            return result;
        }

        private List<CcaProperty> CreateProperties(List<PropertyDeclarationSyntax> declarationSyntax)
        {
            List<CcaProperty> result = new List<CcaProperty>();
            declarationSyntax.ForEach(x =>
            {
                result.Add(CreateCcaProperty(x));
            });
            return result;
        }

        private CcaProperty CreateCcaProperty(PropertyDeclarationSyntax declarationSyntax)
        {
            PropertyParser parser = new PropertyParser(declarationSyntax);
            parser.Parse();
            return parser.Result;
        }

        private List<CcaMethod> CreateCcaMethods(List<MethodDeclarationSyntax> methodDeclarationSyntax)
        {
            List<CcaMethod> methods = new List<CcaMethod>();
            methodDeclarationSyntax.ForEach(x =>
            {
                methods.Add(CreateCcaMethod(x));
            });
            return methods;
        }

        private CcaMethod CreateCcaMethod(MethodDeclarationSyntax methodDeclaration)
        {
            MethodParser parser = new MethodParser(methodDeclaration);
            parser.Parse();
            return parser.Result;
        }

        /// <summary>
        /// Načte kód ze souboru a vytvoří syntaktický strom. 
        /// </summary>
        private SyntaxTree CreateSyntaxTree(FileInfo file)
        {
            return CreateSyntaxTree(FileUtils.ReadFile(file.FullName));
        }

        /// <summary>
        /// Vytvoří nový syntax tree ze zadaného řetězce.
        /// </summary>
        private SyntaxTree CreateSyntaxTree(string content)
        {
            return CSharpSyntaxTree.ParseText(content);
        }
        
        /// <summary>
        /// Načte soubor a vytvoří jeho Assembly
        /// </summary>
        private Assembly CreateAssembly(FileInfo file)
        {
            return null;
        }
    }
}

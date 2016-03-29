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

    public class CcaParser : BaseParser
    {
        private readonly List<FileInfo> _files;
        public CcaParser(List<FileInfo> files)
        {
            _files = files;
        }

        public override CcaProject Parse()
        {
            List<CcaClass> classes = new List<CcaClass>();
            _files.ForEach(file => classes.AddRange(ParseClasses(file)));
            return new CcaProject(classes);
        }

        /// <summary>
        /// Vrací seznam tříd ze souboru.
        /// </summary>
        private List<CcaClass> ParseClasses(FileInfo fileInfo)
        {
            List<CcaClass> classes = new List<CcaClass>();
            IEnumerable<SyntaxNode> nodes = GetNodes(fileInfo);
            List<ClassDeclarationSyntax> classDeclarationList = nodes.OfType<ClassDeclarationSyntax>().ToList();
            classDeclarationList.ForEach(classDeclaration =>
            {
                CcaClass ccaClass = CreateClass(fileInfo.Directory.Name, fileInfo.Name, classDeclaration);
                ccaClass.Namespace = nodes.OfType<NamespaceDeclarationSyntax>().First().Name.ToString();
                classes.Add(ccaClass);
            });
            return classes;
        }

        private CcaClass CreateClass(string directory, string file, ClassDeclarationSyntax classDeclaration)
        {
            IEnumerable<MemberDeclarationSyntax> memberDeclarationSyntax = classDeclaration.Members;
            
            CcaClass ccaClass = new CcaClass(directory, file, GetClassHeader(classDeclaration))
            {
                Variables =  GetClassVariables(memberDeclarationSyntax.ToList()),
                Properties = GetProperties(memberDeclarationSyntax.OfType<PropertyDeclarationSyntax>().ToList()),
                Methods = GetMethods(memberDeclarationSyntax.OfType<MethodDeclarationSyntax>().ToList())
            };
            return ccaClass;
        }

        private ClassHeader GetClassHeader(ClassDeclarationSyntax syntax) => ClassHeaderParser(syntax).Parse();

        private List<ClassVariable> GetClassVariables(List<MemberDeclarationSyntax> memberDeclaration)
        {
            List<ClassVariable> result = new List<ClassVariable>();
            memberDeclaration.ForEach(x =>
            {
                result.AddRange(GetClassVariables(x.DescendantNodes().OfType<VariableDeclarationSyntax>().ToList()));
            });
            return result;
        }

        private IEnumerable<ClassVariable> GetClassVariables(List<VariableDeclarationSyntax> syntax) => ClassVariableParser(syntax).Parse();

        private List<CcaProperty> GetProperties(List<PropertyDeclarationSyntax> syntax)
            => PropertyParser(syntax).Parse().ToList();

        private List<CcaMethod> GetMethods(List<MethodDeclarationSyntax> syntax)
            => MethodParser(syntax).Parse().ToList();
    }
}
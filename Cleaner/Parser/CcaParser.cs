using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cleaner.Entity;
using Cleaner.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cleaner.Parser
{
    public delegate void OnParsingHandler(object sender, ParseEvent e);
    public interface ICcaParser
    {
        event OnParsingHandler OnParsing;
        CcaProject Parse();
    }

    public class CcaParser : BaseParser, ICcaParser
    {
        public event OnParsingHandler OnParsing;
        private readonly List<FileInfo> _files;
      
        public CcaParser(List<FileInfo> files)
        {
            _files = files;
        }

        public override CcaProject Parse()
        {
            List<CcaFile> ccaFiles = new List<CcaFile>();
            _files.ForEach(file =>
            {
                List<CcaClass> classes = new List<CcaClass>();
                classes.AddRange(ParseClasses(file));
                ccaFiles.Add(new CcaFile(classes, File.ReadAllText(file.FullName)));
            });
            
            return new CcaProject(ccaFiles);
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
                ccaClass.Content = classDeclaration.ToString();
                classes.Add(ccaClass);
                Parsing(fileInfo.Name, ccaClass);
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

        protected virtual void Parsing(string file, CcaClass @class)
        {
            if(OnParsing != null)
                OnParsing(this, new ParseEvent(file, @class));
        } 
    }
}
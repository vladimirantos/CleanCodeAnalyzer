//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Windows.Forms;
//using Cleaner.Entity;
//using Cleaner.Utils;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp.Syntax;

//namespace Cleaner.Parser
//{
//    public class CcaClassEventArgs : EventArgs
//    {
//        public CcaClass Class { get; private set; }
//        public string Tmp { get; set; }
//        public CcaClassEventArgs(CcaClass @class)
//        {
//            Class = @class;
//        }

//        public CcaClassEventArgs(string str)
//        {
//            Tmp = str;
//        }
//    }

//    public delegate void OnParseClass(object sender, CcaClassEventArgs e);

//    /// <summary>
//    /// Hlavní parser, má za úkol zjistit všechny informace o třídě.
//    /// </summary>
//    public class ParserFactory : BaseParser
//    {
//        public event OnParseClass OnParseClass;
//        public CcaClass Result { get; private set; }
        
//        /// <param name="text">Obsah cs souboru.</param>
//        public ParserFactory(string text) : base(text)
//        {
//        }

//        public override void Parse()
//        {
//            IEnumerable classes = Root.DescendantNodes().OfType<ClassDeclarationSyntax>();
//            foreach (ClassDeclarationSyntax @class in classes)
//            {
//               // @class.Modifiers.ToList().ForEach(x => Enum.Parse(typeof(AccessModifiers), x.ToString()).Equals(AccessModifiers.Public) ? Console.WriteLine(x));
//                GetAccessModifier(@class.Modifiers);
                
//                //GetAccessModifier(@class.Modifiers);
//                OnParse(new CcaClassEventArgs(@class.Modifiers.ToFullString()));
//            }
//        }

//        private void GetAccessModifier(SyntaxTokenList modifiers)
//        {
//            foreach (var modifier in modifiers)
//            {
//                MessageBox.Show(modifier.ToString());
//            }
//        }

//        protected virtual void OnParse(CcaClassEventArgs e)
//        {
//            MessageBox.Show("BANIK PICO");
//            OnParseClass?.Invoke(this, e);
//        }
//    }
//}
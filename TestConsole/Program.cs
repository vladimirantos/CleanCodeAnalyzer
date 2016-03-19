using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CleanCodeAnalyzer;
using Cleaner.Entity;
using Cleaner.Parser;
using Cleaner.Utils;

namespace TestConsole
{
        public static class MethodInfoExtension
        {
            public static string MethodSignature(this MethodInfo mi)
            {
                String[] param = mi.GetParameters()
                              .Select(p => String.Format("{0} {1}", p.ParameterType.Name, p.Name))
                              .ToArray();


                string signature = String.Format("{0} {1}({2})", mi.ReturnType.Name, mi.Name, String.Join(",", param));

                return signature;
            }
        
    }

    interface ICar
    {
         
    }
    class Base
    {
        
    }

    class Car : Base, ICar
    {
        private string _type;
        public string Type => _type;

        protected Color Color { get; set; }

        public Car(string type)
        {
            _type = type;
        }

        public void Drive()
        {
            
        }
        public int Fuel(int ammount)
        {
            return 10;
        }

        private void Pokus()
        {
            
        }

        protected void ProtPokus()
        {
            
        }

        private static void BANIK()
        {
            
        }
    }
    class Program
    {

        static List<FileInfo> Files(string path)
        {
            return FileUtils.GetAllFiles(path, Settings.Default.FilePattern, Settings.Default.ForbiddenDir);
        } 
        static void Main(string[] args)
        {
            //Type type = Type.GetType("TestConsole.Car");
            
            //// Get the Type information.
            //Type myTypeObj = type;
            //Console.WriteLine(myTypeObj.GetInterfaces().First());
            //// Get Method Information.
            //var methods = myTypeObj.GetMethods(BindingFlags.NonPublic|BindingFlags.SetProperty|BindingFlags.Instance|BindingFlags.Static);

            //foreach (MethodInfo item in methods)
            //{
            //    Console.WriteLine(item.MethodSignature());
            //}
            string path = @"C:\Users\Vladimír Antoš\Documents\Visual Studio 2015\Projects\CleanCodeAnalyzer\TestApp";
            ParserFactory parserFactory = new ParserFactory(Files(path));
            CcaProject parsedProject = parserFactory.Parse();
            foreach (var ccaClass in parsedProject.Classes)
            {
                //Console.WriteLine(ccaClass.Header.ToFullString());
            }
            Console.ReadKey();
        }
    }
}
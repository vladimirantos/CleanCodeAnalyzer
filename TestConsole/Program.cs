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
using Cleaner;
using Cleaner.Entity;
using Cleaner.Parser;
using Cleaner.Utils;
using Microsoft.CodeAnalysis;

namespace TestConsole
{
       
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
            Cca cca = Cca.Create(path, Settings.Default.FilePattern, Settings.Default.ForbiddenDir);
            cca.Start();
            //ParserFactory parserFactory = new ParserFactory(Files(path));

            Console.WriteLine("\nKONEC");
            Console.ReadKey();
        }
    }
}
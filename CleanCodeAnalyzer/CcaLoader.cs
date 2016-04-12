//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using CleanCodeAnalyzer.Properties;
//using Cleaner.Parser;

//namespace CleanCodeAnalyzer
//{
//    class CcaLoader
//    {
//        private string _path;
//        private ListExtension<FileInfo> _files; 
//        public CcaLoader(string path)
//        {
//            _path = path;
//            _files = GetFiles();
//        }

//        private CcaLoader()
//        {
//        }

//        public static CcaLoader Create(string path)
//        {
//            CcaLoader ccaLoader = new CcaLoader();
//            ccaLoader._path = path;
//            Task.Factory.StartNew(() =>
//            {
//                ccaLoader._files = ccaLoader.GetFiles();
//            });
//            return ccaLoader;
//        }

//        public void Start()
//        {
//            foreach (var fileInfo in _files)
//            {
//                MessageBox.Show(fileInfo.FullName);
//                string content = File.ReadAllText(fileInfo.FullName);
//                ParserFactory parser = new ParserFactory(content);
//                parser.Parse();
//                parser.OnParseClass += ParseReport;
//            }
//        }

//        private void ParseReport(object sender, CcaClassEventArgs e)
//        {
//            MessageBox.Show(e.Tmp);
//        }

//        private ListExtension<FileInfo> GetFiles()
//        {
//            ListExtension<FileInfo> result = new ListExtension<FileInfo>();
//            DirectoryInfo di = new DirectoryInfo(_path);
//            FileInfo[] files = di.GetFiles(Settings.Default.FilePattern, SearchOption.AllDirectories);
//            foreach (FileInfo fileInfo in from fileInfo in files
//                                          let name = fileInfo.Directory.Name
//                                          where !Settings.Default.ForbiddenDir.Contains(name)
//                                          where !result.Contains(fileInfo)
//                                          select fileInfo)
//            {
//                result.Add(fileInfo);
//            }
//            return result;
//        }
//    }
//}

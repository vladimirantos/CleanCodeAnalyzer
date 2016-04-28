using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Utils
{
    public static class FileUtils
    {
        public static List<FileInfo> GetAllFiles(string path, string filePattern, List<string> forbiddenDir)
        {
            List<FileInfo> result = new List<FileInfo>();
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles(filePattern, SearchOption.AllDirectories);
            IEnumerable<FileInfo> fileInfos = from fileInfo in files
                let directoryInfo = fileInfo.Directory
                where directoryInfo != null
                let name = directoryInfo.Name
                where !forbiddenDir.Contains(name)
                where !result.Contains(fileInfo)
                select fileInfo;
            foreach (FileInfo fileInfo in fileInfos)
            {
                result.Add(fileInfo);
            }
            return result;
        }

        public static string ReadFile(string path) => File.ReadAllText(path);

        public static void WriteFile(string path, string content) => File.WriteAllText(path, content);
    }
}
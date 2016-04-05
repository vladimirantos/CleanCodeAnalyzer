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
                        foreach (FileInfo fileInfo in from fileInfo in files
                                                      let name = fileInfo.Directory.Name
                                                      where !forbiddenDir.Contains(name)
                                                      where !result.Contains(fileInfo)
                                                      select fileInfo)
                        {
                            result.Add(fileInfo);
                        }
                        return result;
        }

        public static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}

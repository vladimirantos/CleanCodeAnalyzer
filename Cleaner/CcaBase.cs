using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Utils;

namespace Cleaner
{
    public abstract class CcaBase
    {
        private string _path;

        protected List<FileInfo> Files => FileUtils.GetAllFiles(_path, Config.FilePattern, Config.ForbiddenDirs); 

        protected CcaBase(string path)
        {
            _path = path;
        }
    }
}

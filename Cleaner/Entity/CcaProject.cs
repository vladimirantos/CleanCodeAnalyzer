using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Entity
{
    public class CcaProject
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public List<CcaFile> Files { get; }

        public CcaProject(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public CcaProject(List<CcaFile> files)
        {
            Files = files;
        }

        public CcaProject()
        {
            
        }
    }
}

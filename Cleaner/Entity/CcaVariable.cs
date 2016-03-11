using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner.Entity
{
    class CcaVariable : IVariable
    {
        public string Name { get; set; }
        public string DataType { get; set; }

        public CcaVariable(string name, string dataType)
        {
            Name = name;
            DataType = dataType;
        }
    }
}

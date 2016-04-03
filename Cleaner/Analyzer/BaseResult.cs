using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner.Analyzer
{
    abstract class BaseResult : IResult
    {
        public Location Location { get; }
        public string Description { get; }
        public List<IResult> InnerResults { get; }

        protected BaseResult(Location location, string description)
        {
            Location = location;
            Description = description;
        }

        protected BaseResult(Location location) : this(location, string.Empty)
        {

        }

        protected BaseResult(string file, CcaClass ccaClass) : this(new Location(file, ccaClass), string.Empty)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner.Comparator
{
    class Result
    {
        public CcaClass Class { get; }
        public Dictionary<string, int> Errors { get; } = new Dictionary<string, int>();

        public Result(CcaClass @class)
        {
            Class = @class;
        }

        /// <summary>
        /// Zvýší počet chyb zadaného klíče o 1. Pokud klíč neexistuje, bude automaticky vytvořen.
        /// </summary>
        public void AddError(string key)
        {
            int value;
            if (Errors.TryGetValue(key, out value))
                Errors[key] = value + 1;
            else Errors.Add(key, 1);
        }
    }
}

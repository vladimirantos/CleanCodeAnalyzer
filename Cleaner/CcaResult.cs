using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;
using Cleaner.Utils.Extensions;

namespace Cleaner
{
    /// <summary>
    /// Obsahuje výsledek analýzy pro třídu.
    /// </summary>
    public class CcaResult : IComparable<Errors>
    {
        public CcaClass Class { get; private set; }

        public Errors Errors { get; } = new Errors();

        public CcaResult(CcaClass @class)
        {
            Class = @class;
        }

        public int CompareTo(Errors other)
        {
            int thisPropertiesSum = Errors.Score();
            int thatPropertiesSum = other.Score();
            
            return thisPropertiesSum.CompareTo(thatPropertiesSum);
        }
    }

    /// <summary>
    /// Obsahuje počet chyb pro všechny metriky.
    /// </summary>
    public class Errors
    {
        public int NamesLength { get; set; }
        public int CorrectNames { get; set; }
        public int CodeLines { get; set; }
        public int CommentLines { get; set; }
        public int WhitespaceLines { get; set; }
        public int CountVariables { get; set; }
        public int CountProperties { get; set; }
        public int CountMethods { get; set; }
        public int SimilarityMethods { get; set; }
        public int CountArgs { get; set; }
        public int CyclomaticComplx { get; set; }

        /// <summary>
        /// Počet řádků kódu bez prázdných znaků a komentářů.
        /// </summary>
        public int RealCodeLines => CodeLines - (CommentLines + WhitespaceLines);

        /// <summary>
        /// Součet všech chyb. Může být použit pro řazení podle chybovosti.
        /// </summary>
        public int Score() => this.ToDictionary().Values.Sum();
    }
    
}

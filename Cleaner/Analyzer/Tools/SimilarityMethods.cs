using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Entity;

namespace Cleaner.Analyzer.Tools
{
    /// <summary>
    /// Kontroluje podobnost metod na základě jejich argumentů. Dvě metody je možné prohlásit za podobné, pokud mají na 
    /// stejný počet argumentů a zároveň na stejných pozicích mají argumenty stejného datového typu. V případě, že obě metody
    /// mají 2/3 a více shodných parametrů, poté jsou podobné.
    /// </summary>
    class SimilarityMethods : IAnalyzerHelper<int>
    {
        private readonly List<CcaMethod> _methods;

        private SimilarityMethods(List<CcaMethod> methods)
        {
            _methods = methods;
        }

        public int Analyze()
        {
            if (_methods.Count < 1)
                return 0;
            int result = 0;
            for (int i = 0; i <= _methods.Count; i++)
            {
                for (int j = i + 1; j <= _methods.Count - 1; j++)
                {
                    var m1 = _methods[i];
                    var m2 = _methods[j];
                    if(IsSameArgumentNumbers(m1, m2))
                        if (IsSamilar(m1, m2))
                            result++;
                        //Console.WriteLine($"{_methods[i]} a {_methods[j]} jsou stejné : "+ IsSamilar(_methods[i], _methods[j]));
                    if (j == 4)
                        break;
                }
                if (i == 3)
                    break;
            }
//            _methods.SelectMany((e, i) =>
//                _methods.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
            return result;
        }

        public static int Analyze(List<CcaMethod> methods) => new SimilarityMethods(methods).Analyze();

        /// <summary>
        /// Ověřuje jestli jsou metody stejné z hlediska počtu argumentů. 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        private static bool IsSamilar(CcaMethod m1, CcaMethod m2)
        {
            if (m1.Name.Equals(m2.Name) || m1.Arguments.Count == 0 || m2.Arguments.Count == 0)
                return false;
            
            List<IVariable> variables1;
            List<IVariable> variables2;
            if (m1.Arguments.Count < m2.Arguments.Count)
            {
                variables1 = m1.Arguments;
                variables2 = m2.Arguments;
            }
            else
            {
                variables1 = m2.Arguments;
                variables2 = m1.Arguments;
            }

            int errorCount = variables1.Where((t, i) => t.Equals(variables2[i])).Count();
            var x = variables1.Count * Config.SameArgumentsRate;
            var result = errorCount >= x;
            return result;
        }

        /// <summary>
        /// Kontroluje jestli mají metody stejný (nenulový) počet argumentů.
        /// </summary>
        private static bool IsSameArgumentNumbers(CcaMethod m1, CcaMethod m2) 
            => m1.Arguments.Count > 0 && m2.Arguments.Count > 0 && m1.Arguments.Count == m2.Arguments.Count;
    }
  
}

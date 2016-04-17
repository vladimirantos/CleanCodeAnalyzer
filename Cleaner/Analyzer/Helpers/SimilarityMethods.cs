using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Entity;

namespace Cleaner.Analyzer.Helpers
{
    /// <summary>
    /// Kontroluje podobnost metod na základě jejich argumentů.
    /// </summary>
    class SimilarityMethods : IAnalyzerHelper<int>
    {
        private List<CcaMethod> _methods;

        public SimilarityMethods(List<CcaMethod> methods)
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
                    if (Compare(_methods[i], _methods[j]))
                        result++;
                    if (j == 4)
                        break;
                }
                if (i == 3)
                    break;
            }
//            _methods.SelectMany((e, i) =>
//                _methods.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
            return 0;
        }

        public static int Analyze(List<CcaMethod> methods)
        {
            return new SimilarityMethods(methods).Analyze();
        }

        private bool Compare(CcaMethod m1, CcaMethod m2)
        {
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

            int errorCount = 0;  


            for (int i = 0; i < variables1.Count; i++)
            {
                if (variables1[i].Equals(variables2[i]))
                    errorCount++;
            }
            return false;
        }
    }
}

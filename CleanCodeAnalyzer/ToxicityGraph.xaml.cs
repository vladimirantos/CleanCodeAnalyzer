using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Cleaner;
using Cleaner.Comparator;
using De.TorstenMandelkow.MetroChart;

namespace CleanCodeAnalyzer
{
    public partial class ToxicityGraph : Window
    {
        private List<CcaResult> _results;
        public ToxicityGraph(List<CcaResult> results)
        {
            InitializeComponent();
            //foreach (var result in results)
            //{
            //    ChartSeries series = new ChartSeries();
            //    series.DisplayMember = result.Class.Header.Name;
            //    series.ValueMember = "number";
            //    Graph.Series.Add(series);
            //}
            //var x = new GraphViewModel(results);
            X cwe = new X();
            cwe.Xy++;
            MessageBox.Show(cwe.ToString());
        }
    }

    class X
    {
        public int Xy { get; set; } = 0;

        public override string ToString()
        {
            return Xy.ToString();
        }
    }
}

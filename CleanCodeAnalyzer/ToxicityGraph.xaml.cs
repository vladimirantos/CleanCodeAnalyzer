using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
        ObservableCollection<ChartSeries> Bars = new ObservableCollection<ChartSeries>();
        public ToxicityGraph(List<CcaResult> results)
        {
         
            InitializeComponent();
            
            ObservableCollection<TestClass> blocks = new ObservableCollection<TestClass>()
            {
                new TestClass() {Category = "C1", Number = 155},
                new TestClass() {Category = "C2", Number = 98}
            };
            ChartSeries chartSerie = new ChartSeries();
            chartSerie.DisplayMember = "Category";
            chartSerie.ValueMember = "Number";
            chartSerie.ItemsSource = blocks;
            Bars.Add(chartSerie);
            Chart.Series = Bars;
        }
    }
    public class TestClass
    {
        public string Category { get; set; }

        public int Number { get; set; }
    }

}

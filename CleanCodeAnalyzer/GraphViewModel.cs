using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Cleaner;
using Cleaner.Comparator;

namespace CleanCodeAnalyzer
{
    class GraphViewModel
    {
        private readonly ObservableCollection<Metrics> _populations = new ObservableCollection<Metrics>();
        public ObservableCollection<Metrics> Populations
        {
            get
            {
                return _populations;
            }
        }

        public GraphViewModel(List<CcaResult> results)
        {
            //foreach (var result in results.Take(10))
            //{
            //    _populations.Add(new Metrics() { Name = result.Class.Header.ToString(), Count = result.Errors.Values.Sum() });
            //}
            
            //_populations.Add(new Metrics() { Name = "India", Count = 1220 });
            //_populations.Add(new Metrics() { Name = "United States", Count = 309 });
            //_populations.Add(new Metrics() { Name = "Indonesia", Count = 240 });
            //_populations.Add(new Metrics() { Name = "Brazil", Count = 195 });
            //_populations.Add(new Metrics() { Name = "Pakistan", Count = 174 });
            //_populations.Add(new Metrics() { Name = "Nigeria", Count = 158 });
        }

    }

    public class Metrics : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private int _count = 0;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                NotifyPropertyChanged("Count");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}

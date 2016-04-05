using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Entity;

namespace Cleaner
{
    interface ICalibration
    {
        void Calibrate();
        void Save(string path);
    }
    class Calibration : ICalibration
    {
        private readonly Cca _cca;

        public Calibration(string path)
        {
            _cca = new Cca(path);
        }

        public void Calibrate()
        {
            CcaProject project = Parse();
        }

        public void Save(string path)
        {
            
        }

        private CcaProject Parse() => _cca.Parser.Parse();
    }
}

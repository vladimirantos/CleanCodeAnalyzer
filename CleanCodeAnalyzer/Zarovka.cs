using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCodeAnalyzer
{
    public delegate void ChangeStateHandler(bool sviti);
    class Zarovka
    {
        public ChangeStateHandler Changed;
        public bool Sviti { get; private set; } = false;

        private void OnChange()
        {
            Changed?.Invoke(Sviti);
        }

        public void Rozsvit()
        {
            Sviti = true;
            Thread.Sleep(10000);
            OnChange();
        }

        public void Zhasnout()
        {
            Sviti = false;
            Thread.Sleep(10000);
            OnChange();
        }
    }
}

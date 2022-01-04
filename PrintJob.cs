using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COSMIDENT
{
    public class PrintJob : IPrintJob
    {
        public void Print()
        {
            System.Diagnostics.Debug.WriteLine($"Elke minuut een bericht");
        }
    }
}

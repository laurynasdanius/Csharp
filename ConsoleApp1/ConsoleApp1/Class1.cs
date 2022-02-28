using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Uzd1
{
    internal class Pagrindinis
    {
        static void Main(string[] args)
        {   //Laiko skaiciavimui
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Matematika matematika = new Matematika(Math.Pow(10, 15), 1, 2);
            matematika.Skaiciavimas();
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            Console.WriteLine("Praejes laikas (Valandos:Minutes:Sekundes:Milisekundes) : {0:00}:{1:00}:{2:00}.{3}",
                            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

        }
    }
}

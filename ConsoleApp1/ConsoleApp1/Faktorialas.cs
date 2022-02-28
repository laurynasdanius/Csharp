using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzd1
{
    internal class Faktorialas
    {
        //laukai
        private int fact;
        private int a = 1;
        //setteris faktorialui
        public void setFact(int fact)
        {
            this.fact = fact;
        }
        //getteris faktorialui
        public int getFact() 
        {
            return fact;
        }
        //klase faktorialo skaiciavimui
        public double Faktor()
        {
            for (int x = 1; x <= this.fact; x++)
            {
                this.a *= x;

            }
            Console.WriteLine("Skaicius kurio faktoriala skaiciuojame : [" + this.fact + "] Gautas jo faktorialas : " + this.a);
            return this.a;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzd1
{
    internal class Faktorialas
    {
        private int fact;
        private int a = 1;
        public void setFact(int fact)
        {
            this.fact = fact;
        }
        public int getFact() 
        {
            return fact;
        }
        public double Faktor()
        {
            for (int x = 1; x <= this.fact; x++)
            {
                this.a *= x;

            }
            Console.WriteLine("Skaicius kurio faktoriala skaiciuojame : [" + this.fact + "] Gautas jo faktorialas : " + this.a);
            Console.ReadLine();
            return this.a;
        }
        
    }
}

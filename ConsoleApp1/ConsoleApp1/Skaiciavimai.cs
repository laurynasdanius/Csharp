using System;
using System.Diagnostics;
using System.Threading;

namespace Uzd1
{
    internal class Matematika : Faktorialas
    {
        //field arba laukas
        private double max, sk1;
        private int sk2;
        
        //getters ir setters
        public double getMax()
        {
            return max;
        }
        public void setMax(double max)
        {
            this.max = max;
        }
        public double getSk1()
        {
            return sk1;
        }
        public void setSk1(double sk1)
        {
            this.sk1 = sk1;
        }
        public int getSk2()
        {
            return sk2;
        }
        public void setSk2(int sk2)
        {
            this.sk2 = sk2;
        }
        //Klases konstruktorius su tuo paciu pavadinimu kaip ir klase
        public Matematika(double max, double sk1, int sk2)
        {
            this.max = max;
            this.sk1 = sk1;
            this.sk2 = sk2;
        }

        //metodas
        public void Skaiciavimas()
        {

            int skaiciuokle = 0;

            while (this.sk1 <= this.max)
            {
                this.sk1 = this.sk1 * this.sk2;
                skaiciuokle++;
            }
            Console.WriteLine("Kiek kartu teko skaiciuoti? : " + skaiciuokle + " Koks galutinis skaicius? : " + this.sk1);
        }

    }
}
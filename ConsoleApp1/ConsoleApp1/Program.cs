using System;
using System.Diagnostics;
using System.Threading;

namespace Uzd1
{
    internal class Matematika
    {
        private double max, sk1,laikinas;
        private int sk2;

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
        public Matematika(double max, double sk1, int sk2)
        {
            this.max = max;
            this.sk1 = sk1;
            this.sk2 = sk2;
        }
        public void Skaiciavimas()
        {
            //1 2 2 4 8 32
            // 2 2 4 8 32
            // 2 4 8 32
            int skaiciuokle = 0;
            double laikinas = 1;

            while (this.sk1 < 32)
            {   
                // laikinas = 1 * 2
                // sk1 = 2 * 1
                //laikinas = 2 * 2
                // sk1 = 4 * 2
                //laikinas = 8 * 4
                //sk1 = 8 * 16

                this.laikinas = this.sk1 * this.laikinas;
                this.sk1 = this.laikinas * this.sk1;
                skaiciuokle++;
            }
            Console.WriteLine("Kiek kartu teko skaiciuoti? : " + skaiciuokle + " Koks galutinis skaicius? : " + this.sk1);
        }

        
    }
}
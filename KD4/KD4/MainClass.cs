using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD4
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            Byla byla = new Byla("Failai", 5);
            //byla.kurti();
            //kvieciamas ataskaitos metodas su parametru ataskaitos aplankalo pavadinimas
            //byla.ataskaita("Ataskaita");
            //kvieciamas trinimo metodas, kuris istrins failus kuriuose yra 0, taciau ataskaita neatnaujinama..
            byla.trinti();


        }
    }
}

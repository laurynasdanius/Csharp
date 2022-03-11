using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  // include the System.IO namespace
using System.Diagnostics; // for getting the error message

namespace KD4
{
    internal class Byla : IStruktura
    {
        // Specify a name for your top-level folder.
        string subPath;
        string byluPav;
        string path;
        string fileExtension = ".txt";
        string fullPath;
        string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
        
        public void setByluPav(string byluPav)
        {
            this.byluPav = byluPav;
        }
        public void ataskaita()
        {
            throw new NotImplementedException();
        }

        public void failuSukurimas(int kiekis) {
 
                //Ciklas kuris sukurs failus pagal musu nurodyta kieki
                Console.WriteLine("Creating files..");
                for (int i = 0; i < kiekis; i++)
                {
                    //sujungiame folderio path su failu path be extension (pvz .txt)
                    this.path = System.IO.Path.Combine(this.subPath, "failas" + i);

                    // Kodo eilute sukurs faila, [ aplankalas\ ] failas[ numeris ] [fileExtension(.txt )]
                    // CreateText metodas grazina StreamWriter objekta
                    //fullpath string bus pilnam keliui ir prides extension
                     this.fullPath = this.path + this.fileExtension;
                    using (StreamWriter sw = File.CreateText(this.fullPath)) ;

                    Console.WriteLine("File [" + this.fullPath + "] created..");
                }
                Console.WriteLine("Files have been created successfully");
            }
        
        //Metodas skirtas failu sukurimui su failu kiekiu parametruose
        public void kurti(int kiekis)
        {
            //Aplankalo pavadinimas
             this.subPath = "Failai"; // Your code goes here

            //try ir catch naudojama jeigu ivyktu klaida kuriant ir isvestu klaida
            try
            {
                //if tikrina ar Aplankalas neegzistuoja
                if (!Directory.Exists(this.subPath))
                {
                    //jeigu aplankalas neegzistuoja tada isvedamas tekstas i console ir aplankalas yra sukuriamas
                    Console.WriteLine("This folder : " + this.subPath + " Doesn't exist. Creating it now..");
                    Directory.CreateDirectory(this.subPath);
                    //ivykdomas failu sukurimas
                    failuSukurimas(kiekis);
                }
                //Jeigu aplankalas jau egzistuoja ir egzistuoja sukurti failai bus isvedama si zinute
                else if (Directory.Exists(this.subPath) && File.Exists(this.fullPath))
                {
                    Console.WriteLine("This folder : " + this.subPath + " exist. This file " +this.fullPath+ " exist. Proceeding to rename files..");
                    
                        for (int i = 0; i < kiekis; i++)
                        {
                            //kadangi reikia pereiti per failus vel sujungiame pavadinimus kad i butu is naujo
                            this.path = System.IO.Path.Combine(this.subPath, "failas" + i);
                            //Move metodas pakeis dabartini pavadinima i kita pavadinima
                            System.IO.File.Move(this.path + this.fileExtension, this.path + this.date + this.fileExtension);
                           

                            Console.WriteLine("File " + this.path + " created..");
                        }
                    

                }
                //jeigu aplankalas egzistuoja bet failai ne, sukuriami failai
                else if (Directory.Exists(this.subPath) && !File.Exists(this.fullPath))
                {
                    Console.WriteLine("This folder : " + this.subPath + " exist. This file " + this.fullPath + " doesn't exist. Proceeding..");
                    failuSukurimas(kiekis);
                }
            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
            }
        }

        public void trinti()
        {
            throw new NotImplementedException();
        }
        
        //metodas kuris paims is vartotojo pavadinima failu kurimui
        public void ivestiPav()
        {
            bool tinkamumas = false;
            // ismetamas tekstas i konsole
            Console.WriteLine("Koks bus failo pavadinimas : ");

            // Sukuriamas string kintamasis kuris tures reiksme to, ka ivede vartotojas
            this.setByluPav(Console.ReadLine());

            // Print the value of the variable (userName), which will display the input value
            Console.WriteLine("Ivestas failo pavadinimas : " + byluPav);

            Console.WriteLine("Ar pavadinimas tinkamas? (y/n)" + byluPav);

            while (tinkamumas != true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                        
                
                }else{
                    // ismetamas tekstas i konsole
                    Console.WriteLine("\n Koks bus failo pavadinimas : ");
                    // Sukuriamas string kintamasis kuris tures reiksme to, ka ivede vartotojas
                    this.setByluPav(Console.ReadLine());
                    Console.WriteLine("Ar pavadinimas tinkamas? (y/n) \n" + byluPav);

                }
            }

        }
        //public void kurti(int byluNum)
        //{
        //kiek bylu generuosime
        //   int byluNum;
        //}
        static void Main(string[] args)
        {
            Byla byla = new Byla();
            //byla.ivestiPav();
            byla.kurti(2);
            Console.WriteLine();
        }
}
}

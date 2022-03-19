using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  // include the System.IO namespace
using System.Diagnostics; // for getting the error message
using System.Collections;

namespace KD4
{
    internal class Byla : IStruktura
    {
        // Specify a name for your top-level folder.

        //Naudojant konstruktorių kuriant objektą reikia nurodyti vieną privalomą argumentą - bylos vietą(nurodoma reliatyvus kelias*) .
        private string folderPath;
        private int fileAmmount;
        //private string[] cratedFilesArr;
        // Creates and initializes a new ArrayList.
        ArrayList createdFilesArr = new ArrayList();
        public async void writeFileNames(ArrayList fileNameArray)
        {            
            foreach (string fileName in fileNameArray)
            {
                Console.WriteLine(fileName);
                
                using StreamWriter file = new(Path.Combine(this.folderPath, "FileNames.txt"), true);

                await file.WriteLineAsync("" + fileName);
            }
        }
        public void ataskaita()
        {
            throw new NotImplementedException();
        }

        // Atidarome faila kuris turi visu sukurtu failu pavadinimus ir pereinam per kiekviena eilute
        public bool arFailaiSutampa(string oldFileName,string newFileName)
        {
            foreach (string line in File.ReadLines(Path.Combine(this.folderPath, "FileNames.txt")))
            {
                
                //jeigu failo pavadinimas readline faile sutampa su musu sukurtu failu
                if (line == oldFileName)
                {
                    //Console.WriteLine("old : " + Path.Combine(this.folderPath, oldFileName) + "new : " + Path.Combine(this.folderPath, newFileName));
                    System.IO.File.Move(Path.Combine(this.folderPath, oldFileName), Path.Combine(this.folderPath, newFileName));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //butinas return kitaip metodas neveiks //reiikia potential fix
            return false;
        }
        //public void failoVardoKeitimas(string oldFileName,string newFileName)
        //{
            
        //}
        public void failuSukurimas()
        {
            Random r = new Random();
            int failuSkaicius = this.fileAmmount;
            int rInt;

            //int counter = 0;

            
            //System.Console.WriteLine("There were {0} lines.");


            for (int i = 0; i <= failuSkaicius; i++)
            {
                string filePath = "Failas" + i + ".txt";

                //tikriname ar sukurtas failo pavadinimas atitinka musu turimame failu vardu faile
                arFailaiSutampa(filePath,"Test"+i+".txt");
                
                string fullPath = Path.Combine(this.folderPath, filePath);
                //Ar jau yra tokia pagrindinė byla
                //if (!File.Exists(fullPath))
                //{
                using (FileStream fs = File.Create(fullPath))
                {
                    Console.WriteLine(fullPath);
                    //sukuriamas skaicius tarp 0 ir 1
                    rInt = r.Next(0, 2); 
                    byte[] info = new UTF8Encoding(true).GetBytes(rInt.ToString());
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
               
                //Console.WriteLine("File "+ fullPath + " is created.");
                //i array irasoma failo vieta

                this.createdFilesArr.Add(filePath);

                
                //}
                //else
                //{
                //    Console.WriteLine("Files already exist lol");
                //}
            }
            writeFileNames(this.createdFilesArr);
            

        }
        //Metodas skirtas failu sukurimui su failu kiekiu parametruose
        public void kurti()
        {
            if (Directory.Exists(this.folderPath))
            {
                Console.WriteLine("File \"{0}\" already exists.", this.folderPath);

                failuSukurimas(); 
            }
            else
            {
                Console.WriteLine("File \"{0}\" doesnt already exist.", this.folderPath);
                Directory.CreateDirectory(this.folderPath);
                failuSukurimas();
            }
            

        }

        public void trinti()
        {
            throw new NotImplementedException();
        }

        //Klases konstruktorius su tuo paciu pavadinimu kaip ir klase
        public Byla(string folderPath, int fileAmmount)
        {
            this.folderPath = folderPath;
            this.fileAmmount = fileAmmount;
        }
        //static void Main(string[] args)
        //{
        //    Byla byla = new Byla("Failai",5);
        //    ////byla.ivestiPav();
        //    byla.kurti();
            


        //}
    }
}

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
    internal class Class1 : IStruktura
    {
        private string folderPath;
        private int fileAmmount;
        ArrayList createdFilesArr = new ArrayList();
        public async void writeFileNames(ArrayList fileNameArray)
        {
            foreach (string fileName in fileNameArray)
            {
                Console.WriteLine(fileName);

                using StreamWriter file = new("FileNames.txt", true);

                await file.WriteLineAsync("" + fileName);
            }
        }
        public void checkFile(string filePath)
        {
            int i=0;
            string[] files = Directory.GetFiles(this.folderPath);
            foreach (string file in files)
            {

                Console.WriteLine(Path.GetFileName(file));
                if (filePath == file)
                {
                    i++;
                    Console.WriteLine("Egzistuoja");
                    renameFile(filePath,"",i);
                    break;
                }
            }
            //Prieš sukurdamas bylą patikrintų ar tokia byla dar neegzistuoja,
            //jei egzistuoja seną bylą pervardinti pridedant data pvz.: a1_2022 - 02 - 12.txt;
        }
        public void renameFile(string oldName,string newName,int i)
        {
            newName = "test"+i+".txt";
            string fullPath = Path.Combine(this.folderPath, newName);
            System.IO.File.Move(oldName, fullPath);
        }
        public void createFiles()
        {
            Random r = new Random();
            
            for (int i = 0; i <= this.fileAmmount; i++)
            {
                string filePath = "Failas" + i + ".txt";

                string fullPath = Path.Combine(this.folderPath, filePath);
                //patikrina ar toks failas jau egzistuoja
                checkFile(fullPath);

                

                this.createdFilesArr.Add(filePath);
            }
        }

        //Klases konstruktorius su tuo paciu pavadinimu kaip ir klase
        public Class1(string folderPath, int fileAmmount)
        {
            this.folderPath = folderPath;
            this.fileAmmount = fileAmmount;
        }
        
        public void ataskaita()
        {
            throw new NotImplementedException();
        }

        public void kurti()
        {
            //tikrina ar aplankalas egzistuoja
            if (Directory.Exists(this.folderPath))
            {
                //jeigu aplankalas egzistuoja patikriname ar failai jame egzistuoja
                Console.WriteLine("File \"{0}\" already exists.", this.folderPath);
                createFiles();
            }
            else
            {
                //jeigu aplankalas neegzistuoja sukuriamas aplankalas 
                Console.WriteLine("File \"{0}\" doesnt already exist.", this.folderPath);
                Directory.CreateDirectory(this.folderPath);

                //ir sukuriami failai
                createFiles();
                //sukuriamas failas su sukurtais failu vardais
                writeFileNames(this.createdFilesArr);

            }



        }

        public void trinti()
        {
            throw new NotImplementedException();
        }
        static void Main(string[] args)
        {
            Class1 byla = new Class1("Failai", 5);
            byla.kurti();



        }
    }
}

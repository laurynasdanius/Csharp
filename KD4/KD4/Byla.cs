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
        private string folderPath;
        private int fileAmmount;
        ArrayList createdFilesArr = new ArrayList();


        public bool IsDirectoryEmpty()
        {
            return !Directory.EnumerateFileSystemEntries(this.folderPath).Any();
        }
        public void writeToFile(string fullPath)
        {
            Random rInt = new Random();
            int randomNumber = rInt.Next(0, 2);

            using (var stream = new FileStream(fullPath, FileMode.CreateNew))
            {
                var bytes = Encoding.UTF8.GetBytes(randomNumber.ToString());
                stream.Write(bytes, 0, bytes.Length);
            }
        }
        public void createFiles()
        {
            
            for (int i = 0; i <= this.fileAmmount; i++)
            {
                string fileName = "Failas" + i + ".txt";
                string fullPath = Path.Combine(this.folderPath, fileName);

                //if file already exists rename it 
                if (File.Exists(fileName))
                {
                    fileRename();
                }
                else
                {
                    Console.WriteLine("File: {0}  neegzistuoja. Sukuriame..", fileName);
                    writeToFile(fullPath);
                }   
            }
        }
        public void ataskaitaWrite(string ataskaitaReportPath)
        {
            Console.WriteLine("Pradedame rasyti informacijos i ataskaitos faila");

            foreach (string fileName in Directory.GetFiles(this.folderPath))
            {
                //atsidarome faila skaitymui, kuris turi 0 arba 1
                using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                //atsidarome report faila duomenu irasimui
                using (TextWriter tsw = new StreamWriter(ataskaitaReportPath, true))                    
                {
                    string contents = sr.ReadToEnd();
                    if (contents == "1")
                    {
                        Console.WriteLine("Failas: {0} turi 1.", fileName);
                        //parasoma eilute i report faila
                        tsw.WriteLine(fileName + " " + 1); 
                    }
                    else
                    {
                        Console.WriteLine("Failas: {0} turi 0.", fileName);
                        tsw.WriteLine(fileName + " " + 0);  
                    }
                }
            }
            Console.WriteLine("Ataskaita baigta, rezultatai surasyti faile esanciame {0}", ataskaitaReportPath);
        }
        public void ataskaita(string ataskaitosAplankaloPav)
        {
            //sukuriamas ataskaitos kelias
            string ataskaitaPath= Path.Combine(this.folderPath, ataskaitosAplankaloPav);
            //sukuriamas ataskaitos failo kelias
            string reportName = "Report.txt";
            string ataskaitaReportPath = Path.Combine(ataskaitaPath, reportName);

            //tikriname ar egzistuoja aplankalas
            if (File.Exists(ataskaitaPath))
            {       
                ataskaitaWrite(ataskaitaReportPath);
            }
            else
            {
                Directory.CreateDirectory(ataskaitaPath);
                ataskaitaWrite(ataskaitaReportPath);
            }
        }

        public void kurti()
        {
            //tikrina ar aplankalas egzistuoja
            if (Directory.Exists(this.folderPath))
            {
                //jeigu aplankalas egzistuoja patikriname ar failai jame egzistuoja
                Console.WriteLine("Folder \"{0}\" already exists.", this.folderPath);
                createFiles();

                if (IsDirectoryEmpty())
                {
                    Console.WriteLine("Folder \"{0}\" is empty. Proceeding to write files", this.folderPath);
                    createFiles();
                }
                else
                {
                    Console.WriteLine("Folder \"{0}\" not empty. Checking for files", this.folderPath);
                }
                
            }
            else
            {
                //jeigu aplankalas neegzistuoja sukuriamas aplankalas 
                Console.WriteLine("Folder \"{0}\" doesnt already exist.", this.folderPath);
                Directory.CreateDirectory(this.folderPath);

                //ir sukuriami failai
                createFiles();
                

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
        static void Main(string[] args)
        {
            Byla byla = new Byla("Failai", 5);
            byla.kurti();



        }
    }
}

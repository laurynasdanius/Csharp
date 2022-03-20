using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  // include the System.IO namespace
using System.Diagnostics; // for getting the error message
using System.Collections; //for working with collections

namespace KD4
{
    internal class Byla : IStruktura
    {
        private string folderPath;
        private int fileAmmount;
        //ArrayList su folderyje esanciais failu pavadinimais
        ArrayList createdFilesArr = new ArrayList();

        //metodas kuris grazins reiksme ar musu aplankalas tuscias ar ne
        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
        //metodas skirtas 0 arba 1 irasimui i faila
        public void writeToFile(string fullPath)
        {
            Random rInt = new Random();
            //random skaicius, kuris bus arba 1 arba 0
            int randomNumber = rInt.Next(0, 2);
            Console.WriteLine("Failas: {0}  sukurtas. Irasome {1} jame..", fullPath,randomNumber);


            using (var stream = new FileStream(fullPath, FileMode.CreateNew))
            {
                var bytes = Encoding.UTF8.GetBytes(randomNumber.ToString());
                stream.Write(bytes, 0, bytes.Length);
            }
        }
        public void fileRename(string oldFilePath,int i)
        {
            //dabartine data
            string currentDate = DateTime.UtcNow.ToString("MM-dd-yyyy");
            //naujas failo vardas
            string newName = "Failas_"+i+"_"+ currentDate + ".txt";
            //naujo failo kelias
            string newPath = Path.Combine(this.folderPath, newName);

            try
            {
                //metodas kuris paims sena kelia ir pakeis failo varda naudodamasis nauja kelia
                File.Move(oldFilePath, newPath);

                //jeigu senas failas nebeegzistuoja isves i konsole sia zinute
                if (!File.Exists(oldFilePath))
                {
                    Console.WriteLine("Failas {0} buvo pervadintas i {1}.",oldFilePath,newPath);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The renaming failed: {0}", e.ToString());
            }
        }
        public void createFiles()
        {
            //ciklas kurs failus iki nurodyto fileAmmount, kuri jis gauna kai sukuriamas objektas
            for (int i = 0; i <= this.fileAmmount; i++)
            {
                //sukuriamas string su failo vardu
                string fileName = "Failas" + i + ".txt";

                //sukuriamas kelias i aplankala + failas kuri sukursime tenai
                string fullPath = Path.Combine(this.folderPath, fileName);

                //Jeigu failas kuri kuriame jau egzistuoja tai ji pervadinsime
                if (File.Exists(fullPath))
                {
                    Console.WriteLine("Failas: {0}  jau egzituoja. Ji pervadiname..",fileName);
                    fileRename(fullPath,i);
                }
                //jeigu toks failas neegzistuoja ji sukursime ir ivesime duomenis
                else
                {
                    Console.WriteLine("File: {0}  neegzistuoja. Sukuriame..", fileName);
                    writeToFile(fullPath);
                }   
            }
        }
        public void ataskaitaWrite(string pagrindinisAplankalas, string ataskaitaReportPath)
        {
            Console.WriteLine("Pradedame rasyti informacijos i ataskaitos faila");

            foreach (string fileName in Directory.GetFiles(pagrindinisAplankalas))
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
        public void ataskaita(string pagrindinisAplankalas,string ataskaitosAplankaloPav)
        {
            //sukuriamas ataskaitos kelias
            string ataskaitaPath= Path.Combine(pagrindinisAplankalas, ataskaitosAplankaloPav);
            //sukuriamas ataskaitos failo kelias
            string reportName = "Report.txt";
            string ataskaitaReportPath = Path.Combine(ataskaitaPath, reportName);

            //tikriname ar egzistuoja aplankalas
            if (File.Exists(ataskaitaPath))
            {       
                ataskaitaWrite(pagrindinisAplankalas, ataskaitaReportPath);
            }
            else
            {
                Directory.CreateDirectory(ataskaitaPath);
                ataskaitaWrite(pagrindinisAplankalas, ataskaitaReportPath);
            }
        }

        public void kurti()
        {
            //tikrina ar aplankalas egzistuoja
            if (Directory.Exists(this.folderPath))
            {
                //jeigu aplankalas egzistuoja patikriname ar failai jame egzistuoja
                Console.WriteLine("Aplankalas \"{0}\" jau egzistuoja.", this.folderPath);
                
                //tikrina ar aplankalas tuscias
                if (IsDirectoryEmpty(this.folderPath))
                {
                    Console.WriteLine("Aplankalas \"{0}\" yra tuscias. Pradedame kurti failus", this.folderPath);
                    createFiles();
                }
                else
                {
                    Console.WriteLine("Aplankalas \"{0}\" nera tuscias. Ieskome failu", this.folderPath);
                    createFiles();
                }  
            }
            else
            {
                //jeigu aplankalas neegzistuoja sukuriamas aplankalas 
                Console.WriteLine("Aplankalas \"{0}\" neegzistuoja. Ji sukursime ir irasysime failus", this.folderPath);
                Directory.CreateDirectory(this.folderPath);

                //ir sukuriami failai
                createFiles();
            }
        }

        public void trinti()
        {
            foreach (string fileName in Directory.GetFiles(this.folderPath))
            {
                //atsidarome faila skaitymui, kuris turi 0 arba 1
                using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                {
                    string fileContent = sr.ReadToEnd();
                    if (fileContent =="0")
                    {
                        sr.Close();
                        Console.WriteLine("Failas: \"{0}\" turi 0, triname..",fileName);
                        File.Delete(fileName);

                    }
                }
            }
        }
        //Klases konstruktorius su tuo paciu pavadinimu kaip ir klase
        public Byla(string folderPath, int fileAmmount)
        {
            this.folderPath = folderPath;
            this.fileAmmount = fileAmmount;
        }
    }
}

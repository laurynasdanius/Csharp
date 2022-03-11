using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace KD5
{
    internal class Nr1
    {
        public void createDuomFile()
        {
            string duomFile = "PradDuomenys.txt";
            string tekstas = "Hello world!!";

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(duomFile))
                {
                    //IRASOMA I FAILA
                    byte[] info = new UTF8Encoding(true).GetBytes(tekstas);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                //using (StreamReader sr = File.OpenText(duomFile))
                //{
                //    string s = "";
                //    while ((s = sr.ReadLine()) != null)
                //    {
                //        Console.WriteLine(s);
                //    }
                //}
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void aesEncrypt()
        {
            try
            {
                using (FileStream fileStream = new ("TestData.txt", FileMode.OpenOrCreate))
                {

                    using (Aes aes = Aes.Create())
                    {
                        byte[] key =
                        {
                            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                        };
                    aes.Key = key;

                        byte[] iv = aes.IV;
                    fileStream.Write(iv, 0, iv.Length);

                        using (CryptoStream cryptoStream = new (
                            fileStream,
                            aes.CreateEncryptor(),
                            CryptoStreamMode.Write))
                        {
                            using (StreamWriter encryptWriter = new (cryptoStream))
                            {
                                encryptWriter.WriteLine("Hello World!");
                            }
                        }
                    }
                }

                Console.WriteLine("The file was encrypted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The encryption failed. {ex}");
            }
        }
        public async Task decryptAsync()
        {
            try
            {
                using (FileStream fileStream = new("TestData.txt", FileMode.Open))
                {
                    using (Aes aes = Aes.Create())
                    {
                        byte[] iv = new byte[aes.IV.Length];
                        int numBytesToRead = aes.IV.Length;
                        int numBytesRead = 0;
                        while (numBytesToRead > 0)
                        {
                            int n = fileStream.Read(iv, numBytesRead, numBytesToRead);
                            if (n == 0) break;

                            numBytesRead += n;
                            numBytesToRead -= n;
                        }

                        byte[] key =
                        {
                            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                        };

                        using (CryptoStream cryptoStream = new(
                           fileStream,
                           aes.CreateDecryptor(key, iv),
                           CryptoStreamMode.Read))
                        {
                            using (StreamReader decryptReader = new(cryptoStream))
                            {
                                string decryptedMessage = await decryptReader.ReadToEndAsync();
                                Console.WriteLine($"The decrypted original message: {decryptedMessage}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The decryption failed. {ex}");
            }
        }
        static void Main(string[] args)
        {
            Nr1 nr1 = new Nr1();
            //sukuriamas failas su pradiniais duomenimis
            

            nr1.aesEncrypt();

            //nr1.decryptAsync();
        }
    }
}

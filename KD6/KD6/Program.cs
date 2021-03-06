using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StrongPasswordGen
{
    class Program
    {
        static RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

        static void Main(string[] args)
        {

            int PasswordAmount = 0;
            int PasswordLength = 0;

            string CapitalLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string SmallLetters = "qwertyuiopasdfghjklzxcvbnm";
            string Digits = "0123456789";
            string SpecialCharacters = "!@#$%^&*()-_=+<,>.";
            string AllChar = CapitalLetters + SmallLetters + Digits + SpecialCharacters;



            Console.WriteLine("\nHow many passwords should be generated?:");
            PasswordAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the password length (chars):");
            PasswordLength = int.Parse(Console.ReadLine());

            string[] AllPasswords = new string[PasswordAmount];


            for (int i = 0; i < PasswordAmount; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int n = 0; n < PasswordLength; n++)
                {
                    sb = sb.Append(GenerateChar(AllChar));
                }

                //Masyvas laikantis slaptazodziu reiksmes. 
                AllPasswords[i] = sb.ToString();
            }

            Console.WriteLine("Generated passwords:");

            foreach (string singlePassword in AllPasswords)
            {
                Console.WriteLine(singlePassword);
            }

            //Darbas su masyvu
            Console.WriteLine("The first generated password:" + AllPasswords.First());
            Console.WriteLine("The last generated password:" + AllPasswords.Last());
            Console.WriteLine("The array of passwords length :" + AllPasswords.Length);


        }

        private static char GenerateChar(string availableChars)
        {
            var byteArray = new byte[1];
            char c;
            do
            {
                provider.GetBytes(byteArray);
                c = (char)byteArray[0];

            } while (!availableChars.Any(x => x == c));

            return c;
        }
    }

}
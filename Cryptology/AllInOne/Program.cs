using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Ciphers;
using AllInOne.Tools;

namespace AllInOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Cipher cipher = new Cipher();

            //cipher = new Atbash(Alphabets.alphabetRUS);
            //Console.WriteLine(cipher.Encrypt("КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА"));
            
            cipher = new Vegenere(Alphabets.alphabetRUS);
            Console.WriteLine(cipher.Encrypt("КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА", "ШИФР"));
            Console.WriteLine(cipher.Decrypt(cipher.Encrypt("КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА", "ШИФР"), "ШИФР"));

            //cipher = new Pollib(Alphabets.alphabetRUS_MATRIX);
            //Console.WriteLine(cipher.Encrypt("КАНДАКОВА АНАСТАСИЯ НИКОЛАЕВНА"));

            //cipher = new Beaufort(Alphabets.alphabetRUS);
            //Console.WriteLine(cipher.Encrypt("КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА", "ШИФР"));

            //cipher = new Gronsfeld(Alphabets.alphabetRUS);
            //Console.WriteLine(cipher.Encrypt("КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА", "2015"));
            //string[] rMatrix = new string[]
            //{
            //    "100111000111011",
            //    "000110100011010",
            //    "111000110111011",
            //    "000100100000000"
            //};
            //cipher = new Richelieu(Alphabets.alphabetRUS);
            //Console.WriteLine(cipher.Encrypt("КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА", rMatrix));


            //cipher = new Book(Alphabets.alphabetRUS);
            //Console.WriteLine(cipher.Encrypt("КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА"));
            //cipher = new Playfer(Alphabets.alphabetRUS);
            //Console.WriteLine(cipher.Encrypt("КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА", "ШИФР"));

        }
    }
}

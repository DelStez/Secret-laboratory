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
            //Console.WriteLine(cipher.Encrypt("КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА", "ШИФР"));

            //cipher = new Vegenere(Alphabets.alphabetRUS);
            //Console.WriteLine(cipher.Encrypt("КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА", "ШИФР"));
            //Console.WriteLine(cipher.Decrypt(cipher.Encrypt("КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА", "ШИФР"), "ШИФР"));

            //cipher = new Pollib(Alphabets.alphabetRUS_MATRIX);
            //Console.WriteLine(cipher.Encrypt("КАНДАКОВА АНАСТАСИЯ НИКОЛАЕВНА"));

            //cipher = new Beaufort(Alphabets.alphabetRUS);
            //Console.WriteLine(cipher.Encrypt("КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА", "ШИФР"));

            //cipher = new Gronsfeld(Alphabets.alphabetENG);
            //Console.WriteLine(cipher.Encrypt("GRONSFELD", "2015"));

        }
    }
}

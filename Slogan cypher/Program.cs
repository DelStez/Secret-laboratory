using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slogan_cypher
{
    class Program
    {
        static string alphabetOld = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        static string alphabetNew = "";
        static void CreateAlphabet(string message)
        {
            foreach (char ch in message)
            {
                if (!alphabetNew.Contains(ch))
                    alphabetNew += ch;
            }
        }
        static void Main(string[] args)
        {
            string openText = "КАНДАКОВААНАСТАСИЯНИКОЛАЕВНА";
            string code = "";
            string sloganKey = Console.ReadLine().ToUpper();
            CreateAlphabet(sloganKey);
            CreateAlphabet(alphabetOld);
            Console.WriteLine(alphabetNew);
            foreach (char ch in openText)
            {
                char newChar = alphabetNew[alphabetOld.IndexOf(ch)];
                code += newChar;
            }
            Console.WriteLine(code);
        }
    }
}

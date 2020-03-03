using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_cypher
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string openText = "ЯМА";
            int k = Convert.ToInt32(Console.ReadLine());
            string code = "";
            foreach (char ch in openText)
            {
                char newChar = alphabet[(alphabet.IndexOf(ch)+k) % 32];
                code += newChar;

            }
            Console.WriteLine(code);
        }
    }
}

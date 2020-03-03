using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atbash_cypher
{
    class Program
    {
        static void Main(string[] args)
        {   // СЪМСЛШЫДЭЪЖЯМГФРУРФРУГЗЦФСЯЫЛОЯФЯ
            string alphaBet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string openText = "ФЯСЫЯФРЭЯЯСЯНМЯНЦА";
            string code = "";
            Console.WriteLine(openText);
            for (int i = 0; i < openText.Length; i++)
            {
                int index = alphaBet.IndexOf(openText[i]) + 1;
                index = 33 - index + 1;
                code += alphaBet[index - 1];
            }
            Console.WriteLine(code);
        }
    }
}

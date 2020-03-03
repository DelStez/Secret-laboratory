using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pollib_cypher
{
    class Program
    {

        static char[,] alphabet = {
                                   {'А', 'Б', 'В', 'Г', 'Д', 'Е',},
                                   {'Ё','Ж', 'З', 'И', 'Й', 'К'},
                                   {'Л','М', 'Н', 'О', 'П', 'Р'},
                                   {'С','Т', 'У', 'Ф', 'Х', 'Ц'},
                                   {'Ч','Ш', 'Щ', 'Ъ', 'Ы', 'Ь'},
                                   {'Э','Ю', 'Я', ',', '.', ' '}
                               };
        static void Main(string[] args)
        {
            string openText = "П";
            string decode = "";
            foreach (char ch in openText)
            {
                for (int i = 0; i < alphabet.GetLength(0); i++)
                {
                    for (int j = 0; j < alphabet.GetLength(1); j++)
                    {
                        if (alphabet[i, j] == ch)
                        {
                            decode += ((i+1).ToString() + (j+1).ToString() + " ");
                        }
                    }
                }
            }
            Console.WriteLine(decode);
        }
    }
}

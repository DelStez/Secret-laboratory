using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pollib
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "35 34 15 11 31 56 52 16 66 34 42 66 46 11 36 16 25 66 14 34 31 34 13 11 66 46 16 31 16 25";
            string[] inputArray = input.Split(' ').ToArray();
            string decode = "";
            char[,] alphavit = {
                                   {'А', 'Б', 'В', 'Г', 'Д', 'Е',},
                                   {'Ё','Ж', 'З', 'И', 'Й', 'К'},
                                   {'Л','М', 'Н', 'О', 'П', 'Р'},
                                   {'С','Т', 'У', 'Ф', 'Х', 'Ц'},
                                   {'Ч','Ш', 'Щ', 'Ъ', 'Ы', 'Ь'},
                                   {'Э','Ю', 'Я', ',', '.', ' '}
                               };
            for (int i = 0; i < inputArray.Length; i++)
            {
                string temp = inputArray[i].ToString();
                int indexFirst = Convert.ToInt32(temp[0].ToString()) - 1;
                int indexSecond = Convert.ToInt32(temp[1].ToString()) - 1;
                char t = alphavit[indexFirst, indexSecond];
                decode += t;
            }
            Console.WriteLine(decode);
        }
    }
}

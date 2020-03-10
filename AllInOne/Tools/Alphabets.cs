using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Tools
{
    class Alphabets
    {
        public static string alphabetRUS = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public static string alphabetENG = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static char[,] alphabetRUS_MATRIX = new char[,]
           {
                {'А', 'Б', 'В', 'Г', 'Д', 'Е'},
                {'Ё', 'Ж', 'З', 'И', 'Й', 'К'},
                {'Л', 'М', 'Н', 'О', 'П', 'Р'},
                {'С', 'Т', 'У', 'Ф', 'Х', 'Ц'},
                {'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь'},
                {'Э', 'Ю', 'Я', ',', '.', '_'}
           };

        public static char[,] alphabetENG_MATRIX = new char[,]
            {
                {'A', 'B', 'C', 'D', 'E'},
                {'F', 'G', 'H', 'I', 'K'},
                {'L', 'M', 'N', 'O', 'P'},
                {'Q', 'R', 'S', 'T', 'U'},
                {'V', 'W', 'X', 'Y', 'Z'}
            };
    }
}

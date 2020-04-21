using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_7
{
    class Program
    {
        public static Dictionary<string, double> alphaBetRUS = new Dictionary<string, double> {
            { "О", 0.090 },
            { "Е", 0.048 }, { "А", 0.062 },
            { "И", 0.062 },
            { "Т", 0.053 }, { "Н", 0.053 },
            { "С", 0.045 }, { "Р", 0.040 },
            { "В", 0.038 }, { "Л", 0.035 },
            { "К", 0.028 }, { "М", 0.026 },
            { "Д", 0.025 }, { "П", 0.023 },
            { "У", 0.021 }, { "Я", 0.018 },
            { "Ы", 0.016 }, { "З", 0.016 },
            { "Ъ", 0.007 }, { "Ь", 0.007 },
            { "Б", 0.014 }, { "Г", 0.013 },
            { "Ч", 0.012 }, { "Й", 0.010 },
            { "Х", 0.009 }, { "Ж", 0.007 },
            { "Ю", 0.006 },{ "Ш", 0.006 },
            { "Ц", 0.004 },{ "Щ", 0.003 },
            { "Э", 0.003 },{ "Ф", 0.003 }
        };
        public static Dictionary<string, string> alphaBetRUSMorze = new Dictionary<string, string> {
            { "О", "- - - "},
            { "Е", ". " }, { "А", ". - " },
            { "И", ". . " },
            { "Т", "- " }, { "Н", "- . " },
            { "С", ". . . " }, { "Р", ". - . " },
            { "В", ". - - " }, { "Л", ". - . . " },
            { "К", "- . - " }, { "М", "- - " },
            { "Д", "- . . " }, { "П", ". - - . " },
            { "У", ". - - " }, { "Я", ". - . - " },
            { "Ы", "- . - - " }, { "З", "- - . . " },
            { "Ъ", "- . . - " }, { "Ь", "- . . - " },
            { "Б", "- . . . " }, { "Г", "- - . " },
            { "Ч", "- - - . " }, { "Й", ". - - - " },
            { "Х", ". . . . " }, { "Ж", ". . . - " },
            { "Ю", ". . - - " },{ "Ш", "- - - - " },
            { "Ц", "- . - . " },{ "Щ", "- - . - " },
            { "Э", ". . - . . " },{ "Ф", ". . - . " }
        };
        public static Dictionary<string, string> alphaBetENGMorze = new Dictionary<string, string> {
            { "E", ". " },
            { "T", "- " }, { "O",  "- - - " },
            { "A", ". - "}, { "N", "- . " },
            { "I", ". . " }, { "R", ". - . "},
            { "S", ". . . " }, { "H", ". . . . " },
            { "D", "- . . "  }, { "L", ". - . . " },
            { "C", "- . - . " }, { "F",  ". . - . " },
            { "U", ". - - " }, { "M", "- - " },
            { "P", ". - - . " }, { "Y","- . - - "},
            { "W", ". - - " }, { "G","- - . "  },
            { "B", "- . . . " }, { "V",". . . - "},
            { "K", "- . - "}, { "X", "- . . - " },
            { "J", ". - - - " }, { "Q","- - . - "}, { "Z","- - . . " }};
        public static Dictionary<string, double> alphaBetENG = new Dictionary<string, double> {
            { "E", 0.105 },
            { "T", 0.072 }, { "O", 0.065 },
            { "A", 0.063 }, { "N", 0.058 },
            { "I", 0.055 }, { "R", 0.052 },
            { "S", 0.052 }, { "H", 0.047 },
            { "D", 0.035 }, { "L", 0.028 },
            { "C", 0.023 }, { "F", 0.023 },
            { "U", 0.023 }, { "M", 0.021 },
            { "P", 0.018 }, { "Y", 0.012 },
            { "W", 0.012 }, { "G", 0.011 },
            { "B", 0.010 }, { "V", 0.008 },
            { "K", 0.003 }, { "X", 0.001 },
            { "J", 0.001 }, { "Q", 0.001 }, { "Z", 0.001 }};

        public static Dictionary<string, string> NumberMorze = new Dictionary<string, string> {
            { "1", ". - - - - " },
            { "2", ". . - - - " },
            { "3", ". . . - - " },
            { "4", ". . . . - " },
            { "5", ". . . . . " },
            { "6", "- . . . . " },
            { "7", "- - . . . " },
            { "8", "- - - . . " },
            { "9", "- - - - ." },
            { "0", "- - - - -" }};
        public static Dictionary<string, double> Number = new Dictionary<string, double> {
            { "1", 0.1 }, { "2", 0.1 },
            { "3", 0.1 }, { "4", 0.1 },
            { "5", 0.1 }, { "6", 0.1 },
            { "7", 0.1 }, { "8", 0.1 },
            { "9", 0.1 }, { "0", 0.1 }};
        public static Dictionary<string, string> alphaBetRUSBodo = new Dictionary<string, string> {
            { "О", "11000"},
            { "Е", "00001" }, { "А", "00011" },
            { "И", "00110" },
            { "Т", "10000" }, { "Н", "01100" },
            { "С", "00101" }, { "Р", "00110" },
            { "В", "10011" }, { "Л", "10010" },
            { "К", "01111" }, { "М", "11100" },
            { "Д", "01110" }, { "П", "10110" },
            { "У", "00111" }, { "Я", "10111" },
            { "Ы", "10001" }, { "З" , "10001" },
            { "Ъ", "11101" }, { "Ь" , "11101" },
            { "Б", "11001" }, { "Г" , "11010" },
            { "Ч", "01110" }, { "Й", "01011" },
            { "Х", "10100" }, { "Ж", "11110" },
            { "Ю", "01011" },{ "Ш", "11010" },
            { "Ц", "01110" },{ "Щ", "10100" },
            { "Э", "01101" }, { "Ф", "01101" }
        };
        public static Dictionary<string, string> alphaBetENGBodo = new Dictionary<string, string> {
            { "E", "11001" },
            { "T", "01010" }, { "O", "11000" },
            { "A", "11011" }, { "N", "00100" },
            { "I", "11100" }, { "R", "00110" },
            { "S", "01110" }, { "H", "10001" },
            { "D", "10000" }, { "L", "00001" },
            { "C", "10010" }, { "F", "10100" },
            { "U", "11010" }, { "M", "00101" },
            { "P", "00000" }, { "Y", "11110" },
            { "W", "01100" }, { "G", "10101" },
            { "B", "10110" }, { "V", "01000" },
            { "K", "00011" }, { "X", "01101" },
            { "J", "10011" }, { "Q", "00010" }, { "Z", "01001" }};
        public static Dictionary<string, string> Numberbyte = new Dictionary<string, string> {
            { "1", "00110001" },
            { "2", "00110010" },
            { "3", "00110011" },
            { "4", "00110100" },
            { "5", "00110101" },
            { "6", "00110110" },
            { "7", "00110111" },
            { "8", "00111000" },
            { "9", "00111001" },
            { "0", "00110000" }};
        public static void GetInformations(Dictionary<string,double> alpabetOrnumber, Dictionary<string, string> Morze)
        {
            double K = 0;
            double Shan = 0;
            Console.WriteLine($"Буква  Вероятность       Код Морзе");
            foreach (KeyValuePair<string, double> pair in alpabetOrnumber)
            {
                Console.WriteLine($"{pair.Key}      ({pair.Value})          {Morze[pair.Key]}");
                K += Morze[pair.Key].Length * alpabetOrnumber[pair.Key];
                Shan += pair.Value * Math.Log(1 / pair.Value, 2);
            }
            Console.WriteLine($"Ср. длина: {Math.Round(K, 3)}");
            Console.WriteLine($"Энтропия: {Math.Round(Shan, 3)}");
            Console.WriteLine($"Избыточность кода: {(K / Shan) - 1}\n");
        }
        public static void GetCode()
        {
            Console.WriteLine("Введите последовательнсоть цифр: ");
            string h = Console.ReadLine();
            string output = String.Empty;
            foreach(char c in h)
            {
                output += Numberbyte[c.ToString()];
            }
            Console.WriteLine(output);


        }
        static void Main(string[] args)
        {
            //Код Морзе
            Console.WriteLine("В алфавитах пробела нет. " +
                "Код Бодо для русского использует модификацию МТК-2!");
            Console.WriteLine("Задание 1");
            GetInformations(alphaBetRUS, alphaBetRUSMorze);
            Console.WriteLine("Задание 2");
            GetInformations(alphaBetENG, alphaBetENGMorze);
            Console.WriteLine("Задание 3");
            GetInformations(Number, NumberMorze);
            // Код Бодо
            Console.WriteLine("Задание 1 для русского");
            GetInformations(alphaBetRUS, alphaBetRUSBodo);
            Console.WriteLine("Задание 2 для английского");
            GetInformations(alphaBetENG, alphaBetENGBodo);
            Console.WriteLine("Задание 3");
            GetCode();
            Console.ReadLine();


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_5_1
{
    class Program
    {   
        public static Dictionary<string, double> FirstEXP = new Dictionary<string, double> {
            {"a", 0.3}, { "b", 0.2 }, { "c", 0.2 }, { "d", 0.015},
            { "c(deutch)", 0.01 }, { "d(deutch)", 0.005 }
        };
        public static Dictionary<string, double> alphaBetRUS = new Dictionary<string, double> {
            {" ", 0.175}, { "О", 0.09 },
            { "Е", 0.048 }, { "Ё", 0.024 },
            { "А", 0.062 }, { "И", 0.062 },
            { "Т", 0.053 }, { "Н", 0.053 },
            { "С", 0.045 }, { "Р", 0.040 },
            { "В", 0.038 }, { "Л", 0.035 },
            { "К", 0.028 }, { "М", 0.026 },
            { "Д", 0.025 }, { "П", 0.023 },
            { "У", 0.021 }, { "Я", 0.018 },
            { "Ы", 0.016 }, { "З", 0.016 },
            { "Ъ", 0.014/2 }, { "Ь", 0.014 /2 },
            { "Б", 0.014 }, { "Г", 0.013 },
            { "Ч", 0.012 }, { "Й", 0.010 },
            { "Х", 0.009 }, { "Ж", 0.007 },
            { "Ю", 0.006 },{ "Ш", 0.006 },
            { "Ц", 0.004 },{ "Щ", 0.003 },
            { "Э", 0.003 },{ "Ф", 0.003 }
        };
        public static Dictionary<string, double> alphaBetENG = new Dictionary<string, double> {
            { " ", 0.2 }, { "E", 0.105 }, 
            { "T", 0.072 }, { "O", 0.065 },
            { "A", 0.063 }, { "N", 0.058 },
            { "I", 0.055 }, { "R", 0.052 }, 
            { "S", 0.052 }, { "H", 0.047 },
            { "D", 0.035 }, { "L", 0.028 },
            { "C", 0.023 }, { "F", 0.023 },
            { "U", 0.023 }, { "M", 0.021 },
            { "P", 0.018 }, { "Y", 0.012 },
            { "W", 0.012 }, { "G", 0.011 },
            { "B", 0.01 }, { "V", 0.008 },
            { "K", 0.003 }, { "X", 0.001 },
            { "J", 0.001 }, { "Q", 0.001 }, { "Z", 0.001 }};
        public static Dictionary<string, double> FourExp = new Dictionary<string, double> {
            { "i", 0.055 }, { "w", 0.012 },
            { "a", 0.063 }, { "n", 0.058 },
            { "d", 0.035 }, { "e", 0.105 },
            { "k", 0.003 }, { "l", 0.028 }
        };
        public static Dictionary<string, double> FiveExpA = new Dictionary<string, double> {
            { "a", 0.6 }, { "b", 0.3 },
            { "c", 0.08 }, { "d", 0.02 }
        };
        public static Dictionary<string, double> FiveExpB = new Dictionary<string, double> {
            { "aa", 0.36 }, { "ab", 0.18 }, { "ac", 0.048 }, { "ad", 0.012 },
            { "ba", 0.18 }, { "bb", 0.09 }, { "bc", 0.024 }, { "bd", 0.006 },
            { "cc", 0.0064 }, { "ca", 0.048 }, { "cb", 0.024 }, { "cd", 0.0016 },
            { "dd", 0.0004 }, { "da", 0.012 }, { "db", 0.006 }, { "dc", 0.0016 },
        };

        public static Dictionary<string, double> FiveExpC = new Dictionary<string, double> {
            { "aaa", 0.000512 }, { "aab", 0.000128 },
            { "aba", 0.000128 }, { "abb", 0.000032 },
            { "baa", 0.000128 }, { "bab", 0.000032 },
            { "bba", 0.000032 }, { "bbb", 0.000008 }
        };
        public static Dictionary<string, double> Seven = new Dictionary<string, double> {
            { "A", 0.2 }, { "B", 0.2 },
            { "C", 0.19 }, { "D", 0.18 },
            { "E", 0.012 }, { "F", 0.011 }
        };

        public static Dictionary<string, string> ReadyDict = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Задание № 1"); GetInformation(FirstEXP);
            Console.WriteLine("Задание № 2"); GetInformation(alphaBetRUS);
            Console.WriteLine("Задание № 3"); GetInformation(alphaBetENG);
            Console.WriteLine("Задание № 4"); GetInformation(FourExp);
            Console.WriteLine("Задание № 5.а"); GetInformation(FiveExpA);
            Console.WriteLine("Задание № 5.б"); GetInformation(FiveExpB);
            Console.WriteLine("Задание № 5.в"); GetInformation(FiveExpC);
            Console.WriteLine("Задание № 2"); GetInformation(Seven);


        }
        static void GetInformation(Dictionary<string, double> alphabet)
        {
            ReadyDict.Clear();
            DividesFunctions(alphabet);
            double k = findK(alphabet);
            Console.WriteLine($"Ср. длина: {k}");
            Console.WriteLine($"Энтропия: {FindShanon(alphabet)}");
            Console.WriteLine($"Избыточность кода: {(k / FindShanon(alphabet)) - 1}");
        }
        static void DividesFunctions(Dictionary<string, double> alphabet)
        {
            int ItsMiddle = FindMid(alphabet);
            Dictionary<string, double> Up = alphabet.OrderBy(pair => pair.Key).Take(ItsMiddle).ToDictionary(pair => pair.Key, pair => pair.Value);
            Dictionary<string, double> Down = alphabet.OrderBy(pair => pair.Key).Skip(ItsMiddle).Take(alphabet.Count).ToDictionary(pair => pair.Key, pair => pair.Value);
            CreateCode(Up, "0");
            CreateCode(Down, "1");
            if (Up.Count > 1) DividesFunctions(Up);
            if (Down.Count > 1) DividesFunctions(Down);
        }
        static void CreateCode(Dictionary<string, double> ForCode, string bit)
        {
            foreach (KeyValuePair<string, double> pair in ForCode)
            {
                if (ReadyDict.ContainsKey(pair.Key))
                    ReadyDict[pair.Key] += bit;
                else
                    ReadyDict.Add(pair.Key, bit);
            }
        }
        static double findK(Dictionary<string, double> pi)
        {
            double K = 0;
            foreach (KeyValuePair<string, string> pairs in ReadyDict.OrderBy(x => x.Value.Length))
            {
                Console.WriteLine($" {pairs.Key} - {pi[pairs.Key]} - {pairs.Value}");
                K += pairs.Key.Length * pi[pairs.Key];
            }
            return Math.Round(K, 3);
        }
        static double FindShanon(Dictionary<string, double> dict)
        {
            double temp = 0;
            foreach (KeyValuePair<string, double> kvp in dict)
            {
                temp += kvp.Value * Math.Log(1 / kvp.Value, 2);
            }
            return Math.Round(temp, 3);
        }
        static int FindMid(Dictionary<string, double> alphabet)
        {

            double minimum = 1;
            int counter = 0;
            double firstPart = 0;
            double SecondPart;
            int ItsMiddle = 1;
            for (int i = 0; i < counter + 1; i++)
            {
                firstPart += alphabet.ElementAt(i).Value;
                SecondPart = 0;
                for (int j = counter + 1; j < alphabet.Count; j++)
                {
                    SecondPart += alphabet.ElementAt(j).Value;

                }
                double MaybeMin = firstPart - SecondPart;
                if (MaybeMin <= minimum && MaybeMin > 0)
                {
                    minimum = MaybeMin;
                    ItsMiddle = counter + 1;

                }
                counter++;
                if (counter == alphabet.Count - 1)
                    break;
            }
            return ItsMiddle;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_8
{
    class Program
    {

        public static int[,] a = {
            { 1, 1, 1, 0, 1, 0, 1},
            { 0, 1, 0, 1, 0, 0, 0},
            { 1, 0, 1, 1, 1, 1, 0},
            { 1, 1, 0, 0, 1, 1, 0},
            { 0, 1, 1, 1, 1, 0, 1}

        };
        public static int[,] b = {
            { 0, 0, 1, 0, 0, 0, 0},
            { 0, 0, 0, 1, 1, 0, 0},
            { 1, 1, 1, 1, 0, 1, 0},
            { 1, 0, 1, 0, 1, 0, 1},
            { 0, 0, 0, 0, 0, 1, 1}

        };
        public static int[,] c = {
            { 1, 1, 1, 1, 1, 1},
            { 0, 0, 0, 0, 0, 0},
            { 1, 1, 1, 0, 0, 0},
            { 1, 1, 0, 0, 1, 1},
            { 1, 0, 1, 0, 1, 0}

        };
        public static int[,] d = {
            { 0, 0, 0, 1, 1, 0, 1},
            { 1, 1, 0, 1, 0, 1, 0},
            { 0, 0, 0, 1, 1, 1, 1},
            { 1, 0, 1, 0, 1, 0, 1},
            { 0, 1, 0, 1, 0, 0, 1}

        };
        public static int[,] e = {
            { 1, 0, 0, 0, 1, 1, 1},
            { 0, 1, 1, 0, 1, 0, 1},
            { 1, 0, 0, 0, 0, 0, 0},
            { 1, 1, 1, 0, 1, 0, 1},
            { 1, 0, 0, 0, 0, 0, 1}

        };
        public static int[,] f = {
            { 1, 0, 1, 0, 1, 0, 1},
            { 1, 1, 0, 1, 0, 0, 0},
            { 1, 0, 1, 1, 1, 1, 0},
            { 1, 1, 0, 0, 1, 1, 0},
            { 0, 1, 1, 1, 1, 0, 1}

        };
        public static int[,] g = {
            { 1, 1, 1, 0, 0, 0},
            { 1, 0, 1, 0, 1, 0},
            { 0, 1, 0, 0, 1, 0},
            { 1, 0, 0, 1, 0, 1}

        }; public static int[,] h = {
            { 1, 1, 1, 0, 0, 0},
            { 1, 0, 1, 0, 1, 0},
            { 0, 1, 1, 0, 1, 0},
            { 1, 0, 0, 1, 0, 1}

        };

        public static string secondCipher = "";
        static string ConvertBoolToString(bool[] input)
        {
            string output = String.Empty;
            for (int i = 0; i < input.Count(); i++)
            {
                if (input[i] == true)
                    output += "1";
                else
                    output += "0";
            }
            return output;
        }
        static List<int> CheckAllString(int[,] matrix, int[] vertical, int[] horizontal)
        {
            List<int> checksHorError = new List<int>();
            for (int i = 0; i < vertical.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < horizontal.Length; j++)
                {
                    if (matrix[i, j] == 1)
                        count++;
                }
                if (count % 2 == 0 && vertical[i] != 0 || count % 2 != 0 && vertical[i] == 0)
                {
                    checksHorError.Add(i);
                }
            }
            return checksHorError;
        }
        static List<int> CheckAllVert(int[,] matrix, int[] vertical, int[] horizontal)
        {
            List<int> checksHorError = new List<int>();

            for (int i = 0; i < horizontal.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < vertical.Length; j++)
                {
                    if (matrix[j, i] == 1)
                        count++;
                }
                if (count % 2 == 0 && horizontal[i] != 0 || count % 2 != 0 && horizontal[i] == 0)
                {
                    checksHorError.Add(i);
                }
            }
            return checksHorError;
        }
        static void FirstExp(int[,] matrix, int[] vertical, int[] horizontal)
        {
            List<int> checksHorError = CheckAllString(matrix, vertical, horizontal);
            List<int> checkVertError = CheckAllVert(matrix, vertical, horizontal);
            if (checksHorError.Count == 0 && checkVertError.Count == 0)
                Console.WriteLine("Ошибки нет");
            else if (checksHorError.Count == 0 && checkVertError.Count != 0)
            {
                for (int i = 0; i < checkVertError.Count; i++)
                {
                    Console.WriteLine($"Ошибка в столбце {checkVertError[i] + 1} или ошибка в контрольном элементе");

                }
            }
            else if (checksHorError.Count != 0 && checkVertError.Count == 0)
            {
                for (int i = 0; i < checksHorError.Count; i++)
                {
                    Console.WriteLine($"Ошибка в строке {checksHorError[i] + 1} или ошибка в контрольном элементе");
                }
            }
            else
            {
                for (int i = 0; i < checksHorError.Count; i++)
                {
                    Console.Write($"Ошибка элемента №{checkVertError[i] + 1} в строке {checksHorError[i] + 1}: ");
                    if (matrix[checksHorError[i], checkVertError[i]] == 1)
                        Console.WriteLine(" исправьте на 0");
                    else
                        Console.WriteLine(" исправьте на 1");

                }
            }
        }
     
        static string BitArrayToStr(BitArray ba)
        {
            
            byte[] bytes = new byte[ba.Length/8];
            ba.CopyTo(bytes, 0);
            return Encoding.UTF8.GetString(bytes);
        }
        static string firstMethod(BitArray input)
        {
            bool[] _input = new bool[input.Length];
            bool[] output = new bool[input.Length + (input.Length / 8)];
            input.CopyTo(_input, 0);
            int startIndex = 0;
            for (int i = 0; i < input.Length - 1; i+=8)
            {
                List<bool> temp = _input.Skip(i).Take(i + 8).ToList();
                int count = 0;
                for (int j = 0; j < temp.Count; j++)
                {
                    if (temp[j] == true)
                        count++;

                }
                if (count % 2 == 0)
                    temp.Add(false);
                else
                    temp.Add(true);
                temp.CopyTo(output, startIndex);
                startIndex += 9;
            }
            
            return ConvertBoolToString(output);
        }
        static string SecondMethod(BitArray input, bool reverse)
        {
            string output = String.Empty;
            if (!reverse)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == true)
                        output += "10";
                    else
                        output += "01";
                }
                secondCipher = output;
                return output;
            }
            else
            {
                bool[] n = new bool[secondCipher.Length/2];
                for (int i = 0, j = 0; i < secondCipher.Length -1 ; i+=2,j++)
                {
                    n[j] = Convert.ToBoolean(Convert.ToInt32(secondCipher[i].ToString()));
                    output += secondCipher[i];
                }
                BitArray outP = new BitArray(n);

                return output + "=>" + BitArrayToStr(outP);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание №1");
            Console.WriteLine("а"); FirstExp(a, new int[] { 0, 0, 1, 0, 1 }, new int[] { 1, 1, 1, 1, 0, 0, 0 });
            Console.WriteLine("б"); FirstExp(b, new int[] { 1, 0, 1, 0, 0 }, new int[] { 0, 1, 1, 1, 0, 0, 0 });
            Console.WriteLine("в"); FirstExp(c, new int[] { 0, 0, 1, 1, 1 }, new int[] { 0, 1, 0, 1, 1, 0 });
            Console.WriteLine("г"); FirstExp(d, new int[] { 1, 0, 0, 0, 0 }, new int[] { 0, 0, 1, 0, 1, 0, 1 });
            Console.WriteLine("д"); FirstExp(e, new int[] { 0, 0, 1, 0, 0 }, new int[] { 0, 1, 0, 0, 1, 1, 0 });
            Console.WriteLine("е"); FirstExp(f, new int[] { 0, 0, 1, 0, 1 }, new int[] { 1, 1, 1, 1, 0, 0, 0 });
            Console.WriteLine("ж"); FirstExp(g, new int[] { 1, 0, 0, 1 }, new int[] { 1, 0, 1, 1, 0, 1 });
            Console.WriteLine("и"); FirstExp(h, new int[] { 1, 1, 0, 1 }, new int[] { 1, 0, 0, 1, 0, 1 });
            Console.WriteLine("Введите сообшение");
            string message = Console.ReadLine();
            BitArray bitMessage = new BitArray(Encoding.UTF8.GetBytes(message));
            Console.WriteLine($"Задание №2 Метод четности-нечетности: {firstMethod(bitMessage)} ");
            Console.WriteLine("Задание №1 Метод кодирования сдвоенными элементами(Шифрование)");
            Console.WriteLine(SecondMethod(bitMessage, false));
            Console.WriteLine("Задание №2 Метод кодирования сдвоенными элементами(Дешифрование)");
            Console.WriteLine(SecondMethod(bitMessage, true));
            Console.ReadLine();
        }
    }
}

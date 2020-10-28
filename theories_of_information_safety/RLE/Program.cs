using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLE
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = String.Empty;
            Console.WriteLine("Задание №1");
            message = "SSSSOOOEEERROOOAAYYYYYDDDDOEUUUUUWWWWJJJORRUUUUUUUUUUXXXKHHHHHHMMMMMMGGGLLLLLLLJJJJ";
            string compress = RLComp(message);
            Console.WriteLine("Сжатие: \n" + compress);
            compress = RLUcomp(compress);
            Console.WriteLine("Обратное: \n" +compress);
            Console.WriteLine("Задание №2");
            
            message = "небесанебонебесныйтихоходнебесносинийпароход";
            int g = message.Length;
            compress = RLComp(message);
            compress = compress.Replace("(", "").Replace(")", "");
            g = compress.Length;
            Console.WriteLine("Сжатие: \n" + compress);
            compress = RLUcomp(compress);
            Console.WriteLine("Обратное: \n" + compress);
            Console.WriteLine("Задание №3");
            message = "Алло это 4565555544488";
            Console.WriteLine("Сообщение:" + message);
            message = GetBinarystring(message);
            compress = RLComp(message);
            Console.WriteLine("Сжатие: \n" + compress);
            compress = RLUcomp(compress);
            Console.WriteLine("Обратное: \n" + compress);
            Console.WriteLine("Переводим в строку: " + GetString(compress));
            Console.ReadKey();
        }
        public static string GetBinarystring(string input)
        {
            Encoding encoding = Encoding.GetEncoding("Windows-1251");
            byte[] g = encoding.GetBytes(input);
            BitArray getbit = new BitArray(g);
            bool[] u = new bool[getbit.Length];
            getbit.CopyTo(u, 0);
            return ConvertBoolToString(u);
        }
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
            Console.WriteLine("Двоичный формат сообщения: " + output);
            return output;
        }
        static string GetString(string input)
        {
            Encoding encoding = Encoding.GetEncoding("Windows-1251");
            bool[] n = input.Select(c => c == '1').ToArray();
            BitArray bits = new BitArray(n);
            byte[] g = new byte[n.Length / 8];
            bits.CopyTo(g, 0);
            return encoding.GetString(g);
        }
        static string RLComp(string uncompressed)
        {
            int c_count = 0;
            uncompressed.ToCharArray();
            int n = uncompressed.Length;
            char prev = uncompressed[0];
            StringBuilder ret_string = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                c_count = 1;
                while (i < n - 1 && uncompressed[i] == uncompressed[i + 1])
                {
                    c_count++;
                    i++;
                }
                ret_string.Append($"({c_count}){uncompressed[i]}");
            }
            return ret_string.ToString();
        }

        static string RLUcomp(string compressed)
        {
            int c_count =0;
            compressed.ToCharArray();
            StringBuilder ret_string = new StringBuilder();
            for (int i = 0; i < compressed.Length; i++)
            {
                string temp = "";
                if (compressed[i].ToString() == "(")
                {
                    for (int j = i; j < compressed.Length; j++)
                    {
                        if (compressed[j].ToString() == ")")
                        {
                            i += (j-i);
                            break;
                        }   
                        if(compressed[j].ToString() != "(") temp +=compressed[j];
                    }
                    c_count += Convert.ToInt32(temp);
                }
                else
                {
                    for (int j = 0; j < (Convert.ToInt32(c_count)); j++)
                    {
                        ret_string.Append(compressed[i]);

                    }
                    c_count = 0;
                }
            }
            return ret_string.ToString();
        }
    }
}

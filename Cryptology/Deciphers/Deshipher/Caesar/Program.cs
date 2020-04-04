using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar
{
    class Program
    {
        static void Main(string[] args)
        {

            string alfaBet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ_";
            string shipher = "ЭВНФ";
            byte[] bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(shipher));
            shipher = Encoding.UTF8.GetString(bytes);
            string decode = "";
            int j = 1;
            int k = 0;
            while (j < 33)
            {
                decode = "";
                for (int i = 0; i < shipher.Length; i++)
                {
                    //(shipher[i] == ',') decode += ',';
                    decode += alfaBet[(shipher[i] - k) % 32];
                }
                Console.WriteLine((32- alfaBet.IndexOf(decode[1]))-33 + " ");
                Console.WriteLine(decode);
                j++; k++;
            }
        }
    }
}

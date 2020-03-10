using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vernam
{
    class Program
    {
        static void Main(string[] args)
        {
            VernamChypher("18 1 2 5 7", "ЯДБЛГЙРРЕЧНУВЖЙВД");

        }
        

        static void VernamChypher(string gamma, string chyphergramm)
        {
            Encoding encoding = Encoding.GetEncoding("Windows-1251");
            List<int> g = new List<int>(gamma.Split(' ').Select(Int32.Parse).ToArray());
            byte[] chypherByte = encoding.GetBytes(chyphergramm);
            for (int j = 0; j < (chyphergramm.Length); j++)
            {
                g.Add(g[j]);
                if (g.Count == chyphergramm.Length) break;

            }
            byte[] decimicalCode = new byte[chyphergramm.Length];
            for (int i = 0; i < (chyphergramm.Length); i++)
            {
                decimicalCode[i] = Convert.ToByte(g[i]);
            }
            BitArray ba1 = new BitArray(decimicalCode);
            BitArray ba2 = new BitArray(chypherByte);
            BitArray ba3 = ba1.Xor(ba2);
            byte[] byteArr = ConvertToByte(ba3);
            string str = encoding.GetString(byteArr, 0, byteArr.Length);
            Console.WriteLine(str);
        }
        static byte[] ConvertToByte(BitArray ba3)
        {
            var bytes = new byte[ba3.Length / 8];
            ba3.CopyTo(bytes, 0);
            return bytes;
        }
    }
   
}

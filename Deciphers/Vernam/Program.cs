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
            string message = "КАНДАКОВА АНАСТАСИЯ НИКОЛАЕВНА";
            string key = "18 1 2 5 7";
            string res = VernamChypher(key , message); //Шифруем
            Console.WriteLine(res);
            res = VernamChypher(key, res); // дешифруем для проверки
            Console.WriteLine(res);

        }


        static string VernamChypher(string gamma, string chyphergramm)
        {
            Encoding encoding = Encoding.GetEncoding("Windows-1251");
            List<int> g = new List<int>(gamma.Split(' ').Select(Int32.Parse).ToArray());//получаем список из гаммы
            byte[] chypherByte = encoding.GetBytes(chyphergramm);
            for (int j = 0; j < (chyphergramm.Length); j++) //длина гаммы должна совпадать с длинной полученного сообщения, по этому добавляем элементы 
            {
                g.Add(g[j]);
                if (g.Count == chyphergramm.Length) break;

            }
            byte[] decimicalCode = new byte[chyphergramm.Length];
            for (int i = 0; i < (chyphergramm.Length); i++)// каждый символ сообщения переводим в hex для оператора Xor это неоходиммо
            {
                decimicalCode[i] = Convert.ToByte(g[i]);
            }
            BitArray ba1 = new BitArray(decimicalCode);// здесь получаем двоичный код для соообщения
            BitArray ba2 = new BitArray(chypherByte);//     и для гаммы
            BitArray ba3 = ba1.Xor(ba2);// гаммирование
            byte[] byteArr = ConvertToByte(ba3);
            string str = encoding.GetString(byteArr, 0, byteArr.Length);// конвертируем и получаем обратно уже шифрованную строку
            return str;
        }
        //Функциия перевода из 2-ого в hex
        static byte[] ConvertToByte(BitArray ba3)
        {
            var bytes = new byte[ba3.Length / 8];
            ba3.CopyTo(bytes, 0);
            return bytes;
        }
    }
   
}

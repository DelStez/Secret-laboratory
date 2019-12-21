using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vernam
{
    //public class XORCipher
    //{
    //    //генератор повторений пароля
    //    private string GetRepeatKey(string s, int n)
    //    {
    //        var r = s;
    //        while (r.Length < n)
    //        {
    //            r += " " + r;
    //        }

    //        //foreach()
    //        return r.Substring(0, n);
    //    }

    //    //метод шифрования/дешифровки
    //    private string Cipher(string text, string secretKey)
    //    {
    //        var currentKey = GetRepeatKey(secretKey, text.Length);
    //        var res = string.Empty;
    //        for (var i = 0; i < text.Length; i++)
    //        {
    //            byte[] q = BitConverter.GetBytes(text[i]);
    //            byte[] h = Encoding.ASCII.GetBytes(currentKey.Split(' ')[i]);
    //            for(var j = 0; j < q[i];j++)
    //                res += ((char)(q[j] ^ h[j]));
    //        }

    //        return res;
    //    }

    //    //шифрование текста
    //    //public string Encrypt(string plainText, string password)
    //    //    => Cipher(plainText, password);

    //    //расшифровка текста
    //    public string Decrypt(string encryptedText, string password)
    //        => Cipher(encryptedText, password);
    //}

    class Program
    {
        static byte[] ConvertToByte(BitArray ba3)
        {
            var bytes = new byte[(ba3.Length - 1)/ 8 + 1];
            ba3.CopyTo(bytes, 0);
            return bytes;
        }

        static void VernamChypher(string gamma, string chyphergramm)
        {
            Encoding encoding = Encoding.GetEncoding("Windows-1251");
            gamma = gamma.Replace(" ", "");
                for (int j = 0; j < (chyphergramm.Length); j++)
                {
                    gamma +=  gamma[j];
                    if (gamma.Length == chyphergramm.Length) break;
                    
                }
            int g = gamma.Length;
            byte[] gammByte = encoding.GetBytes(gamma);
            byte[] chypherByte = encoding.GetBytes(chyphergramm);
           
            BitArray ba1 = new BitArray(gammByte);
            BitArray ba2 = new BitArray(chypherByte);
            BitArray ba3 = ba1.Xor(ba2);
            byte[] byteArr = ConvertToByte(ba3);
            string str = encoding.GetString(byteArr, 0, byteArr.Length);
            Console.WriteLine(str);
        }
        static void Main(string[] args)
        {
            VernamChypher("18 1 2 5 7", "ЯДБЛГЙРРЕЧНУВЖЙВД");

            //var x = new XORCipher();
            //Console.Write("Введите текст сообщения: ");
            //var message = Console.ReadLine();
            //Console.Write("Введите пароль: ");
            //var pass = Console.ReadLine();
            ////foreach(var n in pass.Split)
            ////byte[] q = Encoding.ASCII.GetBytes(message);
            ////var encryptedMessageByPass = x.Encrypt(message, pass);
            ////Console.WriteLine("Зашифрованное сообщение {0}", encryptedMessageByPass);
            //Console.WriteLine("Расшифрованное сообщение {0}", x.Decrypt(message, pass));
            //Console.ReadLine();
            
        }
    }
   
}

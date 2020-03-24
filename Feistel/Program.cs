using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feistel
{
    class Program
    {
        public static bool Mode; // булевая функция отвечающая за шифрование(true) и дешифрование 
        public static int CountR;
        public static byte[] temp = new byte[2];
        public static byte[] key = { 183, 222, 126, 50, 205, 133, 46,  50 };
        public static byte[] CipherMode(byte[] message, byte[] key)
        {
            byte[] result = new byte[message.Length];
            for (int i = 0; i < message.Length - 1; i++)
            {
                temp[0] = message[i];
                temp[1] = message[i + 1];
                Feistel();
                result[i] = temp[0];
                result[i + 1] = temp[1];
            }
            return result;
        }
        public static void Feistel()
        {
            int roundLevel = 0;
            byte Left = temp[0];
            byte Right = temp[1];
            for (int i = 0; i < CountR; i++, roundLevel++)
            {
                if (i < CountR - 1)
                {
                    byte temp1 = Left;
                    Left = Convert.ToByte(Right^(F(Left, key[roundLevel])));
                    Right = temp1;
                }      
            }
            temp[0] = Left;
            temp[1] = Right;

        }
        private static int F(byte A, int B)
        {
            int result = ((Convert.ToInt32(A) + B) % (2*temp.Length));

            return result;
        }
        static void Main(string[] args)
        {
            string message = "КАНДАКОВА АНАСТАСИЯ НИКОЛАЕВНА";
            Random r = new Random();
            CountR = key.Length-1;
            //r.NextBytes(key);
            if (message.Length % 2 != 0) message += " ";
            byte[] messageInByte = Encoding.UTF8.GetBytes(message);
            byte[] outputCipher = CipherMode(messageInByte, key);// Encrypt
            Console.WriteLine(Encoding.UTF8.GetString(outputCipher, 0, outputCipher.Length));
            outputCipher = CipherMode(outputCipher, key);// decrypt
            Console.WriteLine(Encoding.UTF8.GetString(outputCipher, 0, outputCipher.Length));
            Console.ReadLine();

        }
    }
}

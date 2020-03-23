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
        static byte ConvertToByte(BitArray ba3)
        {
            var bytes = new byte[ba3.Length / 8];
            ba3.CopyTo(bytes, 0);
            return bytes[0];
        }
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
            int roundLevel = Mode ? CountR : 1;
            BitArray Left = new BitArray(temp[0]);
            BitArray Right = new BitArray(temp[1]);
            for (int i = 0; i < CountR; )
            {
                if (i < CountR - 1)
                {
                    BitArray temp1 = Left;
                    Left = Right.Xor(F(Left, roundLevel));
                    Right = temp1;
                }
                else
                    Right = Right.Xor(F(Left, roundLevel));
            }
            temp[0] = ConvertToByte(Left);
            temp[1] = ConvertToByte(Right);

        }
        private static BitArray F(BitArray A, int B)
        {
            byte newA = ConvertToByte(A);
            return new BitArray((Convert.ToInt32(newA)+B) % 256);
        }
        static void Main(string[] args)
        {
            string message = "КАНДАКОВА АНАСТАСИЯ НИКОЛАЕВНА";
            Random r = new Random();
            byte[] key = new byte[16];
            CountR = key.Length;
            r.NextBytes(key);
            if (message.Length % 2 != 0) message += " ";
            byte[] messageInByte = Encoding.UTF8.GetBytes(message);
            Mode = true;
            byte[] outputCipher = CipherMode(messageInByte, key);// Encrypt

        }
    }
}

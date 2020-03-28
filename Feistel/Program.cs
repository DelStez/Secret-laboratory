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
        
        public static byte[] CipherMode(byte[] message, byte[] key)
        {
            byte[] output = new byte[message.Length];
            byte[] temp = new byte[2];//для хранения двух субблоков
            for (int i = 0; i < message.Length; i+=2)
            {
                temp[0] = message[i]; temp[1] = message[i+1];
                temp = Feistel(temp, key);
                output[i] = temp[0]; output[i+1] = temp[1];
            }
            return output;
        }
        public static byte[] Feistel(byte[] data, byte[] key)
        {
            int countRound = key.Length - 1;
            int keyIndexRound = 0;
            byte Left = data[0], Right = data[1];
            for (int i = 0; i < countRound; i++)
            {
                if (i < countRound - 1)
                {
                    byte temp = Left;
                    Left = Convert.ToByte(Right ^ F(Left, key[keyIndexRound]));
                    Right = temp;

                }
                else
                {

                    Right = Convert.ToByte(Right ^ F(Left, key[keyIndexRound]));

                }
                keyIndexRound++;
            }
            data[0] = Left;
            data[1] = Right;
            return data;
        }
        private static byte F(byte A, byte B)
        {
            BitArray Abit = new BitArray(new byte[] { A });
            BitArray Bbit = new BitArray(new byte[] { B });
            byte result = ConvertToByte(Abit.Xor(Bbit));
            return result;
        }
        static void Main(string[] args)
        {
            string message = "FUCK ";
            byte[] messageInByte;
            byte[] key = new byte[8];
            Random random = new Random();
            random.NextBytes(key);
            if (Encoding.UTF8.GetBytes(message).Length % 2 != 0)
                message += " ";
            messageInByte = Encoding.UTF8.GetBytes(message);
            byte[] getOutputMessage = CipherMode(messageInByte, key);
            Console.WriteLine(Encoding.UTF8.GetString(getOutputMessage));
            getOutputMessage = CipherMode(getOutputMessage, key);
            Console.WriteLine(Encoding.UTF8.GetString(getOutputMessage));

        }
        private static byte ConvertToByte(BitArray fuckingBits)
        {
            byte[] _byte = new byte[1];
            fuckingBits.CopyTo(_byte, 0);
            return _byte[0];
        }
    }
}

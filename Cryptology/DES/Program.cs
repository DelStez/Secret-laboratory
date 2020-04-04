using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    class Program
    {
        public static MatrixDES mDES = new MatrixDES();
        GeneratorKey key = new GeneratorKey();

        private static byte ConvertToByte(BitArray fuckingBits)//функция перевода бит в байт
        {
            byte[] _byte = new byte[1];
            fuckingBits.CopyTo(_byte, 0);
            return _byte[0];
        }
        static void ExpansionFunction()
        {

        }
        // Maybe it can be used
       
        static byte[] GetBitArray(byte[] message, byte[] key, bool reverse)
        {
            byte[] output = new byte[message.Length];
            byte[] temp = new byte[8];
            for(int i = 0; i < message.Length; i+=8)
            {
                temp = DES_Encryption(message.Skip(i).Take(8).ToArray(), key);
                temp.CopyTo(output, i);
            }
            return output;
        }
        static byte[] DES_Encryption(byte[] data, byte[] key)
        {
            byte[] output = new byte[data.Length];
            BitArray bitBlock = new BitArray(data);
            bitBlock = mDES.FirstPermutation(bitBlock);
            //First permutation
            
            for (int i = 0; i < 16; i++)//Rounds is here
            {
                // feistel's function with adding a generator of key
               // using sixteen S-box
            }
            //Last permutation
            return output;
        }
        static void Main(string[] args)
        {
            string message = "FUCK";
            Random random = new Random();
            byte[] key = new byte[7];
            random.NextBytes(key);
            while (Encoding.UTF8.GetBytes(message).Length % 8 != 0)
            {
                message += " ";
            }
            byte[] byteMessage = Encoding.UTF8.GetBytes(message);
            byte[] getCipher = GetBitArray(byteMessage, key, false);
        }
    }
}

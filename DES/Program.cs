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
        public int[] IPblock = { };
        static void ExpansionFunction()
        {

        }
        // Maybe it can be used
        static void generatorKey()
        {
        }
        static byte[] GetBitArray(byte[] message, byte[] key, bool reverse)
        {
            byte[] output = new byte[message.Length];
            BitArray bitmessage = new BitArray(message);
            for(int i = 0; i < bitmessage.Count; i+=64)
            {

            }
            return output;
        }
        static void DES_Encryption()
        {
            //First permutation
            for (int i = 0; i < 16; i++)//Rounds is here
            {
                // feistel's function with adding a generator of key
               // using sixteen S-box
            }
            //Last permutation
        }
        static void Main(string[] args)
        {
            string message = "FUCK";
            Random random = new Random();
            byte[] key = new byte[56];
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

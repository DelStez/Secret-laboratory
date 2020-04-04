using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucipher
{
    class Program
    {
        private static int[] PblockChanges = { 0, 8, 13, 5, 9, 1, 15, 4, 3, 12, 2, 14, 7, 6, 10, 11 };
        public static BitArray[] InputSbox = new BitArray[] {
            new BitArray(new bool[3] { false, false, false }),
            new BitArray(new bool[3] { false, false, true }),
            new BitArray(new bool[3] { false, true, false }),
            new BitArray(new bool[3] { false, true, true }),
            new BitArray(new bool[3] { true, false, false }),
            new BitArray(new bool[3] { true, false, true }),
            new BitArray(new bool[3] { true, true, false }),
            new BitArray(new bool[3] { true, true, true }),
        };
        public static BitArray[] OutputSbox = new BitArray[] {
            new BitArray(new bool[3] { false, true, true }),
            new BitArray(new bool[3] { true, true, true }),
            new BitArray(new bool[3] { false, false, false }),
            new BitArray(new bool[3] { true, true, false }),
            new BitArray(new bool[3] { false, true, false }),
            new BitArray(new bool[3] { true, false, false }),
            new BitArray(new bool[3] { true, false, true }),
            new BitArray(new bool[3] { false, false, true }),
        };
        private static bool[] Pbox(BitArray mess, int[] PblockChanges, bool reverse)
        {
            bool[] res = new bool[mess.Length];
            for (int i = 0; i < mess.Length; i++)
            {
                if (!reverse)
                {
                    res[PblockChanges[i]] = mess[i];
                }
                else
                {
                    res[i] = mess[PblockChanges[i]];
                }
            }
            return res;

        }
        private static bool Check(BitArray temp, BitArray input)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != input[i])
                    return false;
            }
            return true;
        }
        private static bool[] Sbox(BitArray mess, bool reverse)
        {
            bool[] res = new bool[mess.Length];
            res[0] = mess[0]; 
            for (int i = 1; i < mess.Length-1; i+=3)
            {
                BitArray temp = new BitArray(new bool[3] { mess[i], mess[i+1], mess[i + 2] });
                for (int j = 0; j < InputSbox.Length; j++)
                {
                    if (Check(temp, reverse? OutputSbox[j]:InputSbox[j]))
                    {
                        temp = reverse ? OutputSbox[j]: InputSbox[j];
                        break;
                    }

                }
                temp.CopyTo(res, i);
            }
            return res;
        }
        private static byte[] Encrypt(byte[] byteMessage, bool reverse)
        {
            byte[] result = new byte[byteMessage.Length];
            for (int i = 0; i < byteMessage.Length - 1; i+=2)
            {   
                BitArray mess = new BitArray(new byte[2] {byteMessage[i], byteMessage[i + 1] });
                for (int j = 0; j < 6; j++)
                {
                    mess = new BitArray(Pbox(mess, PblockChanges, reverse));
                    mess = new BitArray(Sbox(mess, reverse));
                }
                mess = new BitArray(Pbox(mess, PblockChanges, reverse));
                mess.CopyTo(result, i); 
            }
            return result;
        }
        static void Main(string[] args)
        {
            string message = "А";
            byte[] byteMessage = Encoding.UTF8.GetBytes(message);
            byte[] result  = Encrypt(byteMessage, false);
            Console.WriteLine(Encoding.UTF8.GetString(result));
            result = Encrypt(result, true);
            Console.WriteLine(Encoding.UTF8.GetString(result));

        }

    }
}

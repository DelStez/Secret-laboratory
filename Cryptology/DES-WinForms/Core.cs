using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES_WinForms
{
    public class Core : Form
    {
        public static byte[] _message;
        public static byte[] _key;
        public static Dictionary<int, int> changesBitRound;
        public static Dictionary<int, List<int[]>> changesBitRoundPositionText;
        public static Dictionary<int, List<int[]>> changesBitRoundPositionKey;

        public Core(string message, string key)
        {
            _message = Encoding.UTF8.GetBytes(message);
            _key = CorrectKey(key);
        }
        static byte[] CorrectKey(string key)
        {
            byte[] bkey = Encoding.UTF8.GetBytes(key);
            byte[] output = new byte[7];
            if (bkey.Length > 7)
                for (int i = 0; i < 7; i++)
                    output[i] = bkey[i];
            else
                Encoding.UTF8.GetBytes(key).CopyTo(output, 0);
            return output;
        }
        public static string Begin()
        {
            return Encoding.UTF8.GetString(GetBitArray());
        }
        public static byte ConvertToByte(BitArray Bits)//функция перевода бит в байт
        {
            
            byte[] _byte = new byte[1];
            Bits.CopyTo(_byte, 0);
            return _byte[0];
        }
        static BitArray GetTwentyEight(BitArray input, int start)
        {
            bool[] temp = new bool[28];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = input[i + start];
            }
            return new BitArray(temp);
        }
        
        public static byte[] getKeys(byte[] _key)
        {
            byte[] keys = new byte[16];
            BitArray _keyt = MatrixDES.permutation(new BitArray(_key), MatrixDES.PC2);
            for (int i = 0; i < 16; i++)
            {
                BitArray temp = MatrixDES.leftCircularShift(GetTwentyEight(_keyt, 0), MatrixDES.shiftBits[i]);
                BitArray temp1 = MatrixDES.leftCircularShift(GetTwentyEight(_keyt, 28), MatrixDES.shiftBits[i]);
                _keyt = new BitArray(temp1.Cast<bool>().Concat(temp1.Cast<bool>()).ToArray());

            }
            return keys;
        }
        public static byte[] GetBitArray()
        {
            byte[] output = new byte[_message.Length];
            byte[] temp = new byte[8];
            for (int i = 0; i < _message.Length; i += 8)
            {
                temp = DES_Encryption(_message.Skip(i).Take(8).ToArray(), _key);
                temp.CopyTo(output, i);
            }
            return output;
        }
        static byte[] DES_Encryption(byte[] data, byte[] _key)
        {
            byte[] output = new byte[data.Length];
            BitArray bitBlock = new BitArray(data);
            bitBlock = MatrixDES.FirstPermutation(bitBlock);
            byte[] temp = new byte[data.Length];
            byte[] roundKeys = getKeys(_key);
            bitBlock.CopyTo(temp, 0);
            for (int i = 0; i < 16; i++)//Rounds is here
            {
                // feistel's function with adding a generator of key
                if (i < 15) // если i не последний элемент 
                {
                    BitArray left = new BitArray(temp.Take(data.Length / 2).ToArray());
                    BitArray temp1 = new BitArray(temp.Skip(data.Length / 2).Take(data.Length / 2).ToArray());
                    BitArray Right = new BitArray(temp1);
                    // function
                    temp1 = MatrixDES.permutation(temp1, MatrixDES.matrixExpansion);
                    temp1 = left.Xor(new BitArray(roundKeys[i]));
                    temp1 = MatrixDES.


                }
                // using sixteen S-box
            }
            //Last permutation
            return output;
        }

    }
}

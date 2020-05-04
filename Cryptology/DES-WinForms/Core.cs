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
        public static bool Reverse;
        public static Dictionary<int, int> changesBitRound;
        public static Dictionary<int, List<int[]>> changesBitRoundPositionText;
        public static Dictionary<int, List<int[]>> changesBitRoundPositionKey;

        public Core(string message, string key, bool mode)
        {
            _message = Encoding.Default.GetBytes(CorrectMessage(message));
            _key = CorrectKey(key);
            Reverse = mode;
        }
        static string CorrectMessage(string message)
        {
            while (Encoding.Default.GetBytes(message).Length % 8 != 0)
            {
                message += " ";
            }
            return message;
        }
        static byte[] CorrectKey(string key)
        {
            byte[] bkey = Encoding.Default.GetBytes(key);
            byte[] output = new byte[8];
            if (bkey.Length > 8)
                for (int i = 0; i < 8; i++)
                    output[i] = bkey[i];
            else
            {
                while (key.Length % 8 != 0)
                    key += " ";
                bkey = Encoding.Default.GetBytes(key);
                for (int i = 0; i < 8; i++)
                    output[i] = bkey[i];
                Encoding.Default.GetBytes(key).CopyTo(output, 0);
            }
            return output;
        }
        public static string Begin()
        {
            return Encoding.Default.GetString(GetBitArray());
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
        
        public static List<BitArray> getKeys(byte[] _key)
        {
            List<BitArray> keys = new List<BitArray>();
            //Функция E - процедура получения 56 битов из 64 битов
            BitArray E = MatrixDES.permutation(new BitArray(_key), MatrixDES.PC1);
            for (int i = 0; i < 16; i++)
            {
                //Делим 56битный ключ на 2 блока C и D, каждый сдвигается влево на N битов
                BitArray C = MatrixDES.leftCircularShift(GetTwentyEight(E, 0), MatrixDES.shiftBits[i]);
                BitArray D = MatrixDES.leftCircularShift(GetTwentyEight(E, 28), MatrixDES.shiftBits[i]);
                //Объединяем 2 части и отправляем на сжимающую перестановку(из 56 битов получаем 48 бит)
                keys.Add(MatrixDES.permutation(new BitArray(C.Cast<bool>().Concat(D.Cast<bool>()).ToArray()), MatrixDES.PC2));

            }
            return keys;
        }
        public static byte[] GetBitArray()
        {
            byte[] output = new byte[_message.Length];
            byte[] temp = new byte[8];
            for (int i = 0; i < _message.Length; i += 8)
            {
                if(!Reverse)
                    temp = DES_Encryption(_message.Skip(i).Take(8).ToArray(), _key);
                else
                    temp = DES_Decryption(_message.Skip(i).Take(8).ToArray(), _key);
                temp.CopyTo(output, i);
            }
            return output;
        }
        static BitArray Function(BitArray Right,BitArray roundKey )
        {

            BitArray result = MatrixDES.permutation(Right, MatrixDES.matrixExpansion);
            result = result.Xor(roundKey);
            result = MatrixDES.Sbox(result);
            result = MatrixDES.permutation(result, MatrixDES.straightPermutation);
            return result;
        }
        static byte[] DES_Encryption(byte[] data, byte[] _key)
        {
            byte[] output = new byte[data.Length];
            BitArray bitBlock = new BitArray(data);
            //Начальная перестановка блока
            bitBlock = MatrixDES.permutation(bitBlock, MatrixDES.IPblock);
            byte[] temp = new byte[data.Length];
            //получение раундовых ключей.
            List<BitArray> roundKeys = getKeys(_key);
            bitBlock.CopyTo(temp, 0);
            for (int i = 0; i < 16; i++)//Rounds is here
            {
               BitArray left = new BitArray(temp.Take(data.Length / 2).ToArray());
               BitArray Right = new BitArray(temp.Skip(data.Length / 2).Take(data.Length / 2).ToArray());
               //Левая часть xor функция f(правая часть, ключ)
               left = left.Xor(Function(Right, roundKeys[i]));
               //Swap
               bool[] _out = new bool[64];
               Right.CopyTo(_out, 0); //правая становиться левой
               left.CopyTo(_out, 32); //левая становиться правой
               temp = new byte[8];
               new BitArray(_out).CopyTo(temp, 0);
            }
            bitBlock = MatrixDES.permutation(new BitArray(temp), MatrixDES.IPblockEnd);
            bitBlock.CopyTo(output, 0);
            return output;
        }
        static byte[] DES_Decryption(byte[] data, byte[] _key)
        {
            byte[] output = new byte[data.Length];
            BitArray bitBlock = new BitArray(data);
            //Начальная перестановка блока
            bitBlock = MatrixDES.permutation(bitBlock, MatrixDES.IPblockEnd);
            byte[] temp = new byte[data.Length];
            //получение раундовых ключей.
            List<BitArray> roundKeys = getKeys(_key);
            bitBlock.CopyTo(temp, 0);
            for (int i = 15; i >= 0 ; i--)//Rounds is here
            {
                BitArray left = new BitArray(temp.Take(data.Length / 2).ToArray());
                BitArray Right = new BitArray(temp.Skip(data.Length / 2).Take(data.Length / 2).ToArray());
                //Левая часть xor функция f(правая часть, ключ)
                left = Right.Xor(Function(left, roundKeys[i]));
                //Swap
                bool[] _out = new bool[64];
                left.CopyTo(_out, 0); //правая становиться левой
                Right.CopyTo(_out, 32); //левая становиться правой
                temp = new byte[8];
                new BitArray(_out).CopyTo(temp, 0);
            }
            bitBlock = MatrixDES.permutation(new BitArray(temp), MatrixDES.IPblock);
            bitBlock.CopyTo(output, 0);
            return output;
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES_ECB
{
    public class Core: DES
    {
        public static byte[] _message;
        public static byte[] _key;
        public static bool Reverse;
        public static bool OneBlockGrapth = true;
        public static List<BitArray> RoundHistoryChangesBasicBlock;
        public static List<int> KeyBit;
        public static List<int> BlockBit;
        public Core(string message, string key, bool mode)
        {
            _message = Encoding.Default.GetBytes(CorrectMessage(message));
            _key = CorrectKey(key, 8);
            Reverse = mode;
        }
        static string CorrectMessage(string message)
        {
            while (Encoding.Default.GetBytes(message).Length % 8 != 0)
            {
                message += "\0";
            }
            return message;
        }
        public static byte[] CorrectKey(string key, int lengthKey)
        {
            byte[] bkey = Encoding.Default.GetBytes(key);
            byte[] output = new byte[lengthKey];
            if (bkey.Length > lengthKey)
                for (int i = 0; i < lengthKey; i++)
                    output[i] = bkey[i];
            else
            {
                while (key.Length % lengthKey != 0)
                    key += "\0";
                bkey = Encoding.Default.GetBytes(key);
                for (int i = 0; i < lengthKey; i++)
                    output[i] = bkey[i];
                Encoding.Default.GetBytes(key).CopyTo(output, 0);
            }
            return output;
        }
        public static string Begin()
        {
            DES.RoundHistoryChangesBasicBlock = new List<BitArray>();
            KeyBit = new List<int>();
            BlockBit = new List<int>();
            return Encoding.Default.GetString(GetBitArray());
        }
        public static byte[] GetBitArray()
        {
            byte[] output = new byte[_message.Length];
            byte[] temp = new byte[8];
            OneBlockGrapth = true;
            for (int i = 0; i < _message.Length; i += 8)
            {
                if (!Reverse)
                    temp = DES_Encryption(_message.Skip(i).Take(8).ToArray(), _key);
                else
                    temp = DES_Decryption(_message.Skip(i).Take(8).ToArray(), _key);
                temp.CopyTo(output, i);
                OneBlockGrapth = false;
            }
            return output;
        }
        public static byte ConvertToByte(BitArray Bits)//функция перевода бит в байт
        {

            byte[] _byte = new byte[1];
            Bits.CopyTo(_byte, 0);
            return _byte[0];
        }

        public static List<BitArray> getKeys(byte[] _key)
        {
            List<BitArray> keys = new List<BitArray>();
            //Функция E - процедура получения 56 битов из 64 битов
            BitArray E = MatrixDES.permutation(new BitArray(_key), MatrixDES.PC1);
            for (int i = 0; i < 16; i++)
            {
                //Делим 56 битный ключ на 2 блока C и D, каждый сдвигается влево на N битов
                bool[] CD = new bool[E.Length];
                E.CopyTo(CD, 0);
                BitArray C = MatrixDES.CircularShift(new BitArray(CD.Take(28).ToArray()), MatrixDES.shiftBits[i]);
                BitArray D = MatrixDES.CircularShift(new BitArray(CD.Skip(28).Take(28).ToArray()), MatrixDES.shiftBits[i]);
                //Объединяем 2 части и отправляем на сжимающую перестановку(из 56 битов получаем 48 бит)
                E = new BitArray(new BitArray(C.Cast<bool>().Concat(D.Cast<bool>()).ToArray()));
                keys.Add(MatrixDES.permutation(E, MatrixDES.PC2));

            }
            return keys;
        }

        static BitArray Function(BitArray Right, BitArray roundKey)
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
            if (OneBlockGrapth) DES.RoundHistoryChangesBasicBlock.Add(bitBlock); //Для граффика
            //Начальная перестановка блока
            bitBlock = MatrixDES.permutation(bitBlock, MatrixDES.IPblock);
            byte[] temp = new byte[data.Length];
            //получение раундовых ключей.
            List<BitArray> roundKeys = getKeys(_key);
            bitBlock.CopyTo(temp, 0);
            for (int i = 0; i < 16; i++)//Rounds is here
            {
                BitArray left = new BitArray(temp.Take(data.Length / 2).ToArray());
                BitArray temp1 = new BitArray(temp.Skip(data.Length / 2).Take(data.Length / 2).ToArray());
                BitArray Right = temp1;
                //Левая часть xor функция f(правая часть, ключ)
                left = left.Xor(Function(temp1, roundKeys[i]));
                //Swap
                bool[] _out = new bool[64];
                Right.CopyTo(_out, 0);
                left.CopyTo(_out, 32);
                temp = new byte[8];
                new BitArray(_out).CopyTo(temp, 0);
                if (OneBlockGrapth) DES.RoundHistoryChangesBasicBlock.Add(new BitArray(temp));
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
            bitBlock = MatrixDES.permutation(bitBlock, MatrixDES.IPblock);
            byte[] temp = new byte[data.Length];
            //получение раундовых ключей.
            List<BitArray> roundKeys = getKeys(_key);
            bitBlock.CopyTo(temp, 0);
            for (int i = 15; i >= 0; i--)//Rounds is here
            {
                BitArray temp1 = new BitArray(temp.Take(data.Length / 2).ToArray());
                BitArray Right = new BitArray(temp.Skip(data.Length / 2).Take(data.Length / 2).ToArray());
                BitArray left = temp1;
                //Левая часть xor функция f(правая часть, ключ)
                Right = Right.Xor(Function(temp1, roundKeys[i]));
                //Swap
                bool[] _out = new bool[64];
                Right.CopyTo(_out, 0);
                left.CopyTo(_out, 32);
                temp = new byte[8];
                new BitArray(_out).CopyTo(temp, 0);
            }
            bitBlock = MatrixDES.permutation(new BitArray(temp), MatrixDES.IPblockEnd);
            bitBlock.CopyTo(output, 0);
            return output;
        }

    }
}

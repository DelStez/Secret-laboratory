using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES_WinForms
{
    public static class GOST
    {
        public static List<BitArray> differentialBitList;

        private static byte[,] sBoxes =
            {
                {4, 10, 9, 2, 13, 8, 0, 14, 6, 11, 1, 12, 7, 15, 5, 3},
                {14, 11, 4, 12, 6, 13, 15, 10, 2, 3, 8, 1, 0, 7, 5, 9},
                {5, 8, 1, 13, 10, 3, 4, 2, 14, 15, 12, 7, 6, 0, 9, 11},
                {7, 13, 10, 1, 0, 8 ,9, 15, 14, 4, 6, 12, 11, 2, 5, 3},
                {6, 12, 7, 1, 5, 15, 13, 8, 4, 10, 9, 14, 0, 3, 11, 2},
                {4, 11, 10, 0, 7, 2, 1, 13, 3, 6, 8, 5, 9, 12, 15, 14},
                {13, 11, 4, 1, 3, 15, 5, 9, 0, 10, 14, 7, 6, 8, 2, 12},
                {1, 15, 13, 0, 5, 7, 10, 4, 9, 2, 3, 14, 6, 11, 8, 12}
            };

        private static List<UInt64> StringToBlocks(string data)
        {
            List<UInt64> result = new List<UInt64>();
            byte[] temp = Encoding.Default.GetBytes(data);
            int startIndex = 0;

            while (startIndex < temp.Length)
            {
                try
                {
                    result.Add(BitConverter.ToUInt64(temp, startIndex));
                    startIndex += 8;
                }
                catch
                {
                    break;
                }
            }

            return result;
        }

        private static List<UInt32> SplitKey(string keyString)
        {
            List<UInt32> resultList = new List<UInt32>();
            byte[] temp = Core.CorrectKey(keyString, 32);
            for (int i = 0; i <= 28; i += 4)
            {
                resultList.Add(BitConverter.ToUInt32(temp, 0));
            }
            return resultList;
        }

        private static string BlockToString(UInt64 block)
        {
            byte[] temp = BitConverter.GetBytes(block);
            string result = Encoding.Default.GetString(temp);
            return result;
        }

        private static UInt32 ModPow(UInt32 a, UInt32 b)
        {
            UInt32 result = a + b;
            return result;
        }

        private static UInt32 CycleShift(UInt32 toShift, int n)
        {
            for (int i = 0; i < n; ++i)
            {
                UInt32 temp = toShift >> 31;
                toShift <<= 1;
                toShift += temp;
            }

            return toShift;
        }
        private static UInt32 F(UInt32 R, UInt32 Ki)
        {
            UInt32 s = ModPow(R, Ki);
            List<UInt32> blocksCopy = new List<UInt32>();

            for (int i = 0; i < 8; ++i)
            {

                UInt32 temp = s >> 28;
                blocksCopy.Add(temp);
                s <<= 4;
            }

            blocksCopy.Reverse();

            for (int i = 0; i < 8; ++i)
            {
                blocksCopy[i] = sBoxes[i, (int)blocksCopy[i]];
            }

            s = 0;

            for (int i = 0; i < blocksCopy.Count; ++i)
            {
                s += blocksCopy[i];
                s <<= 4;
            }

            s = CycleShift(s, 11);

            return s;
        }

        private static UInt64 EncryptBlock(UInt64 block, List<UInt32> keys)
        {
            for (int i = 0; i < 24; ++i)
            {
                block = FeistelPermute(block, keys[i % 8]);
                differentialBitList.Add(new BitArray(BitConverter.GetBytes((block << 32) + (block >> 32))));
            }

            for (int i = 7; i >= 0; --i)
            {
                block = FeistelPermute(block, keys[i]);
                differentialBitList.Add(new BitArray(BitConverter.GetBytes((block << 32) + (block >> 32))));
            }

            UInt64 result = (block << 32) + (block >> 32);

            return result;
        }

        private static UInt64 DecryptBlock(UInt64 block, List<UInt32> keys)
        {
            for (int i = 0; i < 8; ++i)
            {
                block = FeistelPermute(block, keys[i]);
            }

            for (int i = 23; i >= 0; --i)
            {
                block = FeistelPermute(block, keys[i % 8]);
            }

            UInt64 result = (block << 32) + (block >> 32);
            return result;
        }

        private static UInt64 FeistelPermute(UInt64 block, UInt32 key)
        {

            UInt32 L = (UInt32)(block >> 32);
            UInt32 R = (UInt32)(block);

            UInt32 temp = F(R, key);
            UInt32 xor = L ^ temp;

            UInt64 result = (UInt64)R;

            result <<= 32;
            result += (UInt64)xor;

            return result;
        }

        public static string Encrypt(string input, string key)
        {
            differentialBitList = new List<BitArray>();

            if (!CheckMod64(input.Length))
            {
                while (!CheckMod64(input.Length))
                {
                    input += " ";
                }
            }

            List<UInt32> partsKey = SplitKey(key);
            List<UInt64> partsData = StringToBlocks(input);
            List<UInt64> encodedData = new List<UInt64>();

            string result = "";
            //Шифруем блоки тескта
            for (int i = 0; i < partsData.Count; ++i)
            {
                encodedData.Add(EncryptBlock(partsData[i], partsKey));
                //переводим блок в строку
                result += BlockToString(encodedData[i]);
            }
            return result;
        }

        public static string Decrypt(string encryptedString, string key)
        {
            List<UInt32> keys = SplitKey(key);
            List<UInt64> blocks = StringToBlocks(encryptedString);
            List<UInt64> decrypted = new List<UInt64>();

            string result = "";

            for (int i = 0; i < blocks.Count; ++i)
            {
                decrypted.Add(DecryptBlock(blocks[i], keys));
                result += BlockToString(decrypted[i]);
            }
            return result;
        }

        private static bool CheckMod64(int length)
        {
            if ((length % 8) == 0)
                return true;
            else
                return false;
        }
    }
}
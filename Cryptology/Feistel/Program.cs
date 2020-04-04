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
            byte[] output = new byte[message.Length];// выходное сообщение 
            byte[] temp = new byte[2];//для хранения двух субблоков
            for (int i = 0; i < message.Length-1; i++)
            {
                temp[0] = message[i]; temp[1] = message[i+1];
                temp = Feistel(temp, key);
                output[i] = temp[0]; output[i+1] = temp[1];
            }
            return output;
        }
        public static byte[] Feistel(byte[] data, byte[] key) // Фейстель
        {
            int countRound = key.Length - 1;// кол-во раундов
            int keyIndexRound = 0; // индекс раундового ключа
            byte Left = data[0], Right = data[1]; // делим субблок на правую и левую часть
            for (int i = 0; i < countRound; i++)
            {
                if (i < countRound - 1) // если i не последний элемент 
                {
                    byte temp = Left;
                    Left = Convert.ToByte(Right ^ F(Left, key[keyIndexRound]));
                    Right = temp;

                }
                keyIndexRound++;
            }
            data[0] = Left;
            data[1] = Right;
            return data;
        }
        private static byte F(byte A, byte B)// функция F 
        {
            BitArray Abit = new BitArray(new byte[] { A });
            BitArray Bbit = new BitArray(new byte[] { B });
            byte result = ConvertToByte(Abit.Xor(Bbit));
            return result;
        }
        static void Main(string[] args)
        {
            string message = "КАНДАКОВА АНАСТАСИЯ НИКОЛАЕВНА";// сообщение
            byte[] messageInByte;
            byte[] key = new byte[8];
            Random random = new Random();
            random.NextBytes(key);// создаем ключ
            if (Encoding.UTF8.GetBytes(message).Length % 2 != 0)
                message += " ";
            messageInByte = Encoding.UTF8.GetBytes(message);// переводим сообщение в байты
            byte[] getOutputMessage = CipherMode(messageInByte, key); // отправляем полученные байты на обработку
            Console.WriteLine(Encoding.UTF8.GetString(getOutputMessage));// Шифротекст
            getOutputMessage = CipherMode(getOutputMessage, key);// дешифрация
            Console.WriteLine(Encoding.UTF8.GetString(getOutputMessage));// открытый текст

        }
        private static byte ConvertToByte(BitArray fuckingBits)//функция перевода бит в байт
        {
            byte[] _byte = new byte[1];
            fuckingBits.CopyTo(_byte, 0);
            return _byte[0];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_9
{
    class Program
    {
        private static string BinMsgContrBit;
        public static string ContrValues;
        private static string Message;
        private static int[] ArrayOfPow = new int[20];
        private static string StringToBinary(string message)
        {
            string BinaryMessage = "";
            byte[] MessageCode = Encoding.UTF8.GetBytes(message);
            for (int i = 0; i < MessageCode.Length; i++)
                BinaryMessage += Convert.ToString(MessageCode[i], 2).PadLeft(8, '0');
            return BinaryMessage;
        }

        private static void decoding(string BinMsgContrBit)
        {
            string nContrValues = ContrValues;
            ContrValues = "";
            string Values = CreateMatrixOfX(BinMsgContrBit);
            

            BinMsgContrBit = FindFixError(BinMsgContrBit, nContrValues, Values);

            BinToChar(BinMsgContrBit);
        }
        private static string FindFixError(string BinMsgContrBit, string ContrValues, string Values)
        {
            int ErrorBit = 0;
            bool Find = true;
            for (int i = 0; i < Values.Length; i++)
            {
                if (ContrValues[i] != Values[i])
                {
                    ErrorBit += (int)Math.Pow(2, i);
                    Find = true;
                }
            }
            if (Find)
            {
                Console.WriteLine("ошибка в: {0} бите", ErrorBit);
                if (BinMsgContrBit[ErrorBit - 1] == '1')
                    BinMsgContrBit = BinMsgContrBit.Remove(ErrorBit-1, 1).Insert(ErrorBit, "0");
                else
                    BinMsgContrBit = BinMsgContrBit.Remove(ErrorBit-1, 1).Insert(ErrorBit, "1");
            }
            return BinMsgContrBit;
        }

        private static void BinToChar(string BinMsgContrBit)
        {
            int Pow = 0;
            for (int i = 0; i < BinMsgContrBit.Length; i++)
                if (i != Math.Pow(2, Pow) - 1)
                    Message += BinMsgContrBit[i];
                else
                    Pow++;

            List<byte> ByteList = new List<byte>();

            for (int i = 0; i < Message.Length; i += 8)
            {
                ByteList.Add(Convert.ToByte(Message.Substring(i, 8), 2));
            }

            Message = Encoding.UTF8.GetString(ByteList.ToArray());
            Console.WriteLine(Message);
        }
        public static void encrypt(string BinaryMessage)
        {
            for (int i = 0; i < 20; i++)
                if (BinaryMessage.Length >= (int)Math.Pow(2, i))
                    ArrayOfPow[i] = (int)Math.Pow(2, i);

            int NumPow = 0;
            for (int i = 0; i < ArrayOfPow.Length; i++)
                if (ArrayOfPow[i] != 0)
                    NumPow++;

            BinMsgContrBit = CreateBinMsgContrBit(BinaryMessage, BinaryMessage.Length + NumPow);
            Console.WriteLine($"Код Хемминга: {BinMsgContrBit}");
            ContrValues = CreateMatrixOfX(BinMsgContrBit);
            Console.WriteLine($"Контрольные значения {ContrValues}");
        }
        private static string CreateBinMsgContrBit(string BinaryMessage, int LenghtMsg)
        {
            int NumBit = 0;
            int NumContrBit = 0;
            string BinMsgContrBit = "";
            for (int i = 1; i <= LenghtMsg; i++)
            {
                if (i == ArrayOfPow[NumContrBit])
                {
                    BinMsgContrBit += "0";
                    if (NumContrBit < ArrayOfPow.Length - 1)
                    {
                        if (ArrayOfPow[NumContrBit] != 0)
                        {
                            NumContrBit++;
                        }
                    }
                }
                else
                {
                    BinMsgContrBit += BinaryMessage[NumBit];
                    if (NumBit < BinaryMessage.Length - 1)
                    {
                        NumBit++;
                    }
                }
            }
            return BinMsgContrBit;
        }
        public static string CreateMatrixOfX(string BinMsgContrBit)
        {
            char[] LineX = new char[BinMsgContrBit.Length];
            int Pow;

            for (int i = 0; i < 20; i++)
            {
                Pow = (int)Math.Pow(2, i);
                if (BinMsgContrBit.Length > Pow)
                {
                    bool IsPow = false;
                    int CounterX = 0;
                    for (int j = Pow - 1; j < BinMsgContrBit.Length; j++)
                    {
                        if (!IsPow)
                        {
                            LineX[j] = 'X';
                            CounterX++;
                        }
                        else if (IsPow)
                        {
                            LineX[j] = ' ';
                            CounterX--;
                        }
                        else
                        {
                            CounterX = 0;
                        }
                        if (CounterX == Pow)
                            IsPow = true;
                        if (CounterX == 0)
                            IsPow = false;
                    }

                    CreateArrayOfContrBit(BinMsgContrBit, LineX);

                    for (int j = 0; j < LineX.Length; j++)
                    {
                        //Console.Write(LineX[j]);
                        LineX[j] = ' ';
                    }
                }
            }
            return ContrValues;
        }
        private static string CreateArrayOfContrBit(string BinMsgContrBit, char[] LineX)
        {
            int CounterArrayOfContrBits = 0;

            for (int i = 0; i < BinMsgContrBit.Length; i++)
            {
                if (LineX[i] == 'X')
                {
                    if (BinMsgContrBit[i] == '1')
                    {
                        CounterArrayOfContrBits++;
                    }
                }
            }
            if (CounterArrayOfContrBits % 2 == 0)
                ContrValues += "0";
            else
                ContrValues += "1";
            return ContrValues;
        }
        static void Main(string[] args)
        {
            string k1 = "1001100", k2 = "1101011";
            int d = 0;
            for (int i = 0; i < k1.Length; i++)
            {
                if (k1[i] != k2[i])
                    d++;
            }
            string BinaryMessage = "";
            Console.WriteLine($"Задание №1: Кодовое растояние между 1001100, 1101011: d = {d}");
            Console.WriteLine(" ");
            Console.WriteLine($"Задание №5.1");
            Console.Write($"а:"); BinaryMessage = "1101"; encrypt(BinaryMessage); ContrValues = "";
            Console.Write($"б:"); BinaryMessage = "0001"; encrypt(BinaryMessage); ContrValues = "";
            Console.Write($"в:"); BinaryMessage = "0111"; encrypt(BinaryMessage); ContrValues = "";
            Console.Write($"г:"); BinaryMessage = "1001"; encrypt(BinaryMessage); ContrValues = "";
            Console.Write($"д:"); BinaryMessage = "0110"; encrypt(BinaryMessage); ContrValues = "";
            Console.WriteLine(" ");
            Console.WriteLine($"Задание №5.2");
            Console.Write($"а:"); BinaryMessage = "0010101"; encrypt(BinaryMessage); ContrValues = "";
            Console.Write($"б:"); BinaryMessage = "0011110"; encrypt(BinaryMessage); ContrValues = "";
            Console.Write($"в:"); BinaryMessage = "0101010"; encrypt(BinaryMessage); ContrValues = "";
            Console.Write($"г:"); BinaryMessage = "1010100"; encrypt(BinaryMessage); ContrValues = "";
            Console.Write($"д:"); BinaryMessage = "1110000"; encrypt(BinaryMessage); ContrValues = "";
            Console.WriteLine(" ");
            Console.WriteLine($"Задание №5.3");
            Console.Write($"а:"); BinaryMessage = "1101101001110110"; encrypt(BinaryMessage); ContrValues = "";
            Console.Write($"б:"); BinaryMessage = "1011111011111100"; encrypt(BinaryMessage); ContrValues = "";
            Console.Write($"в:"); BinaryMessage = "1001100110011001"; encrypt(BinaryMessage); ContrValues = "";
            Console.WriteLine(" ");
            Console.WriteLine("Введите сообщение");
            string Message = Console.ReadLine();
            BinaryMessage = StringToBinary(Message);
            encrypt(BinaryMessage);
            Console.Write("Симулировать одиночную ошибку? Y/N: ");
            string mode = Console.ReadLine();
            if (mode == "y" || mode == "Y")
            {
                Random r = new Random();
                int i = r.Next(0, BinaryMessage.Length - 1);
                BinMsgContrBit = BinMsgContrBit.Remove(i, 1).Insert(i, BinMsgContrBit[i] == '0'? "1": "0");
            }
            Console.WriteLine("Декодирование...");
            decoding(BinMsgContrBit);
            Console.ReadLine();
        }
       
    }
}

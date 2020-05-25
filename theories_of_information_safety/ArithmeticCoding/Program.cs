using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticCoding
{
    class Program
    {

        //
        public static Dictionary<char, double> alphaBetSeven = new Dictionary<char, double> { 
            {'е', 0.3 },{'р', 0.2 },{'п', 0.1 },{'м', 0.1 }, {'я', 0.1},{'т', 0.1 },{'ь', 0.1 }};
        public static Dictionary<char, double> alphaBetNew = new Dictionary<char, double>();
        public static void CreateDictonary(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {

                int count = (message.Split(new string[] { message[i].ToString() }, StringSplitOptions.None).Count() - 1);
                KeyValuePair<char, double> keyValuePair = new KeyValuePair<char, double>(message[i], Math.Round(((double)count/message.Length), 5));
                if (!alphaBetNew.Contains(keyValuePair))
                {
                    alphaBetNew.Add(message[i], Math.Round(((double)count / message.Length), 5));
                }

            }
            var n = alphaBetNew.OrderByDescending(key => key.Value);
            alphaBetNew = new Dictionary<char, double>(n.ToDictionary(x => x.Key, x => x.Value));

        }
        public static void DoubleToLongBits(double argument, string message)
        {
            long longValue;
            longValue = BitConverter.DoubleToInt64Bits(argument);
            string str = Convert.ToString(longValue, 2);
            Console.WriteLine("Сжатое сообщение: ");
            Console.WriteLine(str);
            double sizeFirst = Math.Round((double)message.Length * 2);
            double sizeSecond = Math.Round((double)str.Length / 8);
            Console.WriteLine($"Первоначальный размер файла: {sizeFirst} байт");
            Console.WriteLine($"Размер сжатого файла: {sizeSecond} байт");
            Console.WriteLine($"Сжатие : {Math.Round((double)(100-(sizeSecond/(sizeFirst/ 100))))} %");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("_________________________________");
            ArithmeticCoder arithmeticCoder = new ArithmeticCoder();
            arithmeticCoder.defineSegments(alphaBetSeven);
            decimal n = (decimal)0.510104730725288;
            string messge = arithmeticCoder.arithmeticDecoding(n, 10);
            Console.WriteLine(messge);
            DoubleToLongBits((double)n, messge);
            Console.WriteLine("_________________________________");
            arithmeticCoder = new ArithmeticCoder();
            string message = "таинственные Огни";
            Console.WriteLine(message);
            CreateDictonary(message);
            arithmeticCoder.defineSegments(alphaBetNew);
            decimal j = arithmeticCoder.arithmeticCoding(message);
            Console.WriteLine(arithmeticCoder.arithmeticDecoding(j, message.Length));
            DoubleToLongBits((double)j, message);
            Console.ReadLine();

        }
    }
    class ArithmeticCoder
    {
        public struct Segment
        {
            public decimal left;
            public decimal right;
        }
        public static Dictionary<char, Segment > symbolSegments;
        public void defineSegments(Dictionary<char, double> input)
        {
            symbolSegments = new Dictionary<char, Segment>();
            decimal right = 1;
            foreach (KeyValuePair<char, double> valuePair in input)
            {
                char c = valuePair.Key;
                Segment segment = new Segment();
                segment.right =right;
                segment.left = right - (decimal)valuePair.Value;
                Console.WriteLine($"{c} - Интервал: [{segment.left} : {segment.right})");
                right = segment.left;
                symbolSegments.Add(c, segment);
            }

        }
        
        public decimal arithmeticCoding(string message)
        {
            decimal output;
            decimal right = 1, left = 0;
            for (int i = 0; i < message.Length; i++)
            {
                char symbol = message[i];
                decimal newRight = left + (right - left) * symbolSegments[symbol].right;
                decimal newLeft = left + (right - left) * symbolSegments[symbol].left;
                left = newLeft;
                right = newRight;
            }
            output = (left + right) / 2;
            return output;
        }
        public string arithmeticDecoding(decimal code, int n)
        {
            string output = String.Empty;
            for(int i = 0; i < n; i++)
            {    foreach(KeyValuePair<char, Segment> valuePair in symbolSegments)
                {
                    if (code >= valuePair.Value.left && code <= valuePair.Value.right)
                    {
                        output += valuePair.Key.ToString();
                        code = (code - valuePair.Value.left) / (valuePair.Value.right - valuePair.Value.left);
                        break;
                    }
                }
            }
            return output;
        }
    }
}

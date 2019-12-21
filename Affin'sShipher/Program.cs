using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affin_sShipher
{
    class Program
    {
        public static long findGreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static void Eucclid(long a, long m, ref long x, ref long y, ref long d)
        {
            long q, r, x1, x2, y1, y2;

            if (m == 0)
            {

                d = a; x = 1; y = 0;

                return;
            }

            x2 = 1; x1 = 0; y2 = 0; y1 = 1;

            while (m > 0)
            {

                q = a / m; r = a - q * m;

                x = x2 - q * x1; y = y2 - q * y1;

                a = m; m = r;

                x2 = x1; x1 = x; y2 = y1; y1 = y;

            }

            d = a; x = x2; y = y2;
            return;
        }
        public static long Inverse(long a, long m)
        {
            long d=0, x=0, y=0;
            Eucclid(a, m, ref x,ref y, ref d);
            if (d == 1) return x;
            return 0;
        }
        static void Main(string[] args)
        {
            //Dictionary<string, double> diagrammOfAlfaBet = new Dictionary<string, double> { { "о", 0.09 }, { "е", 0.072 }, { "ё", 0.072 },
            //{ "а", 0.062 }, { "и", 0.062 }, { "т", 0.053 }, { "н", 0.053 },{ "с", 0.045 }, { "р", 0.040 }, { "в", 0.038 }, { "л", 0.035 }, { "к", 0.028 }, { "м", 0.026 },
            //{ "д", 0.025 }, { "п", 0.023 }, { "У", 0.021 }, { "я", 0.018 }, { "ы", 0.016 }, { "з", 0.016 }, { "ъ", 0.014 }, { "ь", 0.014 }, { "б", 0.014 },
            //{ "г", 0.013 }, { "ч", 0.012 }, { "й", 0.010 }, { "х", 0.009 }, { "ж", 0.007 },{ "ю", 0.006 },{ "ш", 0.006 }, { "ц", 0.004 },{ "щ", 0.003 },{ "э", 0.003 },{ "ф", 0.003 }};
            //int a = 0;
            Dictionary<string, int> alfaBet = new Dictionary<string, int>();
            int n = 33;
            string shipherText = "щжбжеощжеобтгыртщфщурбюомбкчщтгыртжбжеощщрбюомбфщу";
            string alfabetStr = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            for (int a = 1; a <= 33; a++)
            {
                if (Convert.ToInt64(findGreatestCommonDivisor(a,n)) == 1)
                {
                    int a1 = (int)Inverse(a, n);
                    if (a1 > 0)
                    {
                        for (int b = 1; b <= 33; b++)
                        {
                            Console.WriteLine("Для a = {0} и  b = {1}:", a, b);
                            string Decode = "";
                            for (int i = 0; i < shipherText.Length; i++)
                            {
                                int x = alfabetStr.IndexOf(shipherText[i]);
                                int D = (a1 * (x - b)) % n;
                                if (D < 0) D += 33;
                                Decode += alfabetStr[D];
                            }
                            Console.WriteLine(Decode);
                        }
                    }
                    
                }
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class Program
    {
        public static int functionEuler(int n)
        {
            int ans = n;
            for (int i = 2; i*i <= n;   i++)
            {
                if (n % i == 0)
                {
                    while (n % i == 0) n /= i;
                    ans -= ans / i;
                }
            }
            if (n > 1) ans -= ans / n;
            return ans;
        }
        public static int findGreatestCommonDivisorEq(int a, int b, out int d, out int y)
        {
            if (b < a)
            {
                var t = a;
                a = b;
                b = t;
            }

            if (a == 0)
            {
                d = 0;
                y = 1;
                return b;
            }
           

            int gcd = findGreatestCommonDivisorEq(b % a, a, out d, out y);

            int newY = d;
            int newX = y - (b / a) * d;

            d = newX;
            y = newY;
            return gcd;
        }
        public int NOD(int a, int b, int c)
        {
            int Nod = Math.Min(a, Math.Min(a, b));
            for (; Nod > 1; Nod--)
            {
                if (a % Nod == 0 && b % Nod == 0 && c % Nod == 0)
                    break;
            }
            return Nod;
        }

        public static void GetOpenKey(int p, int q, int keyClose)
        {
            int n = p * q;
            int d, y;
            Random r = new Random();
            int e = r.Next(1, functionEuler(n));
            do {
                e = r.Next(1, functionEuler(n));
            } while(findGreatestCommonDivisor(e, p-1, q-1, out d, out y) != 1);


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Вычислить открытый ключ RSA");
            GetOpenKey(13, 3, 11);

        }
    }
}

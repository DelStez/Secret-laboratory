using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolardStrass
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
        public static long Factorial(long n)
        {
            int i = 1;
            while (i <= n)
            {
                i *= i;
                i++;
            }
            return n;
        }
        static void Main(string[] args)
        {
            long n = Convert.ToInt32(Console.ReadLine());
            long z = (long)(Math.Pow(n, 1 / 4)) + 1;
            long y = (long)Math.Pow(z, 2);
            long t = n;
            long d1 = findGreatestCommonDivisor(n, Factorial(y));

            Console.WriteLine(d1);
            Console.WriteLine(n / d1);
            
            


        }
    }
}

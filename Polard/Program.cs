using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polard
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
        static void Main(string[] args)
        {   
            int n = Convert.ToInt32(Console.ReadLine());
            var r = new Random();
            int y = 1; int i = 0; int stage = 2;
            int x = r.Next(1, n - 2);
            while (findGreatestCommonDivisor(n, Math.Abs(x - y)) == 1)
            {
                if ( i == stage)
                {
                    y = x;
                    stage *= 2;
                }
                x = (x * x + 1) % n;
                i++;
            }
            Console.WriteLine(findGreatestCommonDivisor(n, Math.Abs(x - y)));
        }
    }
}

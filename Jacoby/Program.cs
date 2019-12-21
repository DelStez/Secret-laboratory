using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacoby
{
    class Program
    {
        static void Main(string[] args)
        {
            string srt = "";
            while (srt != "exit")
            {
                int s = 0;
                Console.WriteLine("Числитель: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Нечетное число M: ");
                int m = Convert.ToInt32(Console.ReadLine());
                int l = Convert.ToInt32(findGreatestCommonDivisor(n, m));
                if (l == 1)
                {
                    s = 1;
                    if (n < 0)
                    {
                        n -= n;
                        if (m % 4 == 3) s = -s;
                    }
                    int t = 0;
                    while (n != 0)
                    {
                        while (n % 2 == 0)
                        {
                            t++;
                            n /= 2;
                        }
                        if (t % 2 != 0)
                        {
                            if (m % 8 == 3 || m % 8 == 5) s = -s;
                        }
                        if (n % 4 == 3 && m % 4 == 3) s = -s;
                        int c = n; n = m % c; m = c;

                    }
                }
                Console.WriteLine(s);
                srt = Console.ReadLine();
            }
            

        }
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
    }
}

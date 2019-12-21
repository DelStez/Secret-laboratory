using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = Convert.ToInt32(Console.ReadLine());
            long x = (long)Math.Sqrt(n)+1;
            long z;
            long l = (long)Math.Pow(x, 2) - n;
            long y = (long)Math.Sqrt(l);
            if (Math.Pow(x, 2) == n) Console.WriteLine("Делители: " + n);
            else
            {
                while (true)
                {
                    if (Math.Pow(y, 2) == l) { Console.WriteLine("Делители: {0} * {1}", x+y, x - y); break; }
                    x++;
                    l = (long)Math.Pow(x, 2) - n; y = (long)Math.Sqrt(l);
                    
                }
            }
        }
    }
}

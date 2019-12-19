using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukasTest
{
    class Program
    {
        public static List<int> factors = new List<int>();
        static void PrimeFactors(int n, List<int> factors)
        {
            if (n % 2 == 0) factors.Add(2);
            while (n % 2 == 0) n /= 2;
            for (int i = 3; i < Math.Sqrt(n); i +=2)
            {
                if(n % i == 0) factors.Add(i);
                while (n % i == 0) n /= i;
            }
            if(n>2) factors.Add(n);
        }
        public static int Power(int n, int r, int q)
        {
            int total = n;
            for (int i = 1; i < r; i++)
            {
                total = (total * n) % q;
            }
            return total;
        }
        public static string Lucas(int n)
        {
            //Base rules
            if (n == 1) return "Число \"1\" не явялется простым";
            if (n == 2) return "Число \"2\" - простое";
            if (n % 2 == 0) return "Число \""+n+"\" - простое";
            PrimeFactors(n - 1, factors);
            List<int> random = new List<int>();
            for (int i = 0; i < n-2; i++)
            {
                random.Add(i+2);
            }
            var r = new Random();
            for (int k = random.Count-1; k > 0 ; k--)
            {
                int g = r.Next(k);
                var t = random[k];
                random[k] = random[g];
                random[g] = t;

            }
            for (int j = 0; j < n-2; j++)
            {
                int a = random[j];
                if (Power(a, n - 1, n) != 1) return "Число \"" + n + "\" - составное";
                bool flag = true;
                for (int i = 0; i < factors.Count; i++)
                {
                    if (Power(a, (n - 1) / factors[i], n) == 1) 
                    {
                        flag = false;
                        break;
                    }
                }
                if(flag) return "Число \"" + n + "\" - простое";

            }
            return "Число \"" + n + "\" - вероятно составное";

        }
        public static void Main(string[] args)
        {
            string numberInput;
            Console.Write("Введите число: "); numberInput = Console.ReadLine();
            Console.WriteLine("=======Результат Теста=======");
            Console.WriteLine(Lucas(Convert.ToInt32(numberInput)));
        }
    }
}

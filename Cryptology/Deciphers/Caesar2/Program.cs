using System;

namespace Caesar2
{
    class Program
    {
        public int N;
        public int p;
        public int u = 0;
        public void findP(int q)
        {
            p = ((N + u) * q) + 1;
        }
        public void findN(int t, int q)
        {
            
            N = Convert.ToInt32(Math.Truncate((Math.Pow(2, t - 1) / q)));
        }
        static void Main(string[] args)
        {
            var pr = new Program();
            int t = Convert.ToInt32(Console.ReadLine());
            int q = Convert.ToInt32(Math.Truncate(Convert.ToDouble(t / 2)));
            pr.findN(t, q);
            pr.findP(q);
            while (true)
            {
                if (pr.p > Math.Pow(2, t)) pr.findN(t, q);
                if (Math.Pow(2, pr.p - 1) == 1 % pr.p && Math.Pow(2, pr.N + pr.u) != 1 % pr.p)
                {
                    Console.WriteLine(pr.p);
                    break;
                }
                else
                {
                    pr.u += 2;
                    pr.findP(q);
                }
            }
        }
    }
}

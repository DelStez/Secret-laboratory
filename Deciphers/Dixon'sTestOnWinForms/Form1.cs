using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Numerics;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace Dixon_sTestOnWinForms
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        public static long[] ExtendedGCD(long a, long b)
        {
            long[] result = new long[3];
            if (b == 0)
            {
                result[0] = a;
                result[1] = 1;
                result[2] = 0;
                return result;
            }
            var sub_res = ExtendedGCD(b, a % b);
            result[0] = sub_res[0];
            result[1] = sub_res[2];
            result[2] = sub_res[1] - (a / b) * sub_res[2];
            return result;
        }
        public class SmoothInfo
        {
            public long a;
            public long b;
            public List<long> aVec = new List<long>();
            public List<long> epsVec = new List<long>();
        }
        public static bool IsPower(int n)
        {
            if ((-n & n) == n)
            {
                return true;
            }
            var lgn = 1 + (deciToBinary(Math.Abs(n)).ToString().Length - 2);
            for (int b = 2; b < lgn; b++)
            {
                var lowa = 1L;
                var higha = 1L << (lgn / b + 1);
                while (lowa < (higha - 1))
                {
                    var mida = (lowa + higha) >> 1;
                    var ab = FastExponentiation(mida, b);
                    if (ab > n)
                    {
                        higha = mida;
                    }
                    else if (ab < n)
                    {
                        lowa = mida;
                    }
                    else
                    {
                        return true; //mida ^ b
                    }
                }
            }
            return false;
        }
        private static long FastExponentiation(long a, int n)
        {
            long ans = 1;
            while (n > 0)
            {
                if ((n & 1) > 0)
                {
                    ans = ans * a;
                }
                a = a * a;
                n = n >> 1;
            }
            return ans;
        }

        private static int deciToBinary(int num)
        {
            int bin;
            if (num != 0)
            {
                bin = (num % 2) + 10 * deciToBinary(num / 2);
                return bin;
            }
            else
            {
                return 0;
            }
        }
       
        public static IEnumerable<int> SieveOfEratosthenes(int num)
        {
            return Enumerable.Range(1, Convert.ToInt32(Math.Floor(Math.Sqrt(num))))
                .Aggregate(Enumerable.Range(1, num).ToList(),
                (result, index) =>
                {
                    result.RemoveAll(i => i > result[index] && i % result[index] == 0);
                    return result;
                }
                );
        }
        private void Log(string text)
        {
            
            listBox1.BeginInvoke(new MethodInvoker(() => listBox1.Items.Add(text)));
        }
        public static double LofN(double N)
        {
            return Math.Exp(Math.Sqrt(Math.Log(N, Math.E) * Math.Log(Math.Log(N, Math.E), Math.E)));
        }
        public static bool IsSmooth(long num, List<long> baseFactor, out List<long> factors)
        {
            try
            {
                var simpleFactors = new List<long>();
                int b, c;

                while ((num % 2) == 0)
                {
                    num = num / 2;
                    simpleFactors.Add(2);
                }
                b = 3; c = (int)Math.Sqrt(num) + 1;
                while (b < c)
                {
                    if ((num % b) == 0)
                    {
                        if (num / b * b - num == 0)
                        {
                            simpleFactors.Add(b);
                            num = num / b;
                            c = (int)Math.Sqrt(num) + 1;
                        }
                        else
                        {
                            b += 2;
                        }
                    }
                    else
                    {
                        b += 2;
                    }
                }

                simpleFactors.Add(num);
                factors = new List<long>();
                foreach (var bf in baseFactor)
                {
                    factors.Add(simpleFactors.Count(x => x == bf));
                }
                return true;
            }
            catch (Exception ex)
            {
                factors = new List<long>();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                System.Windows.Forms.MessageBox.Show(ex.StackTrace);
                return false;
            }
        }
        public static int TheTruePowerfullGauss(List<List<double>> a, List<double> ans)
        {
            int n = (int)a.Count();
            int m = (int)a[0].Count() - 1;
            double eps = 0.0001;
            List<int> where = new List<int>(Enumerable.Repeat(-1, m));
            ans.AddRange(Enumerable.Repeat(-1.0, m));

            for (int col = 0, row = 0; col < m && row < n; ++col)
            {
                int sel = row;
                for (int i = row; i < n; ++i)
                    if (Math.Abs(a[i][col]) > Math.Abs(a[sel][col]))
                        sel = i;
                if (Math.Abs(a[sel][col]) < eps)
                    continue;
                for (int i = col; i <= m; ++i)
                {
                    var value = a[sel][i];
                    a[sel][i] = a[row][i];
                    a[row][i] = value;
                }
                where[col] = row;

                for (int i = 0; i < n; ++i)
                    if (i != row)
                    {
                        double c = a[i][col] / a[row][col];
                        for (int j = col; j <= m; ++j)
                            a[i][j] -= a[row][j] * c;
                    }
                ++row;
            }

            for (int i = 0; i < m; ++i)
                if (where[i] != -1)
                    ans[i] = a[where[i]][m] / a[where[i]][i];
            for (int i = 0; i < n; ++i)
            {
                double sum = 0;
                for (int j = 0; j < m; ++j)
                    sum += ans[j] * a[i][j];
                if (Math.Abs(sum - a[i][m]) > eps)
                    return 0;
            }

            for (int i = 0; i < m; ++i)
                if (where[i] == -1)
                    return int.MaxValue;
            return 1;
        }
        private void DixonTest(int N, int numberOfInstances)
        {
            
            var tasks = new List<Task>();
            for (int ii = 0; ii < numberOfInstances; ii++)
            {
               
                tasks.Add(new Task(()=>
                {
                    
                    try
                    {
                       
                        var primesUponN = SieveOfEratosthenes(N).ToList();
                        if (primesUponN.Contains(N))
                        {
                            Log("Число " + N + " - простое!");
                            return;
                        }

                        primesUponN.RemoveAt(0);

                        var minN = (int)Math.Sqrt(N);
                        var M = Math.Pow(LofN(N), 0.5);
                        var primes = primesUponN.Where(x => x <= M).ToList();

                        if (primes.Count == 0)
                        {
                            Log("Слишком маленькое число !!");
                            return;
                        }

                        var B = new List<long>(primes.ConvertAll(i => (long)i));
                        int h = B.Count + 1;

                        var smoothed = new List<SmoothInfo>();
                        var answerNotFound = true;

                        while (answerNotFound)
                        {
                            int curFound = 0;
                            smoothed.Clear();
                            while (curFound < h)
                            {
                                var b = random.Next(minN + 1, N - 1);
                                var a = long.Parse(BigInteger.ModPow(new BigInteger(b), new BigInteger(2), new BigInteger(N)).ToString());
                                if (a == 0)
                                {
                                    continue;
                                }

                                var factors = new List<long>();
                                if (IsSmooth(a, B, out factors))
                                {
                                    var smooth = new SmoothInfo();
                                    smooth.a = a;
                                    smooth.b = b;
                                    smooth.aVec = factors;
                                    factors.ForEach(x => smooth.epsVec.Add(x % 2));
                                    smoothed.Add(smooth);
                                    curFound += 1;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            for (int first = 0; first < smoothed.Count && answerNotFound == true; first++)
                            {
                                for (int second = first; second < smoothed.Count && answerNotFound == true; second++)
                                {
                                    if (first != second)
                                    {
                                        var vecOne = smoothed[first];
                                        var vecTwo = smoothed[second];

                                        var deltaLeft = smoothed.Count - (smoothed.Count - first);
                                        var deltaMiddle = second - (first + 1);
                                        var currentAnswer = new List<double>();
                                        var matrix = new List<List<double>>();
                                        for (int i = 0; i < vecOne.aVec.Count; i++)
                                        {
                                            var vertex = new List<double>();
                                            vertex.AddRange(Enumerable.Repeat(0.0, deltaLeft));
                                            vertex.Add(vecOne.aVec[i]);
                                            vertex.AddRange(Enumerable.Repeat(0.0, deltaMiddle));
                                            vertex.Add(vecTwo.aVec[i]);
                                            vertex.Add(0);
                                            matrix.Add(vertex);
                                        }

                                        TheTruePowerfullGauss(matrix, currentAnswer);

                                        if (currentAnswer.Any(x => x != 0))
                                        {
                                            var probableX = (vecOne.b * vecTwo.b) % N;

                                            var probableY = 1.0;
                                            for (int i = 0; i < B.Count; i++)
                                            {
                                                var value = B[i];
                                                var step = (vecOne.aVec[i] + vecTwo.aVec[i]) / 2.0;
                                                probableY *= Math.Pow(value, step);
                                            }

                                            probableY = probableY % N;
                                            if ((probableX == probableY) || (probableX == -probableY))
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                var u = ExtendedGCD((int)(probableX + probableY), N)[0];
                                                var v = ExtendedGCD((int)(probableX - probableY), N)[0];
                                                if (((u * v) == N) && (u != 1) && (v != 1))
                                                {
                                                    Log("Разложение найдено - (" + u + ") * (" + v + ") = " + N);
                                                    answerNotFound = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        if (e.Message.Contains("OutOfMemoryException"))
                        {
                            Log("Недостаточно памяти для вычисления значения");
                        }
                        else
                        {
                            Log("Возникла ошибка:" + e.Message);
                        }
                        return;
                    }
                }));
            }
            tasks.ForEach(x => x.Start());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var N = Convert.ToInt32(textBox2.Text);
            var instances = Convert.ToInt32(textBox3.Text);
            if (IsPower(N))
            {
                Log("N = " + N + " - степень простого числа");
            }
            else DixonTest(N, instances);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}

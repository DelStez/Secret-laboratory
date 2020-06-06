using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA_WF
{
    public partial class mainForm : Form
    {
        public static string pathFile;
        public static string saveFile;
        public Encoding encoding = Encoding.UTF8;
        public ElGamal q = new ElGamal();
        public List<decimal[]> text = new List<decimal[]>();
        public mainForm()
        {
            InitializeComponent();
        }

        public void readFile()
        {
            using (StreamReader sr = new StreamReader(pathFile, encoding))
            {
                textBox5.Text = sr.ReadToEnd();
            }
        }
        private void downlodFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                pathFile = openFileDialog1.FileName;
                readFile();

            }
        }

        private void button1_Click(object sender, EventArgs e)//RSA шифрование
        {
            if (textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox1.Text.Length > 0)
            {
                long p = Convert.ToInt64(textBox3.Text);
                long q = Convert.ToInt64(textBox4.Text);
                if (IsTheNumberSimple(p) && IsTheNumberSimple(q))
                {
                    long n = p * q;
                    long m = (p - 1) * (q - 1);
                    long e_ = Calculate_e(m);
                    long d = Calculate_d(m, e_);
                    string s = "";
                    StreamReader sr = new StreamReader(pathFile, encoding);
                    while (!sr.EndOfStream)
                    {
                        s += sr.ReadLine();
                    }
                    sr.Close();

                    List<string> result = RSA_Endoce(s, e_, n);

                    StreamWriter sw = new StreamWriter(pathFile);
                    foreach (string item in result)
                        sw.Write(item);
                    sw.Close();
                    textBox6.Text = d.ToString();
                    textBox2.Text = n.ToString();
                    readFile();
                    Process.Start(pathFile);
                }
            }
        }

        private List<string> RSA_Endoce(string s, long e, long n)//RSA шифрование
        {
            List<string> result = new List<string>();

            BigInteger bi;
                for (int j = 0; j < s.Length; j++)
                {
                    int index = Convert.ToInt32(s[j]);

                    bi = new BigInteger(index);
                    bi = BigInteger.Pow(bi, (int)e);

                    BigInteger n_ = new BigInteger((int)n);

                    bi = bi % n_;
                    result.Add(Convert.ToChar(Convert.ToInt32(bi.ToString())).ToString());
            }
          return result;
        }
        static long GCD(long a, long b)// НОД
        {
            long Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }
        private string RSA_Dedoce(string s, long d, long n)//RSA дешифрование
        {
            string result = "";

            BigInteger bi;
            int count = 0;
            for (int j = 0; j < s.Length; j++)
            {
                bi = new BigInteger(Convert.ToInt32(s[j]));
                    bi = BigInteger.Pow(bi, (int)d);

                    BigInteger n_ = new BigInteger((int)n);

                    bi = bi % n_;

                result += Convert.ToChar(Convert.ToInt32(bi.ToString()));
            }

            return result;
        }
        private bool IsTheNumberSimple(long n)//проверка на простоту
        {
            if (n < 2)
                return false;

            if (n % 2 == 0)
                return false;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }
        private long Calculate_d(long m, long e)// вычисление d (RSA)
        {
            long d = 0;

            while ((d * e) % m != 1)
            {
                d++;
            }

            return d;
        }
        private long Calculate_e(long m)// вычисление e (RSA)
        {
            long e = 2;

            while (GCD(e, m) != 1)
            {
                e++;
            }

            return e;
        }

        private void button2_Click(object sender, EventArgs e)//RSA дешифрование
        {
            if ((textBox6.Text.Length > 0) && (textBox2.Text.Length > 0) && textBox1.Text.Length > 0)
            {
                long d = Convert.ToInt64(textBox6.Text);
                long n = Convert.ToInt64(textBox2.Text);

                string input = String.Empty;

                using (StreamReader sr = new StreamReader(pathFile))
                {
                    input = sr.ReadToEnd();
                }
                string result = RSA_Dedoce(input, d, n);

                StreamWriter sw = new StreamWriter(pathFile);
                sw.WriteLine(result);
                sw.Close();
                readFile();
                Process.Start(pathFile);
            }
        }

        private void button3_Click(object sender, EventArgs e)//Rsa генератор ключей
        {
            Random r = new Random();
            long p = r.Next(41, 67);
            long q = r.Next(41, 67);
            do
            {
                    p = r.Next(41, 67);
                    q = r.Next(41, 67);
            }
            while (!IsTheNumberSimple(p) || !IsTheNumberSimple(q));
            long n = p * q;
            long m = (p - 1) * (q - 1);
            long e_ = Calculate_e(m);
            long d = Calculate_d(m, e_);
            textBox3.Text = p.ToString();
            textBox4.Text = q.ToString();
            textBox6.Text = d.ToString();
            textBox2.Text = n.ToString();
        }

        private void button4_Click(object sender, EventArgs e)//ELGAMAL генератор ключей
        {
            Random r = new Random();
            ulong p = 0;
            do
            {
                p = (ulong)r.Next(1500, 65535);
            }
            while (!IsTheNumberSimple((long)(p)));
            q = new ElGamal(p);
            textBox9.Text = p.ToString();
            textBox10.Text = q.g.ToString(); 
            textBox8.Text = q.KOpen.ToString();
            textBox7.Text = q.KOpen.ToString();

        }
       
        private void button5_Click(object sender, EventArgs e)//ELGAMAL шифрование
        {
            Random r = new Random();
            long p, g, y;
            int k = 0;
            string temp = String.Empty;
            p = (long)Convert.ToInt32(textBox9.Text);
            g = (long)Convert.ToInt32(textBox10.Text);
            y = (long)Convert.ToInt32(textBox8.Text);

            StreamReader sr = new StreamReader(pathFile, encoding);
            while (!sr.EndOfStream)
            {
                temp += sr.ReadLine();
            }
            sr.Close();
            
            text = q.Encrypting(temp);
            using (StreamWriter sw = new StreamWriter(pathFile))
            {
                for (int i = 0; i < text.Count; i++)
                {
                    sw.Write("{" + text[i][0] + ", " + text[i][1] + "}, ");
                }

            }
            readFile();
            Process.Start(pathFile);

        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            long p, g, y;
            int k = 0;
            string temp = String.Empty;
            p = (long)Convert.ToInt32(textBox9.Text);
            g = (long)Convert.ToInt32(textBox10.Text);
            y = (long)Convert.ToInt32(textBox8.Text);
            long x = (long)Convert.ToInt32(textBox7.Text);
            StreamReader sr = new StreamReader(pathFile, encoding);
            while (!sr.EndOfStream)
            {
                temp += sr.ReadLine();
            }
            sr.Close();
            string result = q.Decrypting(text);
            using (StreamWriter sw = new StreamWriter(pathFile))
            {
                sw.Write(result);
            }
            readFile();
            Process.Start(pathFile);
        }
    }
    public class ElGamal: Form
    {

        public decimal P;
        public decimal g;
        public decimal KOpen;
        private decimal KClose;

        public ElGamal()
        {
        }
        /// Инициализирует экземпляр значениями ключей по указанному модулю
        /// <param name="p"></param>
        public ElGamal(ulong p)
        {
            P = p; /* (x,p)=1 */
            KeyGen(P);
        }
        /// Генерация ключей
        protected void KeyGen()
        {
            P = CreateBigPrime(10);
            g = TakePrimitiveRoot(P);
            KClose = 2;
            while (GCD(KClose, P) != 1)
            {
                KClose = CreateBigPrime(10) % (P - 1);
            }
            KOpen = PowMod(g, KClose, P);
        }
        /// Генерация ключей
        protected void KeyGen(decimal prime)
        {
            g = TakePrimitiveRoot(prime);
            Random rand = new Random();
            KClose = 2;
            while (GCD(KClose, prime) != 1)
            {
                KClose = (rand.Next(1, Int32.MaxValue) * rand.Next(1, Int32.MaxValue)) % (prime - 1);
            }
            KOpen = PowMod(g, KClose, prime);
        }
        /// Поиск наибольшего общего делителя

        public static decimal GCD(decimal a, decimal b)
        {
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }
        protected decimal TakePrimitiveRoot(decimal primeNum)
        {
            for (ulong i = 0; i < primeNum; i++)
                if (IsPrimitiveRoot(primeNum, i))
                    return i;
            return 0;
        }
        /// Проверка на примитивность
        public bool IsPrimitiveRoot(decimal p, decimal a)
        {
            if (a == 0 || a == 1)
                return false;
            decimal last = 1;
            HashSet<decimal> set = new HashSet<decimal>();
            for (ulong i = 0; i < p - 1; i++)
            {
                last = (last * a) % p;
                if (set.Contains(last))
                    return false;
                set.Add(last);
            }
            return true;
        }
        /// Шифрование
        public List<decimal[]> Encrypting(string message)
        {
            byte[] binary = Encoding.UTF8.GetBytes(message);
            List<decimal[]> ciphermessage = new List<decimal[]>(); //Хранение шифртекста - пары чисел 
            Random rand = new Random();
            decimal[] pair = new decimal[2];
            decimal k = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                k = (rand.Next(1, Int16.MaxValue) * rand.Next(1, Int16.MaxValue)) % (P - 1);
                pair = new decimal[2];
                pair[0] = PowMod(g, k, P);
                pair[1] = (PowMod(KOpen, k, P) * binary[i]) % P;
                ciphermessage.Add(pair);
            }
            return ciphermessage;
        }

        /// Расшифрование
        public string Decrypting(List<decimal[]> ciphermesage)
        {
            string plain = "";
            byte n;
            for (int i = 0; i < ciphermesage.Count; i++)
            {
                n = (byte)((PowMod((decimal)EuclideanAlgorithm(P, ciphermesage[i][0]), KClose, P) * ciphermesage[i][1]) % P);
                plain += Encoding.ASCII.GetChars(new byte[] { n })[0];
            }
            return plain;
        }

        public static string GetPlainFromCipher(List<decimal[]> ciphermesage, decimal p, decimal g, decimal OpenKey)
        {
            string plain = "";
            byte n;
            decimal k;
            for (int i = 0; i < ciphermesage.Count; i++)
            {
                k = ElGamal.MatchingAlgorithm(g, ciphermesage[i][0], p);
                n = (byte)((ElGamal.PowMod(ElGamal.EuclideanAlgorithm(p, OpenKey), k, p) * ciphermesage[i][1]) % p);
                Console.WriteLine($"{ciphermesage[i][0]} = {g}^k mod {p}\nk = {k}");
                Console.WriteLine($"M = {n} = (({OpenKey})^-1)^{k} * {ciphermesage[i][1]} mod {p}");
                plain += Encoding.ASCII.GetChars(new byte[] { n })[0];
            }
            return plain;
        }
        /// Вычисление обратного числа. Расширенный алгоритм Евклида
        public static decimal EuclideanAlgorithm(decimal module, decimal element)
        {
            decimal inverse = 0;
            decimal w1 = 0, w3 = module, r1 = 1, r3 = element; //Инициализация
            decimal q = (decimal)Math.Floor((w3 / r3));
            decimal cr1, cr3;
            while (r3 != 1)
            {
                cr1 = r1;
                cr3 = r3;
                r1 = w1 - r1 * q;
                r3 = w3 - r3 * q;
                w1 = cr1;
                w3 = cr3;
                q = Math.Floor(w3 / r3);
            }

            inverse = r1;
            if (inverse < 0) //Устранение отрицательности 
            {
                inverse += module;
            }

            return inverse;
        }
        public static decimal MatchingAlgorithm(decimal a, decimal b, decimal p)
        {
            decimal x = 0,
                H = (long)Math.Sqrt(Decimal.ToUInt64(p)) + 1;
            decimal c = PowMod(a, H, p);
            List<decimal> table_0 = new List<decimal>(),
                table_1 = new List<decimal>();
            table_1.Add((b % p));
            for (long i = 1; i <= H; i++)
            {
                table_0.Add(PowMod(c, i, p));
                table_1.Add(((PowMod(a, i, p) * b) % p));
            }
            decimal q;
            for (short i = 0; i < table_1.Count; i++)
            {
                q = table_0.IndexOf(table_1[i]);
                if (q > 0)
                {
                    x = ((q + 1) * H - i);
                    break;
                }
            }
            return x;
        }
        public static decimal RhoPolard(decimal a, decimal b, decimal p)
        {
            List<decimal> u = new List<decimal>(),
                v = new List<decimal>(),
                z = new List<decimal>();
            List<int> ii = new List<int>();
            decimal x = 0;
            int i2;
            u.Add(0);
            v.Add(0);
            z.Add(1);
            int i = 0;
            while (true)
            {
                if (z[i] > 0 && z[i] < p / 3)
                {
                    u.Add((u[i] + 1) % (p - 1));
                    v.Add(v[i] % (p - 1));
                }
                if (z[i] > p / 3 && z[i] < 2 * (p / 3))
                {
                    u.Add((2 * u[i]) % (p - 1));
                    v.Add((2 * v[i]) % (p - 1));
                }
                if (z[i] > 2 * (p / 3) && z[i] < p)
                {
                    u.Add(u[i] % (p - 1));
                    v.Add((v[i] + 1) % (p - 1));
                }
                z.Add((PowMod(b, u[u.Count - 1], p - 1) * PowMod(a, v[v.Count - 1], p - 1)) % (p - 1));
                i++;
                if (z[i] > 0 && z[i] < p / 3)
                {
                    z[i] = (b * z[i]) % p;
                }
                if (z[i] > p / 3 && z[i] < 2 * (p / 3))
                {
                    z[i] = (z[i] * z[i]) % p;
                }
                if (z[i] > 2 * (p / 3) && z[i] < p)
                {
                    z[i] = (a * z[i]) % p;
                }
                i2 = -1;
                i2 = (int)Math.Ceiling((double)i / 2);
                if (i >= 2 && z[i2] == z[i])
                {
                    ii.Add(i2);
                    if (GCD(u[i] - u[i2], p - 1) == 1)
                    {
                        x = (EuclideanAlgorithm(p - 1, (u[i] - u[i2])) * (v[i2] - v[i]));
                        x = (x < 0) ? ((p - 1) + x) % (p - 1) : x % (p - 1);
                    }
                    if (ii.Count >= 3)
                    {
                        break;
                    }
                }
            }
            if (GCD(u[i] - u[i2], p - 1) == 1)
            {
                x = EuclideanAlgorithm(p - 1, (u[i] - u[i2]));
                x = (x < 0) ? ((p - 1) + x) % (p - 1) : x % (p - 1);
            }
            return x;
        }
        /// Определение большого простого числа(генерация)
        public ulong CreateBigPrime(short numDec)
        {
            ulong N = 1;
            Random rand = new Random(DateTime.Now.Millisecond);
            while (Convert.ToString(N).Length < numDec || !isPrime(N))
            {
                N = (ulong)(rand.Next(0, int.MaxValue) * rand.Next(0, int.MaxValue)) - 1;
            }
            return N;
        }
        public bool isPrime(ulong n)
        {
            for (ulong i = 2; i < n / 2 + 1; i++)
            {
                if ((n % i) == 0) return false;
            }
            return true;
        }
        /// Алгоритм быстрого возведения в степень по модулю
        public static decimal PowMod(decimal number, decimal pow, decimal module)
        {
            string q = Convert.ToString((long)pow, 2); //Двоичное представление степени
            BigInteger s = 1, c = (BigInteger)number; //Инициализация
            for (int i = q.Length - 1; i >= 0; i--)
            {
                if (q[i] == '1')
                {
                    s = (s * c) % (BigInteger)module;
                }
                c = (c * c) % (BigInteger)module;
            }
            return (decimal)s;
        }
    }
}

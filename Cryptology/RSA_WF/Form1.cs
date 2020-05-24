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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0 && textBox4.Text.Length > 0)
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
                        sw.WriteLine(item);
                    sw.Close();
                    textBox6.Text = d.ToString();
                    textBox2.Text = n.ToString();
                    readFile();
                    Process.Start(pathFile);
                }
            }
        }

        private List<string> RSA_Endoce(string s, long e, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;
            List<byte[]> text = GetBytes(s);
            for (int i = 0; i < text.Count; i++)
            {
                string temp = String.Empty;
                for (int j = 0; j < text[i].Length; j++)
                {
                    byte[] b = text[i];
                    int index = Convert.ToInt32(b[j]);

                    bi = new BigInteger(index);
                    bi = BigInteger.Pow(bi, (int)e);

                    BigInteger n_ = new BigInteger((int)n);

                    bi = bi % n_;

                    temp += bi.ToString();
                    if (text[i].Length - 1 != j) temp += " ";
                }
                result.Add(temp);
            }

            return result;
        }
        private List<byte[]> GetBytes(string s)
        {
            List<byte[]> output = new List<byte[]>();
            foreach (char c in s)
            {
                output.Add(encoding.GetBytes(c.ToString()));
            }
            return output;
        }
        static long GCD(long a, long b)
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
        private string RSA_Dedoce(List<string> input, long d, long n)
        {
            string result = "";

            BigInteger bi;
            int count = 0; 
            foreach (string item in input)
            {
                string[] t = item.Split(' ').ToArray();
                for (int i = 0; i < t.Length; i++)
                {
                    bi = new BigInteger(Convert.ToDouble(item));
                    bi = BigInteger.Pow(bi, (int)d);

                    BigInteger n_ = new BigInteger((int)n);

                    bi = bi % n_;

                    t[i] = bi.ToString();
                }
                result += GetCharString(t);
            }

            return result;
        }
        private string GetCharString(string[] h)
        {
            byte[] output = new byte[h.Length];
            for (int i = 0; i < h.Length; i++)
            {
                output[i] = Convert.ToByte(Convert.ToInt32(h[i])% 255);
            }
            return encoding.GetString(output);
        }
        private bool IsTheNumberSimple(long n)
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }
        private long Calculate_d(long m, long e)
        {
            long d = 0;

            while ((d * e) % m != 1)
            {
                d++;
            }

            return d;
        }
        private long Calculate_e(long m)
        {
            long e = 2;

            while (GCD(e, m) != 1)
            {
                e++;
            }

            return e;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox6.Text.Length > 0) && (textBox2.Text.Length > 0))
            {
                long d = Convert.ToInt64(textBox6.Text);
                long n = Convert.ToInt64(textBox2.Text);

                List<string> input = new List<string>();

                StreamReader sr = new StreamReader(pathFile);

                while (!sr.EndOfStream)
                {
                    input.Add(sr.ReadLine());
                }

                sr.Close();

                string result = RSA_Dedoce(input, d, n);

                StreamWriter sw = new StreamWriter(pathFile);
                sw.WriteLine(result);
                sw.Close();
                readFile();
                Process.Start(pathFile);
            }
        }
    }
}

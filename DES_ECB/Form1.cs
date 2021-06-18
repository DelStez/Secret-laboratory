using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES_ECB
{
    public partial class DES : Form
    {
        public DES()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        public string key;
        public string DirectorySave;
        public string Path;
        public string outtext;
        public static List<BitArray> RoundHistoryChangesBasicBlock;
        private void downloadKey_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    key = sr.ReadToEnd();
                    textBox3.Text = key;
                    byte[] ba = Encoding.Default.GetBytes(key);

                    textBox8.Text = BitConverter.ToString(ba).Replace("-", " ");
                }
            }
        }
        private void hexTextChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] ba = new byte[(sender as TextBox).Text.Replace(" ", "").Length / 2];
                for (int i = 0; i < (sender as TextBox).Text.Replace(" ", "").Length; i += 2)
                    ba[i / 2] = Convert.ToByte((sender as TextBox).Text.Replace(" ", "").Substring(i, 2), 16);
                if (sender == textBox8) textBox3.Text = Encoding.Default.GetString(ba);
                if (sender == textBox5) textBox4.Text = Encoding.Default.GetString(ba);
                if (sender == textBox7) textBox6.Text = Encoding.Default.GetString(ba);
            }
            catch (ArgumentOutOfRangeException q)
            { }
        }
        private void TextChanged(object sender, EventArgs e)
        {

            byte[] ba = new byte[(sender as TextBox).Text.Length / 2];
            ba = Encoding.Default.GetBytes((sender as TextBox).Text.ToString());
            if (sender == textBox3) textBox8.Text = BitConverter.ToString(ba).Replace("-", " ");
            if (sender == textBox4) textBox5.Text = BitConverter.ToString(ba).Replace("-", " ");
            if (sender == textBox6) textBox7.Text = BitConverter.ToString(ba).Replace("-", " ");

        }

        private void HexKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((sender as TextBox) == textBox4 || (sender as TextBox) == textBox6)
            {
                string hexSymbol = "0123456789ABCDEFabcdef ";
                if (!hexSymbol.Contains(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
                else
                    e.Handled = false;
            }
        }
        private void GetFilesText(object sender, object sender2)
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                (sender as TextBox).Text = sr.ReadToEnd();
                byte[] ba = Encoding.Default.GetBytes((sender as TextBox).Text);
                (sender2 as TextBox).Text = BitConverter.ToString(ba).Replace("-", " ");
            }
        }
        private void downlodFile_Click(object sender, EventArgs e)
        {
            Clear();
            openFileDialog2.InitialDirectory = "c:\\";
            openFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog2.FileName;
                Path = openFileDialog2.FileName;
                if (comboBox1.SelectedIndex == 0)
                    GetFilesText(textBox4, textBox5);
                else
                    GetFilesText(textBox6, textBox7);

            }

        }
        private void Clear()
        {
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void GroupEnableCheck(object sender, EventArgs e)
        {

            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                groupBox3.Enabled = true;
                foreach (Control ctr in groupBox3.Controls)
                    ctr.Enabled = true;
            }
            else groupBox3.Enabled = false;
        }
        private void VoidDes(object sender, EventArgs e)
        {
            if (sender == button1)
            {
                if (textBox4.Text.Length > 0)
                {
                    //DES
                    DateTime time1 = DateTime.Now;
                    Core c = new Core(textBox4.Text, textBox3.Text, false);
                    string text = Core.Begin();
                    DateTime time2 = DateTime.Now;
                    textBox6.Text = text;
                    TimeSpan timeDelta = time2 - time1;
                    label6.Text = timeDelta.TotalMilliseconds.ToString();
                    SaveMessage(text);
                }
            }
            else if (sender == button2)
            {
                if (textBox6.Text.Length > 0)
                {
                    DateTime time1 = DateTime.Now;
                    Core c = new Core(textBox6.Text, textBox3.Text, true);
                    string text = Core.Begin();
                    DateTime time2 = DateTime.Now;
                    textBox4.Text = text;
                    TimeSpan timeDelta = time2 - time1;
                    label6.Text = timeDelta.TotalMilliseconds.ToString();
                    SaveMessage(text);
                }
            }
        }
        public static string FromTextToBinary(string text)
        {
            StringBuilder result = new StringBuilder(text.Length * 8);

            foreach (char word in text)
            {
                int binary = (int)word;
                int factor = 128;

                for (int i = 0; i < 8; i++)
                {
                    if (binary >= factor)
                    {
                        binary -= factor;
                        result.Append("1");
                    }
                    else
                    {
                        result.Append("0");
                    }

                    factor /= 2;
                }
            }

            return result.ToString();
        }
        public static int[,] FormDependencyMatrix(string[] Yi, string Y)
        {
            int[,] result = new int[Y.Length, Y.Length];

            for (int i = 0; i < Y.Length; i++)
            {
                for (int j = 0; j < Y.Length; j++)
                {
                    result[i, j] = (Yi[i][j] != Y[j] ? 1 : 0);
                }
            }

            return result;
        }

        public static int[,] FormDistanceMatrix(string[] Yi, string Y)
        {
            int[,] result = new int[Y.Length, Y.Length];

            for (int i = 0; i < Y.Length; i++)
            {
                for (int j = 0; j < Y.Length; j++)
                {
                    string xor = DES.StringXOR(Yi[i], Y);
                    int w = HammingDistance(xor);
                    result[i, j] = w == j ? 1 : 0;
                }
            }

            return result;
        }
        public static int HammingDistance(string binaryVector)
        {
            int result = 0;

            foreach (char ch in binaryVector)
            {
                if (ch != '0')
                    result++;
            }

            return result;
        }
        public static string StringXOR(string text1, string text2)
        {
            if (text1.Length != text2.Length)
            {
                Console.WriteLine("Блоки должны быть одинакового размера.");
                return null;
            }

            StringBuilder result = new StringBuilder(text1.Length);

            for (int i = 0; i < text1.Length; i++)
            {
                if (!text1[i].Equals(text2[i]))
                {
                    result.Append("1");
                }
                else
                {
                    result.Append("0");
                }
            }

            return result.ToString();
        }
        public static string InvertBitInStringBinary(string s, int bitIndex)
        {
            string result = s;


            if (result[bitIndex] == '1')
            {
                result = result.Remove(bitIndex, 1);
                result = result.Insert(bitIndex, "0");
            }
            else
            {
                result = result.Remove(bitIndex, 1);
                result = result.Insert(bitIndex, "1");
            }

            return result;
        }

        public static string FromBinaryToText(string binaryString)
        {
            StringBuilder result = new StringBuilder(binaryString.Length / 8);

            for (int i = 0; i < (binaryString.Length / 8); i++)
            {
                string word = binaryString.Substring(i * 8, 8);
                result.Append((char)Convert.ToInt32(word, 2));
            }

            return result.ToString();
        }
        public static int Criteria1(int[,] a, int[,] b, int Upwr)
        {
            double sum1 = 0;
            double sum2 = 0;

            for (int i = 0; i < 64; i++)
            {
                sum2 = 0;

                for (int j = 0; j < 64; j++)
                {
                    sum2 += (j * b[i, j]);
                }

                sum1 += sum2 / (double)1;
            }

            return (int)(((double)1 / (double)64) * sum1);
        }
        public static double Criteria2(int[,] a)
        {
            double result = 0;

            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    if (a[i, j] == 0)
                    {
                        result += 1;
                    }
                }
            }

            return Math.Round((1 - (result / (64 * 64))), 4);
        }

        public static double Criteria3(int[,] b, int Upwr)
        {
            double sum1 = 0;
            double sum2 = 0;

            for (int i = 0; i < 64; i++)
            {
                sum2 = 0;

                for (int j = 0; j < 64; j++)
                {
                    sum2 += ((2 * j * b[i, j]) - 64);
                }

                sum1 += Math.Abs(((double)1 / (double)64) * sum2);
            }

            return Math.Round(1 - (1 - (sum1 / (64 * 64))), 4);
        }

        public static double Criteria4(int[,] a, int Upwr)
        {
            double sum1 = 0;
            double sum2 = 0;

            for (int i = 0; i < 64; i++)
            {
                sum2 = 0;

                for (int j = 0; j < 64; j++)
                {
                    sum2 += Math.Abs((2 * a[i, j] / (double)Upwr) - 1);
                }

                sum1 += sum2;
            }

            return Math.Round(1 - (sum1 / ((double)64 * (double)64)), 4);
        }
        private void SaveMessage(string tempResult)
        {
            saveFileDialog1.Filter = "TXT file|*.txt";
            saveFileDialog1.Title = "Save txt file";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.Write(tempResult);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 0)
            {
                Clear();
                if (comboBox1.SelectedIndex == 0)
                    GetFilesText(textBox4, textBox5);
                else
                    GetFilesText(textBox6, textBox7);
            }
        }

    }
}

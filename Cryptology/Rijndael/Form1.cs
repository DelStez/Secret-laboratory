using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rijndael
{
    public partial class Form1 : Form
    {
        private string key128;
        private int nrOfIterations = 10;
        public byte[] generation128 = new byte[16];
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        public static byte[] ToByteArray(String HexString)
        {
            int NumberChars = HexString.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
            }
            return bytes;
        }
        private void cipher_Click(object sender, EventArgs e)
        {
            string encryptedMsg = String.Empty;
            byte[] inputKey = readHexString(CorrectKey(tbKey.Text));
            Key key = new Key(inputKey);
            string message = CorrectMessage(tbPlain.Text);
            byte[] ivector = new byte[16];
            generation128.CopyTo(ivector, 0);
            for (int i = 0; i < message.Length; i += 32)
            {
                if (comboBox1.SelectedIndex == 1)//CBC
                {
                    byte[] inputPlain = new byte[16];
                    BitArray mes = new BitArray(readHexString(message.Substring(i, 32)));
                    BitArray iv = new BitArray(ivector);
                    mes.Xor(iv).CopyTo(inputPlain, 0);
                    encryptedMsg += EncryptMessage(inputPlain, key, nrOfIterations);
                    ivector = readHexString(EncryptMessage(inputPlain, key, nrOfIterations));
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    byte[] inputPlain = readHexString(new State(ivector).ToString());
                    BitArray openText = new BitArray(readHexString(message.Substring(i, 32)));
                    BitArray ivCipher = new BitArray(readHexString(EncryptMessage(inputPlain, key, nrOfIterations)));
                    openText.Xor(ivCipher).CopyTo(inputPlain, 0);
                    ivector = inputPlain;
                    encryptedMsg += new State(inputPlain).ToString();
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    byte[] inputPlain = readHexString(new State(ivector).ToString());
                    BitArray ivCipher = new BitArray(readHexString(EncryptMessage(inputPlain, key, nrOfIterations)));
                    ivCipher.CopyTo(ivector, 0);
                    BitArray openText = new BitArray(readHexString(message.Substring(i, 32)));
                    openText.Xor(ivCipher).CopyTo(inputPlain, 0);
                    encryptedMsg += new State(inputPlain).ToString();
                }
                else
                {
                    byte[] inputPlain = readHexString(message.Substring(i, 32));
                    encryptedMsg += EncryptMessage(inputPlain, key, nrOfIterations);

                }
                
            }
            tbCipher.Text = encryptedMsg;
            tbPlain.Text = String.Empty;

        }
        public string CorrectMessage(string message)
        {
            while (message.Length % 32 != 0)
            {
                message += "f";
            }
            return message;
        }
        private string CorrectKey(string key)
        {

            if (key.Length > 32)
            {
                string output = String.Empty;
                for (int i = 0; i < 32; i++)
                    output += key[i];
                return output;
            }
            else
            {
                while (key.Length % 32 != 0)
                    key += "f";
                return key;
            }
        }
        public string ConvertHex(String hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }
        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        private void DecipherButton_Click(object sender, EventArgs e)
        {
            string msg = CorrectMessage(tbCipher.Text);
            string decryptededMsgHex = String.Empty;
            
            byte[] inputKey = readHexString(CorrectKey(tbKey.Text));
            Key key = new Key(inputKey);
            byte[] ivector = new byte[16];
            generation128.CopyTo(ivector, 0);
            for (int i = 0; i < msg.Length; i += 32)
            {
                if (comboBox1.SelectedIndex == 1)
                {
                    byte[] inputPlain = HexStringToByteArray(msg.Substring(i, 32));
                    BitArray mes = new BitArray(readHexString(DecryptMessage(inputPlain, key, nrOfIterations)));
                    BitArray iv = new BitArray(ivector);
                    (mes.Xor(iv)).CopyTo(inputPlain, 0);
                    mes.CopyTo(ivector,0);
                    decryptededMsgHex += new State(inputPlain);
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    byte[] inputPlain = readHexString(new State(ivector).ToString());
                    BitArray openText = new BitArray(readHexString(msg.Substring(i, 32)));
                    BitArray ivCipher = new BitArray(readHexString(EncryptMessage(inputPlain, key, nrOfIterations)));
                    ivCipher.CopyTo(ivector, 0);
                    openText.Xor(ivCipher).CopyTo(inputPlain, 0);
                    decryptededMsgHex += new State(inputPlain).ToString();
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    byte[] inputPlain = readHexString(new State(ivector).ToString());
                    BitArray ivCipher = new BitArray(readHexString(EncryptMessage(inputPlain, key, nrOfIterations)));
                    ivCipher.CopyTo(ivector, 0);
                    BitArray openText = new BitArray(readHexString(msg.Substring(i, 32)));
                    openText.Xor(ivCipher).CopyTo(inputPlain, 0);
                    decryptededMsgHex += new State(inputPlain).ToString();
                }
                else
                {
                    byte[] inputPlain = HexStringToByteArray(msg.Substring(i, 32));
                    decryptededMsgHex += DecryptMessage(inputPlain, key, nrOfIterations);
                }
            }
            tbPlain.Text = decryptededMsgHex;
            tbCipher.Text = String.Empty;
        }
        private byte[] readHexString(string s)
        {
            int size = s.Length / 2;
            byte[] b = new byte[size];

            if ((size != 16) && (size != 24) && (size != 32))
            {
                throw new Exception();
            }

            for (int i = 0; i < size; i++)
            {
                b[i] = Convert.ToByte(s.Substring(2 * i, 2), 16);
            }
            return (b);
        }
        private void DownlodKey_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    tbKey.Text = sr.ReadToEnd();
                }
            }
        }

        private void DownloadFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    tbPlain.Text = sr.ReadToEnd();
                }
            }
        }
        public static string EncryptMessage(byte[] inputPlain, Key k, int nrOfIterations)
        {
            State inputState = new State(inputPlain);
            inputState = inputState.addRoundKey(k, 0);
            for (int i = 1; i < nrOfIterations; i++)
            {
                inputState = inputState.subBytes();
                inputState = inputState.shiftRows();
                inputState = inputState.mixColumns();
                inputState = inputState.addRoundKey(k, i);
            }
            inputState = inputState.subBytes();
            inputState = inputState.shiftRows();
            inputState = inputState.addRoundKey(k, nrOfIterations);
            Console.Out.WriteLine(inputState.ToMatrixString());
            return inputState.ToString();
        }
        public static string DecryptMessage(byte[] inputPlain, Key k, int nrOfIterations)
        {
            State outputState = new State(inputPlain);
            outputState = outputState.addRoundKey(k, nrOfIterations);

            for (int i = nrOfIterations - 1; i > 0; i--)
            {
                outputState = outputState.shiftRowsInv();
                outputState = outputState.subBytesInv();
                outputState = outputState.addRoundKey(k, i);
                outputState = outputState.mixColumnsInv();

            }
            outputState = outputState.shiftRowsInv();
            outputState = outputState.subBytesInv();
            outputState = outputState.addRoundKey(k, 0);
            return outputState.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "TXT file|*.txt";
            saveFileDialog1.Title = "Save txt file";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    if (tbPlain.TextLength > 0 && tbCipher.TextLength == 0)
                        sw.Write(tbPlain.Text);
                    else
                        sw.Write(tbCipher.Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbPlain.TextLength > 0 && tbCipher.TextLength == 0)
            {
                tbCipher.Text = tbPlain.Text;
                tbPlain.Clear();
            }
            else
            {
                tbPlain.Text = tbCipher.Text;
                tbCipher.Clear();
            }
        }
        private void TextChanged(object sender, EventArgs e)
        {
            
            if (sender == tbCipher || sender == tbPlain || sender == tbKey || sender == textBox1)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    if (tbPlain.TextLength != 0 && tbKey.TextLength != 0)
                        CipherButon.Enabled = true;
                    else
                        CipherButon.Enabled = false;

                    if (tbCipher.TextLength != 0 && tbKey.TextLength != 0)
                        DecipherButton.Enabled = true;
                    else
                        DecipherButton.Enabled = false;
                }
                else
                {
                    if (tbPlain.TextLength != 0 && tbKey.TextLength != 0 && textBox1.TextLength != 0)
                        CipherButon.Enabled = true;
                    else
                        CipherButon.Enabled = false;

                    if (tbCipher.TextLength != 0 && tbKey.TextLength != 0 && textBox1.TextLength != 0)
                        DecipherButton.Enabled = true;
                    else
                        DecipherButton.Enabled = false;
                }
               
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            generation128 = new byte[16];
            Random rnd = new Random();
            rnd.NextBytes(generation128);
            textBox1.Text = new State(generation128).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                textBox1.Clear();
            }
            else
            {
                textBox1.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                generation128 = new byte[16];
                Random rnd = new Random();
                rnd.NextBytes(generation128);
                textBox1.Text = new State(generation128).ToString();
            }
        }

        private void HexKeyPress(object sender, KeyPressEventArgs e)
        {
          
                string hexSymbol = "0123456789ABCDEFabcdef ";
                if (!hexSymbol.Contains(e.KeyChar) && e.KeyChar != (char)Keys.Back || e.KeyChar == (char)Keys.Space)
                {
                    e.Handled = true;
                }
                else
                    e.Handled = false;
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength != 0)
                generation128 = readHexString(CorrectKey(textBox1.Text));

        }
    }
}

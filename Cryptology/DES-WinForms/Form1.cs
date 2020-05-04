using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES_WinForms
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

        private void downloadKey_Click(object sender, EventArgs e)
        {

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
                if(sender == textBox8) textBox3.Text = Encoding.Default.GetString(ba);
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
            string hexSymbol = "0123456789ABCDEFabcdef ";
            if (!hexSymbol.Contains(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            else
                e.Handled = false;

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
                if (textBox4.Text.Length > 0 && comboBox1.SelectedIndex == 0)
                {
                    Core c = new Core(textBox4.Text, textBox3.Text, false);
                    string text = Core.Begin();
                    textBox6.Text = text;
                }
            }
            else if (sender == button2)
            {
                if (textBox6.Text.Length > 0 && comboBox1.SelectedIndex == 0)
                {
                    Core c = new Core(textBox6.Text, textBox3.Text, true);
                    string text = Core.Begin();
                    textBox4.Text = text;
                }
            }
            else { }
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

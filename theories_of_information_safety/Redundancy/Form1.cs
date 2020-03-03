using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redundancy
{
    public partial class Form1 : Form
    {
        private string Rus = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ";
        private string Eng = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
        public string fileContent;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileContent = string.Empty;
            var filePath = string.Empty;

            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Encoding coder = Encoding.GetEncoding("windows-1251"); 
                filePath = openFileDialog1.FileName;
                var fileStream = openFileDialog1.OpenFile();
                using(StreamReader reader = new StreamReader(fileStream, coder))
                {
                    fileContent = reader.ReadToEnd();
                }
                textBox1.Text = filePath;
                textBox2.Text = fileContent;
                fileContent = fileContent.ToLower();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                fileContent = Regex.Replace(fileContent, @"[^а-я\s]+", "");
            }
            else fileContent = Regex.Replace(fileContent, @"[^a-z\s]+", "");
            string temp = fileContent.Replace("\r\n"," ");
            //for(int i = 0; i < )
            textBox2.Text = temp;


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

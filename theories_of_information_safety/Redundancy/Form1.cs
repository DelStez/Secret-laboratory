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
        public bool ItWasUsed = false;
        List<double> oftens = new List<double>(); 
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
                using(StreamReader reader = new StreamReader(fileStream))
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
            if (ItWasUsed)
            {
                Cleaner();
                ItWasUsed = false;
            }
            string alphabet = String.Empty;
            if (comboBox1.SelectedIndex == 0)
            {
                fileContent = Regex.Replace(fileContent, @"[^а-я\s]+", "");
                alphabet = Rus;

            }
            else
            {
                fileContent = Regex.Replace(fileContent, @"[^a-z\s]+", "");
                alphabet = Eng;
            }
            string temp = fileContent.Replace("\r\n"," ");
            //double Hmax;
            double Shannon = 0;
            int counterRows = 1;
            foreach (var ch in alphabet) 
            {
                double numbersOfChar = 0;
                if (fileContent.Contains(ch.ToString().ToLower()))
                { 
                    numbersOfChar = (double)(fileContent.Length - fileContent.Replace(ch.ToString()
                        .ToLower(), "").Length) / (double)fileContent.Length;
                    Shannon += numbersOfChar * Math.Log(1 / numbersOfChar, 2);
                }
                oftens.Add(numbersOfChar);
                string[] tempRow = { counterRows.ToString(), ch.ToString(), numbersOfChar.ToString() };
                dataGridView1.Rows.Add(tempRow);
                counterRows++;
            }
            double D = 1 - (Shannon / Hmax(alphabet.Length));
            label1.Text = $"Избыточность = {D} ";
            ItWasUsed = true;
            textBox2.Text = temp;


        }
        public double Hmax(int alphabetSize)
        {
            double N = Math.Pow(2, alphabetSize);
            double result = Math.Log(N, 2);
            return result;

        }
        public void Calculate()
        {

        }
        public void Cleaner()
        {
            dataGridView1.Rows.Clear();

        }
        
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

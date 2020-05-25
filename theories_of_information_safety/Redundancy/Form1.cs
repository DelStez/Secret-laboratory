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
        public int totalWords;
        public int totalSentence;
        public int totalSyllables;
        public int totalHardWords;
        public bool ItWasUsed = false;
        public string alphabet;
        List<double> oftens = new List<double>(); 
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        public string GetHmax()// Нахождение избыточности
        {
            string _temp = fileContent;
            alphabet = String.Empty;
            if (comboBox1.SelectedIndex == 0)
            {
                _temp = Regex.Replace(_temp, @"[^а-я\s]+", "");
                alphabet = Rus;

            }
            else
            {
                _temp = Regex.Replace(_temp, @"[^a-z\s]+", "");
                alphabet = Eng;
            }
            string temp = _temp.Replace("\r\n", " ");
            double Shannon = 0;
            int counterRows = 1;
            foreach (var ch in alphabet)
            {
                double numbersOfChar = 0;
                if (_temp.Contains(ch.ToString().ToLower()))
                {
                    numbersOfChar = (double)(_temp.Length - _temp.Replace(ch.ToString()
                        .ToLower(), "").Length) / (double)_temp.Length;
                    Shannon += numbersOfChar * Math.Log(1 / numbersOfChar, 2);
                }
                oftens.Add(numbersOfChar);
                string[] tempRow = { counterRows.ToString(), ch.ToString(), numbersOfChar.ToString() };
                dataGridView1.Rows.Add(tempRow);
                counterRows++;
            }
            double D = 1 - (Shannon / Hmax(alphabet.Length));
            label1.Text = $"Избыточность = {D} ";
            return temp;
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

        public void Flash()
        {
            string temp = fileContent;
            String[] words = temp.Split(new char[] { ' ', '\r' ,'\n', '\0', '—' });
            totalWords = 0;
            totalSentence = 0;
            totalHardWords = 0;
            totalSyllables = 0;
            foreach (var word in words)
            {
                if (word.Length != 0)
                    totalWords++;
            }
            String[] s = fileContent.Split(new char[] { '!', '.', '?' });
           
            foreach (var word in s)
            {
                if (word.Length != 0)
                    totalSentence++;
            }
            string reg = @"(\b[aа-яzAА-ЯZ]+)";
            string gl = @"([aeyuioуеыаояиюэ]+)";
            Match oneWord = Regex.Match(temp, reg);
            int slogs = 0;
            while (oneWord.Success)
            {
                Match number = Regex.Match(oneWord.Groups[1].Value, gl);
                while (number.Success)
                {
                    slogs++;
                    totalSyllables++;
                    number = number.NextMatch();
                }

                if (slogs >= 4)
                {
                    slogs = 0;
                    totalHardWords++;
                }

                oneWord = oneWord.NextMatch();
            }
            double flash = 0;
            double flashKincade = 0;
            double Gunning = 0;

            if (comboBox1.SelectedIndex == 0)// для русского
            {
                
                flash = 206.835 - (1.3 * Math.Round((double)(totalWords / totalSentence), 2)) - (60.1 * Math.Round((double)(totalSyllables / totalWords), 2));
                flashKincade = ((8.38 * (double)(totalWords / totalSentence)) + (0.45 * (double)(totalSyllables / totalWords))) - 15.59;
                Gunning = 0.4 * (0.78 * (totalWords / totalSentence) + 100 * (totalHardWords / totalWords));
            }
            else// для английского
            {
                flash = 206.835 - (1.015 * Math.Round((double)(totalWords / totalSentence), 2)) - (84.6 * (Math.Round((double)(totalSyllables / totalWords), 2)));
                flashKincade = ((0.39 * Math.Round((double)(totalWords / totalSentence), 2)) + (11.8 * Math.Round((double)(totalSyllables / totalWords), 2))) - 15.59;
                Gunning = 0.4 * ((totalWords / totalSentence) + (totalHardWords / totalWords));
            }
            label2.Text = "Флеш:" + flash.ToString();
            label3.Text = "Флеш-Кинсайд: " + flashKincade.ToString();
            label4.Text = "Индекс туманности Ганнинга: " + Gunning.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (ItWasUsed)
            {
                Cleaner();
                ItWasUsed = false;
            }
            ItWasUsed = true;
            textBox2.Text = GetHmax();
            Flash();


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
      
    }
}

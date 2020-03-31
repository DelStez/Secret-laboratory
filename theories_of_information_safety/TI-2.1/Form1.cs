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

namespace TI_2._1
{
    public partial class Form1 : Form
    {
        private string Rus = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ";
        private string Eng = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
        public string fileContent;
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadButtonClick(object sender, EventArgs e)
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
                using (StreamReader reader = new StreamReader(fileStream, coder))
                {
                    fileContent = reader.ReadToEnd();
                }
                textBox1.Text = filePath;
                textBox2.Text = fileContent;
                fileContent = fileContent.ToLower();
            }
        }
        //private float LenghtSen(string)
        //{
        //    int size;
        //    return size;
        //}
        private void StartAnalyzeButtonClick(object sender, EventArgs e)
        {
            string[] sentences = Regex.Split(fileContent, @"(?<=[\.!\?])\s+", RegexOptions.IgnoreCase);
            var c = sentences.Select(n => n.Split(new char[] {'.', '!', '?' }) ).ToArray();
            var wordsForEachSentence = sentences.Select(input => Regex.Matches(input, @"\w+")
                    .Cast<Match>().Select(x => x.Value).Count()).ToArray();// кол-во слов, но здесь не учитываются дефисы т.е.  по-английски - 2 слова
            var wordsForEachSentence1 = sentences.Select(input => Regex.Matches(input, @"\w+-")
                    .Cast<Match>().Select(x => x.Value).Count()).ToArray();
            var wordsSyl = sentences.Select(input => Regex.Matches(input, @"[eyuioaуеыаоэяию]")
                    .Cast<Match>().Select(x => x.Value).Count()).ToArray();
            float ASL = sentences.Length / wordsForEachSentence.Count();
            float ASW; 
            label4.Text = sentences.Count().ToString();
            label6.Text = wordsForEachSentence.Count().ToString();
            label12.Text = wordsSyl.Count().ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

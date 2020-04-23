using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace MutatorProject
{
    public partial class Form1 : Form
    {
        public string getPathOneProgect;
        public bool WasProjectDonwload = false;
        public Project project;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
                DirectoryInfo dir = new DirectoryInfo(textBox2.Text);
                listBox1.Items.Add("Проверка каталога...");
                FileInfo[] files = dir.GetFiles("*.csproj");
                if (files.Length != 0 && files.Length == 1)
                {
                    listBox1.Items.Add("Загрузка решения прошла успешно");
                    getPathOneProgect += textBox2.Text + @"\\" + files[0];
                    WasProjectDonwload = true;
                    button2.Enabled = true;
                }
                else if (files.Length > 1)
                {
                    listBox1.Items.Add("Слишком много решенний в папкке! Выберите один!");
                    openFileDialog1.InitialDirectory = textBox2.Text;
                    openFileDialog1.Filter = "csproj files (*.csproj)| *.csproj";
                    openFileDialog1.FileName = "Выберите проект...";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        listBox1.Items.Add("Загрузка проекта прошла успешно");
                        getPathOneProgect = openFileDialog1.FileName;
                        WasProjectDonwload = true;
                        button2.Enabled = true;
                    }
                    else
                    {
                        listBox1.Items.Add("Произошла ошибка");
                        WasProjectDonwload = false;
                    }

                }
                else
                {
                    listBox1.Items.Add("Произошла ошибка");
                    WasProjectDonwload = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            new StartMutatorCore(getPathOneProgect);
            Run();
            
        }
        public void Run()
        {
            listBox1.Items.Add(StartMutatorCore.GetProjectsFiles());
            StartMutatorCore.ProjectAnalysis();
            foreach (var codeFile in StartMutatorCore.codes)
            {
                if (!codeFile.fn.Contains("AssemblyInfo"))
                    MutationChanger.BeginMutation(codeFile);
            }
                

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

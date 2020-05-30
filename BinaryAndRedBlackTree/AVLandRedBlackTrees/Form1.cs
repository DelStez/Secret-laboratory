using AVLandRedBlackTrees.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVLandRedBlackTrees
{
    public partial class Form1 : Form
    {
        public string key;
        public List<int> NodeList = new List<int>();
        public static double l = 50.0;
        public static List<string> UsesVertex = new List<string>();
        public BST bTree = new BST();
        public RBT rTree = new RBT();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            rTree.Insert(Convert.ToInt32(textBox1.Text));
            var spendtime = DateTime.Now - start;
            label11.Text = "Время: " + spendtime.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            rTree.Remove(Convert.ToInt32(textBox1.Text));
            var spendtime = DateTime.Now - start;
            label14.Text = "Время: " + spendtime.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var start = DateTime.Now;
            rTree.Find(Convert.ToInt32(textBox1.Text));
            var spendtime = DateTime.Now - start;
            label13.Text = "Время: " + spendtime.ToString();
        }
    }
}

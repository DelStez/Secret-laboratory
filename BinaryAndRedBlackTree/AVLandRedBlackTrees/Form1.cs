using AVLandRedBlackTrees.Core;
using AVLandRedBlackTrees.Core.AVL;
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
        public AVL aTree = new AVL();
        public RBT rTree = new RBT();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            //BST
            var start = DateTime.Now;
            bTree.Insert(Convert.ToInt32(textBox1.Text));
            var spendtime = DateTime.Now - start;
            label3.Text = "Время: " + spendtime.ToString();

            //AVL
            start = DateTime.Now;
            aTree.Add(Convert.ToInt32(textBox1.Text));
            spendtime = DateTime.Now - start;
            label23.Text = "Время: " + spendtime.ToString();

            //RBT
            start = DateTime.Now;
            rTree.Insert(Convert.ToInt32(textBox1.Text));
            spendtime = DateTime.Now - start;
            label11.Text = "Время: " + spendtime.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BST
            var start = DateTime.Now;
            bTree.Remove(Convert.ToInt32(textBox1.Text));
            var spendtime = DateTime.Now - start;
            label16.Text = "Время: " + spendtime.ToString();

            //AVL
            start = DateTime.Now;
            aTree.Remove(Convert.ToInt32(textBox1.Text));
            spendtime = DateTime.Now - start;
            label10.Text = "Время: " + spendtime.ToString();

            //RBT
            start = DateTime.Now;
            rTree.Remove(Convert.ToInt32(textBox1.Text));
            spendtime = DateTime.Now - start;
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
            //BST
            var start = DateTime.Now;
            bTree.find(Convert.ToInt32(textBox1.Text));
            var spendtime = DateTime.Now - start;
            label28.Text = "Время: " + spendtime.ToString();

            //AVL
            start = DateTime.Now;
            aTree.Find(Convert.ToInt32(textBox1.Text));
            spendtime = DateTime.Now - start;
            label26.Text = "Время: " + spendtime.ToString();

            //RBT
            start = DateTime.Now;
            rTree.Find(Convert.ToInt32(textBox1.Text));
            spendtime = DateTime.Now - start;
            label20.Text = "Время: " + spendtime.ToString();
        }
    }
}

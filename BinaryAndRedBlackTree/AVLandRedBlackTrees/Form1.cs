using AVLandRedBlackBSTs.Core;
using AVLandRedBlackTrees.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public Stopwatch sw = new Stopwatch();
        public static double l = 50.0;
        public static List<string> UsesVertex = new List<string>();
        public BST bTree = new BST();
        public AVL aTree = new AVL();
        public RBT rTree = new RBT();
        public List<double> times = new List<double>();
        public List<double> timesRemove = new List<double>();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add("Вершина " + textBox1.Text);
            //BST
            sw.Start();
            bTree.Insert(Convert.ToInt32(textBox1.Text));
            sw.Stop();
            TreeDraw bstTree = new TreeDraw(bTree);
            pictureBox1.Image = bstTree.Draw();
            label3.Text = "Время: " + (sw.ElapsedMilliseconds / 100.0).ToString();
            listBox2.Items.Add("BST: ");
            listBox2.Items.Add(label3.Text);

            //AVL
            sw.Start();
            aTree.Add(Convert.ToInt32(textBox1.Text));
            sw.Stop();
            TreeDraw avlTree = new TreeDraw(aTree);
            pictureBox3.Image = avlTree.Draw();
            label23.Text = "Время: " + (sw.ElapsedMilliseconds / 100.0).ToString();
            listBox2.Items.Add("AVL: ");
            listBox2.Items.Add(label23.Text);

            //RBT
            sw.Start();
            rTree.Add(Convert.ToInt32(textBox1.Text));
            sw.Stop();
            TreeDraw rbtDraw = new TreeDraw(rTree);
            pictureBox2.Image = rbtDraw.Draw();
            label11.Text = "Время: " + (sw.ElapsedMilliseconds / 100.0).ToString();
            listBox2.Items.Add("RBT: ");
            listBox2.Items.Add(label11.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Add("Вершина " + textBox1.Text);
            //BST
            sw.Start();
            bTree.Remove(Convert.ToInt32(textBox1.Text));
            sw.Stop();
            if (bTree.root != null)
            {
                TreeDraw bstTree = new TreeDraw(bTree);
                pictureBox1.Image = bstTree.Draw();
            }
            else
            {
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
            }
            label16.Text = "Время: " + (sw.ElapsedMilliseconds / 100.0).ToString();
            listBox3.Items.Add("BsT: ");
            listBox3.Items.Add(label16.Text);

            //AVL
            sw.Start();
            aTree.Remove(Convert.ToInt32(textBox1.Text));
            sw.Stop();
            if (aTree.root != null)
            {
                TreeDraw avlTree = new TreeDraw(aTree);
                pictureBox3.Image = avlTree.Draw();
            }
            else
            {
                pictureBox3.Image = null;
                pictureBox3.Invalidate();
            }
            label10.Text = "Время: " + (sw.ElapsedMilliseconds / 100.0).ToString();
            listBox3.Items.Add("AVL: ");
            listBox3.Items.Add(label10.Text);

            //RBT
            sw.Start();
            rTree.Remove(Convert.ToInt32(textBox1.Text));
            sw.Stop();
            if (rTree.root != null)
            {
                TreeDraw rbtDraw = new TreeDraw(rTree);
                pictureBox2.Image = rbtDraw.Draw();
            }
            else
            {
                pictureBox2.Image = null;
                pictureBox2.Invalidate();
            }
            label14.Text = "Время: " + (sw.ElapsedMilliseconds / 100.0).ToString();
            listBox3.Items.Add("RBT: ");
            listBox3.Items.Add(label14.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox4.Items.Add("Вершина "+textBox1.Text);
            //BST
            sw.Start();
            bTree.Find(Convert.ToInt32(textBox1.Text));
            sw.Stop();
            label28.Text = "Время: " + (sw.ElapsedMilliseconds / 100.0).ToString();
            listBox4.Items.Add("BST: ");
            listBox4.Items.Add(label28.Text);

            //AVL
            sw.Start();
            aTree.Find(Convert.ToInt32(textBox1.Text));
            sw.Stop();
            label26.Text = "Время: " + (sw.ElapsedMilliseconds / 100.0).ToString();
            listBox4.Items.Add("AVL: ");
            listBox4.Items.Add(label26.Text);

            //RBT
            sw.Start();
            rTree.Contains(Convert.ToInt32(textBox1.Text));
            sw.Stop();
            label20.Text = "Время: " + (sw.ElapsedMilliseconds / 100.0).ToString();
            listBox4.Items.Add("RBT: ");
            listBox4.Items.Add(label20.Text);
        }

        private void getData_Click(object sender, EventArgs e)
        {
            bTree = new BST();
            aTree = new AVL();
            rTree = new RBT();
            times = new List<double>();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            label3.Text = "Время: ";
            label10.Text = "Время: ";
            label11.Text = "Время: ";
            label14.Text = "Время: ";
            label16.Text = "Время: ";
            label20.Text = "Время: ";
            label26.Text = "Время: ";
            label23.Text = "Время: ";
            label28.Text = "Время: ";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

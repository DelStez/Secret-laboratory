using AVLandRedBlackBSTs.Core;
using AVLandRedBlackTrees.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVLandRedBlackTrees
{
    public partial class Form1 : Form
    {
        public string key;
        public static double l = 50.0;
        public static List<string> UsesVertex = new List<string>();
        public BST bTree = new BST();
        public AVL aTree = new AVL();
        public RBT rTree = new RBT();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Add(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                listBox2.Items.Add("Вершина " + textBox1.Text);
                //BST
                Stopwatch sw = new Stopwatch();
                sw.Start();
                string t = bTree.Insert(Convert.ToInt32(textBox1.Text));
                sw.Stop();
                TreeDraw bstTree = new TreeDraw(bTree);
                pictureBox1.Image = bstTree.Draw();
                listBox2.Items.Add("BST: ");
                if (t.Length > 0)
                    listBox2.Items.Add(t);
                else
                    label3.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";

                listBox2.Items.Add(label3.Text);

                //AVL
                sw = new Stopwatch();
                sw.Start();
                aTree.Add(Convert.ToInt32(textBox1.Text));
                sw.Stop();
                TreeDraw avlTree = new TreeDraw(aTree);
                pictureBox3.Image = avlTree.Draw();
                listBox2.Items.Add("AVL: ");
                if (t.Length > 0)
                    listBox2.Items.Add(t);
                else
                    label23.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                listBox2.Items.Add(label23.Text);

                //RBT
                sw = new Stopwatch();
                sw.Start();
                t = rTree.Add(Convert.ToInt32(textBox1.Text));
                sw.Stop();
                TreeDraw rbtDraw = new TreeDraw(rTree);
                pictureBox2.Image = rbtDraw.Draw();
                listBox2.Items.Add("RBT: ");
                if (t.Length > 0)
                    listBox2.Items.Add(t);
                else
                    label11.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                listBox2.Items.Add(label11.Text);
            }
        }

        private void Remove(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                listBox3.Items.Add("Вершина " + textBox1.Text);
                //BST
                Stopwatch sw = new Stopwatch();
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
                label16.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                listBox3.Items.Add("BsT: ");
                listBox3.Items.Add(label16.Text);

                //AVL
                sw = new Stopwatch();
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
                label10.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                listBox3.Items.Add("AVL: ");
                listBox3.Items.Add(label10.Text);

                //RBT
                sw = new Stopwatch();
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
                label14.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                listBox3.Items.Add("RBT: ");
                listBox3.Items.Add(label14.Text);
            }
        }

        private void Search(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                listBox4.Items.Add("Вершина " + textBox1.Text);
                //BST
                Stopwatch sw = new Stopwatch();
                sw.Start();
                bTree.Find(Convert.ToInt32(textBox1.Text));
                sw.Stop();
                label28.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                listBox4.Items.Add("BST: ");
                listBox4.Items.Add(label28.Text);

                //AVL
                sw = new Stopwatch();
                sw.Start();
                aTree.Find(Convert.ToInt32(textBox1.Text));
                sw.Stop();
                label26.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                listBox4.Items.Add("AVL: ");
                listBox4.Items.Add(label26.Text);

                //RBT
                sw = new Stopwatch();
                sw.Start();
                rTree.Contains(Convert.ToInt32(textBox1.Text));
                sw.Stop();
                label20.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                listBox4.Items.Add("RBT: ");
                listBox4.Items.Add(label20.Text);
            }
        }
        void Clear()
        {
            bTree = new BST();
            aTree = new AVL();
            rTree = new RBT();
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
        private void Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Plan(List<string> commands, List<int> nodes)
        {
            long AddBSt = 0;
            long AddRBT = 0; 
            long AddAVL = 0;
            long RBSt = 0;
            long RRBT = 0;
            long RAVL = 0;
            long SBSt = 0;
            long SRBT = 0;
            long SAVL = 0;
            for (int i = 0; i < commands.Count; i++)
            {
                if (commands[i].ToString() == "Add:")
                {
                    listBox2.Items.Add("Вершина " + nodes[i].ToString());
                    //BST
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    string t = bTree.Insert(Convert.ToInt32(nodes[i]));
                    sw.Stop();
                    TreeDraw bstTree = new TreeDraw(bTree);
                    pictureBox1.Image = bstTree.Draw();
                    listBox2.Items.Add("BST: ");
                    if (t.Length > 0)
                        listBox2.Items.Add(t);
                    label3.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                    AddBSt += sw.ElapsedTicks;

                    listBox2.Items.Add(label3.Text);

                    //AVL
                    sw = new Stopwatch();
                    sw.Start();
                    aTree.Add(Convert.ToInt32(nodes[i]));
                    sw.Stop();
                    TreeDraw avlTree = new TreeDraw(aTree);
                    pictureBox3.Image = avlTree.Draw();
                    listBox2.Items.Add("AVL: ");
                    if (t.Length > 0)
                        listBox2.Items.Add(t);
                    label23.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                    listBox2.Items.Add(label23.Text);
                    AddAVL += (sw.ElapsedTicks);

                    //RBT
                    sw = new Stopwatch();
                    sw.Start();
                    t = rTree.Add(Convert.ToInt32(nodes[i]));
                    sw.Stop();
                    TreeDraw rbtDraw = new TreeDraw(rTree);
                    pictureBox2.Image = rbtDraw.Draw();
                    listBox2.Items.Add("RBT: ");
                    if (t.Length > 0)
                        listBox2.Items.Add(t);
                    label11.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                    listBox2.Items.Add(label11.Text);
                    AddRBT += (sw.ElapsedTicks);
                }
                else if (commands[i].ToString() == "Remove:")
                {
                    listBox3.Items.Add("Вершина " + nodes[i].ToString());
                    //BST
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    bTree.Remove(Convert.ToInt32(nodes[i]));
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
                    label16.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                    listBox3.Items.Add("BsT: ");
                    listBox3.Items.Add(label16.Text);
                    RBSt += sw.ElapsedTicks;

                    //AVL
                    sw = new Stopwatch();
                    sw.Start();
                    aTree.Remove(Convert.ToInt32(nodes[i]));
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
                    label10.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                    listBox3.Items.Add("AVL: ");
                    listBox3.Items.Add(label10.Text);
                    RAVL += (sw.ElapsedTicks);

                    //RBT
                    sw = new Stopwatch();
                    sw.Start();
                    rTree.Remove(Convert.ToInt32(nodes[i]));
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
                    label14.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                    listBox3.Items.Add("RBT: ");
                    listBox3.Items.Add(label14.Text);
                    RRBT += (sw.ElapsedTicks);
                }
                else if (commands[i].ToString() == "Search:")
                {
                    listBox4.Items.Add("Вершина " + nodes[i].ToString());
                    //BST
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    bTree.Find(Convert.ToInt32(nodes[i]));
                    sw.Stop();
                    label28.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                    listBox4.Items.Add("BST: ");
                    listBox4.Items.Add(label28.Text);
                    SBSt += sw.ElapsedTicks;

                    //AVL
                    sw = new Stopwatch();
                    sw.Start();
                    aTree.Find(Convert.ToInt32(nodes[i]));
                    sw.Stop();
                    label26.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                    listBox4.Items.Add("AVL: ");
                    listBox4.Items.Add(label26.Text);
                    SAVL += (sw.ElapsedTicks);

                    //RBT
                    sw = new Stopwatch();
                    sw.Start();
                    rTree.Contains(Convert.ToInt32(nodes[i]));
                    sw.Stop();
                    label20.Text = "Время: " + (sw.ElapsedTicks).ToString() + " тактов";
                    listBox4.Items.Add("RBT: ");
                    listBox4.Items.Add(label20.Text);
                    SRBT += (sw.ElapsedTicks);
                }
            }
            listBox2.Items.Add("BST: " + AddBSt.ToString());
            listBox2.Items.Add("AVL: " + AddAVL.ToString());
            listBox2.Items.Add("RBT: " + AddRBT.ToString());
            listBox3.Items.Add("BST: " + RBSt.ToString());
            listBox3.Items.Add("AVL: " + RAVL.ToString());
            listBox3.Items.Add("RBT: " + RRBT.ToString());
            listBox4.Items.Add("BST: " + SBSt.ToString());
            listBox4.Items.Add("AVL: " + SAVL.ToString());
            listBox4.Items.Add("RBT: " + SRBT.ToString());
        }
        private void GetPlan(object sender, EventArgs e)
        {
            Clear();
            listBox1.Items.Clear();
            textBox1.Text = "";
            List<string> commands = new List<string>();
            List<int> nodes = new List<int>();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
                using(StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    string s = "";
                    while (s != null)
                    {
                        s = sr.ReadLine();
                        if (s == null) break;
                        listBox1.Items.Add(s);
                        List<string> temp = s.Split(' ').ToList();
                        commands.Add(temp[0]);
                        nodes.Add(Convert.ToInt32(temp[1]));
                        
                    }
                       
                }
                Plan(commands, nodes); 
            }
            
        }
    }
}

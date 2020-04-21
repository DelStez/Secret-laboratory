using System;
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
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string getkey = textBox1.Text;
            while (Encoding.UTF8.GetBytes(textBox7.Text).Length % 8 != 0)
            {
                textBox7.Text += " ";
            }
            string getmessage = textBox7.Text;
            new Core(getmessage, getkey);
            textBox6.Text = Core.Begin();
        }
    }
}

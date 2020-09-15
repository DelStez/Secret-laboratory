using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stegano_Bmp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public byte[,] rgbMatrixImage;
        public string contentCont = string.Empty;
        public string pathCont = string.Empty;
        public string fileLoadContetnt = string.Empty;
        public string fileLoadPath = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|png files (*.png)|*.png|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image j = Image.FromFile(openFileDialog1.FileName.ToString());
                LSB newImageMessage = new LSB(j);
            }
        }
    }
}

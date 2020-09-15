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

namespace Stegano_Bmp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Bitmap image;
        public string message = string.Empty;

        #region LoadFiles
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files(*.png,*.jpg) | *.png; *.jpg";
            fileDialog.InitialDirectory = @"C:\";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                image = (Bitmap)Image.FromFile(fileDialog.FileName.ToString());
                textBox1.Text = fileDialog.FileName;
                pictureBox1.Image = image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text files(*.txt) |*.txt";
            fileDialog.InitialDirectory = @"C:\";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(fileDialog.FileName))
                    message = sr.ReadToEnd();
                textBox2.Text = fileDialog.FileName;
                textBox3.Text = message;
            }
        }
        #endregion LoadFiles
        public void encodeImage()
        {
            LSB newImageMessage = new LSB(image, message);
            pictureBox1.Image = newImageMessage.insertTextToImage();

        }
        public void decodeImage()
        {
            LSB newImageMessage = new LSB(image);
            textBox3.Text = newImageMessage.ExtractMessage();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            encodeImage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            decodeImage();
        }
    }
}

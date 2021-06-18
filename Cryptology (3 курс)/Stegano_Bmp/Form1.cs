using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Stegano_Bmp
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }
        public Bitmap image;
        public string message = string.Empty;

        #region LoadFiles
        private void GetImage_Click(object sender, EventArgs e) //Загрузка изображения
        {
            OpenFileDialog fileDialog = new OpenFileDialog();// Диалог. окно - выбор файла
            fileDialog.Filter = "Image files(*.jpg, *.bmp, *.png, *.gif) | *.jpg; *.bmp; *.png; *.gif";//Фильтр форматов
            fileDialog.InitialDirectory = @"C:\"; // католог по умолчанию

            if (fileDialog.ShowDialog() == DialogResult.OK)// Если файл был выбран
            {
                image = (Bitmap)Image.FromFile(fileDialog.FileName.ToString());// Загрузить изображение из файла
                pathImage.Text = fileDialog.FileName;//показать путь файла
                pictureShow.Image = image;// загрузка изображения
            }
        }

        private void GetTXT_Click(object sender, EventArgs e)//Загрузка сообщения
        {
            OpenFileDialog fileDialog = new OpenFileDialog();// Диалог. окно - выбор файла
            fileDialog.Filter = "Text files(*.txt) |*.txt"; //Фильтр форматов
            fileDialog.InitialDirectory = @"C:\"; // католог по умолчанию

            if (fileDialog.ShowDialog() == DialogResult.OK) // Если файл был выбран
            {
                loadTXT(fileDialog.FileName);// вызов метода загрузки тхт файла
                pathFile.Text = fileDialog.FileName;
            }
        }
        private void loadTXT(string path)
        {
            using (StreamReader sr = new StreamReader(path)) //чтение из файла
                message = sr.ReadToEnd();// записавыаем в переменную
                messageShow.Text = message;// вывод содержимого
        } 
        #endregion LoadFiles
        public void encodeImage() // метод кодирования 
        {
            loadTXT(pathFile.Text);
            CheckSize();//проверка размера сообщения
            LSB newImageMessage = new LSB(image, message);// создания нового LSB - класса (содержит методы для кодировки LSB методом)
            pictureShow.Image = newImageMessage.insertTextToImage();// полученный результат сохраняется в изображение

        }
        public void decodeImage()
        {
            LSB newImageMessage = new LSB((Bitmap)pictureShow.Image);// оздания нового LSB - класса (содержит методы для декодировки LSB метода)
            string temp = newImageMessage.ExtractMessage((Bitmap)pictureShow.Image);
            messageShow.Text = temp.Replace("\0", "");// показать результат (немного отредактирован для читабельности)

        }
        public void CheckSize()
        {
            if(image.Height*image.Width < message.Length * 3)
            {
                MessageBox.Show("Размер сообщения превышает допустимое кол-во символов. Часть сообщения будет утраченно!");
                message = message.Substring(0, (image.Height * image.Width/3));// сокращение сообщения до подходящего размера
            }
        }
        private void Coder_Click(object sender, EventArgs e)
        {
            if (Checking())
            {
                encodeImage();// метод кодировки
                SaveFileDialog save = new SaveFileDialog();//диалог. окно -сохранение bmp файла
                save.Filter = "bitmap files(*.bmp) |*.bmp";
                save.InitialDirectory = @"C:\";
                if (save.ShowDialog() == DialogResult.OK)
                    pictureShow.Image.Save(save.FileName, ImageFormat.Bmp);// сохранение изображения
            }
        }

        private void Decoder_Click(object sender, EventArgs e)
        {
            if (pictureShow.Image != null)
            {
                decodeImage();// метод декодировки изображения
                SaveFileDialog save = new SaveFileDialog();// диалог. окно -сохранение тхт файла
                save.Filter = "Text files(*.txt) |*.txt";
                save.InitialDirectory = @"C:\";
                if (save.ShowDialog() == DialogResult.OK)
                     File.WriteAllText(save.FileName, messageShow.Text);// запись результата в файл
            }
            else
                MessageBox.Show("Нет изображения");
        }
        private bool Checking()//проверка файлов
        {
            if (pictureShow.Image == null)
            {
                MessageBox.Show("Нет изображения");
                return false;
            }
            else if (String.IsNullOrEmpty(pathFile.Text))
            {
                MessageBox.Show("Загрузите текст");
                return false;
            }
            else return true;
        }
    }
}

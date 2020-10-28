using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace ShannonFanoPicture
{
    public partial class Form1 : Form
    {


        public Form1()
        {

            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
        }
        public bool LZW = true;

        int maxByte = 0;
        int byteProcessed = 0;
        bool procesedFinished = false;
        string compressFile;

        delegate void SetTextCallback(string text, int type);
        public const int LBL_INFO = 1;
        public const int TXT_KOMPRES = 2;
        public const int TXT_KOMPRES_SIZE = 3;
        public const int TXT_KOMPRES_TIME = 4;
        public const int TXT_FILE_NAME = 5;
        public const int TXT_FILE_TYPE = 6;
        public const int TXT_FILE_SIZE = 7;


        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
            pctImage.Image = image;
            txtFile.Text = openFileDialog1.FileName;

            FileInfo fileinfo = new FileInfo(openFileDialog1.FileName);
            FileType type = fileinfo.GetFileType();
            lblInfo.Text = "";
            progressBar1.Value = 0;
        }

        private void SetText(string text, int type)
        {
            if (type == LBL_INFO)
            {
                lblInfo.Text = text;
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            while (procesedFinished == false)
            {
                backgroundWorker1.ReportProgress(byteProcessed);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            progressBar1.Value = e.ProgressPercentage;
        }

        private void btnDelompres_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
            {

                return;
            }

            if (txtSimpan.Text == "")
            {

                return;
            }

            if (new DirectoryInfo(txtSimpan.Text).Exists == false)
            {

                return;
            }

            SetTextCallback de = new SetTextCallback(SetText);
            System.Diagnostics.Stopwatch sWatch = new System.Diagnostics.Stopwatch();
            progressBar1.Visible = true;
            procesedFinished = false;
            maxByte = 0;
            byteProcessed = 0;
            progressBar1.Value = 0;
            string resultPath = txtSimpan.Text;
            string sfcFile = openFileDialog1.FileName.Substring(0, openFileDialog1.FileName.Length - 3);
            if (!File.Exists(sfcFile + ".sfc"))
            {
                return;
            }
            backgroundWorker1.RunWorkerAsync();
            Thread SFThread = new Thread(
                new ThreadStart(() =>
                {
                    sWatch.Start();

                    FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);
                    this.Invoke(de, new object[] { "Start dencoding " + fileInfo.Name, LBL_INFO });

                    compressFile = fileInfo.Name.Substring(0, fileInfo.Name.Length - 4);
                    Decoder decoder = new Decoder();
                    String sfc = File.ReadAllText(sfcFile + ".sfc");
                    decoder.SetSFCode(sfc);

                    byte[] encodingByte = File.ReadAllBytes(openFileDialog1.FileName);
                    int fileType = Convert.ToInt32(encodingByte[0]);
                    int width = 0;
                    int height = 0;
                    int widthLeng = Convert.ToInt32(encodingByte[1]);
                    int heightLeng = Convert.ToInt32(encodingByte[2]);
                    decoder.getResolution(ref width, ref height, widthLeng, heightLeng, encodingByte);
                    byte[] decodingByte = new byte[encodingByte.Length - (3 + widthLeng + heightLeng)];
                    Array.Copy(encodingByte, 3 + widthLeng + heightLeng, decodingByte, 0, decodingByte.Length);

                    File.WriteAllBytes("test.sf", decodingByte);
                    Bitmap decImage = decoder.Decoding(decodingByte.GetBinaryString(), width, height, ref byteProcessed);
                    String type = "";
                    if (fileType == SFCode.JPG)
                    {
                        decImage.Save(resultPath + "\\" + compressFile + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        type = resultPath + "\\" + compressFile + ".jpg";
                    }
                    else if (fileType == SFCode.GIF)
                    {
                        decImage.Save(resultPath + "\\" + compressFile + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
                        type = resultPath + "\\" + compressFile + ".gif";
                    }
                    else if (fileType == SFCode.PNG)
                    {
                        decImage.Save(resultPath + "\\" + compressFile + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        type = resultPath + "\\" + compressFile + ".png";
                    }

                    pctImage.Image = decImage;
                    sWatch.Stop();
                    procesedFinished = true;
                    fileInfo = new FileInfo(type);
                    this.Invoke(de, new object[] { fileInfo.Length + " Bytes", TXT_FILE_SIZE });
                    this.Invoke(de, new object[] { fileInfo.Name, TXT_FILE_NAME });
                    this.Invoke(de, new object[] { fileInfo.Extension, TXT_FILE_TYPE });
                    this.Invoke(de, new object[] { Math.Round(sWatch.Elapsed.TotalSeconds, 2).ToString() + " second", TXT_KOMPRES_TIME });
                    this.Invoke(de, new object[] { "", LBL_INFO });
                    MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
                }));
            SFThread.Start();

        }
        private void btnKompres_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
            {
                return;
            }

            if (txtSimpan.Text == "")
            {
                return;
            }

            if (new DirectoryInfo(txtSimpan.Text).Exists == false)
            {
                return;
            }

            maxByte = 0;
            byteProcessed = 0;
            progressBar1.Value = 0;
            SetTextCallback de = new SetTextCallback(SetText);
            System.Diagnostics.Stopwatch sWatch = new System.Diagnostics.Stopwatch();
            progressBar1.Visible = true;
            procesedFinished = false;
            backgroundWorker1.RunWorkerAsync();
            Thread SFThread = new Thread(
                    new ThreadStart(() =>
                    {
                        sWatch.Start();

                        Encoder encoder = new Encoder();
                        Bitmap image = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                        FileInfo info = new FileInfo(openFileDialog1.FileName);
                        string resultPath = txtSimpan.Text;

                        String encodingString = encoder.Encoding(image, ref byteProcessed);
                        byte[] encodingCode = ToByteArray(encodingString);
                        byte[] width = BitConverter.GetBytes(image.Width);
                        byte[] height = BitConverter.GetBytes(image.Height);
                        byte[] resultEncoding = new byte[encodingCode.Length + width.Length + height.Length + 3];
                        resultEncoding[0] = Convert.ToByte(checkImageType(info));
                        resultEncoding[1] = Convert.ToByte(width.Length);
                        resultEncoding[2] = Convert.ToByte(height.Length);
                        width.CopyTo(resultEncoding, 3);
                        height.CopyTo(resultEncoding, 3 + width.Length);
                        encodingCode.CopyTo(resultEncoding, 3 + width.Length + height.Length);

                        compressFile = info.Name.Substring(0, info.Name.Length - 4);
                        File.WriteAllBytes(resultPath + "\\" + compressFile + ".sf", resultEncoding);
                        File.WriteAllText(resultPath + "\\" + compressFile + ".sfc", encoder.GetSFCode());

                        sWatch.Stop();
                        procesedFinished = true;
                        this.Invoke(de, new object[] { info.Length + " Bytes", TXT_KOMPRES_SIZE });
                        this.Invoke(de, new object[] { compressFile + ".sf", TXT_KOMPRES });
                        this.Invoke(de, new object[] { Math.Round(sWatch.Elapsed.TotalSeconds, 2).ToString() + " second", TXT_KOMPRES_TIME });
                        this.Invoke(de, new object[] { "", LBL_INFO });
                    }));
                SFThread.Start();
        }

        public static byte[] ToByteArray(string value)
        {
            List<byte> l = new List<byte>();

            int i = 0;
            for (i = 0; i < value.Length; i += 8)
            {
                string bs = "";
                if (i + 8 <= value.Length)
                {
                    bs = value.Substring(i, 8);
                }
                else
                {
                    bs = value.Substring(i, value.Length - i);
                }

                byte b = Convert.ToByte(bs, 2);

                l.Add(b);
            }

            return l.ToArray();
        }
        private int checkImageType(FileInfo info)
        {
            FileType fileType = info.GetFileType();
            if (fileType.extension == "jpg")
            {
                return SFCode.JPG;
            }
            else if (fileType.extension == "png")
            {
                return SFCode.PNG;
            }
            else
            {
                return SFCode.GIF;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            DialogResult path = folderBrowserDialog1.ShowDialog();
            if (path == DialogResult.OK)
            {
                txtSimpan.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
    class SFCode
    {
        public byte Simbol { get; set; }
        public int Frekuensi { get; set; }
        public string Code { get; set; }

        public static int JPG = 1;
        public static int JPEG = 2;
        public static int PNG = 3;
        public static int GIF = 4;
    }
}

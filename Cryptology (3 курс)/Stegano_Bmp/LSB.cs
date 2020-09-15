using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace Stegano_Bmp
{
    public enum State 
    {
        Hiding,
        ZeroZone
    }
    public class LSB
    {
        public Bitmap bmp;
        public BitArray bits { get; set; }
        public int numberOfsymbols;
        public LSB(Bitmap image, string message)
        {
            this.bmp = new Bitmap(image);
            numberOfsymbols = message.Length;
            GetBitsOfMessage(message);

        }
        public LSB(Bitmap image)
        {
            this.bmp = new Bitmap(image);

        }
        public void GetBitsOfMessage(string message)
        {
            byte[] temp = Encoding.Default.GetBytes(message);
            bits = new BitArray(temp);
        }
        public Bitmap insertTextToImage()
        {
            int R, G, B;
            Bitmap bitmap = (Bitmap)bmp.Clone();
            int numberOfBits = bits.Length;
            int numberOfPixel = numberOfsymbols*3;
            int pixelCount = 0, bitCount = 0;
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    if (pixelCount < numberOfPixel)
                    {
                        Color pixel = bmp.GetPixel(i, j);
                        R = SetPixel(bits[bitCount], pixel.R);
                        bitCount++;
                        G = SetPixel(bits[bitCount], pixel.G);
                        bitCount++;
                        if ((bitCount % 8 != 0) || pixelCount == 0)
                        {
                            B = SetPixel(bits[bitCount], pixel.B);
                            bitCount++;
                        }
                        else
                        {
                            B = pixel.B;
                        }
                        bitmap.SetPixel(i, j, Color.FromArgb(R, G, B));
                        pixelCount++;
                    }
                }
            }
            return bitmap;
        }
        public string ExtractMessage()
        {
            char buf, bufOld = ' ';
            string result = string.Empty, temp;
            int j = 0;
            for (int i = 0; i < bmp.Height; i++)
            {
                
                for (j = 0; j < bmp.Width; j+=3)
                {
                    temp = "";
                    buf = GetLetter(i,j);
                    result += buf;
                    temp = String.Concat(bufOld, buf);
                    bufOld = buf;
                    if(String.Compare(temp, "\\0") == 0) { return result; }
                }
                if (j - bmp.Height == 0)
                {
                    for (j = 1; j < bmp.Height; j += 3)
                    {
                        temp = "";
                        buf = GetLetter(i, j);
                        result += buf;
                        temp = String.Concat(bufOld, buf);
                        if (String.Compare(temp, "\\0") == 0) return result;

                    }
                }
                if (j - bmp.Height == 1)
                {
                    for (j = 2; j < bmp.Height; j += 3)
                    {
                        temp = "";
                        buf = GetLetter(i, j);
                        result += buf;
                        temp = String.Concat(bufOld, buf);
                        if (String.Compare(temp, "\\0") == 0) return result;

                    }
                }
            }
            return result;
            
        }

        private char GetLetter(int i, int j)
        {
            char letter;
            int pixelCount = 0;
            int[] bitArray = new int[8];
            int count = 0;
            if (j < bmp.Height - 2)
            {
                for (int k = 0; k < 3; k++)
                {
                    Color pixel = bmp.GetPixel(i, j + k);
                    bitArray[count] = GetBitfromPixel(pixel.R);
                    count++;
                    bitArray[count] = GetBitfromPixel(pixel.G);
                    count++;
                    if (k != 2)
                    {
                        bitArray[count] = GetBitfromPixel(pixel.B);
                        count++;
                    } 
                }
            }
            else if (bmp.Height - j == 2)
            {
                Color pixel = bmp.GetPixel(i, j);

                bitArray[count] = GetBitfromPixel(pixel.R);
                count++;
                bitArray[count] = GetBitfromPixel(pixel.G);
                count++;
                bitArray[count] = GetBitfromPixel(pixel.B);
                count++;

                Color pixel2 = bmp.GetPixel(i, j + 1);

                bitArray[count] = GetBitfromPixel(pixel2.R);
                count++;
                bitArray[count] = GetBitfromPixel(pixel2.G);
                count++;
                bitArray[count] = GetBitfromPixel(pixel2.B);
                count++;

                Color pixel3 = bmp.GetPixel(i + 1, 0);

                bitArray[count] = GetBitfromPixel(pixel3.R);
                count++;
                bitArray[count] = GetBitfromPixel(pixel3.G);
                count++;
            }
            else if (bmp.Height - j == 1)
            {
                Color pixel = bmp.GetPixel(i, j);

                bitArray[count] = GetBitfromPixel(pixel.R);
                count++;
                bitArray[count] = GetBitfromPixel(pixel.G);
                count++;
                bitArray[count] = GetBitfromPixel(pixel.B);
                count++;

                Color pixel2 = bmp.GetPixel(i + 1, 0);

                bitArray[count] = GetBitfromPixel(pixel2.R);
                count++;
                bitArray[count] = GetBitfromPixel(pixel2.G);
                count++;
                bitArray[count] = GetBitfromPixel(pixel2.B);
                count++;

                Color pixel3 = bmp.GetPixel(i + 1, 1);

                bitArray[count] = GetBitfromPixel(pixel3.R);
                count++;
                bitArray[count] = GetBitfromPixel(pixel3.G);
                count++;

            }
            byte b = (byte)((bitArray[0] << 7)
          | (bitArray[1] << 6)
          | (bitArray[2] << 5)
          | (bitArray[3] << 4)
          | (bitArray[4] << 3)
          | (bitArray[5] << 2)
          | (bitArray[6] << 1)
          | (bitArray[7] << 0));

            letter = Convert.ToChar(b);
            return letter;
        }
        private int GetBitfromPixel(int currentPix)
        {
            int temp = 0;
            temp = currentPix | 0xFE;
            return temp;
        }
        private int SetPixel(bool currentBit, int pixel)
        {
            int newPixel;
            if (currentBit)
                newPixel = pixel | 0x01;
            else
                newPixel = pixel | 0xFE;
            return newPixel;
        }
    }
}

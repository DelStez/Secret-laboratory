using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.IO.Ports;

namespace Stegano_Bmp
{
    public class LSB
    {
        public Bitmap bmp;
        public BitArray bits { get; set; }
        public int numberOfSymbols;
        public LSB(Bitmap image, string message)
        {
            this.bmp = new Bitmap(image);
            numberOfSymbols = message.Length;
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
            Bitmap bitmap = (Bitmap)bmp.Clone();//Клонируем изображение
            int numberOfPixels = numberOfSymbols * 3; //Каждый символ занимает 3 пискеля, получаем кол-во необходимых пикселей
            int pixelCount = 0, bitCount = 0; //счетчики битов сообщения и пикселей изображения
            bool getAllNeedPixel = false; // булевая переменная, необходимая для выхода из внешнего цикла
            //С помощью циклов проходим по изображению (по пикселям)
            for (int i = 0; i < bmp.Height; i++)
            {
                if (getAllNeedPixel) break; //Если сообщение уже закодированно, то прекращаем проход по изображению
                for (int j = 0; j < bmp.Width; j++)
                {
                    if (pixelCount != numberOfPixels)
                    {
                        Color pixel = bmp.GetPixel(i, j); // получем текущий пиксель по координате
                        //Далее в каждый цвет. код влаживаем бит сообщения
                        R = SetPixel(bits[bitCount], pixel.R);
                        bitCount++; // увеличиваем счетчик - получаем бит следующий сообщения
                        G = SetPixel(bits[bitCount], pixel.G);
                        bitCount++;
                        //Так как каждый символ - занимает 8 битов, то он может занять полных 2 пикселя (6 бит) + пиксель с последним не изменяемым 
                        //кодом цвета (3 бита - 2 из которых ушло на хранение битов сообщения). Каждый девятный бит переходит в следующую тройку пикселей
                        if (bitCount % 8 != 0)
                        {
                            B = SetPixel(bits[bitCount], pixel.B);
                            bitCount++;
                        }
                        else
                            B = pixel.B;
                        bitmap.SetPixel(i,j, Color.FromArgb(R,G,B));
                        pixelCount++;
                    }
                    else
                    {
                        getAllNeedPixel = true;
                        break;
                    }
                }
            }
            return bitmap;
        }
        public string ExtractMessage(Bitmap bmpCry)
        {
            char newChar, oldChar = ' ';
            string result = string.Empty, buf;
            int bitCount = 0, bit;
            List<int> messBits = new List<int>();
            //int j = 0;
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);
                    bit = GetBitfromPixel(pixel.R);
                    messBits.Add(bit);
                    bitCount++;
                    bit = GetBitfromPixel(pixel.G);
                    messBits.Add(bit);
                    bitCount++;
                    if (bitCount % 8 != 0)
                    {
                        bit = GetBitfromPixel(pixel.B);
                        messBits.Add(bit);
                        bitCount++;
                    }
                    //temp = "";
                    //buf = GetLetter(i, j);
                    //result += buf;
                    //temp = String.Concat(bufOld, buf);
                    //bufOld = buf;
                    //if (String.Compare(temp, "\\0") == 0) { return result; }
                }
                
                //if (j - bmp.Width == 0)
                //{
                //    for (j = 1; j < bmp.Height; j += 3)
                //    {
                //        temp = "";
                //        buf = GetLetter(i, j);
                //        result += buf;
                //        temp = String.Concat(bufOld, buf);
                //        if (String.Compare(temp, "\\0") == 0) return result;

                //    }
                //}
                //if (j - bmp.Width == 1)
                //{
                //    for (j = 2; j < bmp.Width; j += 3)
                //    {
                //        temp = "";
                //        buf = GetLetter(i, j);
                //        result += buf;
                //        temp = String.Concat(bufOld, buf);
                //        if (String.Compare(temp, "\\0") == 0) return result;

                //    }
                //}
            }
            BitArray n = new BitArray(messBits.ToArray());
            byte[] n2 = new byte[n.Length/8];
            n.CopyTo(n2, 0);
            result = Encoding.Default.GetString(n2);
            return result;
            
        }

        private char GetLetter(int i, int j)
        {
            char letter;
            int pixelCount = 0;
            int[] bitArray = new int[8];
            int count = 0;
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
            BitArray bitspixel = new BitArray(new int[] {currentPix});
            return Convert.ToInt32(bitspixel[7]);

        }

        // оператор "|" - логическое ИЛИ 
        // на вход функции получаем значение бита и номер цвета пиксиля (R, G или B)
        private int SetPixel(bool currentBit, int pixel)
        {
            int newPixel;
            if (currentBit)// если значение бита = 1
                newPixel = pixel | 0x01; // 0x01 - 00000001 -> последние значение бита цвета, если равен нулю - изменится     
            else
                newPixel = pixel | 0xFE; // 0xFE - 11111110 -> последние значение бита цвета, если неравен нулю - изменится
            return newPixel;
        }
    }
}

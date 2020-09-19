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
            for (int i = 0; i < bmp.Height-1; i++)
            {
                if (getAllNeedPixel) break; //Если сообщение уже закодированно, то прекращаем проход по изображению
                for (int j = 0; j < bmp.Width-1; j++)
                {
                    if (pixelCount != numberOfPixels)
                    {
                        Color pixel = bmp.GetPixel(j, i); // получем текущий пиксель по координате
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
                        bitmap.SetPixel(j,i, Color.FromArgb(pixel.A,R,G,B));
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
            List<bool> messBits = new List<bool>();
            //int j = 0;
            for (int i = 0; i < bmp.Height - 1; i++)
            {
                for (int j = 0; j < bmp.Width - 1; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);
                    bit = GetBitfromPixel(pixel.R);
                    messBits.Add(Convert.ToBoolean(bit));
                    bitCount++;
                    bit = GetBitfromPixel(pixel.G);
                    messBits.Add(Convert.ToBoolean(bit));
                    bitCount++;
                    if (bitCount % 8 != 0)
                    {
                        bit = GetBitfromPixel(pixel.B);
                        messBits.Add(Convert.ToBoolean(bit));
                        bitCount++;
                    }
                }
            }
            //messBits.Reverse();
            BitArray n = new BitArray(messBits.ToArray());
            byte[] n2 = new byte[n.Length];
            n.CopyTo(n2, 0);
            result = Encoding.Default.GetString(n2);
            return result;
            
        }
        private int GetBitfromPixel(int currentPix)
        {
            
           
            BitArray n = new BitArray(new int[] { currentPix });
            BitArray t = new BitArray(new int[] { 0xFE});
            var array = n.Xor(t);
            return Convert.ToInt32(n[0]);
        }

        private int SetPixel(bool currentBit, int pixel)
        {
            int newPixel;
            BitArray n = new BitArray( new int[] {pixel} );
            if (currentBit)// если значение бита = 1
                n[0] = true;
            else
                n[0] = false;
            int[] y = new int[1];
            n.CopyTo(y,0);
            return y[0];
        }
    }
}

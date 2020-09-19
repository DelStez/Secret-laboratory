using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
namespace Stegano_Bmp
{
    public class LSB
    {
        public Bitmap bmp; // изображение
        public BitArray bits { get; set; } // Битовый массив сообщения
        public int numberOfSymbols;// кол-во сиволов
        public LSB(Bitmap image, string message) //передача данных в текущий класс (режим кодирования)
        {
            this.bmp = new Bitmap(image);
            numberOfSymbols = message.Length;
            GetBitsOfMessage(message);// получение битового массива сообщения

        }
        public LSB(Bitmap image)//передача данных в текущий класс (режим декодирования)
        {
            this.bmp = new Bitmap(image);
        }
        public void GetBitsOfMessage(string message) // получение битового массива сообщения
        {
            byte[] temp = Encoding.Default.GetBytes(message); //перевод в массив байтов
            bits = new BitArray(temp); // перевод в массив битов
        }
        public Bitmap insertTextToImage() // LSB -кодировние
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
                        bitmap.SetPixel(j,i, Color.FromArgb(pixel.A,R,G,B)); // "перезапись" пикселя с новыми данными по каждому цвету
                        pixelCount++;// увеличиваем счетчик пикселей
                    }
                    else // выход из цикла
                    {
                        getAllNeedPixel = true;
                        break;
                    }
                }
            }
            return bitmap; // возвращаем результат
        }
        public string ExtractMessage(Bitmap bmpCry) // Декодировка всего изображения
        {
            string result = string.Empty;
            int bitCount = 0, bit; // счётчик и переменая для сохранение каждого бита отдельно (временная переменная)
            List<bool> messBits = new List<bool>();//Список булевых значений, здесь будут храниться значения битов
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);// получение пикселя
                    bit = GetBitfromPixel(pixel.R);// вызов метода для получение последнего бита
                    messBits.Add(Convert.ToBoolean(bit));//запоминаем бит
                    bitCount++;
                    bit = GetBitfromPixel(pixel.G);
                    messBits.Add(Convert.ToBoolean(bit));
                    bitCount++;
                    if (bitCount % 8 != 0) // каждый "пустой" бит пропускается
                    {
                        bit = GetBitfromPixel(pixel.B);
                        messBits.Add(Convert.ToBoolean(bit));
                        bitCount++;
                    }
                }
            }
            BitArray n = new BitArray(messBits.ToArray()); // булевый список в битовый массив
            byte[] n2 = new byte[n.Length]; //массив байтов
            n.CopyTo(n2, 0); //перевод в байты
            result = Encoding.Default.GetString(n2);// байты в строку
            return result;
            
        }
        private int GetBitfromPixel(int currentPix)
        {
            BitArray n = new BitArray(new int[] { currentPix });// битовое представление пикселя
            // так как битовый массив хранит биты в дргугом порядке в отличии от привычного порядка
            // Пример  число 2 - 00010 (привычный порядок), в битовом массиве - реверс т.е. 01000
            // последний бит - первый бит в массиве
            return Convert.ToInt32(n[0]);
        }

        private int SetPixel(bool currentBit, int pixel)
        {
            BitArray n = new BitArray( new int[] {pixel} ); // битовое представление пикселя
            // так как битовый массив хранит биты в дргугом порядке в отличии от привычного порядка
            // Пример  число 2 - 00010 (привычный порядок), в битовом массиве - реверс т.е. 01000
            // последний бит - первый бит в массиве
            if (currentBit)// если значение бита = 1
                n[0] = true;
            else
                n[0] = false;
            int[] y = new int[1]; //получаем значение  пикселя в привычном виде (натурального числа)
            n.CopyTo(y,0);
            return y[0];
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;

namespace PinGenerator
{
    public partial class MainForm : Form
    {
        Encoding asciCode = Encoding.ASCII;
        ///------ Работа с формой------///
        public MainForm()
        {
            InitializeComponent();
            comboBoxLen.SelectedIndex = 0;
        }

        private void numberClient_KeyPress(object sender, KeyPressEventArgs e) //Запрет на ввод посторонних символов (Только цифры)
        {
            if (Char.IsNumber(e.KeyChar)
                || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void GenButton_Click(object sender, EventArgs e)
        {
            if (numberClient.Text.Length == 16  )
            {
                BitArray arr = Generation(numberClient.Text, comboBoxLen.SelectedIndex);
                GetPin(arr);
            }
            else if(numberClient.Text.Length < 16 && numberClient.Text.Length > 0)
                MessageBox.Show("Длина PAN-номер меньше 16!");
            else
                MessageBox.Show("Введите PAN-номер");
        }
        ///------Генерация-------///
        BitArray Generation(string number, int size)
        {
            BitArray numberClient = new BitArray(getFull(number));//получение номера
            BitArray randomNumber = new BitArray(GetRandomKey());//получение псевдослучайного числа
            BitArray resultXor = numberClient.Xor(randomNumber);//сложение по модулю 2, или операция
            BitArray n = new BitArray(EncryptDes(BitArrayToByteArray(resultXor), BitArrayToByteArray(numberClient))); // DES
            return n;
        }
        void GetPin(BitArray currentArr) //получение цифр пинкода
        {
            string h = "";
            bool[] t = new bool[currentArr.Length];
            currentArr.CopyTo(t,0);
            List<int> unusedVal = new List<int>();
            for (int i = 0, j= 0; i < currentArr.Count; i += 4)//выбираема блоки
            {
                int temp = NumberCheck(t.Skip(i).Take(4).ToArray());//получаем число
                if (temp < 10)// выбираем только цифры от 0 до 9 (включительно)
                    h += temp.ToString();
                else
                    unusedVal.Add(temp - 10);//получаем не использованнае числа
                if (h.Length == Convert.ToInt32(comboBoxLen.SelectedItem))//если мы получили достаточно цифр - выходим
                    break;
            }
            int x = 0;
            while (h.Length != Convert.ToInt32(comboBoxLen.SelectedItem) && x != unusedVal.Count) //если мы получили достаточно цифр - вывод результа
            {
                h += unusedVal[x].ToString(); //иначе выбираем из неиспользованных блоков
                x++;
            }
            PinBox.Text = h;//выод результата
        }
        int NumberCheck(bool[] current)//перевод из двоичной в десятичную
        {
            char[] temp = new char[current.Length];

            for (int i = 0; i < current.Length; i++)
            {
                if (current[i] == true)
                    temp[i] = '1';
                else
                    temp[i] = '0';
            }

            string str = new string(temp);
            int caseNum = System.Convert.ToInt32(str,2);
            return caseNum;
        }
        byte[] GetRandomKey()
        {
            Random r = new Random();
            int number = r.Next(0, 1000);//генерация числа
            return getFull(number.ToString());
        }

        byte[] getFull(string number)//Добавление нулей в полседовательность
        {
            byte[] result = new byte[8];//создаём пустой массив с нулями
            int[] intArr = number.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();//перевод последовательности цифр в массив
            return GetRow(result, intArr);
        }
        byte[] GetRow(byte[] result, int[] intArr)//заполнение массива
        {
            for (int i = 0,j = 0; i < intArr.Length; i+=2, j++)
            {
                int t = (intArr.Length % 2 != 0 && i == intArr.Length-1) ? 0 : intArr[i + 1];
                result[j] = (byte)Convert.ToInt32(intArr[i].ToString() + t);
            }
            return result;
        }

        
        static byte[] EncryptDes(byte[] key, byte[] plain )//DES
        {
            DES des = new DESCryptoServiceProvider();
            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream encStream = new CryptoStream(msEncrypt, des.CreateEncryptor(plain, key ), CryptoStreamMode.Write);//Шифрование
            encStream.Write(plain, 0, 0);
            encStream.Close();
            byte[] result = msEncrypt.ToArray();//результат шифрования
            return result;

        }
        public static byte[] BitArrayToByteArray(BitArray bits)//Перевод масива битов в массив байтов
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }

    }
}

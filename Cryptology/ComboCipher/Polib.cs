using System;
using System.Linq;


namespace ComboCipher
{
    class Polib: Cipher
    {
        int size;
        string message;
        static char[,] alphabet = {
                                   {'А', 'Б', 'В', 'Г', 'Д', 'Е',},
                                   {'Ё','Ж', 'З', 'И', 'Й', 'К'},
                                   {'Л','М', 'Н', 'О', 'П', 'Р'},
                                   {'С','Т', 'У', 'Ф', 'Х', 'Ц'},
                                   {'Ч','Ш', 'Щ', 'Ъ', 'Ы', 'Ь'},
                                   {'Э','Ю', 'Я', ',', '.', ' '}
            };

        public override string Encrypt(string opentext = "", object key = null)
        {
            string codeOneLevel = "";
            foreach (char ch in opentext)
            {
                for (int i = 0; i < alphabet.GetLength(0); i++)
                {
                    for (int j = 0; j < alphabet.GetLength(1); j++)
                    {
                        if (alphabet[i, j] == ch)
                        {
                            codeOneLevel += ((i + 1).ToString() + (j + 1).ToString() + " ");
                        }
                    }
                }
            }
            return codeOneLevel;
        }
        public override string Decrypt(string cipherText = "", object key = null)
        {
            string result = "";
            string[] inputArray = cipherText.Split(' ').ToArray();

            for (int i = 0; i < inputArray.Length; i++)
            {
                string temp = inputArray[i].ToString();
                if (temp != "") 
                {
                    int indexFirst = Convert.ToInt32(temp[0].ToString()) - 1;
                    int indexSecond = Convert.ToInt32(temp[1].ToString()) - 1;
                    char t = alphabet[indexFirst, indexSecond];
                    result += t;
                }
                
            }
            return result;
        }
    }
}

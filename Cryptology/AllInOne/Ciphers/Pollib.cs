using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Ciphers
{
    class Pollib: Cipher
    {
        char[,] alpha;
        public Pollib(char[,] alphabet)
        {
            alpha = alphabet;
        }
        
        public override string Encrypt(string opentext, object key = null)
        {
            string codeOneLevel = "";
            foreach (char ch in opentext)
            {
                for (int i = 0; i < alpha.GetLength(0); i++)
                {
                    for (int j = 0; j < alpha.GetLength(1); j++)
                    {
                        if (alpha[i, j] == ch)
                        {
                            codeOneLevel += ((i + 1).ToString() + (j + 1).ToString() + " ");
                        }
                    }
                }
            }
            return codeOneLevel;
        }
        public override string Decrypt(string cipherText, object key = null)
        {
            string result = "";
            string[] inputArray = cipherText.Split(' ').ToArray();

            for (int i = 0; i < inputArray.Length; i++)
            {
                string temp = inputArray[i].ToString();
                int indexFirst = Convert.ToInt32(temp[0].ToString()) - 1;
                int indexSecond = Convert.ToInt32(temp[1].ToString()) - 1;
                char t = alpha[indexFirst, indexSecond];
                result += t;
            }
            return result;
        }
    }
}

using System;
using System.Linq;

namespace ComboCipher
{
    class DoubleRearrangement: Cipher
    {
        public override string Encrypt(string opentext = "", object key = null)
        {
            string[] keysPart = key.ToString().Split(' ').ToArray();
            string[] messageArray = opentext.ToString().Split(' ').ToArray();
            string[,] code = new string[keysPart[0].Length, keysPart[1].Length];
            int counterMessage = 0;
            for (int i = 0; i < keysPart[0].Length; i++)
            {
                for (int j = 0; j < keysPart[1].Length; j++, counterMessage++)
                { 
                    code[i, j] = (counterMessage < messageArray.Length) ?messageArray[counterMessage]: "_";
                }

            }
            string[,] newcode = new string[keysPart[0].Length, keysPart[1].Length];
            for (int i = 0; i < keysPart[1].Length; i++)
            {
                for (int j = 0; j < keysPart[0].Length; j++)
                {
                    int index1 = Convert.ToInt32(keysPart[1].ToString()[i].ToString()) - 1;
                    int index2 = Convert.ToInt32(keysPart[0].ToString()[j].ToString()) - 1;
                    newcode[index2, index1] = code[i, j];
                }

            }
            string getResult = String.Empty;
            for (int i = 0; i < keysPart[1].Length; i++)
            {
                for (int j = 0; j < keysPart[0].Length; j++)
                {

                    getResult += newcode[i, j]+ " ";
                }
                
            }
            return getResult;
        }
        public override string Decrypt(string opentext = "", object key = null)
        {
            string[] keysPart = key.ToString().Split(' ').ToArray();
            string[] messageArray = opentext.ToString().Split(' ').ToArray();
            string[,] code = new string[keysPart[0].Length, keysPart[1].Length];
            int counterMessage = 0;
            for (int i = 0; i < keysPart[0].Length; i++)
            {
                for (int j = 0; j < keysPart[1].Length; j++, counterMessage++)
                {
                    code[i, j] = messageArray[counterMessage];
                }

            }
            string[,] decode = new string[keysPart[0].Length, keysPart[1].Length];
            for (int i = 0; i < keysPart[1].Length; i++)
            {
                for (int j = 0; j < keysPart[0].Length; j++)
                {
                    int index1 = Convert.ToInt32(keysPart[1].ToString()[i].ToString()) - 1;
                    int index2 = Convert.ToInt32(keysPart[0].ToString()[j].ToString()) - 1;
                    decode[j, i] = code[index2, index1];
                }

            }
            string getResult = String.Empty;
            for (int i = 0; i < keysPart[1].Length; i++)
            {
                for (int j = 0; j < keysPart[0].Length; j++)
                {

                    getResult += decode[j, i] + " ";
                }

            }
            return getResult.Replace("_","");

        }

    }
}

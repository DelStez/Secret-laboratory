using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Ciphers
{
    class Playfer:Cipher
    {
        string key;

        public Playfer(string alphabet)
        {
            
            textAlphabet = alphabet.ToUpper().Replace(" ", "").Replace("Ь", "");
        }

        public override string Encrypt(string message, object key)
        {
            Func<string[,], int[], int[], string> getPair = GetEncryptionPair;

            return CipherHelper(message, getPair);
        }

        public override string Decrypt(string message, object key)
        {
            Func<string[,], int[], int[], string> getPair = GetDecryptionPair;

            return CipherHelper(message, getPair);
        }

        private string CipherHelper(string Message, Func<string[,], int[], int[], string> GetPair)
        {
            var alphabetMatrix = CreateAlphabetDynamicMatrix();
            var bigrams = CreateBigrams(Message);

            var returnMessage = "";

            var fIndex = new int[] { 0, 0 };
            var sIndex = new int[] { 0, 0 };

            foreach (var bigram in bigrams)
            {
                fIndex = GetIndexFromMatrix(alphabetMatrix, bigram.firstChar);
                sIndex = GetIndexFromMatrix(alphabetMatrix, bigram.lastChar);

                returnMessage += GetPair(alphabetMatrix, fIndex, sIndex);
            }

            return returnMessage;
        }
        private string GetDecryptionPair(string[,] alphabetMatrix, int[] firstCharIndexes, int[] secondCharIndexes)
        {
            string pair = "";

            if (firstCharIndexes[0] == secondCharIndexes[0])
            {
                pair += alphabetMatrix[
                    firstCharIndexes[0],
                      ((firstCharIndexes[1] - 1 + alphabetMatrix.GetLength(1)) % alphabetMatrix.GetLength(1))];

                pair += alphabetMatrix[
                    secondCharIndexes[0],
                      ((secondCharIndexes[1] - 1 + alphabetMatrix.GetLength(1)) % alphabetMatrix.GetLength(1))];
            }
            else if (firstCharIndexes[1] == secondCharIndexes[1])
            {
                pair += alphabetMatrix[
                 ((firstCharIndexes[0] - 1 + alphabetMatrix.GetLength(0)) % alphabetMatrix.GetLength(0)),
                    firstCharIndexes[1]];


                pair += alphabetMatrix[
                ((secondCharIndexes[0] - 1 + alphabetMatrix.GetLength(0)) % alphabetMatrix.GetLength(0)),
                    secondCharIndexes[1]];
            }
            else
            {
                pair += alphabetMatrix[
                   firstCharIndexes[0],
                   secondCharIndexes[1]];

                pair += alphabetMatrix[
                    secondCharIndexes[0],
                    firstCharIndexes[1]];
            }

            return pair;
        }
        private string GetEncryptionPair(string[,] alphabetMatrix, int[] firstCharIndexes, int[] secondCharIndexes)
        {
            string pair = "";

            if (firstCharIndexes[0] == secondCharIndexes[0])
            {
                pair += alphabetMatrix[
                 firstCharIndexes[0],
                   ((firstCharIndexes[1] + 1) % alphabetMatrix.GetLength(1))];

                pair += alphabetMatrix[
                    secondCharIndexes[0],
                      ((secondCharIndexes[1] + 1) % alphabetMatrix.GetLength(1))];
            }

            else if (firstCharIndexes[1] == secondCharIndexes[1])
            {
                pair += alphabetMatrix[
                 ((firstCharIndexes[0] + 1) % alphabetMatrix.GetLength(0)),
                    firstCharIndexes[1]];

                pair += alphabetMatrix[
                ((secondCharIndexes[0] + 1) % alphabetMatrix.GetLength(0)),
                    secondCharIndexes[1]];
            }

            else
            {
                pair += alphabetMatrix[
                   firstCharIndexes[0],
                   secondCharIndexes[1]];

                pair += alphabetMatrix[
                    secondCharIndexes[0],
                    firstCharIndexes[1]];
            }

            return pair;
        }

        private int[] GetIndexFromMatrix(string[,] matrix, string letter)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == letter)
                        return new int[] { i, j };
                }
            }
            return new int[] { 0, 0 };
        }

        private IEnumerable<Bigram> CreateBigrams(string normalMessage)
        {
            normalMessage = normalMessage.ToUpper();
            var temp = new List<Bigram>();

            for (int i = 0; i < normalMessage.Length; i += 2)
            {
                if (i == normalMessage.Length - 1)
                {
                    temp.Add(new Bigram()
                    {
                        firstChar = normalMessage[i].ToString(),
                        lastChar = "х"
                    });
                }
                else if (normalMessage[i] == normalMessage[i + 1])
                {
                    temp.Add(new Bigram()
                    {
                        firstChar = normalMessage[i].ToString(),
                        lastChar = "х"
                    });
                    i--;
                }
                else
                {
                    temp.Add(new Bigram()
                    {
                        firstChar = normalMessage[i].ToString(),
                        lastChar = normalMessage[i + 1].ToString()
                    });
                }
            }

            return temp;
        }

        private string[,] CreateAlphabetDynamicMatrix()
        {
            var let = (key + textAlphabet).Select(x => x.ToString()).Distinct().ToArray();

            var alphabetMatrix = new string[5, 6];

            var temp_index = 0;

            for (int i = 0; i < alphabetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < alphabetMatrix.GetLength(1); j++)
                {
                    alphabetMatrix[i, j] = let[temp_index];
                    temp_index++;
                }
            }

            return alphabetMatrix;
        }

        private class Bigram
        {
            public string firstChar { get; set; }
            public string lastChar { get; set; }

            public override string ToString()
            {
                return firstChar + " " + lastChar;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Ciphers
{
    class Vertical:Cipher
    {
        public Vertical(string key )
        {
            keyType = key;
        }
        public override string Encrypt(string message = "", object key = null)
        {
            string output = String.Empty;
            message = message.ToUpper();
            string keyVert = (keyType.Split(' ').ToArray())[1];
            string keyHoriz = (keyType.Split(' ').ToArray())[0];
            char[,] matrix = new char[keyHoriz.Length, keyVert.Length];
            for (int i = 0; i < keyHoriz.Length; i++)
                for (int j = 0; j < keyVert.Length; j++)
                {
                    matrix[i, j] = message[i* keyVert.Length + j];
                }
            return output; 
        }
        public override string Decrypt(string mess = "", object key = null)
        {
            string output = String.Empty;
            return output;
        }

    }
}

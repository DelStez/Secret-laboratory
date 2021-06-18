using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Ciphers
{
    class Richelieu: Cipher
    {
        public Richelieu(string alphabet)
        {
            textAlphabet = alphabet;
        }
        public override string Encrypt(string message = "", object key = null)
        {
            string output = string.Empty;
            int messageCounter = 0;

            string[] k = (string[])key;
            Random random = new Random();

            for (int i = 0; i < k.Length; i++)
            {
                for (int j = 0; j < k[i].Length; j++)
                {
                    if (k[i][j] == '1')
                    {
                        if (messageCounter < message.Length)
                            output += message[messageCounter++];
                    }
                    else output += textAlphabet[random.Next(textAlphabet.Length)];
                }
            }

            return output;
        }
    }
}

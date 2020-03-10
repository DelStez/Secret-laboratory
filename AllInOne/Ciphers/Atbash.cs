using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Ciphers
{
    class Atbash: Cipher
    {
        public Atbash(string alphabet)
        {
            textAlphabet = alphabet;
        }
        public override string Encrypt(string message = "", object key = null) { return AtbashCipher(message); }
        public override string Decrypt(string message = "", object key = null) { return AtbashCipher(message); }
        private string AtbashCipher(string message)
        {
            string output = String.Empty;
            for (int i = 0; i < message.Length; i++)
            {
                int index = textAlphabet.IndexOf(message[i]) + 1;
                index = 33 - index + 1;
                output += textAlphabet[index - 1];
            }

            return output;
        }
    }
    
}

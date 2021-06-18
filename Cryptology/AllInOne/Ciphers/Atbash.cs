using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Ciphers
{
    class Atbash: Cipher
    {
        public string cipherAlphabet = "";
        public Atbash(string alphabet)
        {
            textAlphabet = alphabet;
            cipherAlphabet = new string(alphabet.ToCharArray().Reverse().ToArray());
        }
        public override string Encrypt(string message = "", object key = null) { return AtbashCipher(message); }
        public override string Decrypt(string message = "", object key = null) { return AtbashCipher(message); }
        private string AtbashCipher(string message)
        {
            string output = "";
            message = message.ToUpper();

            foreach (char ch in message)
            {
                if (cipherAlphabet.Contains(ch))
                    output += cipherAlphabet[textAlphabet.IndexOf(ch)];
                else
                    output += ch;
            }

            return output;
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Ciphers
{
    class Caesar : Cipher
    {
        public Caesar(string alphabet)
        {
            textAlphabet = alphabet;
        }
        public override string Encrypt(string message = "", object key = null)
        {
            string result = String.Empty;
            message = message.ToUpper();
            foreach (char ch in message)
            {
                char newChar = textAlphabet[(textAlphabet.IndexOf(ch) + Convert.ToInt32(key)) % textAlphabet.Count()];
                result += newChar;
            }
            return result;
        }
        public override string Decrypt(string message = "", object key = null)
        {
            string result = String.Empty;
            message = message.ToUpper();
            foreach (char ch in message)
            {
                int index1 = textAlphabet.IndexOf(ch) - (int)key;
                char newChar = textAlphabet[(textAlphabet.IndexOf(ch) + index1) % textAlphabet.Count()];
                result += newChar;
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Tools;

namespace AllInOne.Ciphers
{
    class Vegenere: Cipher
    {

         public Vegenere(string alphabet)
        {
            textAlphabet = alphabet;
        }
       
        public override string Encrypt(string mess = "", object key = null) { return VegenereCiphers(mess, key.ToString(), true); }
        public override string Decrypt(string mess = "", object key = null) { return VegenereCiphers(mess, key.ToString(), false); }

        private string VegenereCiphers(string message, string key, bool crypt)
        {
            string newText = String.Empty;
            message = message.ToUpper();
            key = key.ToUpper();
            for (int i = 0; i < message.Length; i++)
            {
                int indexOfKey = i % ((key.Length == 0) ? 1: key.Length);
                int k = textAlphabet.IndexOf(key[indexOfKey]) * (crypt ? 1: -1);
                char c = textAlphabet[Maths.Mod(textAlphabet.IndexOf(message[i]) + k, textAlphabet.Length)];
                newText += c;

            }
            return newText;
        }
    }
}

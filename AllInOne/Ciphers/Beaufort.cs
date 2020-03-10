using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Tools;

namespace AllInOne.Ciphers
{
    class Beaufort: Cipher
    {
        public Beaufort(string alphabet)
        {
            textAlphabet = alphabet;
        }
        public override string Encrypt(string message = "", object key = null){ return BeaufortCipher(message, key.ToString(), true); }
        public override string Decrypt(string message = "", object key = null){ return BeaufortCipher(message, key.ToString(), false); }
		private string BeaufortCipher(string message, string key, bool encrypt)
		{
			string output = string.Empty;
			message = message.ToUpper();
			key = key.ToUpper();
			for (int i = 0; i < message.Length; ++i)
			{
				int keyIndex = i % ((key.Length == 0) ? 1 : key.Length);
				int k = textAlphabet.IndexOf(key[keyIndex]);
				char ch = textAlphabet[Maths.Mod(k - textAlphabet.IndexOf(message[i]), textAlphabet.Length)];
				output += ch;
			}

			return output;
		}
	}
}

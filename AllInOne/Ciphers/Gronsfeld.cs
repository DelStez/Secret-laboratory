using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Ciphers
{
    class Gronsfeld : Cipher
    {
        public Gronsfeld(string alphabet)
        {
            textAlphabet = alphabet;
        }
        public override string Encrypt(string message = "", object key = null) 
        {
            string output = String.Empty;
            Cipher cipher = new Caesar(textAlphabet);
            string newKey = String.Empty;
            while (newKey.Length < message.Length)
                newKey += key;
            if (newKey.Length > message.Length) newKey = newKey.Substring(0, message.Length);
            for (int i = 0; i < message.Length; i++)
            {
                if (textAlphabet.Contains(message[i]))
                {
                    output += cipher.Encrypt(message[i].ToString(), Convert.ToInt32(newKey[i].ToString()));
                    
                }
                else
                    output += message[i];
            }

            return output;
        }

        public override string Decrypt(string message = "", object key = null)
        {
            string output = String.Empty;
            Cipher cipher = new Caesar(textAlphabet);
            string newKey = String.Empty;
            while (newKey.Length < message.Length)
                newKey += key;
            if (newKey.Length > message.Length) newKey = newKey.Substring(0, message.Length);
            for (int i = 0; i < message.Length; i++)
            {
                if (textAlphabet.Contains(message[i]))
                {
                    output += cipher.Decrypt(message[i].ToString(), Convert.ToInt32(newKey[i].ToString()));

                }
                else
                    output += message[i];
            }

            return output;
        }
       
    }
}

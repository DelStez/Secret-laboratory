using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Ciphers
{
    class Cipher 
    {
        public string name;
        public string textAlphabet;
        public string cipherAlphabet = "";

        public virtual string Encrypt(string message = "", object key = null)
        {
            return "Not Implemented";
        }

        public virtual string Decrypt(string message = "", object key = null)
        {
            return "Not Implemented";
        }
    }
}

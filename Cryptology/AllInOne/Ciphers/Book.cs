using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Ciphers
{
    class Book: Cipher
    {
        private string bookPath = "book.txt";
        public Book(string alphabet)
        {
            textAlphabet = alphabet;
        }
        public override string Encrypt(string message = "", object key = null)
        {
            string output = string.Empty;
            int messageCounter = 0;
            int lineCounter = 0;
            message += " ";

            StreamReader sr = new StreamReader(bookPath);

            while (messageCounter < message.Length - 1)
            {
                string line = sr.ReadLine();
                if (line != null)
                {
                    line = line.ToUpper();

                    while (line.Contains(message[messageCounter]) && messageCounter < message.Length - 1)
                    {
                        output += $"{lineCounter + 1}{line.IndexOf(message[messageCounter]) + 1} ";
                        line.Replace(message[messageCounter], '*');
                        messageCounter++;
                    }

                    lineCounter++;
                }
                else
                {
                    break;
                }
            }

            return output;
        }

        public override string Decrypt(string message = "", object key = null)
        {
            string output = string.Empty;

            return output;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace CAESAR3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string shipher = "a_oPIODK@JGOMA?LGDAGCDM";

            // 114112
            string Filename = "78.txt";
            FileStream f = null;
            f = new FileStream(Filename, FileMode.Create);
            int i = 1;
            using (StreamWriter s = new StreamWriter(f, Encoding.Unicode))
            { while (i < 1114112)
                {
                    string decode = "";
                    for (int j = 0; j < shipher.Length; j++)
                    {
                        string h = shipher[j].ToString();
                        int g;
                        if (Encoding.Unicode.GetBytes(h).Length > 1 && Encoding.Unicode.GetBytes(h)[1] != 0)
                        {
                            if (j > i) g = BitConverter.ToInt16(Encoding.Unicode.GetBytes(h), 0) + i;
                            else g = BitConverter.ToInt16(Encoding.Unicode.GetBytes(h), 0) + j;
                        }
                        else
                        {
                            g = BitConverter.ToInt16(Encoding.Unicode.GetBytes(h), 0) + i;
                            byte[] l = BitConverter.GetBytes(g);
                            decode += Encoding.Unicode.GetString(l).Replace("\0", string.Empty);
                        }
                    }
                    s.WriteLine(decode);
                    i++;
               }
            } 
        }
    }
}
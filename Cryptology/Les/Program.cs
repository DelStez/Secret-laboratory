using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "ШФССОЬОАИМЕЕТНВИИРИПЛЗВНЕПРСАОК";
            for (int l = 1; l < (input.Length); l++)
            {
                Console.Write("{0}: ", l);
                for (int i = 0; i < l; i++)
                {
                    
                    for (int y = 0; y * l + i < input.Length; y++)
                    {
                        Console.Write(input[y * l + i]);
                    }
                }
                Console.WriteLine();
                //Console.WriteLine("- - - - - - - - - - -");
            }
        }
    }
}

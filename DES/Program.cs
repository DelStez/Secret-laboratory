using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "FUCK";
            while (Encoding.UTF8.GetBytes(message).Length % 8 != 0)
            {
                message += " ";
            }
            byte[] byteMessage = Encoding.UTF8.GetBytes(message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Tools
{
    class Maths
    {
        public static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }
    }
}

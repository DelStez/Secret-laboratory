using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Stegano_Bmp
{
    public class LSB
    {
        protected byte[] matrixOriginal;
        public LSB(Image image)
        {
            using(var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                matrixOriginal = ms.ToArray();
            }
        }

    }
}

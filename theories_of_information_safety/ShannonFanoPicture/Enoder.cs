using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShannonFanoPicture
{
    class Encoder
    {
        public List<SFCode> SFCode;

        public Encoder()
        {
            SFCode = new List<SFCode>();
        }

        public void CovertPixel(Bitmap image, ref int persen)
        {
            for (int i = 0; i < image.Height; i++)
            {
                persen = (int)Math.Ceiling(((double)i / image.Height * 100) * 0.3);
                for (int j = 0; j < image.Width; j++)
                {
                    //red color
                    var red = (from s in SFCode
                               where s.Simbol == image.GetPixel(j, i).R
                               select s).FirstOrDefault();

                    if (red == null)
                    {
                        SFCode.Add(new SFCode { Simbol = image.GetPixel(j, i).R, Frekuensi = 1, Code = "" });
                    }
                    else
                    {
                        red.Frekuensi++;
                    }

                    //green color
                    var green = (from s in SFCode
                                 where s.Simbol == image.GetPixel(j, i).G
                                 select s).FirstOrDefault();

                    if (green == null)
                    {
                        SFCode.Add(new SFCode { Simbol = image.GetPixel(j, i).G, Frekuensi = 1, Code = "" });
                    }
                    else
                    {
                        green.Frekuensi++;
                    }

                    //blue color
                    var blue = (from s in SFCode
                                where s.Simbol == image.GetPixel(j, i).B
                                select s).FirstOrDefault();

                    if (blue == null)
                    {
                        SFCode.Add(new SFCode { Simbol = image.GetPixel(j, i).B, Frekuensi = 1, Code = "" });
                    }
                    else
                    {
                        blue.Frekuensi++;
                    }
                }
            }
            SFCode = SFCode.OrderByDescending(s => s.Frekuensi).ToList();
        }

        public String Encoding(Bitmap image, ref int persen)
        {
            this.CovertPixel(image, ref persen);
            ShannonFanoCode();
            int temp = persen += 30;

            String bit = "";
            for (int i = 0; i < image.Height; i++)
            {
                int persen2 = (int)Math.Ceiling(((double)i / image.Height * 100) * 0.4);
                persen = persen2 + temp;
                for (int j = 0; j < image.Width; j++)
                {
                    //red
                    var encod = (from s in SFCode
                                 where s.Simbol == image.GetPixel(j, i).R
                                 select s.Code).FirstOrDefault();
                    bit += encod;

                    //green
                    encod = (from s in SFCode
                             where s.Simbol == image.GetPixel(j, i).G
                             select s.Code).FirstOrDefault();
                    bit += encod;

                    //blue
                    encod = (from s in SFCode
                             where s.Simbol == image.GetPixel(j, i).B
                             select s.Code).FirstOrDefault();
                    bit += encod;
                }
            }
            persen = 100;
            return bit;
        }

        public void ShannonFanoCode()
        {
            if (SFCode.Count == 1)
            {
                SFCode[0].Code = "0";
            }
            else
            {
                int midFrekuensi = SFCode.Sum(sf => sf.Frekuensi) / 2;
                List<SFCode> S1 = new List<SFCode>();
                List<SFCode> S2 = new List<SFCode>();
                SplitList(ref S1, ref S2, SFCode, midFrekuensi);
                ShannonFanoCode(S1, "0");
                ShannonFanoCode(S2, "1");
            }
        }

        public void ShannonFanoCode(List<SFCode> sf, string codebit)
        {
            if (sf.Count == 1)
            {
                SFCode code = (from s in SFCode
                                           where s.Simbol == sf[0].Simbol
                                           select s).FirstOrDefault();
                code.Code = codebit;
            }
            else
            {
                int midFrekuensi = sf.Sum(s => s.Frekuensi) / 2;
                List<SFCode> S1 = new List<SFCode>();
                List<SFCode> S2 = new List<SFCode>();
                SplitList(ref S1, ref S2, sf, midFrekuensi);
                ShannonFanoCode(S1, codebit + "0");
                ShannonFanoCode(S2, codebit + "1");
            }
        }

        private void SplitList(ref List<SFCode> S1, ref List<SFCode> S2, List<SFCode> list, int frekuensi)
        {
            int sum = 0;
            foreach (var item in list)
            {
                if (sum < frekuensi)
                {
                    S1.Add(item);
                }
                else
                {
                    S2.Add(item);
                }
                sum += item.Frekuensi;
            }
        }

        public String GetSFCode()
        {
            String sf = "";
            foreach (var item in SFCode)
            {
                sf += item.Simbol + "#" + item.Code + ";";
            }

            return sf;
        }
    }
    class Decoder
    {
        public List<SFCode> SFCode;
        private List<byte> tempImage;

        public Decoder()
        {
            SFCode = new List<SFCode>();
            tempImage = new List<byte>();
        }

        public void SetSFCode(String sf)
        {
            string[] listcode = sf.Split(';');
            foreach (String item in listcode)
            {
                string[] code = item.Split('#');
                if (code.Length < 2)
                    continue;

                SFCode.Add(new SFCode()
                {
                    Simbol = Convert.ToByte(Convert.ToInt32(code[0])),
                    Code = code[1]
                });
            }
        }

        public Bitmap Decoding(String code, int width, int height, ref int persen)
        {
            Bitmap image = new Bitmap(width, height);
            int i = 0;
            int j = 1;
            while (i < code.Length)
            {
                try
                {
                    persen = (int)Math.Ceiling((double)i / code.Length * 100);
                    String binary = "";
                    binary = code.Substring(i, j);
                    var sfitem = (from sf in SFCode
                                  where sf.Code == binary
                                  select sf).FirstOrDefault();
                    if (sfitem == null)
                    {
                        j++;
                    }
                    else
                    {
                        tempImage.Add(sfitem.Simbol);
                        i += j;
                        j = 1;
                    }
                }
                catch (Exception e)
                {
                    i += j;
                    j = 1;
                }
            }

            int temp = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    image.SetPixel(x, y, Color.FromArgb(tempImage[temp], tempImage[temp + 1], tempImage[temp + 2]));
                    temp += 3;
                }
            }
            return image;
        }

        public void getResolution(ref int width, ref int height, int widthLeng, int heightLeng, byte[] encodingByte)
        {
            byte[] temp = new byte[widthLeng];
            for (int i = 0; i < widthLeng; i++)
            {
                temp[i] = encodingByte[i + 3];
            }
            width = BitConverter.ToInt32(temp, 0);

            temp = new byte[heightLeng];
            for (int i = 0; i < heightLeng; i++)
            {
                temp[i] = encodingByte[i + widthLeng + 3];
            }
            height = BitConverter.ToInt32(temp, 0);
        }

        internal Bitmap Decoding(object p, int width, int height, ref int byteProcessed)
        {
            throw new NotImplementedException();
        }
    }
}

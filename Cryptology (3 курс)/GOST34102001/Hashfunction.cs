using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOST34102001
{
    public class Hashfunction
    {
        public byte[] message;
        public string hashHex;
        // S-блоки, используемые ЦБ РФ
        byte[,] S = { 
        { 4, 10,  9,  2, 13,  8,  0, 14,  6, 11,  1, 12,  7, 15,  5,  3},
        {14, 11,  4, 12,  6, 13, 15, 10,  2,  3,  8,  1,  0,  7,  5,  9},
        { 5,  8,  1, 13, 10,  3,  4,  2, 14, 15, 12,  7,  6,  0,  9, 11},
        { 7, 13, 10,  1,  0,  8,  9, 15, 14,  4,  6, 12, 11,  2,  5,  3},
        { 6, 12,  7,  1,  5, 15, 13,  8,  4, 10,  9, 14,  0,  3, 11,  2},
        { 4, 11, 10,  0,  7,  2,  1, 13,  3,  6,  8,  5,  9, 12, 15, 14},
        {13, 11,  4,  1,  3, 15,  5,  9,  0, 10, 14,  7,  6,  8,  2, 12},
        { 1, 15, 13,  0,  5,  7, 10,  4,  9,  2,  3, 14,  6, 11,  8, 12},
        };


        public Hashfunction(byte[] temp)
        {
            //Инициализация
            message = temp;
        }
        public string GetHash()
        {

            CheckMess();//
            byte[] mess = new byte[message.Length];
            message.CopyTo(mess, 0);
            byte[] H = new byte[message.Length];
            for (int i = 0; i < mess.Length; i += 32)
            {
            }
            return " ";
        }
        public void CheckMess()
        {
            List<bool> result = new List<bool>();
            message.CopyTo(result.ToArray(), 0);
            while (result.Count % 256 != 0)
            {
                result.Add(false);
            }

            BitArray temp = new BitArray(result.ToArray());
            message = new byte[result.Count/256];
            temp.CopyTo(message, 0);
            
        }


        public void GostR(byte[] a, byte[] k, byte[] r)
        {
            int c = 0;
            //for(int i =0; i <)
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "ЦРЯ:ЛХОЗКЕНБИЯЙЧЯУБЬАХЯ:КХ.ЗХРЯЖЦВ.ХЬАБЖЧРД:ЕЯЖЯ.ЖЗСЯ:КЗ_ЧЕСТЯХ:КБЯЗЯЖЧ:ЯЙХРЯ:ЬХ.:РЖПЯБЯХ:КБЯЦЙБЯЗЯЖЧ:ЯХ:РД,";
            int y = 0;
            while (y < text.Length) 
            {
                string temp = text[0].ToString();
                text += temp;
                text = text.Remove(0, 1);
                Console.WriteLine(text);
                y++;
            }

        }
    }
}

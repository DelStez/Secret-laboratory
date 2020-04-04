using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SwapingShipher
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Зашифрованный текст:
            //ИАОТЮОЕРКМФНТЫЧРИКМОШВСЫЛ Частично восстановленный ключ: XX3X2
            string CodeInput = "ИАОТЮОЕРКМФНТЫЧРИКМОШВСЫЛ";
            string key = "XX3X2";
            List<string> CodeTable = new List<string>();
            int i = -5;
            for (int j = 0; j < key.Length; j++)
            {
                i += 5;
                string p = (j + 1).ToString() + " ";
                for (int g = i; g < CodeInput.Length; g++)
                {
                    //int j = 0;

                    p += (CodeInput[g] + " ");
                    if ((g + 1) % key.Length == 0 && g != 0) break;
                }
                CodeTable.Add(p);
                Console.WriteLine(p);
            }
//            Regex regex = new Regex(@"..3.2");
            var results = Allcombinations(CodeTable);
            foreach (List<string> lst in results)
            {
                string keygen = "";
                string message = "";
                int j = 1;
                foreach  (string s in  lst)
                {
                    Console.WriteLine(s+ " ");
                    bool ka = true;
                    string[] jStr = s.Split(' ').ToArray();
                    for (int y = 0; y < jStr.Length; y++)
                    {
                        if (y == 0) keygen += jStr[y];
                    }
                    j++;
                }
                //if( regex == keygen)
                Console.WriteLine("Ключ: {0}",keygen);
                Console.WriteLine("___");
            }
        }
        public static List<List<T>> Allcombinations<T>(List<T> Arr, List<List<T>> list = null, List<T> current = null)
        {
            if (list == null) list = new List<List<T>>();
            if (current == null) current = new List<T>();
            if (Arr.Count == 0) 
            {
                list.Add(current);
                return list;
            }
            for (int l = 0; l < Arr.Count; l++) 
            {
                List<T> lst = new List<T>(Arr);
                lst.RemoveAt(l);
                var newlst = new List<T>(current);
                newlst.Add(Arr[l]);
                Allcombinations(lst, list, newlst);
            }
            return list;
        }
    }
}

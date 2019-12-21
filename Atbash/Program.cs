using System;

namespace Atbash
{
    class Program
    {
        static void Main(string[] args)
        {
            string alfaBet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string code = "ТСРЬЦЪШЪЮЛЫЛМПЪОЭДЪПРНУЪЫСЦТЦЦПРНУЪЫСЦЪПЪОЭДТЦ";
            string decode = "";
            Console.WriteLine(alfaBet);
            for (int i = 0; i < code.Length; i++)
            {
                int index = alfaBet.IndexOf(code[i]) + 1;
                index = 33 - index + 1;
                decode += alfaBet[index - 1];
            }
            Console.WriteLine(decode);
        }
    }
}

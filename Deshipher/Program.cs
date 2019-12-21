using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deshipher
{
    class Program
    {
       
        public static void Main(string[] args)
        {
            Dictionary<string, double> diagrammOfAlfaBet = new Dictionary<string, double> { {" ", 0.175}, { "О", 0.09 }, { "Е", 0.072 }, { "Ё", 0.072 },
            { "А", 0.062 }, { "И", 0.062 }, { "Т", 0.053 }, { "Н", 0.053 },{ "С", 0.045 }, { "Р", 0.040 }, { "В", 0.038 }, { "Л", 0.035 }, { "К", 0.028 }, { "М", 0.026 },
            { "Д", 0.025 }, { "П", 0.023 }, { "У", 0.021 }, { "Я", 0.018 }, { "Ы", 0.016 }, { "З", 0.016 }, { "Ъ", 0.014 }, { "Ь", 0.014 }, { "Б", 0.014 },
            { "Г", 0.013 }, { "Ч", 0.012 }, { "Й", 0.010 }, { "Х", 0.009 }, { "Ж", 0.007 },{ "Ю", 0.006 },{ "Ш", 0.006 }, { "Ц", 0.004 },{ "Щ", 0.003 },{ "Э", 0.003 },{ "Ф", 0.003 }};
            string SevenVariant = "34 92 45 25 90 30 25 71 16 62 37 71 55 71 89 18 96 62 55 85 22 71 11 62 62 24 62 89 71 55 55 62 85 55 16 71 92 71 24 55 62 11 62-" +
                "90 30 49 30 24 55 18 71 24 16 85 92 30 55 18 71 52 37 85 55 24 18, 49 30 92 62 22 25 30 22 85 24 16 18 73 92 58 89 30 67 71 25, " +
                "90 58 89 55 30 20 86 71 16 25 30 24 16 45 89 85 25 62 14 49 30 24 16 18-89 92 62 52 20 11 71 68 16 62 49 62 96 62 37 71 55 62, 25 62 96 85 62 55 30 34 24 16 92 30 96 85 71 46 92 62 52 62 14, " +
                "49 30 92 30 89 30 55 62 25 25 62 55 24 71 92 34 62 34, 49 62 22 30 16 18 94 39 96 30 25 62 55 24 62 89 71 90 90 30 92 30 37 85 34 30 45 86 85 14 85 34 62 52 58 16 30 89 96 71 16 25 30 14 85," +
                " 24 16 30 92 18 94 25 62 14 49 30 24, 62 89 67 30 92 49 30 55 55 18 94 39 62 55 30 92 85 25 85 49 92 62 22 30 20 52 92 71 89 71 52 71 55 19," +
                " 85 90 62 89 96 85 22 30 34 67 30 20 34 52 37 62 55 71 24 16 19 45 - 25 30 25 - 71 11 62 - 16 30 14 52 62 24 16 30 16 62 22 55 62 62 49 18 16 55 62 11 62 49 58 16 71 67 71 24 16 34 71 55 55 85 25 30," +
                " 14 30 16 92 62 24 30 24 55 71 14 30 96 18 14 24 16 30 37 71 14, 34 62 52 85 55 49 92 71 25 92 30 24 55 18 94 52 71 55 19 92 71 67 85 34 67 71 11 62 49 62 85 24 25 30 16 19 24 22 30 24 16 19 20 55 30 89 71 92 71 11 58. " +
                "49 92 71 52 71 96 19 55 62 24 25 92 62 14 55 18 71 49 62 37 85 16 25 85, 55 71 24 49 62 24 62 89 55 18 71 49 92 85 34 96 71 22 19 34 55 85 14 30 55 85 71 24 71 92 19 71 90 55 18 73 11 92 30 89 85 16 71 96 71 94."+
                "85 14 71 96 62 24 19 85 62 92 58 37 85 71, 30 25 30 25 37 71. 49 92 85 96 85 22 55 18 73 92 30 90 14 71 92 62 34 62 73 62 16 55 85 22 85 94 55 62 37, 34 16 62 92 62 94, " +
                "25 30 92 14 30 55 55 18 94 67 34 71 94 46 30 92 24 25 85 94 49 71 92 62 22 85 55 55 85 25 24 52 34 58 14 20 52 71 24 20 16 25 30 14 85 49 92 85 22 85 55 52 30 96 62 34," +
                " 30 16 30 25 37 71 49 62 16 71 92 16 18 94 49 85 24 16 62 96 71 16 - 25 62 96 19 16 89 62 96 71 71 22 71 14 52 34 30 52 46 30 16 85 96 71 16 55 71 11 62 34 62 90 92 30 24 16 30," +
                " 55 62 58 73 62 37 71 55 55 18 94 85 24 14 30 90 30 55 55 18 94 - 85 14 71 55 55 62 16 30 25 62 71 62 92 58 37 85 71 14 62 37 55 62 89 71 90 62 24 62 89 18 73 49 92 62 89 96 71 14 49 92 85 62 89 92 71 24 16 85 34 49 62 92 16 62 34 18 73 16 92 58 86 62 89 30 73. 34 24 71 49 92 62 52 58 14 30 55 62. 90 52 71 67 55 85 71 49 62 96 85 46 30 85 24 89 62 96 19 67 85 14 49 62 52 62 90 92 71 55 85 71 14 62 16 55 62 24 20 16 24 20 25 24 58 89 10 71 25 16 30 14 24 30 34 16 62 14 30 16 85 22 71 24 25 85 14 62 92 58 37 85 71 14 55 30 49 96 71 22 71, 90 30 16 62 55 71 62 24 62 89 62 55 30 34 62 92 62 22 71 55 55 18 94 25 30 92 30 89 85 55 85 96 85 49 92 62 24 16 71 55 19 25 85 94 49 85 24 16 62 96 71 16 34 25 30 92 14 30 55 71 34 90 52 71 67 55 85 7314 71 24 16 30 73 24 22 85 16 30 45 16 24 20 55 71 49 92 71 14 71 55 55 18 14 30 16 92 85 89 58 16 62 14 58 34 30 37 30 45 86 71 11 62 24 71 89 20 25 30 89 30 96 19 71 92 62, 49 85 24 19 14 71 55 55 62 11 62 92 30 90 92 71 67 71 55 85 20 55 71 16 92 71 89 58 45 16 85, 34 62 89 86 71 14, 49 62 52 62 90 92 71 55 85 94 55 71 34 18 90 18 34 30 45 16," +
                " 49 62 25 30 24 85 73 49 62 14 62 86 19 45 55 71 24 62 16 34 62 92 20 16 22 71 11 62 - 16 62 55 71 90 30 25 62 55 55 62 11 62.";
            string TEMP = SevenVariant;
            string temp = "";
            List<String> numbers = new List<string>();
            Dictionary<string, int> NumbersOfSeven = new Dictionary<string, int>();
            int size = TEMP.Length;
            int count = 0;
            for (int j = 0; j < size; j++)
            {
                if (TEMP[j] != ' ' && TEMP[j] != ',' && TEMP[j] != '.' && TEMP[j] != '-')
                {
                    temp += TEMP[j];
                }
                else
                {
                    double num;
                    if (double.TryParse(temp, out num))
                    {
                        numbers.Add(temp);
                        int numberOfNumber = (TEMP.Split(new string[] { temp }, StringSplitOptions.None).Count() - 1);
                        count += numberOfNumber;
                        NumbersOfSeven.Add(temp, numberOfNumber);
                        TEMP = TEMP.Replace(temp, "");
                        size = TEMP.Length;
                        temp = ""; j = 0;

                    }
                    else temp = "";
                }
            }
            var dic = NumbersOfSeven.OrderByDescending(Key => Key.Value);
            Dictionary<string, int> NumbersOfSevenCopy = new Dictionary<string, int>(dic.ToDictionary(x=>x.Key, x=> x.Value));
            Console.WriteLine();
            List<List<int>> History = new List<List<int>>();
            List<string> ModifityHistory = new List<string>();
            Dictionary<string, double> diagrammOfAlfaBetCopy = new Dictionary<string, double>(diagrammOfAlfaBet);
            List<Dictionary<string, double>> ModifityDictVariotions = new List<Dictionary<string, double>>();
            string SevenVariantCopy = SevenVariant;
            int h = 0;
            while(h < NumbersOfSevenCopy.Count)
            {

                float H = Convert.ToSingle(NumbersOfSevenCopy.ElementAt(h).Value)/count;
                string tempR = "";
                foreach (var r in SevenVariant)
                {
                    if (r != ' ' && r != ',' && r != '.' && r != '-')
                        {
                            tempR += r;
                        }
                    else
                    {   
                        int y = 0;
                        bool ka = int.TryParse(tempR, out y);
                        if (tempR == NumbersOfSevenCopy.ElementAt(h).Key) Console.ForegroundColor = ConsoleColor.Red;
                        else 
                        {
                            Console.ResetColor();
                            if (!ka) Console.ForegroundColor = ConsoleColor.Green;
                        } 
                        
                        Console.Write(tempR+ r);
                        tempR = "";
                    }
                }
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine(NumbersOfSevenCopy.ElementAt(h).Key + " Частота: " + Math.Round(H, 4)) ;
                foreach (var pair in diagrammOfAlfaBetCopy)
                { 
                    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                }
                //ClosestTo(diagrammOfAlfaBetCopy, H);
                string cInput = Console.ReadLine();
                if (!cInput.ToLower().Contains("назад"))
                {
                    SevenVariant = SevenVariant.Replace(NumbersOfSevenCopy.ElementAt(h).Key, cInput);
                    ModifityHistory.Add(SevenVariant);
                    diagrammOfAlfaBetCopy.Remove(Convert.ToString(cInput));
                    ModifityDictVariotions.Add(new Dictionary<string, double>(diagrammOfAlfaBetCopy));
                    h++;
                }
                else
                {
                    ModifityHistory.Remove(ModifityHistory.Last());
                    ModifityDictVariotions.Remove(ModifityDictVariotions.Last());
                    if (ModifityHistory.Count != 0)
                    {
                        
                        SevenVariant = ModifityHistory.Last();
                        diagrammOfAlfaBet = ModifityDictVariotions.Last();
                    }
                    else
                    {
                        SevenVariant = SevenVariantCopy;
                        diagrammOfAlfaBetCopy = new Dictionary<string, double>(diagrammOfAlfaBet);
                    }
                    h--;
                }
            }
            Console.WriteLine(SevenVariant);
        }
    }
}

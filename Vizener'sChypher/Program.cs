using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vizener_sChypher
{
    public partial class Program
    {
        /*                                   ___________________________//
        /_______________________ /----------/ Весь код - костыль       //  
        /                       /----------/__________________________//
                                                                     //
       */
        static Regex regex = new Regex("[А-Я]", RegexOptions.Compiled);
        static int minKeyLength = 3;
        static int maxKeyLength = 16;
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите шифротекст: ");
            string cipherText = Console.ReadLine();
            string alphabet = "";
            string inputSettingLanguage;
            int passLength = minKeyLength;
            do
            {
                Console.Write("Определите алфафит: \n\r1)Английский с нижним подчёркиванием \n\r2)Русский с нижним подчёркиванием \n\r");
                inputSettingLanguage = Console.ReadLine();
                if (inputSettingLanguage == "2") alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ_".ToLower();
                if (inputSettingLanguage == "1") alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_".ToLower();
            }
            while (inputSettingLanguage != "1" && inputSettingLanguage != "2");
            Console.WriteLine("Известна ли длина ключа, y/n ?");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("Введите длину ключа: ");
                passLength = Convert.ToInt32(Console.ReadLine());
                maxKeyLength = passLength;
            }
            else maxKeyLength = Kasiski.KasiskiExam(cipherText).Max();
            for (; passLength <= maxKeyLength; passLength++)
            {
                Console.WriteLine("Длина ключа {0}", passLength);
                for (int i = 0; i < passLength; i++)
                {
                    if (cipherText.Length % passLength == 0) break;
                    cipherText += " ";
                }
                string[] rows = new string[cipherText.Length / passLength];
                string[] columns = new string[passLength];
                for (int i = 0; i < cipherText.Length; i++)
                {
                    try
                    {
                        rows[i % passLength] += cipherText[i];
                    }
                    catch
                    {
                    };
                }


                List<char> Symbols = new List<char>();

                for (int i = 0; i < passLength; i++)
                {
                    string currentRow = rows[i];

                    Symbols.Clear();
                    for (int j = 0; j < currentRow.Length; j++)
                        if (Symbols.Contains(currentRow[j]) == false)
                            Symbols.Add(currentRow[j]);

                    int[] tempTimes = new int[Symbols.Count];
                    List<int> Times = new List<int>(Symbols.Count);

                    for (int a = 0; a < Symbols.Count; a++)
                        for (int b = 0; b < currentRow.Length; b++)
                            if (Symbols[a] == currentRow[b]) tempTimes[a] = tempTimes[a] + 1;

                    for (int t = 0; t < tempTimes.Length; t++)
                        Times.Add(tempTimes[t]);

                    SortListIC(ref Times, ref Symbols);
                    int max = 0;
                    int index = 0;

                    for (int t = 0; t < Times.Count; t++)
                        if (Times[t] > max)
                        {
                            max = Times[t];
                            index = t;
                        }

                    ShiftLists(ref Times, ref Symbols, index);

                    for (int t = 0; t < Symbols.Count; t++)
                        columns[i] += Symbols[t].ToString();
                }

                string[] keys = new string[columns[0].Length];
                string temp = "";
                int vol = 22;

                while (true)
                {
                    try
                    {
                        temp = cipherText.Substring(0, vol);
                        break;
                    }
                    catch
                    {
                        vol /= 2;
                    }
                };

                for (int i = 0; i < columns[0].Length; i++)
                {
                    for (int j = 0; j < passLength; j++)
                    {
                        try
                        {
                            keys[i] += columns[j][i];
                        }
                        catch { };
                    }
                }

                for (int i = 0; i < keys.Length; i++)
                {
                    Console.WriteLine(keys[i] + " - " + Decoding(cipherText, keys[i].ToLower(), alphabet));
                    Console.WriteLine("==========================================================================================================");
                }

            }

        }
        public static bool CheckKey(string key, string alphabet)
        {
            if (key == "") return false;
            for (int i = 0; i < key.Length; i++)
                if (!alphabet.Contains(key[i])) return false;
            return true;
        }

        private static string Decoding(string text, string keyWord, string alphabet)
        {
            text = text.ToLower();
            text = ConvertText(text, alphabet);

            keyWord = ConvertText(keyWord, alphabet);

            StringBuilder tempRes = new StringBuilder();

            StringBuilder keyWordBuilder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
                keyWordBuilder.Append(keyWord[i % keyWord.Length]);

            keyWord = keyWordBuilder.ToString();

            for (int i = 0; i < text.Length; i++)
            {
                int p = -1, k = -1;
                for (int j = 0; j < alphabet.Length; j++)
                    if (text[i] == alphabet[j])
                    {
                        p = j;
                        break;
                    }
                for (int j = 0; j < alphabet.Length; j++)
                    if (keyWord[i] == alphabet[j])
                    {
                        k = j;
                        break;
                    }
                if (k != -1 && p != -1) tempRes.Append(alphabet[(p - k + alphabet.Length) % alphabet.Length]);
            }

            return tempRes.ToString().ToLower();
        }
        public static string ConvertText(string text, string alphabet)
        {
            text = text.ToLower();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
                if (alphabet.Contains(text[i])) result.Append(text[i]);
            return result.ToString().ToLower();
        }

        public static void ShiftLists(ref List<int> listNumb, ref List<char> listSymb, int index)
        {
            List<int> resultNumb = new List<int>();
            List<char> resultSymb = new List<char>();

            for (int i = index; i < listNumb.Count; i++)
            {
                resultNumb.Add(listNumb[i]);
                resultSymb.Add(listSymb[i]);
            }
            for (int i = 0; i < index; i++)
            {
                resultNumb.Add(listNumb[i]);
                resultSymb.Add(listSymb[i]);
            }

            listNumb = resultNumb;
            listSymb = resultSymb;
        }


        public static void SortListIC(ref List<int> listNumb, ref List<char> listSymb)
        {
            Dictionary<char, int> sorted = new Dictionary<char, int>();

            for (int i = 0; i < listSymb.Count; i++)
            {
                sorted.Add(listSymb[i], listNumb[i]);
            }

            listNumb.Clear();
            listSymb.Clear();

            foreach (KeyValuePair<char, int> kvp in sorted.OrderBy(key => key.Key))
            {
                listSymb.Add(kvp.Key);
                listNumb.Add(kvp.Value);
            }
            //for (int i = 0; i < listSymb.Count - 1; i++)
            //{
            //    int min = i;
            //    for (int j = i + 1; j < listSymb.Count; j++)
            //        if (listSymb[j] < listSymb[min])
            //            min = j;

            //    char tempChar = listSymb[i];
            //    listSymb[i] = listSymb[min];
            //    listSymb[min] = tempChar;

            //    int tempInt = listNumb[i];
            //    listNumb[i] = listNumb[min];
            //    listNumb[min] = tempInt;
            //}
        }
        public static long findGreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static List<string> maybeIsPass = new List<string>();
        public static bool Check(string str1)
        {
            if (maybeIsPass.Count != 0)
                foreach (string str in maybeIsPass)
                {
                    if (str != str1) return true;
                    else return false;
                }
            return true;
        }
        public static class Kasiski
        {
            public static string GetSubString(int n, int passLength, string temp)
            {
                var filtred = regex.Replace(temp, string.Empty);
                var getBuffer = new StringBuilder();
                for (var i = n - 1; i < filtred.Length; i += passLength)
                {
                    getBuffer.Append(filtred[i]);
                }
                return getBuffer.ToString();
            }
            public static Dictionary<string, List<int>> FindRepeat(string temp)
            {
                var output = new Dictionary<string, List<int>>();
                var filtred = regex.Replace(temp, string.Empty);
                for (var i = 3; i < 6; i++)
                {
                    for (var j = 0; j < filtred.Length - i; j++)
                    {
                        var currentSequence = filtred.Substring(j, i);

                        var sequenceFoundPosition = filtred.IndexOf(currentSequence, j + 1, StringComparison.Ordinal);
                        while (sequenceFoundPosition > 0)
                        {
                         
                            var lengthApart = (sequenceFoundPosition + i) - (j + i);

                           
                            if (!output.ContainsKey(currentSequence))
                                output.Add(currentSequence, new List<int>());
                            if (!output[currentSequence].Contains(lengthApart))
                                output[currentSequence].Add(lengthApart);
                            sequenceFoundPosition = filtred.IndexOf(currentSequence, sequenceFoundPosition + 1, StringComparison.Ordinal);
                        }
                    }
                }
                return output;
            }

            public static List<int> GetUsefulFactors(int number)
            {
                var output = new List<int>();

                for (var i = 2; i <= maxKeyLength; i++)
                {
                    if (number % i == 0)
                        output.Add(i);
                }

                if (output.Contains(1))
                    output.Remove(1);

                return output;
            }
            public static Dictionary<int, int> GetMostCommonFactors(List<List<int>> sequenceFactors)
            {
                var output = new Dictionary<int, int>();

                foreach (var factor in sequenceFactors.SelectMany(seqFactor => seqFactor))
                {
                    if (!output.ContainsKey(factor))
                    {
                        output.Add(factor, 1);
                    }
                    else
                    {
                        output[factor]++;
                    }
                }

                return output;
            }
            public static List<int> KasiskiExam(string cipherText)
            {
                var seqSpacing = FindRepeat(cipherText);
                var seqList = (from seq in seqSpacing.Values from spacing in seq select GetUsefulFactors(spacing)).ToList();
                var likelyKeyLengths = GetMostCommonFactors(seqList);
                var sortedCommonFactors = (from entry in likelyKeyLengths orderby entry.Value descending select entry)
                                     .Take(3)
                                     .ToDictionary(pair => pair.Key, pair => pair.Value);
                return sortedCommonFactors.Keys.ToList();

            }
        }
    }
}

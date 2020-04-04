using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PoliAlphabet
{
    class Program
    {
        static Regex regex = new Regex("[А-Я]", RegexOptions.Compiled);
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
        }
        static void Main(string[] args)
        {

        }
    }
}

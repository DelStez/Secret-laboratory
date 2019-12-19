using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizener_sChypher
{
    public partial class Program
    {
        
        public static string alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ_".ToLower();
        public static bool CheckKey(string key, string alphabet)
        {
            if (key == "") return false;
            for (int i = 0; i < key.Length; i++)
                if (!alphabet.Contains(key[i])) return false;
            return true;
        }

        private static string Decoding(string text, string keyWord)
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
            for (int i = 0; i < listSymb.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < listSymb.Count; j++)
                    if (listSymb[j] < listSymb[min])
                        min = j;

                char tempChar = listSymb[i];
                listSymb[i] = listSymb[min];
                listSymb[min] = tempChar;

                int tempInt = listNumb[i];
                listNumb[i] = listNumb[min];
                listNumb[min] = tempInt;
            }
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
            if(maybeIsPass.Count != 0)
                foreach (string str in maybeIsPass)
                {
                    if (str != str1) return true;
                    else return false;
                }
            return true;
        }
        public static void Main(string[] args)
        {
            //string mainAlfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_";
            
            string crypText = "МЕЩИЯРЕЕЗЪУСУГКИЩТЩЛГКЮЮЪФЙ_МОЙ_ЭУЛННРУЯЗХРКЩХЛ_КВЪЕШФЩНИОЖНВШККЦПЪЬЕХРРИШКМЫКЕКРВШАЗНЩМЧГХТМЛЬКИШКИЗЗРННЖКВЗФРТРВМАХНЩВЩНУХЗГНТЦПЛТЦЕКПШИСДНВБЕФВЩТЧУЛВРХЖ_РРЯОШПЛЦРАКВЗНЩМЧЯИТНУКЕНВШАМСКПШИЩБШГТОКГЭЬЗЕКДКСУЧХЮФ_КЛП_ИВЧА_ЛШЫЗЩУФШСНЫНВЮСЪУЩЙЩХНАЗЕЩЗКУЛЩИАЭ_РРЯОШПЛЦРЛКЕНВЪЕШЕЩНИЪЛЛГРЮЮЗЧЩРФЦККИЙПОНВЭАТСР_ЫФЭРЦМЬТКСКМЦЙШОЗТЫЕМФЭАКЛЭЬЗНЛКЗРЛБЦУКПНУРКУАБАЪИЦЕСВЮПШГНЛЖАГИЭВЪОЪСХОФВЗЛННЭРЦРЩВЗ_ЭИЗТРРННЦЮЯГЭЕУЛКОЙЮБНЦВУЗЛСЭАКОУВИИЧЫНВУЗЗНЫЕФРУЯЗНЫАСРР_ФГЦЫЗЛКСШГМАЪЮНАЕХКПЦЗКДНМЬТКЛРМЗ_ЦЕТХЫИЯИЬКРШКЗИУЙДЦЕКЧШИТВВЪЛЙХСКБВФЭРЦВЭЕФВЬАФЮЧ_КСЬПШСУЗКСПЯЗХРКЩХКНИВЗКШГШЕЗТРРЩСШАУЯШОЛСККЦПЪЬЕХРРИВЧУПЮХУЗРЛ_ЧУЩИЛУЕВИХРЛНВХОФТЛКЪЗУСТСН_РВХОФГШДВВМАХНЩВЩНЩМЫВЛВЪСЧАЪЦККЦХЩРВМКВВЗЛЕЪВНАФВШАУЛБНЦФЭЬЗОРГТСКПШСЬЛНЗУТГВХАТВЬТШСХАЗХРКЩХЛ_ЧУРВШГЭИУГЬЬЗЕКНИДЩРЗЗНОРЪШЫЭВБИЩИЦ_ЯХЩБВВЪОХБЭЬЗНЛКЗТЫЕЦДЫАПЦИТЗЗЫУЛЛР_КЛПЫЗЗЛНХЮ__КВПВЦЛБНЫАКФЦУЧУЗУЛЗЙИЫЕФВРЩНВЩДРРКПШЛЧЕШВТАЧЛЬЬЗРЛ_КЛШИУСНОСВЪЛИФЭИХНР_ДХЩ_ИРЛЛЦЖЩВЦИКПШИПСЪГНЛНРУЕЗКНУТСНЫЭВХОУИМАХЛФ_ИЦПИЦЛШФЦУЧАЮЛЙ_ЭУЛНРХЬЯЗРЛ_ХИФ_КВНИМИКМРНЫОЩНЩПРЪРСТЛ__ЙЦООШНЩВЗУЛСЧСЦООИШНВШКВЗЗЦИХРЕХЗФЪИШГЦЬХЮ__ТГШАКНЛХЗИЬЛРВН_ТГХОФХЩ_ФИЬТНВЧУПЮХАЗКНУЯЛЭ_ЛУЩМЯИКБЫЖЩРТЛКГУЦМЖНВНРНКЛЮЪФЙ_КВХАХГНКЫВЛ_ЧУУ_КЮЬОТСФ_ХСЭЕЗДЮГЦУХИЗУЛСЧСЦАЛГИТЩБКТНФШЕНВЗТРВМУЛСЫКРВЙВУБИТЩБКАХГЦОЛГЧИЗЛЬХЦЗШЫЭВХОУИМАХЛФ_ПЕЮКЦЕЕХЗЕЩЛХВЮЛИЕЦИКГРМВШКМРНЫОЬСШОФВПВРЖЛЯЩЯКПЦВХАХГНКНВУГЦОХАЗТЫОРЖЫЫКГЭЕУБКПЦТЛДИИЭ_ХГКБЫЖЩРТЛКИЗЕУБШЛЫУНХКЕНВНИЙУЛЦРБКВЩИКТЦВСЕЗГШАУСООКСР_ЧУРДЩХЛВУИШИНВУСЭСПНЦЖЩ_ПЕЮКИВЮСРОУВИИЭСЖВУ_ПЕЮЧРХКИПВПИХГЧИТСН_ТГХ_ФЦТЫТГКВРРУЛЦЕЩЙЗТЦАЩХУНТИКПЦЗЩБХСКВЩБХОФЦКАХГЦОЛСНОФЦКУЩХЫОСФЭВЫВ_РИРРНРБКИХЧЩРФГАИРВЬВЦМЬТКИШ_ШБП_ХИПОЩХЛТТСН_ЧЮЦЬЗФЦЕМЮКПИОЖЦНЕКИУЛКЦИУЛПРРЕ_ХГКПЦЕРРЭРЩСЪЛКПУГЬТРРХИЗПЩГЫХКПШЛНОМЛЭЬЗНКННГПЕТЕЛТХЮЧ_ТСЦЕЙГШИЖПКИЛОЕ_КЮТЫКГЙ_КВПИХГЧИТГ__ЧСЭРНФХИКГШИНВУ_МУЮГРИКШЫПЕ_НФЦИЗФХОШСЬТГВНРИЬРНРБКПУГЬТРРХИЗШЩТЖВМЫЗРРМХСООЗСЭКУСШЯНХЬЯЗСЭ_ПГПАХРЩЙЗЕЕСЦХЛ_ПЕЮКИВЬРИКЮ_ОИКМНРЙЕЪФЙ_ЧУУ_ТГСДЦПКПШСУГШЮНАХЛУ_ЧОЛСЪЛШКРВУГУГКПЦФЭЕЧИШНЦВЬНИЫУВИЕЛЕЪВМУЛСЫКРВН_ТГШАКНР_РВХАЯИЬТКСКЗКЦБАХЛЙ_ЩСЩТКИЭСЪЕРНХСКУЭЦПШИИЭСЖВРСУЛКЖНВХАТЦИНРДЮДГВЪЕЩРИ_ПГЪИЩГЭЬЗФКВРРУЛЦЕЩЙЗТЦАЩХУНТЛКНИВХАЩФРТХЮФ_ФГОНРХЩФЦРКТЦВНСНВВЕШС_ОКГЭОЩХУ_ЧИЫЕХСЬЯЪФЙ_ХГКПУИШКЫВЛ_ЩСКВШИЧЕХИЧ_ТВШИФВПОЙГНЯЪФЙ_ХСНЫНВЪОЪСЧУЗЪЭОЗСМЫЯРЕЕЗПЛГХЛЭОЬСШЫЗФЛМРВЙВУБИТЩБКАХГЦОЛСНЫФЛКУЩХЫОСФЭВИПУ_ЪГХИФВЩБШГТОФВЪРРВХАОЗЩЙЗТРРНКЛПРФУ_РОУ_ЧИЫЕМГБЕЗЛШФЦУЧАЮЛЙ_ЪИЫЯНХКВЗНЛЧНФЭВНВ";
            int passLength = 4;
            for (int i = 0; i < passLength; i++)
            {
                if (crypText.Length % passLength == 0) break;
                crypText += " ";
            }
            string[] rows = new string[crypText.Length / passLength];
            string[] columns = new string[passLength];
            for (int i = 0; i < crypText.Length; i++)
            {
                try
                {
                    rows[i % passLength] += crypText[i];
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
                //Записываем все неповторяющиеся символы
                for (int j = 0; j < currentRow.Length; j++)
                    if (Symbols.Contains(currentRow[j]) == false)
                        Symbols.Add(currentRow[j]);

                //Количество повторений каждого символа
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
                    temp = crypText.Substring(0, vol);
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
                Console.WriteLine(keys[i] + " - " + Decoding(crypText, keys[i].ToLower()));
                Console.WriteLine("==========================================================================================================");
            }

            //List<int> maybeIsPassLong = new List<int>();
            //List<int> NODs = new List<int>();
            //for (int i = 0; i < crypText.Length - passLength + 1; i++)
            //{
            //    string temp = crypText.Substring(i, passLength);
            //    if (Check(temp))
            //    {
            //        maybeIsPass.Add(temp);

            //    }
            //    //for (int j = i+1; j < crypText.Length - passLength+1; j++)
            //    //{
            //    //    string temp2 = crypText.Substring(j, passLength);
            //    //    if (temp.Equals(temp2))
            //    //    {
            //    //        maybeIsPass.Add(temp);
            //    //        maybeIsPassLong.Add((crypText.Length - crypText.Replace(temp, "").Length)/temp.Length);
            //    //    }
            //    //}

            //}
            ////Пробел является частью алфавита, значит это не нужно
            //int len = maybeIsPass.Count;
            //for (int y = 0; y < maybeIsPass.Count;)
            //{
            //    bool flag = true;
            //    string temp = maybeIsPass[y];
            //    for (int j = 0; j < temp.Length; j++)
            //    {
            //        if (temp[j] == '_')
            //        {
            //            flag = false;
            //            break;
            //        }
            //    }
            //    if (!flag)
            //    {
            //        maybeIsPass.RemoveAt(y);
            //        //maybeIsPassLong.RemoveAt(y);
            //        y--;
            //    }
            //    else y++;
            //}




            //List<string> passMaybe = new List<string>();
            //maybeIsPass = new List<string>(maybeIsPass.Distinct());
            ///*           __________________//
            // /----------/ Костыль         //  
            ///----------/_________________//
            //                            //
            //*/
            //foreach (var i in maybeIsPass)
            //{
            //    maybeIsPassLong.Add((crypText.Length - crypText.Replace(i, "").Length) / i.Length);
            //}


            //int maxValue = maybeIsPassLong.Max();
            //for (int y = 0; y < maybeIsPassLong.Count; y++)
            //{
            //    if (maybeIsPassLong[y] == maxValue)
            //    {
            //        passMaybe.Add(maybeIsPass[y]);
            //    }
            //}
            //foreach (var s in passMaybe)
            //{
            //    Console.WriteLine(s);
            //}
            //Console.WriteLine(passMaybe.Count);
            ////for (int i = 0; i < length; i++)
            ////{

            ////}
            //var indeces = new List<int>();
            ////int index = crypText.IndexOf()


        }
    }
}

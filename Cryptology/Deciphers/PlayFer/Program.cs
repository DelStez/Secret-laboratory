using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayFer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string alfabet = "абвгдежзиклмнопрстуфхцчшщъыэюя";
            string chypher = "УЕНАЕЭМЧЗПФТКСЪИАРУЕПЕСЯЕХТИСЩГХМЖФЗЧБГЩКМЮАЕЪ".ToLower(); 
            string key = "МАТЕРИЯ".ToLower();
            for (int i = 0; i < chypher.Length-1; i++)
                if (chypher[i]!= chypher.Length && chypher[i] == chypher[i + 1])
                    chypher = chypher.Insert(i, "#");
            int Len = chypher.Length;
            if (Len % 2 != 0)
                chypher += "#";
            for (int i = 0; i < key.Length; i++)
            {
                alfabet = alfabet.Remove(alfabet.IndexOf(key[i]), 1);
            }
            string s = key + alfabet;
            char[,] alphavit = {
                                   {'_', '_', '_', '_', '_', '_'},
                                   {'_', '_', '_', '_', '_', '_'},
                                   {'_', '_', '_', '_', '_', '_'},
                                   {'_', '_', '_', '_', '_', '_'},
                                   {'_', '_', '_', '_', '_', '_'}
                                   
                               };
            int num = 0;
            string sr = " ";
            for (int i = 0; i < 5; i++) 
            {
                for (int j = 0; j < 6; j++)
                {
                    alphavit[i, j] = s[num];
                    num++;
                }
            }
            string ResText = "";
            // индексы букв в столбцах
            int ind_x1 = 0;
            int ind_y1 = 0;
            int ind_x2 = 0;
            int ind_y2 = 0;

            int k = 0;
            while (k < chypher.Length - 1)
            {
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 6; j++)
                    {
                        if (chypher[k] == alphavit[i , j])
                        {
                            ind_x1 = i;
                            ind_y1 = j;
                        }

                        if (chypher[k + 1] == alphavit[i , j])
                        {
                            ind_x2 = i;
                            ind_y2 = j;
                        }
                    }

                // Если буквы находятся в одной строке
                if (ind_x1 == ind_x2)
                {
                    if (ind_y1 == 0)
                    {
                        ResText += alphavit[ind_x1,5];
                        ResText += alphavit[ind_x2,ind_y2 - 1];
                    }
                    else
                    if (ind_y2 == 0)
                    {
                        ResText += alphavit[ind_x1,ind_y1 - 1];
                        ResText += alphavit[ind_x2,15];
                    }
                    else
                    {
                        ResText += alphavit[ind_x1,ind_y1 - 1];
                        ResText += alphavit[ind_x2,ind_y2 - 1];
                    }
                }

                // Если буквы находятся в одном столбце
                if (ind_y1 == ind_y2)
                {
                    if (ind_x1 == 0)
                    {
                        ResText += alphavit[4,ind_y1];
                        ResText += alphavit[ind_x2 - 1,ind_y2];
                    }
                    else
                    if (ind_x2 == 0)
                    {
                        ResText += alphavit[ind_x1 - 1,ind_y1];
                        ResText += alphavit[4,ind_y2];
                    }
                    else
                    {
                        ResText += alphavit[ind_x1 - 1,ind_y1];
                        ResText += alphavit[ind_x2 - 1,ind_y2];
                    }
                }

                // Если буквы находятся в разных строках и разных столбцах
                if ((ind_x1 != ind_x2) && (ind_y1 != ind_y2))
                {
                    ResText += alphavit[ind_x1,ind_y2];
                    ResText += alphavit[ind_x2,ind_y1];
                }

                k = k + 2;
            }
            Console.WriteLine(ResText);
        }
    }
    }
//}

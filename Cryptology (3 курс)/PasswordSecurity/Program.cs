using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordSecurity
{
    class Program
    {
        public  static bool[] A = { false, true};

        static void allBoolfunction(bool[] a, bool[] b)
        {
            Console.WriteLine("Негация");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"{a[i]}, не {!a[i]}");
            }
            Console.WriteLine("Конъюнкция");
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                    Console.WriteLine($"{a[i]} и {a[j]} : {a[i] && a[j]}");
            }
            Console.WriteLine("Дизъюнкция");
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                    Console.WriteLine($"{a[i]} или {a[j]} : {a[i] || a[j]}");
            }
            Console.WriteLine("Импликация");
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                    Console.WriteLine($"Если {a[i]}, то {a[j]} : {!a[i] || a[j]}");
            }
            Console.WriteLine("Обратная импликация");
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                    Console.WriteLine($"Если {a[i]}, то {a[j]} : {a[i] || !a[j]}");
            }
            Console.WriteLine("Эквиваленция");
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                    Console.WriteLine($"{a[i]} тогда и только тогда, когда {a[j]} : {a[i] ^ a[j]}");
            }
        }
        static void Boolfunction8(int[] a, int[] b)
        {
            Console.WriteLine("A    | B     | A&B    | A&B-> A  |");
            Console.WriteLine("----------------------------------");
            for (int i = 0; i < a.Length; i++)
            {
                int n = a[i] & b[i];
                int t = Convert.ToInt32((!Convert.ToBoolean(n)) || Convert.ToBoolean(a[i]));
                Console.WriteLine($"{a[i]}    | {b[i]}       | {n}    | {t}         |");
            }
            Console.WriteLine();
        }
        static void Boolfunction9(int[] a, int[] b)
        {
            Console.WriteLine("f(b,a) =  (b or a) -> (not a and not b)");
            Console.WriteLine("A    | B     | notA  | notB  | AorB  |notA and notB| f(x,y)");
            Console.WriteLine("----------------------------------");
            for (int i = 0; i < a.Length; i++)
            {
                int n = Convert.ToInt32((Convert.ToBoolean(a[i])) || Convert.ToBoolean(b[i]));
                int notN = Convert.ToInt32((!Convert.ToBoolean(a[i])) || !Convert.ToBoolean(b[i]));
                int t = Convert.ToInt32((!Convert.ToBoolean(n)) || !Convert.ToBoolean(notN));
                Console.WriteLine($"{a[i]}    | {b[i]}     | {Convert.ToInt32(!Convert.ToBoolean(a[i]))}" +
                    $"     | {Convert.ToInt32(!Convert.ToBoolean(b[i]))}     | {n}     | {notN}           |{t}");
            }
        }
        #region Решение Заданий
        static void StepExpFirst()
        {
            Console.WriteLine("№1: Определить время перебора всех паролей с параметрами. Алфавит состоит из n символов. " +
                "\n\nРазмер алфавита n - 128;\n" +
                "Длина пароля k - 10;\nСкорость перебора s - 500;\n" +
                "Кол-во попыток до паузы m - 0;\nДлительность паузы v - 0\n");
            double C = Math.Round(Math.Pow(10, 6) / 10);
            Console.WriteLine($"Ответ: {C} секунд");
        }
        static void StepExpSecond()
        {
            Console.WriteLine("№2: Определить минимальную длину пароля, алфавит которого состоит из " +
                "n символов, время перебора которого было не меньше t лет. Скорость перебора s паролей в секунду" +
                          "\n\nРазмер алфавита n - 128;\n" +
                          "Время перебора t - 100;\nСкорость перебора s - 500;\n");
            double C = 100 * 500;
            double k = Math.Log(10,128);
            Console.WriteLine($"Ответ: {C} секунд");
        }
        static void StepExpThird()
        {
            Console.WriteLine("№3: Определить количество символов алфавита, пароль состоит из k символов, время перебора которого было не меньше t лет." +
                "\n\nДлина пароля k - 12;\nСкорость перебора s - 500;\n" +
                "Время перебора t - 100;\n");
            double C = Math.Round(Math.Pow(10, 6) / 10);
            Console.WriteLine($"Ответ: {C} секунд");
        }
        #endregion Решение Заданий

        static void Main(string[] args)
        {
            int[] bA = { 0, 0, 1, 1 };
            int[] bB = { 0, 1, 0, 1 };
            Boolfunction8(bA,bB);
            Boolfunction9(bA, bB);
            //Console.WriteLine("Рассчётные задачи 1-3: Вариант №7\n");

            //Console.Write("Размер алфавита: ");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Длина пароля: ");
            //int k = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Скорость перебора: ");
            //int s = Convert.ToInt32(Console.ReadLine());
            StepExpFirst();
            //StepExpSecond();
            //StepExpThird();

        }
    }
}

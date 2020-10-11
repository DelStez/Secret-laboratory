using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EllipticCurveCryptography
{
    public class Program
    {
        
        static bool Check(int a, int b, int p)
        {
            if ((4 * (int)Math.Pow(a, 3)) + ((27 * Math.Pow(b, 2)) % p) != 0)
            {
                Console.Write("Проверка условия 4 * (a^3) + 27 * (b^3) (mod p) !=0: ");
                Console.WriteLine((4 * (int)Math.Pow(a, 3)) + ((27 * Math.Pow(b, 2)) % p));
                return true;
            }
              
            return false;
        }
        static void GetMark(int p)
        {
            int minM = p + 1 - 2 * (int)Math.Round(Math.Sqrt(37));
            int maxM = p + 1 + 2 * (int)Math.Round(Math.Sqrt(37));
            Console.WriteLine($"{minM} <= m <= {maxM}") ;
        }
        public static List<Point> points = new List<Point>
        {
            new Point(0, 3), new Point(36, 3), new Point(1, 34), new Point(35, 22), new Point(9, 27), new Point(31, 13), new Point(17, 13), new Point(11, 21), new Point(14, 1), new Point(20, 21),
            new Point(13, 36), new Point(21, 31), new Point(26, 24), new Point(7, 7), new Point(19, 2), new Point(22, 4), new Point(3, 12), new Point(6, 16), new Point(10, 0), new Point(6, 21),
            new Point(3, 25), new Point(22, 33), new Point(19, 35), new Point(7, 30), new Point(26, 13), new Point(21, 6), new Point(13, 11), new Point(20, 16), new Point(14, 36), new Point(11, 16),
            new Point(17, 24), new Point(31, 24), new Point(9, 10), new Point(35, 15), new Point(1, 3), new Point(36, 34), new Point(0, 34)
        };
        public static void Main(string[] args)
        {
            int p = 37, a = -1, b = 1;
            int k = 7;
            Console.WriteLine("Введите исходный двочиный вектор");
            int vectorA = Convert.ToInt32(Console.ReadLine(), 2);
            if (Check(a, b, p) && vectorA < 37)
            {
                Console.WriteLine("Соответствует условию...");
                Console.WriteLine("Производим оценку порядка точек m ЭК...");
                GetMark(p);
                Point pA = points[vectorA];
                Console.WriteLine($"Двоичный вектор равен {vectorA}, тогда aP = Pa(Xa, Ya) = P{vectorA} ({pA.X}, {pA.Y})");
                Console.WriteLine($"Вычисляем: Pk (Xk, Yk) + Pa (Xa, Ya) = Q(X,Y)");
                int y = k + vectorA;
                Point res = points[y];
                Console.WriteLine($"Вычисляем: P{k} ({points[k].X}, {points[k].Y}) + P{vectorA} ({points[vectorA].X}, {points[vectorA].Y}) = Q({res.X},{res.Y})");
                Point res1 = points[y - k];
                Console.WriteLine($"Дешифруем: Q({res.X},{res.Y}) + P{k} ({points[k].X}, {points[k].Y}) = P{vectorA} ({res1.X}, {res1.Y})");
            }
        }
    }
}

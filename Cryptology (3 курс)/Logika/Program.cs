using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    class Program
    {
            static void allBoolfunction(bool[] a)
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
                        Console.WriteLine($"{a[i]} тогда и только тогда, когда {a[j]} : {a[i] == a[j]}");
                }
            }
            static void Boolfunction6(int[] a, int[] b)
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
            static void Boolfunction7(int[] a, int[] b)
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
                Console.WriteLine();
            }
            static void Boolfunction9(int[] a, int[] b)
            {

                Console.WriteLine("X    | Y     | not X  | not Y  | X and Y  |notX or notY | X <=> (X and Y) | (X <=> (X and Y)) => (notX or notY)");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(a[i])) && Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((!Convert.ToBoolean(a[i])) || !Convert.ToBoolean(b[i]));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(a[i])) ^ !Convert.ToBoolean(n));
                    int t = Convert.ToInt32((!Convert.ToBoolean(n3)) || Convert.ToBoolean(n2));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {Convert.ToInt32(!Convert.ToBoolean(a[i]))}  " +
                        $"    | {Convert.ToInt32(!Convert.ToBoolean(b[i]))} " +
                        $"     | {n}        " +
                        $"| {n2}           |{n3}                |{t}");
                }
                Console.WriteLine();
            }
            static void Boolfunction10(int[] a, int[] b)
            {
                Console.WriteLine("f1 = (X and Y) => (notX or notY)");
                Console.WriteLine("f2 = X <=> ((X and Y) => (notX or notY))");
                Console.WriteLine("X    | Y     | not X  | not Y  | X and Y  |notX or notY | f1     | f2   ");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(a[i])) && Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((!Convert.ToBoolean(a[i])) || !Convert.ToBoolean(b[i]));
                    int n3 = Convert.ToInt32((!Convert.ToBoolean(n)) || Convert.ToBoolean(n2));
                    int t = Convert.ToInt32((Convert.ToBoolean(a[i])) == Convert.ToBoolean(n3));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {Convert.ToInt32(!Convert.ToBoolean(a[i]))}  " +
                        $"    | {Convert.ToInt32(!Convert.ToBoolean(b[i]))} " +
                        $"     | {n}        " +
                        $"| {n2}          |{n3}       |{t}");
                }
                Console.WriteLine();
            }
            static void Boolfunction14(int[] a, int[] b)
            {
                Console.WriteLine("I.	Основные равносильности:");
                int[] first = { 0, 1 };
                Console.WriteLine("X    | X and X  | X and X <=> X");
                for (int i = 0; i < first.Length; i++)
                {
                    int temp = Convert.ToInt32(Convert.ToBoolean(first[i]) && Convert.ToBoolean(first[i]));
                    int temp1 = Convert.ToInt32(Convert.ToBoolean(temp) == Convert.ToBoolean(first[i]));
                    Console.WriteLine($"{first[i]}    | {temp}        |  {temp1}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | X or X  | X or X <=> X");
                for (int i = 0; i < first.Length; i++)
                {
                    int temp = Convert.ToInt32(Convert.ToBoolean(first[i]) || Convert.ToBoolean(first[i]));
                    int temp1 = Convert.ToInt32(Convert.ToBoolean(temp) == Convert.ToBoolean(first[i]));
                    Console.WriteLine($"{first[i]}    | {temp}        |  {temp1}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | X and 1  | X and 1 <=> X");
                for (int i = 0; i < first.Length; i++)
                {
                    int temp = Convert.ToInt32(Convert.ToBoolean(first[i]) && true);
                    int temp1 = Convert.ToInt32(Convert.ToBoolean(temp) == Convert.ToBoolean(first[i]));
                    Console.WriteLine($"{first[i]}    | {temp}        |  {temp1}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | X or 1  | X or 1 <=> 1");
                for (int i = 0; i < first.Length; i++)
                {
                    int temp = Convert.ToInt32(Convert.ToBoolean(first[i]) || true);
                    int temp1 = Convert.ToInt32(Convert.ToBoolean(temp) == true);
                    Console.WriteLine($"{first[i]}    | {temp}        |  {temp1}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | X and 0  | X and 0 <=> 0");
                for (int i = 0; i < first.Length; i++)
                {
                    int temp = Convert.ToInt32(Convert.ToBoolean(first[i]) && false);
                    int temp1 = Convert.ToInt32(Convert.ToBoolean(temp) == false);
                    Console.WriteLine($"{first[i]}    | {temp}        |  {temp1}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | X or 0  | X or 0 <=> X");
                for (int i = 0; i < first.Length; i++)
                {
                    int temp = Convert.ToInt32(Convert.ToBoolean(first[i]) || false);
                    int temp1 = Convert.ToInt32(Convert.ToBoolean(temp) == Convert.ToBoolean(first[i]));
                    Console.WriteLine($"{first[i]}    | {temp}        |  {temp1}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | X and notX  | X and notX  <=> 0");
                for (int i = 0; i < first.Length; i++)
                {
                    int temp = Convert.ToInt32(Convert.ToBoolean(first[i]) && !Convert.ToBoolean(first[i]));
                    int temp1 = Convert.ToInt32(Convert.ToBoolean(temp) == false);
                    Console.WriteLine($"{first[i]}    | {temp}        |  {temp1}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | X or notX  | X or notX  <=> 1");
                for (int i = 0; i < first.Length; i++)
                {
                    int temp = Convert.ToInt32(Convert.ToBoolean(first[i]) || !Convert.ToBoolean(first[i]));
                    int temp1 = Convert.ToInt32(Convert.ToBoolean(temp) == true);
                    Console.WriteLine($"{first[i]}    | {temp}        |  {temp1}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | notX      | not notX <=> X");
                for (int i = 0; i < first.Length; i++)
                {
                    int temp = Convert.ToInt32(!Convert.ToBoolean(first[i]));
                    int temp1 = Convert.ToInt32(!Convert.ToBoolean(temp) == Convert.ToBoolean(first[i]));
                    Console.WriteLine($"{first[i]}    | {temp}        |  {temp1}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | Y     |  X or Y  | X and (Y or X) | X and (Y or X) <=> X");
                Console.WriteLine("-----------------------------------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(a[i])) || Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((Convert.ToBoolean(a[i])) && Convert.ToBoolean(n));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(n2)) == Convert.ToBoolean(a[i]));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {Convert.ToInt32(Convert.ToBoolean(n))}    " +
                        $"    | {Convert.ToInt32(Convert.ToBoolean(n2))}        " +
                        $"     | {n3}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | Y     |  X and Y  | X or (Y and X) | X or (Y and X) <=> X");
                Console.WriteLine("-----------------------------------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(a[i])) && Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((Convert.ToBoolean(a[i])) || Convert.ToBoolean(n));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(n2)) == Convert.ToBoolean(a[i]));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {Convert.ToInt32(Convert.ToBoolean(n))}    " +
                        $"    | {Convert.ToInt32(Convert.ToBoolean(n2))}        " +
                        $"     | {n3}");
                }
                Console.WriteLine();
                Console.WriteLine("II.	Равносильности, выражающие одни логические операции через другие:");
                Console.WriteLine("X    | Y     |  X -> Y  | Y -> X |(X -> Y) and (Y -> X) | X <=> Y | (X <=> Y) <=> (X -> Y) and (Y -> X)");
                Console.WriteLine("-----------------------------------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((!Convert.ToBoolean(a[i])) || Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((!Convert.ToBoolean(b[i])) || Convert.ToBoolean(a[i]));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(n)) && Convert.ToBoolean(n2));
                    int n4 = Convert.ToInt32((Convert.ToBoolean(a[i])) == Convert.ToBoolean(b[i]));
                    int n5 = Convert.ToInt32((Convert.ToBoolean(n4)) == Convert.ToBoolean(n3));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {Convert.ToInt32(Convert.ToBoolean(n))}    " +
                        $"    | {Convert.ToInt32(Convert.ToBoolean(n2))}" +
                        $"      | {n3}                    | {n4}       | {n5}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | Y     |  X -> Y  | not X  |notX or Y | (X -> Y <=> not X or Y");
                Console.WriteLine("-----------------------------------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((!Convert.ToBoolean(a[i])) || Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((!Convert.ToBoolean(a[i])));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(n2)) || Convert.ToBoolean(b[i]));
                    int n4 = Convert.ToInt32((Convert.ToBoolean(n)) == Convert.ToBoolean(n3));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {Convert.ToInt32(Convert.ToBoolean(n))}    " +
                        $"    | {Convert.ToInt32(Convert.ToBoolean(n2))}" +
                        $"      | {n3}                    | {n4}       ");
                }
                Console.WriteLine();
                Console.WriteLine("X and Y | not(X and Y) | not X | not Y | not X or not Y |not (X and Y) <=> not X or not Y");
                Console.WriteLine("-----------------------------------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(a[i])) && Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((!Convert.ToBoolean(b[i])));
                    int n3 = Convert.ToInt32((!Convert.ToBoolean(a[i])) || !Convert.ToBoolean(b[i]));
                    int n4 = Convert.ToInt32((!Convert.ToBoolean(n)) == Convert.ToBoolean(n3));
                    Console.WriteLine($"{n}      " +
                        $" | {n2}      " +
                        $"      | {Convert.ToInt32(!Convert.ToBoolean(a[i]))}" +
                        $"     | {Convert.ToInt32(!Convert.ToBoolean(b[i]))}" +
                        $"      | {n3}            | {n4}       ");
                }
                Console.WriteLine();
                Console.WriteLine("X or Y | not(X or Y) | not X | not Y | not X and not Y |not (X or Y) <=> not X and not Y");
                Console.WriteLine("-----------------------------------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(a[i])) || Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((!Convert.ToBoolean(n)));
                    int n3 = Convert.ToInt32((!Convert.ToBoolean(a[i])) && !Convert.ToBoolean(b[i]));
                    int n4 = Convert.ToInt32((!Convert.ToBoolean(n)) == Convert.ToBoolean(n3));
                    Console.WriteLine($"{n}     " +
                        $" | {n2}     " +
                        $"      | {Convert.ToInt32(!Convert.ToBoolean(a[i]))}" +
                        $"     | {Convert.ToInt32(!Convert.ToBoolean(b[i]))}" +
                        $"      | {n3}              | {n4}       ");
                }
                Console.WriteLine();
                Console.WriteLine("not X  | not Y  | not X or not Y | not(not X or not Y) | X and Y | X and Y <=> not(not X or not Y)");
                Console.WriteLine("-----------------------------------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((!Convert.ToBoolean(a[i])) || !Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((!Convert.ToBoolean(n)));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(a[i])) && Convert.ToBoolean(b[i]));
                    int n4 = Convert.ToInt32((Convert.ToBoolean(n3)) == Convert.ToBoolean(n2));
                    Console.WriteLine($"{Convert.ToInt32(!Convert.ToBoolean(a[i]))}     " +
                        $" | {Convert.ToInt32(!Convert.ToBoolean(b[i]))}      " +
                        $"| {n}          " +
                        $"    | {n2}             " +
                        $"      | {n3}       | {n4}       ");
                }
                Console.WriteLine();
                Console.WriteLine("not X  | not Y  | not X and not Y | not(not X and not Y) | X and Y | X or Y <=> not(not X and not Y)");
                Console.WriteLine("-----------------------------------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((!Convert.ToBoolean(a[i])) && !Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((!Convert.ToBoolean(n)));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(a[i])) || Convert.ToBoolean(b[i]));
                    int n4 = Convert.ToInt32((Convert.ToBoolean(n3)) == Convert.ToBoolean(n2));
                    Console.WriteLine($"{Convert.ToInt32(!Convert.ToBoolean(a[i]))}     " +
                        $" | {Convert.ToInt32(!Convert.ToBoolean(b[i]))}      " +
                        $"| {n}          " +
                        $"    | {n2}             " +
                        $"      | {n3}       | {n4}       ");
                }
                int[] X = { 0, 0, 0, 0, 1, 1, 1, 1 };
                int[] Y = { 0, 0, 1, 1, 0, 0, 1, 1 };
                int[] Z = { 0, 1, 0, 1, 0, 1, 0, 1 };
                Console.WriteLine();
                Console.WriteLine("III.	Равносильности, выражающие основные законы алгебры логики:");
                Console.WriteLine("X    | Y     |  X and Y  | Y and X | X and Y <=> Y and X");
                Console.WriteLine("---------------------------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(a[i])) && Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((Convert.ToBoolean(b[i])) && Convert.ToBoolean(a[i]));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(n)) == Convert.ToBoolean(n2));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {n}    " +
                        $"    | {n2}" +
                        $"      | {n3}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | Y     |  X or Y  | Y or X | X or Y <=> Y or X");
                Console.WriteLine("---------------------------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(a[i])) || Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((Convert.ToBoolean(b[i])) || Convert.ToBoolean(a[i]));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(n)) == Convert.ToBoolean(n2));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {n}    " +
                        $"    | {n2}" +
                        $"      | {n3}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | Y     | Z     | Y and Z | X and (Y and Z) | X and Y | (X and Y) and Z | X and (Y and Z) <=> (X and Y) and Z");
                Console.WriteLine("---------------------------------------------------------");
                for (int i = 0; i < X.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(Y[i])) && Convert.ToBoolean(Z[i]));
                    int n2 = Convert.ToInt32((Convert.ToBoolean(X[i])) && Convert.ToBoolean(n));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(X[i])) && Convert.ToBoolean(Y[i]));
                    int n4 = Convert.ToInt32((Convert.ToBoolean(n)) && Convert.ToBoolean(n2));
                    int n5 = Convert.ToInt32((Convert.ToBoolean(n4)) == Convert.ToBoolean(n2));
                    Console.WriteLine($"{X[i]}   " +
                        $" | {Y[i]}     " +
                        $"| {Z[i]}     " +
                        $"| {n}       " +
                        $"| {n2}               " +
                        $"| {n3}       " +
                        $"| {n4}               " +
                        $"| {n5}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | Y     | Z     | Y or Z | X or (Y or Z) | X or Y | (X or Y) or Z | X or (Y or Z) <=> (X or Y) or Z");
                Console.WriteLine("---------------------------------------------------------");
                for (int i = 0; i < X.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(Y[i])) || Convert.ToBoolean(Z[i]));
                    int n2 = Convert.ToInt32((Convert.ToBoolean(X[i])) || Convert.ToBoolean(n));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(X[i])) || Convert.ToBoolean(Y[i]));
                    int n4 = Convert.ToInt32((Convert.ToBoolean(n)) || Convert.ToBoolean(n2));
                    int n5 = Convert.ToInt32((Convert.ToBoolean(n4)) == Convert.ToBoolean(n2));
                    Console.WriteLine($"{X[i]}   " +
                        $" | {Y[i]}     " +
                        $"| {Z[i]}     " +
                        $"| {n}       " +
                        $"| {n2}               " +
                        $"| {n3}       " +
                        $"| {n4}               " +
                        $"| {n5}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | Y     | Z     | Y or Z | X and (Y or Z) | X and Y | X and Z | (X and Y) or (X and Z) | X and (Y or Z) <=> X and Y or X and Z");
                Console.WriteLine("---------------------------------------------------------");
                for (int i = 0; i < X.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(Y[i])) || Convert.ToBoolean(Z[i]));
                    int n2 = Convert.ToInt32((Convert.ToBoolean(X[i])) && Convert.ToBoolean(n));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(X[i])) && Convert.ToBoolean(Y[i]));
                    int n4 = Convert.ToInt32((Convert.ToBoolean(X[i])) && Convert.ToBoolean(Z[i]));
                    int n5 = Convert.ToInt32((Convert.ToBoolean(n4)) || Convert.ToBoolean(n3));
                    int n6 = Convert.ToInt32((Convert.ToBoolean(n5)) == Convert.ToBoolean(n2));
                    Console.WriteLine($"{X[i]}   " +
                        $" | {Y[i]}     " +
                        $"| {Z[i]}     " +
                        $"| {n}      " +
                        $"| {n2}              " +
                        $"| {n3}       " +
                        $"| {n4}       " +
                        $"| {n5}                      " +
                        $"| {n6}");
                }
                Console.WriteLine();
                Console.WriteLine("X    | Y     | Z     | Y and Z | X or (Y and Z) | X or Y | X or Z | (X or Y) and (X or Z) | X or (Y and Z) <=> X or Y and X or Z");
                Console.WriteLine("---------------------------------------------------------");
                for (int i = 0; i < X.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(Y[i])) && Convert.ToBoolean(Z[i]));
                    int n2 = Convert.ToInt32((Convert.ToBoolean(X[i])) || Convert.ToBoolean(n));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(X[i])) || Convert.ToBoolean(Y[i]));
                    int n4 = Convert.ToInt32((Convert.ToBoolean(X[i])) || Convert.ToBoolean(Z[i]));
                    int n5 = Convert.ToInt32((Convert.ToBoolean(n4)) && Convert.ToBoolean(n3));
                    int n6 = Convert.ToInt32((Convert.ToBoolean(n5)) == Convert.ToBoolean(n2));
                    Console.WriteLine($"{X[i]}   " +
                        $" | {Y[i]}     " +
                        $"| {Z[i]}     " +
                        $"| {n}      " +
                        $"| {n2}              " +
                        $"| {n3}       " +
                        $"| {n4}       " +
                        $"| {n5}                      " +
                        $"| {n6}");
                }
            }
            static void Func15(int[] a, int[] b)
            {

                Console.WriteLine("f = A and B -> A");
                Console.WriteLine("A    | B     | A and B | A and B -> A");
                Console.WriteLine("---------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(a[i])) && Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((Convert.ToBoolean(n)) || !Convert.ToBoolean(a[i]));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {n}       " +
                        $"| {n2}");
                }
                Console.WriteLine();
                Console.WriteLine("f= A  -> ( B -> A and B)");
                Console.WriteLine("A    | B     | A and B |  B -> A and B | A  -> ( B -> A and B)");
                Console.WriteLine("---------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(a[i])) && Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((!Convert.ToBoolean(b[i])) || Convert.ToBoolean(n));
                    int n3 = Convert.ToInt32((!Convert.ToBoolean(a[i])) || Convert.ToBoolean(n2));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {n}       " +
                        $"| {n2}             " +
                        $"| {n3}");
                }
                Console.WriteLine();
                Console.WriteLine("f= (A and B) or (A and not B)");
                Console.WriteLine("A    | B     | A and B | A and not B | (A and B) or (A and not B)");
                Console.WriteLine("---------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((Convert.ToBoolean(a[i])) && Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((Convert.ToBoolean(a[i])) && !Convert.ToBoolean(b[i]));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(n)) || Convert.ToBoolean(n2));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {n}       " +
                        $"| {n2}           " +
                        $"| {n3}");
                }
                Console.WriteLine();
                Console.WriteLine("f = (A ->  B) or (B -> A)");
                Console.WriteLine("A    | B     | A ->  B | B -> A | (A ->  B) or (B -> A)");
                Console.WriteLine("---------------------------------------");
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((!Convert.ToBoolean(a[i])) || Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((!Convert.ToBoolean(b[i])) || Convert.ToBoolean(a[i]));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(n)) || Convert.ToBoolean(n2));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {n}       " +
                        $"| {n2}           " +
                        $"| {n3}");
                }
                Console.WriteLine();
            }
            static void Func16()
            {
                int[] X = { 0, 0, 0, 0, 1, 1, 1, 1 };
                int[] Y = { 0, 0, 1, 1, 0, 0, 1, 1 };
                int[] Z = { 0, 1, 0, 1, 0, 1, 0, 1 };
                Console.WriteLine("f= (A or B or C) and not( A or (not B) or C)");
                Console.WriteLine("A    | B     | C      | A or B or C |  A and (not B) and C | (A or B or C) and not( A or (not B) or C) || B and not A and not C");
                Console.WriteLine("---------------------------------------");
                for (int i = 0; i < X.Length; i++)
                {
                    int AorBorC = Convert.ToInt32((Convert.ToBoolean(X[i]) || Convert.ToBoolean(Y[i]) || Convert.ToBoolean(Z[i])));
                    int AandnotBandC = Convert.ToInt32((Convert.ToBoolean(X[i]) || !Convert.ToBoolean(Y[i]) || Convert.ToBoolean(Z[i])));
                    int result = Convert.ToInt32((Convert.ToBoolean(AorBorC) && !Convert.ToBoolean(AandnotBandC)));
                    int BandnotAandnotC = Convert.ToInt32((Convert.ToBoolean(Y[i]) && !Convert.ToBoolean(X[i]) && !Convert.ToBoolean(Z[i])));
                    Console.WriteLine($"{X[i]}    " +
                        $"| {Y[i]}     " +
                        $"| {Z[i]}      " +
                        $"| {AorBorC}           " +
                        $"| {AandnotBandC}                    " +
                        $"| {result}                                        " +
                        $"| {BandnotAandnotC}");
                }
                Console.WriteLine();

            }
            static void Func17(int[] a, int[] b)
            {
                Console.WriteLine("not (not A and A) or B and  (A and B or B)");
                Console.WriteLine("A    | B     | not (not A and A) or B | A and B or B | not (not A and A) or B and  (A and B or B)");
                Console.WriteLine("---------------------------------------");
                bool isTrueTrue = true;
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32(!(!Convert.ToBoolean(a[i]) && Convert.ToBoolean(a[i])) || Convert.ToBoolean(b[i]));
                    int n2 = Convert.ToInt32((Convert.ToBoolean(a[i])) && Convert.ToBoolean(b[i]) || Convert.ToBoolean(b[i]));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(n)) || Convert.ToBoolean(n2));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {n}         " +
                        $"| {n2}        " +
                        $"| {n3}");
                    if (n3 == 0) isTrueTrue = false;
                }
                Console.WriteLine(isTrueTrue ? "Выражение тождественно-истинно" : "");
                Console.WriteLine();
                Console.WriteLine("not (not A and A) or B and  (A and B or B)");
                Console.WriteLine("A    | B     | not A or not B  | B and (not A or not B) |A and B and (not A or not B)");
                Console.WriteLine("---------------------------------------");
                isTrueTrue = true;
                for (int i = 0; i < a.Length; i++)
                {
                    int n = Convert.ToInt32((!Convert.ToBoolean(a[i]) || !Convert.ToBoolean(b[i])));
                    int n2 = Convert.ToInt32((Convert.ToBoolean(b[i])) && Convert.ToBoolean(n));
                    int n3 = Convert.ToInt32((Convert.ToBoolean(a[i])) && Convert.ToBoolean(n2));
                    Console.WriteLine($"{a[i]}   " +
                        $" | {b[i]}     " +
                        $"| {n}         " +
                        $"| {n2}        " +
                        $"| {n3}");
                    if (n3 == 0) isTrueTrue = false;
                }
                Console.WriteLine(isTrueTrue ? "Выражение тождественно-истинно" : "Выражение тождественно - ложно");
            }
            static void Main(string[] args)
            {
                int[] bA = { 0, 0, 1, 1 };
                int[] bB = { 0, 1, 0, 1 };
                Console.WriteLine("№4\n");
                allBoolfunction(new bool[] { false, true });
                Console.WriteLine("№6\n");
                Boolfunction6(bA, bB);
                Console.WriteLine("№7\n");
                Boolfunction7(bA, bB);
                Console.WriteLine("№9\n");
                Boolfunction9(bA, bB);
                Console.WriteLine("№10\n");
                Boolfunction10(bA, bB);
                Console.WriteLine("№14\n");
                Boolfunction14(bA, bB);
                Console.WriteLine("№15\n");
                Func15(bA, bB);
                Console.WriteLine("№16\n");
                Func16();
                Console.WriteLine("№17\n");
                Func17(bA, bB);
                Console.Read();
            }
    }
}

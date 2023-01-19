using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme___setul_3
{
    internal class Program
    {
        static int[] Test(int n)
        {
            Random rnd = new Random();
            int[] A = new int[n];
            for (int i = 0; i < n; i++)
            {
                A[i] = rnd.Next(1, 100);
                Console.Write($"{A[i]} ");
            }
            return A;
        }
        static int[] TestCrescator(int n)
        {
            Random rnd = new Random();
            int[] A = new int[n];
            A[0] = rnd.Next(1, n);
            for (int i = 1; i < n; i++)
            {
                A[i] = rnd.Next(A[i - 1] + 1, A[i - 1] + 30);
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{A[i]} ");
            }
            return A;
        }
        static double val(double[] P, double x)
        {
            double suma = 0;
            for (int i = 0; i < P.Length; i++)
                suma += P[i] * Math.Pow(x, i);
            return suma;
        }
        static int check(int[] s1, int[] s2)
        {
            int min = s1.Length;
            if (s2.Length < min) min = s2.Length;
            for (int i = 0; i < min; i++)
                if (s1[i] != s2[i])
                {
                    if (s1[i] > s2[i])
                        return 1;
                    else
                        return -1;
                }
            if (s1.Length == min && s2.Length == min)
                return 0;
            if (s1.Length == min)
                return -1;
            else
            if (s2.Length == min)
                return 1;
            else
                return 0;

        }
        static void p1()
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            int s = 0;
            for (int i = 0; i < n; i++)
            {
                v[i] = int.Parse(t[i]);
            }
            for (int i = 0; i < n; i++)
            {
                s += v[i];
            }
            Console.WriteLine(s);
        }
        static void p2()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int pozitie = -1;
            int[] v = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                v[i] = int.Parse(t[i]);
            }
            for (int i = 0; i < n; i++)
            {
                if (v[i] == k)
                    pozitie = i;
            }
            Console.WriteLine(pozitie);
        }
        static void p3()
        {
            //Pentru extra-credit realizati programul efectuand 3n/2 comparatii (in cel mai rau caz). 
            int i;
            int n = int.Parse(Console.ReadLine());
            int[] A = Test(n);
            /*int[] A = new int[n];*/
            int max, min, poz_max, poz_min;
            int comparatii = 0;
            if (n % 2 == 0)
            {
                if (A[0] > A[1])
                {
                    max = A[0];
                    min = A[1];
                    poz_max = 0;
                    poz_min = 1;
                }
                else
                {
                    min = A[0];
                    max = A[1];
                    poz_min = 0;
                    poz_max = 1;
                }
                i = 2;
                comparatii += 2;
            }
            else
            {
                min = A[0];
                max = A[0];
                poz_min = 0;
                poz_max = 0;
                i = 1;
                comparatii++;
            }

            while (i < n - 1)
            {
                if (A[i] > A[i + 1])
                {
                    if (A[i] > max)
                    {
                        max = A[i];
                        poz_max = i;
                    }
                    if (A[i + 1] < min)
                    {
                        min = A[i + 1];
                        poz_min = i + 1;
                    }
                    comparatii += 3;
                }
                else
                {
                    if (A[i + 1] > max)
                    {
                        max = A[i + 1];
                        poz_max = i + 1;
                    }
                    if (A[i] < min)
                    {
                        min = A[i];
                        poz_min = i;
                    }
                    comparatii += 3;
                }
                i += 2;
            }
            Console.WriteLine($"Pozitia minimului este {poz_min}({min}), iar pozitia maximului este {poz_max}({max})");
            Console.WriteLine($"Numarul de comparatii este {comparatii}");
        }
        static void p4()
        {
            int n = int.Parse(Console.ReadLine());
            int[] A = Test(n);
            int max = A[0];
            int min = A[0];
            int aparmax = 1;
            int aparmin = 1;
            for(int i = 0; i < n; i++)
            {
                if (A[i] > max)
                {
                    max = A[i];
                    aparmax = 1;
                }
                else if (A[i] == max)
                    aparmax++;
                if (A[i] < min)
                {
                    min = A[i];
                    aparmin = 1;
                }
                else if (A[i] == min)
                    aparmin++;
            }
            Console.WriteLine($"Numarul minim este {min} si apare de {aparmin} ori, iar numarul maxim este {max} si apare de {aparmax} ori");
        }
        static void p5()
        {
            Console.WriteLine("Introduceti lungimea vectorului:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti valoarea lui e:");
            int e = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti valoarea lui k:");
            int k = int.Parse(Console.ReadLine());
            int[] A = Test(n);
            int[] B = new int[n + 1];
            for (int i = 0, j = 0; i < n && j <= n; i++, j++)
            {
                if (k != i)
                    B[j] = A[i];
                else
                {
                    B[j] = e;
                    j++;
                    B[j] = A[i];
                }
            }
            Console.WriteLine();
            for (int i = 0; i <= n; i++)
            {
                Console.Write($"{B[i]} ");
            }
        }
        static void p6()
        {
            Console.WriteLine("Introduceti lungimea vectorului:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti valoarea lui k:");
            int k = int.Parse(Console.ReadLine());
            int[] A = Test(n);
            int[] B = new int[n - 1];
            for (int i = 0, j = 0; i < n && j < n - 1; i++, j++)
            {
                if (k != i)
                    B[j] = A[i];
                else
                {
                    i++;
                    B[j] = A[i];
                }
            }
            Console.WriteLine();
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write($"{B[i]} ");
            }
        }
        static void p7()
        {
            Console.WriteLine("Introduceti lungimea vectorului:");
            int n = int.Parse(Console.ReadLine());
            int[] A = Test(n);
            int[] B = new int[n];
            int j = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                B[j] = A[i];
                j++;
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{B[i]} ");
            }
        }
        static void p8()
        {
            Console.WriteLine("Introduceti lungimea vectorului:");
            int n = int.Parse(Console.ReadLine());
            int[] A = Test(n);
            int k = A[0];
            for (int i = 0; i < n - 1; i++)
            {
                A[i] = A[i + 1];
            }
            A[n - 1] = k;
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{A[i]} ");
            }
        }
        static void p9()
        {
            Console.WriteLine("Introduceti lungimea vectorului:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti valoarea lui k:");
            int k = int.Parse(Console.ReadLine());
            int[] A = Test(n);
            int[] B = new int[n];
            int temp = n - k;
            int j = 0;
            for (int i = k; i < n; i++)
            {
                B[j] = A[i];
                j++;
            }
            for (int i = 0; i < k; i++)
            {
                B[j] = A[i];
                j++;
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{B[i]} ");
            }
        }
        static void p10()
        {
            int n = int.Parse(Console.ReadLine());
            int[] A = TestCrescator(n);
            Console.WriteLine("Introduceti valoarea lui k:");
            int k = int.Parse(Console.ReadLine());
            int left = 0;
            int right = A.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (k == A[mid])
                {
                    Console.WriteLine($"Pozitia lui k este:{mid}");
                    return;
                }
                else if (k < A[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            Console.WriteLine(-1);
        }
        static void p11()
        {
            int n = int.Parse(Console.ReadLine());
            bool[] A = new bool[n];
            for (int i = 2; i < n; i++)
            {
                if (A[i] == false)
                for (int j = i + i; j < n; j += i)
                {
                        A[j] = true;
                }
            }
            Console.WriteLine();
            for (int i = 2; i < n; i++)
            {
                if (!A[i])
                    Console.Write($"{i} ");
            }
        }
        static void p12()
        {
            int n = int.Parse(Console.ReadLine());
            int[] A = Test(n);
            for (int i = 0; i < n - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (A[j] < A[min])
                    {
                        min = j;
                    }
                }

                int temp = A[min];
                A[min] = A[i];
                A[i] = temp;
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
                Console.Write($"{A[i]} ");
        }
        static void p13()
        {
            int n = int.Parse(Console.ReadLine());
            int[] A = Test(n);
            for (int i = 1; i < n; ++i)
            {
                int key = A[i];
                int j = i - 1;
                while (j >= 0 && A[j] > key)
                {
                    A[j + 1] = A[j];
                    j = j - 1;
                }
                A[j + 1] = key;
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
                Console.Write($"{A[i]} ");
        }
        static void p14()
        {
            int n = int.Parse(Console.ReadLine());
            int[] A = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            int nonZeroPointer = 0;
            for (int i = 0; i < n; i++)
            {
                A[i] = int.Parse(t[i]);
            }
            for (int i = 0; i < n; i++)
            {
                if (A[i] != 0)
                {
                    int temp = A[nonZeroPointer];
                    A[nonZeroPointer] = A[i];
                    A[i] = temp;
                    nonZeroPointer++;
                }
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
                Console.Write($"{A[i]} ");
        }
        static void p15()
        {
            int n = int.Parse(Console.ReadLine());
            int[] A = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                A[i] = int.Parse(t[i]);
            }
            A = A.Distinct().ToArray();
            Console.WriteLine();
            for (int i = 0; i < A.Length; i++)
                Console.Write($"{A[i]} ");
        }
        static void p16()
        {
            /*int n = int.Parse(Console.ReadLine());
            int[] A = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                A[i] = int.Parse(t[i]);
            }*/
            int n = int.Parse(Console.ReadLine());
            int[] A = Test(n);
            int a = A[0];
            int b, r;
            for (int i = 1; i < n; i++)
            {
                r = a % A[i];
                while (r > 0)
                {
                    a = A[i];
                    A[i] = r;
                    r = a % A[i];
                }
                a = A[i];
            }
            Console.WriteLine();
            Console.WriteLine($"Cmmdc al vectorului este {a}");
        }
        static void p17()
        {
            int n = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int[] A = new int[32];
            int i = 0;
            while (n > 0)
            {
                A[i] = n % b;
                n /= b;
                i++;
            }
            for (int j = i - 1; j >= 0; j--)
                Console.Write($"{A[j]} ");
        }
        static void p18()
        {
            TextReader load = new StreamReader(@"..\..\Resurse\polinom.txt");

            int n = int.Parse(load.ReadLine());
            double[] P = new double[n];
            string[] t = load.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                P[i] = double.Parse(t[i]);
            }
            double x = double.Parse(load.ReadLine());
            Console.Write(val(P, x).ToString());
        }
        static void p19()
        {
            TextReader load = new StreamReader(@"..\..\Resurse\vectori.txt");

            string[] t1 = load.ReadLine().Split(' ');
            int[] s = new int[t1.Length];
            for (int i = 0; i < t1.Length; i++)
                s[i] = int.Parse(t1[i]);

            string[] t2 = load.ReadLine().Split(' ');
            int[] p = new int[t2.Length];
            for (int i = 0; i < t2.Length; i++)
                p[i] = int.Parse(t2[i]);
            int nr = 0;
            for (int i = 0; i < s.Length - p.Length + 1; i++)
            {
                if (s[i] == p[0])
                {
                    bool ok = true;
                    for (int j = 1; j < p.Length; j++)
                        if (p[j] != s[i + j])
                            ok = false;
                    if (ok) nr++;
                }
            }
            Console.WriteLine();
            Console.Write($"p apare in s de {nr} ori");
        }
        static void p20()
        {
            TextReader load = new StreamReader(@"..\..\Resurse\margele.txt");

            string[] t1 = load.ReadLine().Split(' ');
            int[] s1 = new int[t1.Length];
            for (int i = 0; i < t1.Length; i++)
                s1[i] = int.Parse(t1[i]);

            string[] t2 = load.ReadLine().Split(' ');
            int[] s2 = new int[t2.Length];
            for (int i = 0; i < t2.Length; i++)
                s2[i] = int.Parse(t2[i]);
            int max = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                int s = 0;
                for (int j = 0; j < s2.Length; j++)
                    if (s1[(i + j) % s1.Length] == s2[j])
                        s++;
                if (s > max) max = s;
            }
            Console.Write(max);
        }
        static void p21()
        {
            string[] t1 = Console.ReadLine().Split(' ');
            int[] s1 = new int[t1.Length];
            for (int i = 0; i < t1.Length; i++)
                s1[i] = int.Parse(t1[i]);
            string[] t2 = Console.ReadLine().Split(' ');
            int[] s2 = new int[t1.Length];
            for (int i = 0; i < t2.Length; i++)
                s2[i] = int.Parse(t2[i]);
            Console.Write(check(s1, s2));
        }
        static void p22()
        {
            string[] t1 = Console.ReadLine().Split(' ');
            int[] v1 = new int[t1.Length];
            for (int i = 0; i < t1.Length; i++)
                v1[i] = int.Parse(t1[i]);
            string[] t2 = Console.ReadLine().Split(' ');
            int[] v2 = new int[t2.Length];
            for (int i = 0; i < t2.Length; i++)
                v2[i] = int.Parse(t2[i]);
            int lungime = t1.Length + t2.Length;
            int[] N = new int[lungime];
            int[] U = new int[lungime];
            int[] D1 = new int[lungime];
            int[] D2 = new int[lungime];
            int a = 0, nl = 0;
            for (int i = 0; i < t1.Length; i++)
            {
                for (int j = 0; j < t2.Length; j++)
                    if (v1[i] == v2[j])
                    {
                        N[a++] = v1[i];
                        nl++;
                    }
            }
            for (a = 0; a < nl; a++)
                Console.Write(N[a] + " ");
            Console.WriteLine();

            int b = 0;
            for (int i = 0; i < t1.Length; i++)
            {
                U[b++] = v1[i];
            }
            for (int i = 0; i < t2.Length; i++)
            {
                U[b++] = v2[i];
            }
            for (b = 0; b < lungime; b++)
                Console.Write(U[b] + " ");
            Console.WriteLine();

            int c = 0;
            for (int i = 0; i < t1.Length; i++)
            {
                bool d1 = true;
                for (int j = 0; j < t2.Length; j++)
                {

                    if (v1[i] == v2[j])
                    {
                        d1 = false;
                    }

                }
                if (d1)
                {
                    D1[c] = v1[i];
                    c++;
                }
            }
            for (int i = 0; i < c; i++)
                Console.Write(D1[i] + " ");
            Console.WriteLine();

            int d = 0;
            for (int i = 0; i < t2.Length; i++)
            {
                bool d2 = true;
                for (int j = 0; j < t1.Length; j++)
                {

                    if (v2[i] == v1[j])
                    {
                        d2 = false;
                    }
                }
                if (d2)

                    D2[d++] = v2[i];
            }
            for (int i = 0; i < d; i++)
                Console.Write(D2[i] + " ");

        }
        static void p23()
        {
            string[] t1 = Console.ReadLine().Split(' ');
            int[] v1 = new int[t1.Length];
            for (int i = 0; i < t1.Length; i++)
                v1[i] = int.Parse(t1[i]);
            string[] t2 = Console.ReadLine().Split(' ');
            int[] v2 = new int[t2.Length];
            for (int i = 0; i < t2.Length; i++)
                v2[i] = int.Parse(t2[i]);
            int lungime = t1.Length + t2.Length;
            int[] N = new int[lungime];
            int[] U = new int[lungime];
            int[] D1 = new int[lungime];
            int[] D2 = new int[lungime];
            int a = 0, nl = 0;
            for (int i = 0; i < t1.Length; i++)
            {
                for (int j = 0; j < t2.Length; j++)
                    if (v1[i] == v2[j])
                    {
                        N[a++] = v1[i];
                        nl++;
                    }
            }
            for (a = 0; a < nl; a++)
                Console.Write(N[a] + " ");
            Console.WriteLine();

            int b = 0;
            for (int i = 0; i < t1.Length; i++)
            {
                U[b++] = v1[i];
            }
            for (int i = 0; i < t2.Length; i++)
            {
                U[b++] = v2[i];
            }
            for (b = 0; b < lungime; b++)
                Console.Write(U[b] + " ");
            Console.WriteLine();

            int c = 0;
            for (int i = 0; i < t1.Length; i++)
            {
                bool d1 = true;
                for (int j = 0; j < t2.Length; j++)
                {

                    if (v1[i] == v2[j])
                    {
                        d1 = false;
                    }

                }
                if (d1)
                {
                    D1[c] = v1[i];
                    c++;
                }
            }
            for (int i = 0; i < c; i++)
                Console.Write(D1[i] + " ");
            Console.WriteLine();

            int d = 0;
            for (int i = 0; i < t2.Length; i++)
            {
                bool d2 = true;
                for (int j = 0; j < t1.Length; j++)
                {

                    if (v2[i] == v1[j])
                    {
                        d2 = false;
                    }
                }
                if (d2)

                    D2[d++] = v2[i];
            }
            for (int i = 0; i < d; i++)
                Console.Write(D2[i] + " ");

        }



        static void Main(string[] args)
        {
            {
                Console.WriteLine("Introduceti numarul problemei:");
                int nrp = int.Parse(Console.ReadLine());
                if (nrp == 1)
                {
                    Console.WriteLine("Problema " + nrp);
                    p1();
                }
                if (nrp == 2)
                {
                    Console.WriteLine("Problema " + nrp);
                    p2();
                }
                if (nrp == 3)
                {
                    Console.WriteLine("Problema " + nrp);
                    p3();
                }
                if (nrp == 4)
                {
                    Console.WriteLine("Problema " + nrp);
                    p4();
                }
                if (nrp == 5)
                {
                    Console.WriteLine("Problema " + nrp);
                    p5();
                }
                if (nrp == 6)
                {
                    Console.WriteLine("Problema " + nrp);
                    p6();
                }
                if (nrp == 7)
                {
                    Console.WriteLine("Problema " + nrp);
                    p7();
                }
                if (nrp == 8)
                {
                    Console.WriteLine("Problema " + nrp);
                    p8();
                }
                if (nrp == 9)
                {
                    Console.WriteLine("Problema " + nrp);
                    p9();
                }
                if (nrp == 10)
                {
                    Console.WriteLine("Problema " + nrp);
                    p10();
                }
                if (nrp == 11)
                {
                    Console.WriteLine("Problema " + nrp);
                    p11();
                }
                if (nrp == 12)
                {
                    Console.WriteLine("Problema " + nrp);
                    p12();
                }
                if (nrp == 13)
                {
                    Console.WriteLine("Problema " + nrp);
                    p13();
                }
                if (nrp == 14)
                {
                    Console.WriteLine("Problema " + nrp);
                    p14();
                }
                if (nrp == 15)
                {
                    Console.WriteLine("Problema " + nrp);
                    p15();
                }
                if (nrp == 16)
                {
                    Console.WriteLine("Problema " + nrp);
                    p16();
                }
                if (nrp == 17)
                {
                    Console.WriteLine("Problema " + nrp);
                    p17();
                }
                if (nrp == 18)
                {
                    Console.WriteLine("Problema " + nrp);
                    p18();
                }
                if (nrp == 19)
                {
                    Console.WriteLine("Problema " + nrp);
                    p19();
                }
                if (nrp == 20)
                {
                    Console.WriteLine("Problema " + nrp);
                    p20();
                }
                if (nrp == 21)
                {
                    Console.WriteLine("Problema " + nrp);
                    p21();
                }
                if (nrp == 22)
                {
                    Console.WriteLine("Problema " + nrp);
                    p22();
                }
                if (nrp == 23)
                {
                    Console.WriteLine("Problema " + nrp);
                    p23();
                }
                if (nrp == 24)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p24();
                }
                if (nrp == 25)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p25();
                }
                if (nrp == 26)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p26();
                }
                if (nrp == 27)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p27();
                }
                if (nrp == 28)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p28();
                }
                if (nrp == 29)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p29();
                }
                if (nrp == 30)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p30();
                }
                if (nrp == 31)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p31();
                }
                Console.ReadKey();
            }
        }

    }
}

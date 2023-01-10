using System;
using System.Collections.Generic;
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
                    //p8();
                }
                if (nrp == 9)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p9();
                }
                if (nrp == 10)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p10();
                }
                if (nrp == 11)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p11();
                }
                if (nrp == 12)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p12();
                }
                if (nrp == 13)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p13();
                }
                if (nrp == 14)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p14();
                }
                if (nrp == 15)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p15();
                }
                if (nrp == 16)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p16();
                }
                if (nrp == 17)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p17();
                }
                if (nrp == 18)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p18();
                }
                if (nrp == 19)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p19();
                }
                if (nrp == 20)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p20();
                }
                if (nrp == 21)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p21();
                }
                if (nrp == 22)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p22();
                }
                if (nrp == 23)
                {
                    Console.WriteLine("Problema " + nrp);
                    //p23();
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

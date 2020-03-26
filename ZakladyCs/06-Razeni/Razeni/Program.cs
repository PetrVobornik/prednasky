using System;
using System.Diagnostics;
using System.Linq;

namespace Razeni
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int[] a = new int[1000];
            int[] b = new int[a.Length];
            int[] c = new int[a.Length];
            int[] d = new int[a.Length];
            int[] e = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = random.Next(a.Length);
                b[i] = a[i];
                c[i] = a[i];
                d[i] = a[i];
                e[i] = a[i];
            }

            //SelectionSort(a);
            //InsertionSort(a);
            //BoubbleSort(a);
            //QuickSort(a);
            //LinqSort(a);

            Serad(a, SelectionSort);
            Serad(b, InsertionSort);
            Serad(c, BoubbleSort);
            Serad(d, QuickSort);
            Serad(e, LinqSort);

            //for (int i = 0; i < a.Length; i++)
            //    Console.Write("{0}, ", a[i]);

            Console.ReadLine();
        }

        static ulong PocetKroku;
        delegate void RadiciMetoda(int[] a);

        static void Serad(int[] a, RadiciMetoda metoda)
        {
            Console.WriteLine(metoda.Method.Name);
            PocetKroku = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            metoda(a);
            double cas = sw.Elapsed.TotalMilliseconds;
            sw.Stop();
            Console.WriteLine("Kroků: {0:N0}", PocetKroku);
            Console.WriteLine("Čas:   {0:N5} ms", cas);
            Console.WriteLine();
        }

        static void LinqSort(int[] a)
        {
            a = a.OrderBy(x => x).ToArray();
        }

        static void QuickSort(int[] a)
        {
            QuickSort(a, 0, a.Length - 1);
        }

        static void QuickSort(int[] a, int iFrom, int iTo)
        {
            if (iFrom >= iTo) return;

            int iMez = iFrom;
            for (int i = iFrom+1; i <= iTo; i++)
            {
                if (a[i] < a[iFrom])
                    Prohod(a, i, ++iMez);
                PocetKroku++;
            }
            Prohod(a, iFrom, iMez);
            QuickSort(a, iFrom, iMez - 1);
            QuickSort(a, iMez + 1, iTo);
        }

        static void BoubbleSort(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                bool prohodil = false;
                for (int j = 0; j < a.Length - 1 - i; j++)
                {
                    if (a[j + 1] < a[j])
                    {
                        Prohod(a, j, j + 1);
                        prohodil = true;
                    }
                    PocetKroku++;
                }
                if (!prohodil) return;
            }
        }

        static void InsertionSort(int[] a)
        {
            for (int i = 0; i < a.Length-1; i++)
            {
                int j = i + 1;  // index zařazovaného prvku
                int p = a[j];   // hodnota zařazovaného prvku
                while (j > 0 && p < a[j-1])
                {
                    a[j] = a[j - 1]; // posun většího prvku doprava
                    j--;             // j = j - 1; 
                    PocetKroku++;
                }
                a[j] = p;  // zařazení prvku do setříděné části posloupnosti
            }
        }

        static void SelectionSort(int[] a)
        {
            for (int j = 0; j < a.Length-1; j++)
            {
                int iMin = j;
                for (int i = j+1; i < a.Length; i++)
                {
                    if (a[i] < a[iMin])
                        iMin = i;
                    PocetKroku++;
                }
                Prohod(a, j, iMin);
            }
        }

        static void Prohod(int[] a, int i1, int i2)
        {
            if (i1 != i2)
            {
                int p = a[i1];
                a[i1] = a[i2];
                a[i2] = p;
            }
        }
    }
}

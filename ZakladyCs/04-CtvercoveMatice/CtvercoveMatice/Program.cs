using System;

namespace CtvercoveMatice
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            // Deklarace pole
            int m = 5;
            int[,] a = new int[m, m]; // indexy 0-4

            // Naplnění pole
            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = random.Next(10);

            // Vypsání pole
            VypisMatici(a);

            // Hlavní diagonála = 0
            for (int i = 0; i < m; i++)
                a[i, i] = 0;
            VypisMatici(a);

            // Nad hlavní diagonálou = 1
            for (int i = 0; i < m; i++)
                for (int j = i + 1; j < m; j++) // (j = i) => včetně hl.d.
                    a[i, j] = 1;
            VypisMatici(a);

            // Pod hlavní diagonálou = 2
            for (int i = 0; i < m; i++)
                for (int j = 0; j < i; j++) // (j < i+1) => včetně hl.d.
                    a[i, j] = 2;
            VypisMatici(a);

            // Vedlejší diagonála = 0
            for (int i = 0; i < m; i++)
                a[i, m - 1 - i] = 0;
            VypisMatici(a);

            // Nad vedlejší diagonálou = 3
            for (int i = 0; i < m; i++)
                for (int j = 0; j < m - i - 1; j++) // (j < m-i) => včetně v.d.
                    a[i, j] = 3;
            VypisMatici(a);

            // Pod vedlejší diagonálou = 4
            for (int i = 0; i < m; i++)
                for (int j = m - i; j < m; j++) // (j = m-i-1) => včetně v.d.
                    a[i, j] = 4;
            VypisMatici(a);

            // Trojúhelník nahoře (hranice určují hl.d. a v.d.) = 5
            for (int i = 0; i < m / 2; i++)
                for (int j = i + 1; j < m - i - 1; j++)
                    a[i, j] = 5;
            VypisMatici(a);

            // Trojúhelník dole = 6
            for (int i = m / 2; i < m; i++)
                for (int j = m - i; j < i; j++)
                    a[i, j] = 6;
            VypisMatici(a);

            // Trojúhelník vlevo = 7
            for (int j = 0; j < m / 2; j++)
                for (int i = j + 1; i < m - 1 - j; i++)
                    a[i, j] = 7;
            VypisMatici(a);

            // Trojúhelník vpravo = 8
            for (int j = m / 2; j < m; j++)
                for (int i = m - j; i < j; i++)
                    a[i, j] = 8;
            VypisMatici(a);

            // Naplnění pole
            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = random.Next(10);
            VypisMatici(a);

            // Je větší průměr členů nad hl.d. nebo pod ní
            // V1 - Dva dvojcykly
            int sumNad = 0, pocetNad = 0;
            for (int i = 0; i < m; i++)
                for (int j = i + 1; j < m; j++)
                {
                    sumNad += a[i, j];
                    pocetNad++;
                }
            int sumPod = 0, pocetPod = 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < i; j++)
                {
                    sumPod += a[i, j];
                    pocetPod++;
                }
            // V2 - Jeden cyklus projde celou matici
            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                    if (j > i)
                    {
                        sumNad += a[i, j];
                        pocetNad++;
                    }
                    else if (j < i)
                    {
                        sumPod += a[i, j];
                        pocetPod++;
                    }
            // Vypsání výsledku
            double prumerNad = sumNad / (double)pocetNad;
            double prumerPod = sumPod / (double)pocetPod;
            if (prumerNad == prumerPod)
                Console.WriteLine($"Průměr hodnot nad hl.d. {prumerNad} je stejný jako průměr hodnot pod hl.d. {prumerPod}");
            else if (prumerNad > prumerPod)
                Console.WriteLine($"Průměr hodnot nad hl.d. {prumerNad} je větší než průměr hodnot pod hl.d. {prumerPod}");
            else
                Console.WriteLine($"Průměr hodnot nad hl.d. {prumerNad} je menší než průměr hodnot pod hl.d. {prumerPod}");

            // Prohození hodnot členů trojúhelníku nahoře a dole
            VypisMatici(a);
            for (int i = 0; i < m / 2; i++)
                for (int j = i + 1; j < m - i - 1; j++)
                {
                    int p = a[m - i - 1, j];
                    a[m - i - 1, j] = a[i, j];
                    a[i, j] = p;
                }
            VypisMatici(a);

            // Prohození hodnot členů trojúhelníků vlevo a vpravo
            for (int j = 0; j < m / 2; j++)
                for (int i = j + 1; i < m - 1 - j; i++)
                {
                    int p = a[i, m-j-1];
                    a[i, m - j - 1] = a[i, j];
                    a[i, j] = p;
                }
            VypisMatici(a);

            // Naplnění pole řadou čísel
            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = j + i * m + 1;
            VypisMatici(a);

            // Otočení matice o 90° ve směru hodinových ručiček
             for (int i = 0; i < m/2; i++)
                for (int j = i; j < m-i-1; j++)
                {
                    int p = a[i, j];
                    a[i, j] = a[m-j-1, i];
                    a[m-j-1, i] = a[m-i-1, m-j-1];
                    a[m-i-1, m-j-1] = a[j, m-i-1];
                    a[j, m-i-1] = p;
                }
            VypisMatici(a);

            Console.ReadLine();
        }

        static void VypisMatici(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write("{0,2}, ", a[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
};
using System;

namespace Matice
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            // Deklarace matice
            int m = 4, n = 5; // 4 řádky, 5 sloupců
            int[,] a = new int[m, n];

            // Naplnění matice
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i, j] = random.Next(10);
                    //a[i, j] = j + i * a.GetLength(1) + 1;
                    //a[i, j] = i + j * a.GetLength(0) + 1;

            VypisMatici(a);

            // Součet hondnot
            int soucet = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    soucet += a[i, j];
            Console.WriteLine("Součet členů matice je {0}", soucet);
            Console.WriteLine("Průměr členů matice je {0}", soucet / (double)a.Length);

            // Počet sudých členů
            int pocetSudych = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] % 2 == 0)
                        pocetSudych++;
            Console.WriteLine("Počet sudých členů matice je {0}", pocetSudych);

            // Poslední lichá hodnota - po řádcích
            int poslLich = 2;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] % 2 == 1)
                        poslLich = a[i, j];
            if (poslLich == 2)
                Console.WriteLine("V matici žádná lichá hodnota není");
            else
                Console.WriteLine("Poslední lichá hodnota (po řádcích) je {0}", poslLich);

            // Poslední lichá hodnota - po sloupcích
            poslLich = 2;
            for (int j = 0; j < a.GetLength(1); j++)
                for (int i = 0; i < a.GetLength(0); i++)
                    if (a[i, j] % 2 == 1)
                        poslLich = a[i, j];
            if (poslLich == 2)
                Console.WriteLine("V matici žádná lichá hodnota není");
            else
                Console.WriteLine("Poslední lichá hodnota (po sloupcích) je {0}", poslLich);

            // Minimální a maximální hodnota
            int min = a[0, 0];
            int max = a[0, 0];
            for (int j = 0; j < a.GetLength(1); j++)
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] < min)
                        min = a[i, j];
                    if (a[i, j] > max)
                        max = a[i, j];
                }
            Console.WriteLine("Nejmenší hodnota v matici je {0}", min);
            Console.WriteLine("Největší hodnota v matici je {0}", max);

            // Minimum a počet jeho výskytů
            min = a[0, 0];
            int pocetMinim = 0;
            for (int j = 0; j < a.GetLength(1); j++)
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] < min)
                    {
                        min = a[i, j];
                        pocetMinim = 1;
                    }
                    else if (a[i, j] == min)
                        pocetMinim++;
                }
            Console.WriteLine("Nejmenší hodnota v matici je {0} a je tam {1}x", min, pocetMinim);

            // Průměr hodnot na r-tém řádku
            //Console.Write("Zadej index řádku (0-{0}): ", a.GetLength(0)-1);
            //int r = Convert.ToInt32(Console.ReadLine());
            //int soucetR = 0;
            //for (int j = 0; j < a.GetLength(1); j++)
            //    soucetR += a[r, j];
            //Console.WriteLine("Průměr hodnot na řádku s indexem {0} je {1}", r, 
            //    soucetR / (double)a.GetLength(1));

            // Záměna prvního a posledního řádku 
            VypisMatici(a);
            for (int j = 0; j < a.GetLength(1); j++)
            {
                int p = a[0, j];
                a[0, j] = a[a.GetLength(0)-1, j];
                a[a.GetLength(0) - 1, j] = p;
            }
            VypisMatici(a);

            // Součin prvků z s-tého sloupce
            //Console.Write("Zadej index sloupce (0-{0}): ", a.GetLength(1)-1);
            //int s = Convert.ToInt32(Console.ReadLine());
            //int soucinS = 1;
            //for (int i = 0; i < a.GetLength(0); i++)
            //    soucinS *= a[i, s];
            //Console.WriteLine("Součin hodnot sloupce s indexem {0} je {1}", s, soucinS);

            // Průměry ze všech sloupců
            int[] prS = new int[a.GetLength(1)];
            for (int j = 0; j < a.GetLength(1); j++)
            {
                int sumS = 1;
                for (int i = 0; i < a.GetLength(0); i++)
                    sumS += a[i, j];
                prS[j] = sumS / a.GetLength(0);
            }
            Console.Write("Průměry sloupců: ");
            for (int i = 0; i < prS.Length; i++)
                Console.Write("{0}, ", prS[i]);
            Console.WriteLine();

            // Součet dvou matic (C = A + B)
            var b = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    b[i, j] = random.Next(10);
            
            var c = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    c[i, j] = a[i, j] + b[i, j];

            VypisMatici(a);
            VypisMatici(b);
            VypisMatici(c);


            Console.ReadLine();
        }

        static void VypisMatici(int[,] a)
        {
            // Vypsání matice
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write("{0,2}, ", a[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

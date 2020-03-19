using System;

namespace HledaniMin
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int m = 10, n = 10;  // Rozměry minového pole
            int pocetMin = 10;
            int[,] miny = new int[m, n]; // Deklarace pole
            // 0 - nic, 1-8 číslo, 9 - mina, záporná verze čísla (pro 0 je -10) = odkryté pole

            // Rozmístění min
            for (int k = 0; k < pocetMin; k++)
            {
                int i = random.Next(m);
                int j = random.Next(n);
                while (miny[i, j] == 9)
                    (i, j) = (random.Next(m), random.Next(n));
                miny[i, j] = 9;
                // Zvýšit číslo v sousedních polích o +1
                for (int y = -1; y <= 1; y++)
                    for (int x = -1; x <= 1; x++)
                        if (i + y >= 0 && j + x >= 0 &&
                            i + y <  m && j + x <  n &&
                            miny[i + y, j + x] != 9)
                            miny[i + y, j + x]++;
            }

            VypisMinovePole(miny);

            // Herní smyčka
            short konec = 0;   // -1 = prohra, +1 = výhra, 0 = hra pokračuje
            while (konec == 0)
            {
                int x = -1, y = -1;
                bool platneSouradnice = false;
                while (!platneSouradnice)
                    try
                    {
                        Console.Write("Y: ");
                        y = Convert.ToInt32(Console.ReadLine()); // Y - index řádku
                        Console.Write("X: ");
                        x = Convert.ToInt32(Console.ReadLine()); // X - index sloupce
                        Console.WriteLine();
                        if (x >= 0 && x < n && y >= 0 && y < m)
                            if (miny[y, x] >= 0)
                                platneSouradnice = true;
                            else
                                Console.WriteLine("Pole na zadaných souřadnicích je již odkryto...");
                        else
                            Console.WriteLine("Byly zadány souřadnice mimo rozsah pole...");
                    }
                    catch
                    {
                        Console.WriteLine("Souřadnice musí být platné celé číslo...");
                    }

                // Odkrývání pole podle typu
                if (miny[y, x] == 9)
                {
                    for (int i = 0; i < m; i++)
                        for (int j = 0; j < n; j++)
                            if (miny[i, j] >= 1 && miny[i, j] <= 9)
                                miny[i, j] *= -1;
                            else if (miny[i, j] == 0)
                                miny[i, j] = -10;
                    konec = -1;
                }
                else if (miny[y, x] >= 0)
                    Odkryj(y, x, miny);

                VypisMinovePole(miny);

                // Ověření konce výhrou
                if (konec == 0)
                    if (JeVseOdkryto(miny))
                        konec = 1;
            }

            // Oznámení výhry či prohry
            if (konec < 0)
                Console.WriteLine("Prohrál jsi!");
            else
                Console.WriteLine("Vyhrál jsi!");


            Console.ReadLine();
        }

        static bool JeVseOdkryto(int[,] miny)
        {
            for (int i = 0; i < miny.GetLength(0); i++)
                for (int j = 0; j < miny.GetLength(1); j++)
                    if (miny[i, j] >= 0 && miny[i, j] != 9)
                        return false;
            return true;
        }

        static void Odkryj(int i, int j, int[,] miny)
        {
            if (i >= 0 && j >= 0 &&
                i < miny.GetLength(0) && j < miny.GetLength(1))
                if (miny[i, j] == 0)
                {
                    miny[i, j] = -10;
                    for (int y = -1; y <= 1; y++)
                        for (int x = -1; x <= 1; x++)
                            Odkryj(i + y, j + x, miny);
                }
                else if (miny[i, j] > 0 && miny[i, j] < 9)
                    miny[i, j] *= -1;
        }

        static void VypisMinovePole(int[,] miny)
        {
            // Záhlaví sloupců
            Console.Clear();
            int sirkaZnaku = miny.GetLength(1) > 10 ? 2 : 1;
            Console.Write("   | ");
            for (int j = 0; j < miny.GetLength(1); j++)
                Console.Write("{0} ", j.ToString().PadLeft(sirkaZnaku));
            Console.WriteLine();
            Console.WriteLine("---+-".PadRight(miny.GetLength(1) * (sirkaZnaku + 1) + 5, '-'));

            for (int i = 0; i < miny.GetLength(0); i++)
            {
                Console.Write("{0} |", i.ToString().PadLeft(2));
                for (int j = 0; j < miny.GetLength(1); j++)
                {
                    Console.Write(" ".PadLeft(sirkaZnaku));
                    if (miny[i, j] >= 0)  // Neodkryté pole
                        VypisZnakSBarvou('#'.ToString()[0], ConsoleColor.Black);
                    else if (miny[i, j] == -10)  // Odkryté prázdné pole
                        VypisZnakSBarvou('0', ConsoleColor.DarkGray);
                    else if (miny[i, j] == -9)  // Odkrytá mina
                        VypisZnakSBarvou('X', ConsoleColor.Red);
                    else
                        VypisZnakSBarvou((-miny[i, j]).ToString()[0], ConsoleColor.DarkCyan);
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        static void VypisZnakSBarvou(char znak, ConsoleColor barva)
        {
            var puvodniBarva = Console.BackgroundColor;
            Console.BackgroundColor = barva;
            Console.Write(znak);
            Console.BackgroundColor = puvodniBarva;
        }
    }
}

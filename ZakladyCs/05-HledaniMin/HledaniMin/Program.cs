using System;

namespace HledaniMin
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int m = 11, n = 11;          // Rozměry minového pole (M = řádky, N = sloupce)
            int pocetMin = 10;           // Počet min
            int[,] miny = new int[m, n]; // Deklarace pole (bude obsahovat samé 0)
            // 0 - nic, 1-8 číslo, 9 - mina, záporná verze čísla (pro 0 je -10) = odkryté pole

            // Rozmístění min
            for (int k = 0; k < pocetMin; k++)
            {
                int i = random.Next(m);   // Náhodný řádek
                int j = random.Next(n);   // Náhodný sloupec
                while (miny[i, j] == 9)   // Je-li tam již jiná mina, vybrat jiné souřadnice
                    (i, j) = (random.Next(m), random.Next(n));
                miny[i, j] = 9;           // Umístění miny (9)

                // Zvýšit číslo v sousedních polích o +1
                for (int y = -1; y <= 1; y++)            // projít od pole o 1 vlevo do o 1 vpravo
                    for (int x = -1; x <= 1; x++)        // a také pro o 1 řádek nad až po 1 řádek pod
                        if (i + y >= 0 && j + x >= 0 &&  // nepřekročili-li se levé či horní hranice plochy
                            i + y < m && j + x < n &&  // ani pravé či dolní hranice plochy
                            miny[i + y, j + x] != 9)     // a ani miny včetně té právě položené neměnit
                            miny[i + y, j + x]++;        // zvýšit číslo v této buňce o +1

                // Jiná varianta téhož (zvýšit číslo v sousedních polích o +1)
                //for (int y = Math.Max(i-1, 0); y <= Math.Min(i+1, m-1); y++)
                //    for (int x = Math.Max(j-1, 0); x <= Math.Min(j+1, n-1); x++)
                //        if (miny[y, x] != 9)
                //            miny[y, x]++;
            }

            VypisMinovePole(miny);

            // Herní smyčka
            short konec = 0;                   // -1 = prohra, +1 = výhra, 0 = hra pokračuje
            while (konec == 0)                 // Herní smyčka
            {
                int x = -1, y = -1;
                bool platneSouradnice = false; // Přáznak, byly-li zadány platné souřadnice
                while (!platneSouradnice)      // Opakování dokud nejsou zadány platné souřadnice
                    try
                    {
                        Console.Write("Y: ");
                        y = Convert.ToInt32(Console.ReadLine()); // Y - index řádku
                        Console.Write("X: ");
                        x = Convert.ToInt32(Console.ReadLine()); // X - index sloupce
                        Console.WriteLine();
                        if (x >= 0 && x < n && y >= 0 && y < m)  // Ověření, jsou-li souřadnice v rozsahu pole
                            if (miny[y, x] >= 0)                 // Ověření, není-li na souřadnicích již odkryté pole
                                platneSouradnice = true;
                            else
                                Console.WriteLine("Pole na zadaných souřadnicích je již odkryto...");
                        else
                            Console.WriteLine("Byly zadány souřadnice mimo rozsah pole...");
                    }
                    catch
                    {
                        Console.WriteLine("Souřadnice musí být platné celé číslo...");  // Zadáno neplatné číslo
                    }

                // Odkrývání pole podle typu
                if (miny[y, x] == 9)                   // Mina = konec hry (prohra) a odkrytí všech polí
                {
                    for (int i = 0; i < m; i++)
                        for (int j = 0; j < n; j++)
                            if (miny[i, j] >= 1 && miny[i, j] <= 9)
                                miny[i, j] *= -1;      // Odkrytí neprázdného pole 
                            else if (miny[i, j] == 0)
                                miny[i, j] = -10;      // Odkrytí prázdného pole
                    konec = -1;                        // Konec hry prohrou
                }
                else if (miny[y, x] >= 0)              // Prázdné pole či pole s číslem odkryje metoda Odkryj
                    Odkryj(y, x, miny); 

                VypisMinovePole(miny);                 // Vypsání nové podoby herní plochy

                // Ověření konce výhrou (jsou-li odkryta všechna pole kromě min)
                if (konec == 0)
                    if (JeVseOdkryto(miny))
                        konec = 1;
            }                                          // Konec herní smyčky

            // Oznámení výhry či prohry
            if (konec < 0)
                Console.WriteLine("Prohrál jsi!");
            else
                Console.WriteLine("Vyhrál jsi!");


            Console.ReadLine();
        }

        // Kontrola, jsou-li již všechna pole (kromě min) odkryta nebo ne
        static bool JeVseOdkryto(int[,] miny)
        {
            for (int i = 0; i < miny.GetLength(0); i++)
                for (int j = 0; j < miny.GetLength(1); j++)
                    if (miny[i, j] >= 0 && miny[i, j] != 9)
                        return false;
            return true;
        }

        // Odkryje pole na zadaných souřadnicích a všechny jeho sousedy
        static void Odkryj(int i, int j, int[,] miny)
        {
            if (i >= 0 && j >= 0 &&
                i < miny.GetLength(0) && j < miny.GetLength(1)) // Jsou-li zadané souřadnice v ploše minového pole
                if (miny[i, j] == 0)                            // a je-li v daném poli prázdno a není dosud odkryto
                {
                    miny[i, j] = -10;                           // Odkrytí pole
                    // Odkrytí i všech sousedních polí rekurzivním voláním, jež odkryje i jejich sousední pole
                    for (int y = -1; y <= 1; y++)               // Projít od pole o 1 vlevo do o 1 vpravo
                        for (int x = -1; x <= 1; x++)           // a také pro o 1 řádek nad až po 1 řádek pod
                            Odkryj(i + y, j + x, miny);         // toto pole odkrýt 
                }
                else if (miny[i, j] > 0 && miny[i, j] < 9)      // Není-li pole prázdné, odkrýt jej ale jeho sousedy již ne
                    miny[i, j] *= -1;                           // Odkrytí pole - nastavit mu jeho zápornou hodnotu
        }

        // Vypíše aktuální stav minového pole do konzolového výstupu
        static void VypisMinovePole(int[,] miny)
        {
            // Vypsání záhlaví sloupců
            Console.Clear();
            int sirkaZnaku = miny.GetLength(1) > 10 ? 2 : 1;     // Je-li počet sloupců dvojciferné číslo, přidá mezeru před ta jednociferná
            Console.Write("   | ");
            for (int j = 0; j < miny.GetLength(1); j++)
                Console.Write("{0} ", j.ToString().PadLeft(sirkaZnaku));
            Console.WriteLine();
            Console.WriteLine("---+-".PadRight(miny.GetLength(1) * (sirkaZnaku + 1) + 5, '-'));

            for (int i = 0; i < miny.GetLength(0); i++)
            {
                Console.Write("{0} | ", i.ToString().PadLeft(2));
                for (int j = 0; j < miny.GetLength(1); j++)
                {
                    if (miny[i, j] >= 0)         // Neodkryté pole
                        VypisZnakSBarvou('#'.ToString()[0], ConsoleColor.Black, sirkaZnaku);
                    else if (miny[i, j] == -10)  // Odkryté prázdné pole
                        VypisZnakSBarvou('0', ConsoleColor.DarkGray, sirkaZnaku);
                    else if (miny[i, j] == -9)   // Odkrytá mina
                        VypisZnakSBarvou('X', ConsoleColor.Red, sirkaZnaku);
                    else
                        VypisZnakSBarvou((-miny[i, j]).ToString()[0], ConsoleColor.DarkCyan, sirkaZnaku);
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Vypíše do konzole jeden znak podbarvený zadanou barvou
        static void VypisZnakSBarvou(char znak, ConsoleColor barva, int sirkaZnaku)
        {
            var puvodniBarva = Console.BackgroundColor; // Uložení si původní barvy pozadí 
            Console.BackgroundColor = barva;            // Nastavení barvy pozadí
            Console.Write(sirkaZnaku > 1 ? $" {znak} " : znak.ToString()); // Vypsání znaku
            Console.BackgroundColor = puvodniBarva;     // Vrácení barvy pozadí na původní (černou)
            if (sirkaZnaku == 1)
                Console.Write(" ");                     // Oddělující mezera
        }
    }
}

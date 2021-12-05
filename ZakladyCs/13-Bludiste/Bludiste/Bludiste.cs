using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BludisteProgram
{
    #region Výčet směrů pro přechod z jedné buňky do sousední

    public enum Smer   // Vlastní typ hodnot (enum) a jejich výčet…
    {
        N = 1,  // 0001 Nahoru
        D = 2,  // 0010 Dolů
        P = 4,  // 0100 Pravo
        L = 8,  // 1000 Levo
    }

    #endregion

    public static class Bludiste
    {
        #region Pomocné prvky

        // Generátor náhodných čísel
        static Random Rnd = new Random();

        // Seznam směrů v pořadí směru hodinových ručiček
        static Smer[] Smery => new[] { Smer.N, Smer.P, Smer.D, Smer.L };

        // Náhodně (pokaždé jinak) seřazený seznam všech směrů
        static IEnumerable<Smer> SmeryNahodne
            => Smery.OrderBy(s => Rnd.NextDouble());

        // Překlad směru na směr opačný
        static Dictionary<Smer, Smer> Protismer =
            new Dictionary<Smer, Smer> {
                { Smer.N, Smer.D },
                { Smer.D, Smer.N },
                { Smer.P, Smer.L },
                { Smer.L, Smer.P },
            };

        #endregion

        #region Generátor bludiště s přepážkami

        /// <summary>Vygeneruje bludiště zadaných rozměrů</summary>
        public static int[,] Vytvor(int radku, int sloupcu)
        {
            var mapa = new int[radku, sloupcu]; // Vytvoření 2D pole
            ZpracujPolicko(0, 0, mapa);  // Vygenerování mapy z 0,0
            return mapa;                 // Vrácení vygenerované mapy
        }

        /// <summary>Posune se z pozice pos ve směru smer na pozici new
        /// a vrátí bool, jestli nová pozice není mimo mapu</summary>
        static bool Posun(int[,] mapa, int posY, int posX, Smer smer,
                          out int newY, out int newX)
        {
            // Výchozí hodnoty (pozice)
            newY = posY;
            newX = posX;
            // Posun v daném směru
            switch (smer)
            {
                case Smer.N: newY--; break;
                case Smer.D: newY++; break;
                case Smer.L: newX--; break;
                case Smer.P: newX++; break;
                default: return false; // Nemožné
            }
            // Je nová souřadnice v rozmezí rozměrů mapy?
            return newY >= 0 && newY < mapa.GetLength(0) &&
                   newX >= 0 && newX < mapa.GetLength(1);
        }

        /// <summary>Nastaví políčku výchozímu (pos) i sousednímu 
        /// cílovému (new), že přepážka mezi nimi není</summary>
        static void OdeberPrepazku(int[,] mapa, int posY, int posX,
                                   int newY, int newX, Smer smer)
        {
            mapa[posY, posX] |= (int)smer;
            mapa[newY, newX] |= (int)Protismer[smer];
        }

        /// <summary>Zpracuje políčko bludiště a rekurzí jej pošle dál 
        /// svým nenavštíveným sousedům v náhodném pořadí</summary>
        static void ZpracujPolicko(int posY, int posX, int[,] mapa)
        {
            // Postupné zpracování čtyř sousedních políček v náh. pořadí
            foreach (var smer in SmeryNahodne)
            {
                // Určení souřadnic cílového políčka v daném směru
                if (!Posun(mapa, posY, posX, smer,
                           out int newY, out int newX))
                    continue; // Souřadnice jsou mimo mapu = tudy ne
                              // Test, nebylo-li již toto pole zpracováno
                if (mapa[newY, newX] != 0)
                    continue; // Tam už byl
                              // Zrušení přepážky mezi tímto a cílovým políčkem
                OdeberPrepazku(mapa, posY, posX, newY, newX, smer);
                // Předání zpracování tomuto sousednímu políčku
                ZpracujPolicko(newY, newX, mapa);
            }
        }

        /// <summary>Vypsání přepážkového bludiště do konzole</summary>
        public static void Vypis(int[,] mapa)
        {
            // Horní hranice mapy
            Console.Write(" ");
            for (int j = 0; j < mapa.GetLength(1); j++)
                Console.Write(" _");
            Console.WriteLine();

            // Řádky bludiště
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                Console.Write(" |");   // Levá hranice mapy
                                       // Sloupce bludiště
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    Smer s = (Smer)mapa[i, j];
                    Console.Write(s.HasFlag(Smer.D) ? " " : "_");
                    Console.Write(s.HasFlag(Smer.P) ? " " : "|");
                }
                Console.WriteLine();
            }
        }

        #endregion

        #region Přidání smyček

        // Další směr ve směru hodinových ručiček s nekonečným otáčením
        static Smer DalsiSmer(Smer smer) => smer == Smer.L ? Smer.N
               : Smery[Array.IndexOf(Smery, smer) + 1];

        // Předchozí směr (další v protisměru) hodinových ručiček
        static Smer PredchoziSmer(Smer smer) => smer == Smer.N ? Smer.L
               : Smery[Array.IndexOf(Smery, smer) - 1];

        /// <summary>Test na přepážky v okolí v daném směru</summary>
        static bool JePrepazkaOkolo(int[,] mapa, int posY, int posX,
                                    Smer smer)
        {
            for (int i = 0; i < 3; i++)
                if (!((Smer)mapa[posY, posX]).HasFlag(smer) ||
                    !Posun(mapa, posY, posX, smer, out posY, out posX))
                    return true;  // Přepážka nebo výstup z mapy tam je
                else
                    smer = DalsiSmer(smer);  // Přepnout směr na další
            return false;  // Obejití se zdařilo, přepážka tam není
        }

        /// <summary>Kompletní test okolí na další přepážky</summary>
        static bool LzePrepazkuOdebrat(int[,] mapa, int posY, int posX,
                                       int newY, int newX, Smer smer)
        {
            smer = PredchoziSmer(smer);
            if (!JePrepazkaOkolo(mapa, posY, posX, smer))
                return false;
            return JePrepazkaOkolo(mapa, newY, newX, Protismer[smer]);
        }

        /// <summary>Přidání smyček (odebrání přepážek) v mapě</summary>
        public static void PridejSmycky(int[,] mapa, double pocet = .05)
        {
            int zbyvajiciPocet = pocet >= 1 ? (int)pocet :
                (int)Math.Round(mapa.Length * pocet); // Počet určen %
            while (zbyvajiciPocet > 0)
            {
                // Vybrat náhodné políčko na mapě
                int posY = Rnd.Next(mapa.GetLength(0));
                int posX = Rnd.Next(mapa.GetLength(1));
                // Zkusit odebrat přepážku v některém z náchodných směrů 
                foreach (var smer in SmeryNahodne)
                {
                    // Je v tomto směru vůbec ještě přepážka?
                    if (((Smer)mapa[posY, posX]).HasFlag(smer))
                        continue; // Není = není co odebírat
                                  // Nevede tento směr vede mimo mapu?
                    if (!Posun(mapa, posY, posX, smer,
                               out int newY, out int newX))
                        continue; // Vede = tudy ne
                                  // Nevznikne smazáním přepážky prázdný prostor 2x2?
                    if (!LzePrepazkuOdebrat(mapa, posY, posX,
                                            newY, newX, smer))
                        continue; // Vznikne = tuto přepážku neodebírat
                                  // Odebrat přepážku v daném směru (z obou stran)
                    OdeberPrepazku(mapa, posY, posX, newY, newX, smer);
                    zbyvajiciPocet--; // Jedna přepážka byla odebrána
                    break;            // Z tohoto políčka už neodebírat
                }
            }
        }

        #endregion

        #region Nalezení nejvzdálenější buňky

        /// <summary>Nalezne a vrátí souřadnice nejvzdálenějšího pole (konec),
        /// k výchozímu poli (start) v zadané mapě (mapa). Výstupní 
        /// hodnotou je vzdálenost mezi těmito dvěma poli (start-konec).</summary>
        public static int NejvzdalenejsiPole(int startY, int startX,
                    int[,] mapa, out int konecY, out int konecX)
        {
            // Vytvoření matice vzdáleností s výchozími hodnotami -1
            var vzdalenosti = new int[mapa.GetLongLength(0),
                                      mapa.GetLongLength(1)];
            for (int i = 0; i < vzdalenosti.GetLength(0); i++)
                for (int j = 0; j < vzdalenosti.GetLength(1); j++)
                    vzdalenosti[i, j] = -1;  // -1 = neřešená buňka
            vzdalenosti[startY, startX] = 0; // Jen na startu bude 0
                                             // Určení vzdáleností od startu pro všechny buňky
            VzdalenostiOkolo(startY, startX, mapa, vzdalenosti);
            // Nalezení souřadnic maxima 
            (konecY, konecX) = (startY, startX); // Výchozí souřadnice
            for (int i = 0; i < vzdalenosti.GetLength(0); i++)
                for (int j = 0; j < vzdalenosti.GetLength(1); j++)
                    if (vzdalenosti[i, j] > vzdalenosti[konecY, konecX])
                        (konecY, konecX) = (i, j); // Nové maximum
            return vzdalenosti[konecY, konecX];   // Vrácení max. vzdál.
        }

        /// <summary>Projde okolní dostupná pole (není mezi nimi přepážka),
        /// aktualizuje matici vzdáleností a rekurzivně to pošle dál.</summary>
        static void VzdalenostiOkolo(int posY, int posX, int[,] mapa,
                             int[,] vzdalenosti)
        {
            var s = (Smer)mapa[posY, posX]; // Načtení hodnoty buňky
            foreach (var smer in Smery)
            {
                if (!s.HasFlag(smer) ||     // Přepážka uzavřena, nebo…
                    !Posun(mapa, posY, posX, smer, out int newY,
                           out int newX) || // Vede z mapy? (+ posun)…
                    vzdalenosti[newY, newX] >= 0 && // nebo už tam byl…
                    vzdalenosti[newY, newX] <= vzdalenosti[posY, posX]
                                               + 1) // … kratší cestou
                    continue; // Ve všech těchto případech TUDY NE
                              // Nastavení nové vzdálenosti pro cílovou buňku
                vzdalenosti[newY, newX] = vzdalenosti[posY, posX] + 1;
                // Předat rekurzivní zpracování cílové buňce
                VzdalenostiOkolo(newY, newX, mapa, vzdalenosti);
            }
        }

        #endregion

        #region Blokové bludiště

        /// <summary>Konverze přepážkového bludiště na blokové</summary>
        /// <returns>Mapa blokového bludiště, kde false = průchozí blok, 
        /// true = neprůchodný blok (zeď)</returns>
        public static bool[,] Konverze(int[,] mapaP)
        {
            // Deklarace 2D pole pro blokovou mapu dvojité velikosti
            var mapaB = new bool[mapaP.GetLength(0) * 2,
                                 mapaP.GetLength(1) * 2];
            // Konverze bludiště
            for (int i = 0; i < mapaP.GetLength(0); i++)
                for (int j = 0; j < mapaP.GetLength(1); j++)
                {
                    var s = (Smer)mapaP[i, j];
                    if (!s.HasFlag(Smer.P))
                    {
                        mapaB[i * 2, j * 2 + 1] = true;
                        mapaB[i * 2 + 1, j * 2 + 1] = true;
                    }
                    if (!s.HasFlag(Smer.D))
                    {
                        mapaB[i * 2 + 1, j * 2] = true;
                        mapaB[i * 2 + 1, j * 2 + 1] = true;
                    }
                }
            // Korekce (doplnění) lichých bloků
            for (int i = 1; i < mapaB.GetLength(0) - 1; i += 2)
                for (int j = 1; j < mapaB.GetLength(1) - 1; j += 2)
                    if (mapaB[i, j + 1] || mapaB[i + 1, j])
                        mapaB[i, j] = true;
            return mapaB;
        }

        /// <summary>Vypsání blokového bludiště do konzole</summary>
        public static void Vypis(bool[,] mapa)
        {
            // Horní hranice bludiště
            Console.WriteLine(" ".PadRight(mapa.GetLength(1) + 2, '█'));
            // Řádky bludiště
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                Console.Write(" █");   // Levá hranice bludiště
                                       // Sloupce v řádku (buňky)
                for (int j = 0; j < mapa.GetLength(1); j++)
                    Console.Write(mapa[i, j] ? "█" : " ");
                Console.WriteLine();
            }
        }

        #endregion

    }
}

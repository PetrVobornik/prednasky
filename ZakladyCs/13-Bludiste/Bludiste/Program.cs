using System;

namespace BludisteProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ručně zadaná přepážková mapa
            //var mapa = new int[,] {
            //    {2,   4,     2+4+8, 4+8, 2+8   },
            //    {1+4, 2+8,   1,     2+4, 1+2+8 },
            //    {2,   1+4,   4+8,   1+8, 1+2   },
            //    {1+2, 2+4,   4+8,   2+8, 1+2   },
            //    {1+4, 1+4+8, 8,     1+4, 1+8   }
            //};
            //Bludiste.Vypis(mapa);


            // Vygenerování a vykreslení přepážkové mapy
            var mapa = Bludiste.Vytvor(8, 25);   // Vygenerování nové přepážkové mapy
            Bludiste.PridejSmycky(mapa);         // Přidání smyček
            Bludiste.Vypis(mapa);                // Vypsání přepážkové mapy

            // Nejvzdálenější pole
            int vzdalenost = Bludiste.NejvzdalenejsiPole(0, 0, mapa,
                out int konecY, out int konecX); // Nejvzdálenější pole a jeho souřadnice od [0, 0]
            Console.WriteLine($" Y = {konecY}, X = {konecX}, " +
                $"vzdálenost = {vzdalenost}");   // Výpis souřadnic nejvzdálenějšího pole
            Console.WriteLine();

            // Blokové bludiště
            var mapaB = Bludiste.Konverze(mapa); // Konverze na blokovou mapu
            Bludiste.Vypis(mapaB);               // Vypsání blokové mapy


            Console.ReadLine();        // Vyčkání na stisk Enteru
        }

    }
}

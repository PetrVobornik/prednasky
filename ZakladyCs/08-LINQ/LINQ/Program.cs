using System;
using System.Collections.Generic;
using System.Linq;

namespace Seznamy
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            // SEZNAMY

            // Pole
            //int[] pole = new int[10];
            int[] pole = { 1, 23, 4, 0, 8, 55, -4, -9, 5, 1 };

            // Seznam
            List<int> seznam = new List<int>();

            //Naplnění náhodnými hodnotami
            for (int i = 0; i < 10; i++)
            {
                //pole[i] = random.Next(10);
                seznam.Add(random.Next(10));  // Přidá náhodné číslo na konec seznamu
            }

            // Upravy prvků seznamu
            seznam.Insert(5, 10); // Vloží 10 na index 5 (hodnoty za ní se posunou)
            seznam.Remove(10);    // Umaže první 10
            seznam.RemoveAt(5);   // Umaže člen na indexu 5

            // Vypsání seznamu - v1 - for
            for (int i = 0; i < seznam.Count; i++)
                Console.Write("{0}, ", seznam[i]);
            Console.WriteLine();

            // Vypsání seznamu - v2 - foreach
            foreach (int x in seznam)
                Console.Write("{0}, ", x);
            Console.WriteLine();

            // Vypsání seznamu - v3 - univerzální metoda
            Vypis(seznam);

            // Vypsání seznamu - v4 - univerzální extension metoda
            seznam.Vypis();
            seznam.Vypis("seznam: ");

            // Rozšiřující metody
            pole.Vypis("před: ");
            //pole.Dvojnasobky1().Vypis("dvojnásobky: ");
            //pole.Dvojnasobky2().Vypis("dvojnásobky: ");
            //var pole2 = pole.Dvojnasobky2();
            pole.Vypis("po: ");

            seznam.Dvojnasobky3().Vypis("dvojnásobky seznamu: ");

            Console.WriteLine();
            //SLOVNÍKY
            //var slovnik = new Dictionary<string, string>();
            var slovnik = new Dictionary<string, string>() {
                { "car", "auto" },
                { "air", "vzduch" },
            };
            slovnik.Add("blue", "modrá");
            slovnik["mirror"] = "zrcadlo";
            slovnik["car"] = "automobil"; // Nahradí staré car
            slovnik.Vypis("slovník: ");

            // Ověření, je-li klíč ve slovníku
            if (slovnik.ContainsKey("car"))
                Console.WriteLine("slovíčko: {0} = {1}", "car", slovnik["car"]);

            // Vypsání celého seznamu - v1
            Console.Write("slovník v1: ");
            foreach (var slovo in slovnik)
                Console.Write("{0} = {1}, ", slovo.Key, slovo.Value);
            Console.WriteLine();

            // Vypsání celého seznamu - v2
            Console.Write("slovník v2: ");
            foreach (var key in slovnik.Keys)
                Console.Write("{0} = {1}, ", key, slovnik[key]);
            Console.WriteLine();

            // Seznam EN slov
            List<string> en = slovnik.Keys.ToList();
            en.Vypis("klíče slovníku: ");


            // Převod pole <=> seznam
            seznam = pole.ToList();
            pole = seznam.ToArray();
            Dictionary<int, bool> sudost = pole.Distinct().ToDictionary(k => k, v => v % 2 == 0);
            sudost.Vypis("sudost: ");
            Console.WriteLine();

            // LINQ
            int[] a = pole;
            a.Vypis("a: ");

            // Agregační funkce
            Console.WriteLine("suma = {0}", a.Sum());
            Console.WriteLine("počet = {0}", a.Count());
            Console.WriteLine("průměr = {0}", a.Average());
            Console.WriteLine("min = {0}", a.Min());
            Console.WriteLine("max = {0}", a.Max());

            // Podmíněný počet
            Console.WriteLine("počet lichých = {0}", a.Count(x => x % 2 != 0));
            Console.WriteLine("počet sudých  = {0}", a.Count(x => x % 2 == 0));

            // Součet druhých mocnin
            Console.WriteLine("suma čtverců = {0}", a.Sum(x => x * x));

            // Test celého seznamu
            Console.WriteLine("vše je sudé:  {0}", a.All(x => x % 2 == 0));
            Console.WriteLine("něco lichého: {0}", a.Any(x => x % 2 != 0));
            Console.WriteLine("je tam 5: {0}", a.Contains(5) ? "ANO" : "NE");

            Console.WriteLine();


            // PODČÁSTI SEZNAMU
            // Filtr
            a.Where(x => x % 2 == 0).Vypis("sudé hodnoty: ");
            a.Where(x => Math.Abs(x % 2) == 1).Vypis("liché hodnoty: ");
            Console.WriteLine("průměr dvojciferných = {0}", a.Where(x => x >= 10 && x < 100).Average());
            a.Distinct().Vypis("každá jen jednou: ");
            Console.WriteLine();

            // Řazení
            a.OrderBy(x => x).Vypis("vzestupně seřazená čísla: ");
            a.OrderByDescending(x => x).Vypis("sestupně seřazená čísla: ");
            a.OrderBy(x => Math.Abs(x)).ThenBy(x => -x).Vypis("vícestupňové řazení: ");
            Console.WriteLine();

            // Pole textů
            string[] b = { "zero", "one", "two", "three", "four", "five", "six", "seven" };
            b.Vypis("b: ");

            // základní statistiky
            Console.WriteLine("délka všech textů s mezerou mezi nimi: {0}", b.Sum(x => x.Length + 1) - 1);
            Console.WriteLine("průměrná délka slova: {0}", b.Average(x => x.Length));
            Console.WriteLine("délka nejdelšího slova: {0}", b.Max(x => x.Length));

            // Podčásti
            int maxDelka = b.Max(x => x.Length);
            b.Where(x => x.Length == maxDelka).Vypis("nejdelší slova: ");
            b.Select(x => "'" + x + "'").Vypis("slova v apostrofech: ");
            b.Select(x => $"{x} ({x.Length})").Vypis("slova a jejich délky: ");
            b.OrderBy(x => x).Vypis("vzestupně seřazená slova: ");
            b.OrderBy(x => x.Length).ThenBy(x => x).Vypis("vzestupně seřazená slova dle délky a pak dle abecedy: ");
            b.Reverse().Vypis("obrácený seznam: ");
            Console.WriteLine();

            // Podčásti dle pozice
            b.Take(3).Vypis("první tři prvky: ");
            b.OrderBy(x => x).Take(3).Vypis("první tři prvky dle abecedy: ");
            b.OrderBy(x => x).Take(1).Vypis("první dle abecedy: ");

            b.Skip(3).Vypis("bez prvních tří: ");
            b.Skip(3).Take(2).Vypis("čtvrtý až pátý: ");

            b.TakeWhile(x => x.Length < 5).Vypis("hodnoty před prvním výskytem 5-ti či více znakového slova: ");
            b.SkipWhile(x => x.Length < 5).Vypis("hodnoty od prvního výskytu 5-ti či více znakového slova: ");
            Console.WriteLine();

            // Jeden prvek ze seznamu
            Console.WriteLine("první prvek: {0}", b[0]); // u prázdného seznamu se zasekne
            Console.WriteLine("první prvek: {0}", b.First()); 
            Console.WriteLine("poslední prvek: {0}", b.Last());
            
            Console.WriteLine("první prvek na f: {0}", b.First(x => x.StartsWith("f")));
            Console.WriteLine("poslední prvek na f: {0}", b.Last(x => x.StartsWith("f")));

            Console.WriteLine("první prvek na f: {0}", b.FirstOrDefault(x => x.StartsWith("f")));
            Console.WriteLine("poslední prvek na f: {0}", b.LastOrDefault(x => x.StartsWith("f")));

            Console.WriteLine("první prvek: {0}", b.FirstOrDefault());
            Console.WriteLine("poslední prvek: {0}", b.LastOrDefault());

            Console.WriteLine("třetí prvek: {0}", b[2]);
            Console.WriteLine("třetí prvek: {0}", b.ElementAt(2));
            Console.WriteLine("třetí prvek: {0}", b.ElementAtOrDefault(2));
            Console.WriteLine();

            // SPOJOVÁNÍ SEZNAMŮ
            int[] c = { 1, 2, 2, 3, 4 };
            int[] d = { 2, 3, 5, 5 };
            Console.WriteLine("Spojování seznamů...");
            c.Vypis("c: ");
            d.Vypis("d: ");

            c.Concat(d).Vypis("contact: ");  // Spojení dvou seznamů za sebe
            c.Union(d).Vypis("union: ");     // Spojí seznamy tak, aby tam každá hodnota byla pouze 1x
            c.Except(d).Vypis("except (c-d): ");   // C - D (to co je v C ale není v D)
            d.Except(c).Vypis("except (d-c): ");   // D - C
            c.Intersect(d).Vypis("intersect: ");  // Společný průnik množin (čísla vyskytující se v obou seznamech)
            Console.WriteLine();

            // SESKUPOVÁNÍ

            // Slova seskupená podle prvního písmene
            var skupinySlov = b
                .GroupBy(x => x[0])  // Seskupit dle klíče = prvního znaku
                .Select(g => new { Pismeno = g.Key, Slova = g })  // Upravit seznam, aby měl 2 vlastnosti
                .OrderBy(x => x.Pismeno);  // Seřadit dle písmene

            foreach (var ss in skupinySlov)
            {
                //Console.Write("slova začínající písmenem {0}: ", ss.Pismeno);
                //Vypis(ss.Slova);
                ss.Slova.OrderBy(x => x).Vypis($"slova začínající písmenem {ss.Pismeno}: ");
            }
            Console.WriteLine();

            // LINQ ZÁPIS
            a.Vypis("a: ");
            a.Where(x => x % 2 == 0).OrderBy(x => x).Vypis("sudá čísla v1: "); // lambda zápis

            var w = from x in a
                    where x % 2 == 0
                    orderby x
                    select x;  // LINQ zápis téhož
            w.Vypis("sudá čísla v2: ");
            Console.WriteLine();

            // Skupiny čísel podle zbytků po dělení 5
            var del = from x in a
                      group x by x % 5 into g
                      orderby g.Key
                      select new { Zbytek = g.Key, Cisla = g.OrderBy(x => x) };

            foreach (var de in del)
                de.Cisla.Vypis($"čísla se zbytkem {de.Zbytek} po dělení 5: ");

            Console.ReadLine();
        }

        static void Vypis<T>(IEnumerable<T> a)
        {
            foreach (T x in a)
                Console.Write("{0}, ", x);
            Console.WriteLine();
        }
    }

    static class Rozsireni
    {
        public static void Vypis<T>(this IEnumerable<T> a, string textPred = "")
        {
            Console.Write(textPred);
            foreach (T x in a)
                Console.Write("{0}, ", x);
            Console.WriteLine();
        }

        public static int[] Dvojnasobky1(this int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                a[i] *= 2;
            return a;
        }

        public static int[] Dvojnasobky2(this int[] a)
        {
            var b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                b[i] = a[i] * 2;
            return b;
        }

        public static IEnumerable<int> Dvojnasobky3(this IEnumerable<int> a)
        {
            var b = new List<int>(a.Count());
            foreach (int x in a)
                b.Add(x * 2);
            return b;
        }
    }
}

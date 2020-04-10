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

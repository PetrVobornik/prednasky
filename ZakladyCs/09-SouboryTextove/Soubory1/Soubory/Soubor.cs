using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Soubory
{
    public static class Soubor
    {
        public static string PreciCelySoubor(string soubor)
        {
            string obsah = "";
            //StreamReader sr = new StreamReader(soubor);
            using (StreamReader sr = new StreamReader(soubor))
            {
                obsah = sr.ReadToEnd();
            }
            //sr.Close();
            Console.WriteLine(obsah);
            return obsah;
        }

        public static void PreciCelySouborPoRadcich(string soubor)
        {
            int i = 0;
            using (var sr = new StreamReader(soubor))
                while (!sr.EndOfStream)
                    Console.WriteLine("{0,2}: {1}", ++i, sr.ReadLine());
        }

        public static void PreciCelySouborPoRadcich2(string soubor)
        {
            int i = 0;
            string s;
            using (var sr = new StreamReader(soubor))
                while ((s = sr.ReadLine()) != null)
                    Console.WriteLine("{0,2}: {1}", ++i, s);
        }

        public static void ZapisujDoSouboru(string soubor)
        {
            Console.WriteLine("Zadávej řádky, které chceš zapsat do souboru, zadávání ukonči slovem 'konec':");
            using (var sw = new StreamWriter(soubor, true))
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (s == "konec") break;
                    sw.WriteLine(s);
                }
            }
        }

        static Random random = new Random();

        public static void ZapisujCislaDoSouboru(string soubor)
        {
            using (var sw = new StreamWriter(soubor, false))
                for (int i = 0; i < 20; i++)
                    sw.WriteLine(random.Next(100));
        }

        public static int SumaCiselZeSouboru(string soubor)
        {
            int suma = 0;
            using (var sr = new StreamReader(soubor))
                while (!sr.EndOfStream)
                    suma += Convert.ToInt32(sr.ReadLine());
            Console.WriteLine("Součet čísel ze souboru je {0:N0}", suma);
            return suma;
        }

        public static int SumaCiselZeSouboru2(string soubor)
        {
            int suma = File.ReadAllLines(soubor).Sum(x => Convert.ToInt32(x));
            Console.WriteLine("Součet čísel ze souboru je {0:N0}", suma);
            return suma;
        }

        public static void SerazeniCiselVSouboru(string souborVstup, string souborVystup)
        {
            File.WriteAllLines(souborVystup,
                File.ReadAllLines(souborVstup)
                    .Select(x => Convert.ToInt32(x))
                    .OrderBy(x => x)
                    .Select(x => x.ToString())
                    .ToArray());
        }

        public static void VytorTestovaciSouborCsv(string soubor)
        {
            File.WriteAllLines(soubor, new string[] {
                "Jan;Novák;25",
                "Karel;Vomáčka;50",
                "Alois;Levý;35",
                "Adam;Šedý;43",
                "Eva;Modrá;37",
            });
        }

        public static void RozparsujCsv(string soubor)
        {
            int suma = 0;
            using (var sr = new StreamReader(soubor))
                while (!sr.EndOfStream)
                {
                    string radek = sr.ReadLine();
                    string[] hodnoty = radek.Split(';');
                    for (int i = 0; i < hodnoty.Length; i++)
                        Console.Write(hodnoty[i].PadRight(15));
                    suma += Convert.ToInt32(hodnoty[2]);
                    Console.WriteLine();
                }
            Console.WriteLine("Celkem {0}", suma);
        }

        // Matice čísel

        public static int[,] VytvorMatici(int m, int n)
        {
            var a = new int[m, n];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i, j] = random.Next(100);
            return a;
        }

        public static void UlozMatici(int[,] a, string soubor)
        {
            using (var sw = new StreamWriter(soubor))
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                        sw.Write("{0} ", a[i, j]);
                    sw.WriteLine();
                }
        }

        public static int[,] NactiMatici(string soubor)
        {
            string[] radky = File.ReadAllLines(soubor);
            int sloupcu = radky[0].Trim().Count(x => x == ' ') + 1;
            var a = new int[radky.Length, sloupcu];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                string[] hodnoty = radky[i].Trim().Split(' ');
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i, j] = Convert.ToInt32(hodnoty[j]);
            }
            return a;
        }

        public static void VypisMatici(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write("{0}, ", a[i, j]);
                Console.WriteLine();
            }
        }

    }
}

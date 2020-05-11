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
        #region Textové soubory 

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

        // Přečtení celého souboru jinak
        public static string PreciCelySoubor2(string soubor)
            => File.ReadAllText(soubor);

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

        public static void ZapisujCislaDoSouboru2(string soubor)
            => File.WriteAllLines(soubor,                   // Zapíše do souboru naásl. řádky
                                                            //Enumerable.Range(0, 20)                   // Vytvoří seznam hodnot 0-19   (v1)
                Enumerable.Repeat(0, 20)                    // Vytvoří seznam s 20ti nulami (v2)
                .Select(x => random.Next(100).ToString())); // Změní čísla na náhodná a převede na string

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
                    //.ToArray  // Není nezbytné
                    );
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

        #region Matice čísel

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

        #endregion

        #endregion

        #region Souborový systém

        public static bool ExistujeSoubor(string soubor)
        {
            if (File.Exists(soubor))
            {
                Console.WriteLine("Soubor '{0}' existuje", soubor);
                return true;
            }
            Console.WriteLine("Soubor '{0}' NEexistuje", soubor);
            return false;
        }

        public static void VymazSoubor(string soubor)
        {
            File.Delete(soubor);
            Console.WriteLine("Soubor '{0}' byl vymazán", soubor);
        }

        public static void InfoOSouboru(string soubor)
        {
            var fi = new FileInfo(soubor);
            if (!fi.Exists)
                return;
            Console.WriteLine("Informace o souboru {0}", soubor);
            Console.WriteLine("CreationTime   {0}", fi.CreationTime);
            Console.WriteLine("LastAccessTime {0}", fi.LastAccessTime);
            Console.WriteLine("LastWriteTime  {0}", fi.LastWriteTime);
            Console.WriteLine("DirectoryName  {0}", fi.DirectoryName);
            Console.WriteLine("Extension      {0}", fi.Extension);
            Console.WriteLine("FullName       {0}", fi.FullName);
            Console.WriteLine("Name           {0}", fi.Name);
            Console.WriteLine("IsReadOnly     {0}", fi.IsReadOnly);
            Console.WriteLine("Length         {0}", fi.Length);
        }

        public static void PathPokusy(string soubor)
        {
            Console.WriteLine("Soubor                      {0}", soubor);
            Console.WriteLine("GetFullPath                 {0}", Path.GetFullPath(soubor));
            Console.WriteLine("GetDirectoryName            {0}", Path.GetDirectoryName(soubor));
            Console.WriteLine("GetExtension                {0}", Path.GetExtension(soubor));
            Console.WriteLine("GetFileName                 {0}", Path.GetFileName(soubor));
            Console.WriteLine("GetFileNameWithoutExtension {0}", Path.GetFileNameWithoutExtension(soubor));
            Console.WriteLine("GetPathRoot                 {0}", Path.GetPathRoot(soubor));
            Console.WriteLine("HasExtension                {0}", Path.HasExtension(soubor));
            Console.WriteLine("ChangeExtension             {0}", Path.ChangeExtension(soubor, ".ABC"));
            Console.WriteLine("IsPathRooted                {0}", Path.IsPathRooted(soubor));

            Console.WriteLine("GetRandomFileName           {0}", Path.GetRandomFileName());
            Console.WriteLine("GetTempFileName             {0}", Path.GetTempFileName());

            Console.WriteLine("PathSeparator               {0}", Path.PathSeparator);
            Console.WriteLine("VolumeSeparatorChar         {0}", Path.VolumeSeparatorChar);
            Console.WriteLine("DirectorySeparatorChar      {0}", Path.DirectorySeparatorChar);
        }

        public static void SouboryVeSlozce(string slozka)
        {
            string[] soubory = Directory.GetFiles(slozka);
            foreach (var soubor in soubory)
                Console.WriteLine(Path.GetFileName(soubor));
        }

        public static void PodslozkyVeSlozce(string slozka)
        {
            string[] soubory = Directory.GetDirectories(slozka);
            foreach (var soubor in soubory)
                Console.WriteLine(Path.GetFileName(soubor));
        }

        public static void HledejSoubory(string slozka)
        {
            // Najít soubory
            string[] soubory = Directory.GetFiles(slozka);
            foreach (var soubor in soubory)
            {
                var fi = new FileInfo(soubor);
                Console.WriteLine("{0,-70} {1,12:N0} B", fi.Name, fi.Length);
            }

            // Prohledat podsložky
            string[] slozky = Directory.GetDirectories(slozka);
            foreach (var dir in slozky)
            {
                Console.WriteLine("{0,-79} <DIR>", Path.GetFullPath(dir));
                HledejSoubory(dir);
            }
        }

        // Další způsob hledání souborů i v podsložkách
        public static void HledejJenSoubory(string slozka)
        {
            DirectoryInfo di = new DirectoryInfo(slozka); // Informace o složce
            FileInfo[] soubory = di.GetFiles("*", SearchOption.AllDirectories);
            foreach (var fi in soubory) // Projít všechny nalezené soubory a vypsat je
                Console.WriteLine("{0,-70} {1,12:N0} B", fi.FullName, fi.Length);
        }

        // Výpočet velikosti složky (součet velikostí všech souborů v ní a jejích podsložkách)
        public static long VelikostSlozky(string slozka)
            => (new DirectoryInfo(slozka))                  // Informace o složce
                .GetFiles("*", SearchOption.AllDirectories) // Všechny soubory včetně podsložek
                .Sum(soubor => soubor.Length);              // Součet velikostí všech souborů

        #endregion

    }
}

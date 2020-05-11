using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
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

        #region Binární soubory

        public static void ZapisCislo(string soubor)
        {
            using (var fs = new FileStream(soubor, FileMode.Create))
            using (var bw = new BinaryWriter(fs))
            {
                bw.Write(2185770532);
            }
        }


        public static void ZapisCisla(string soubor)
        {
            using (var fs = new FileStream(soubor, FileMode.Create))
            using (var bw = new BinaryWriter(fs))
            {
                for (int i = 0; i < 20; i++)
                {
                    int x = random.Next();
                    bw.Write(x);
                }
            }
        }

        public static void PrectiCisla(string soubor)
        {
            try
            {
                using (var fs = new FileStream(soubor, FileMode.Open))
                using (var br = new BinaryReader(fs))
                {
                    while (true)
                    {
                        int x = br.ReadInt32();
                        Console.WriteLine(x);
                    }
                }
            }
            catch (EndOfStreamException) { }
        }

        public static void ZapisujDoSouboruBinarne(string soubor)
        {
            Console.WriteLine("Zadávej text pro zápis, zadávání ukonči slovem 'konec':");
            using (var fs = new FileStream(soubor, FileMode.Create))
            using (var bw = new BinaryWriter(fs))
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (s == "konec") break;
                    bw.Write(s);
                }
            }
        }

        public static void PrectiTexty(string soubor)
        {
            try
            {
                using (var fs = new FileStream(soubor, FileMode.Open))
                using (var br = new BinaryReader(fs))
                {
                    while (true)
                    {
                        string s = br.ReadString();
                        Console.WriteLine(s);
                    }
                }
            }
            catch (EndOfStreamException) { }
        }

        public static void PrectiTexty2(string soubor)
        {
            try
            {
                using (var fs = new FileStream(soubor, FileMode.Open))
                using (var br = new BinaryReader(fs))
                {
                    int delkaPrvnihoTextu = br.ReadByte();
                    fs.Seek(delkaPrvnihoTextu, SeekOrigin.Current);
                    while (true)
                        Console.WriteLine(br.ReadString());
                }
            }
            catch (EndOfStreamException) { }
        }

        public static void UlozMaticiBinarne(int[,] a, string soubor)
        {
            using (var fs = new FileStream(soubor, FileMode.Create))
            using (var bw = new BinaryWriter(fs))
            {
                bw.Write(a.GetLength(0));
                bw.Write(a.GetLength(1));
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        bw.Write(a[i, j]);
            }
        }

        public static int[,] NactiMaticiBinarne(string soubor)
        {
            using (var fs = new FileStream(soubor, FileMode.Open))
            using (var br = new BinaryReader(fs))
            {
                int m = br.ReadInt32();
                int n = br.ReadInt32();
                int[,] a = new int[m, n];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        a[i, j] = br.ReadInt32();
                return a;
            }
        }

        #region Slučování souborů

        public static void SlucSoubory(string slozkaSeVstupnimiSoubory, string vystupniSoubor)
        {
            var soubory = Directory.GetFiles(slozkaSeVstupnimiSoubory);

            using (var fs = new FileStream(vystupniSoubor, FileMode.Create, FileAccess.Write))
            using (var gz = new GZipStream(fs, CompressionLevel.Optimal))
            using (var bw = new BinaryWriter(gz))
            {
                bw.Write(soubory.Length);  // Počet souborů

                foreach (var soubor in soubory)
                {
                    bw.Write(Path.GetFileName(soubor)); // Název souboru
                    var fi = new FileInfo(soubor);
                    bw.Write(fi.Length); // Velikost souboru (počet B)

                    // Přepis obsahu zdrojového souboru do cílového souboru

                    // VERZE 1 - Přepisování po bajtech
                    //using (var fsSoubor = new FileStream(soubor, FileMode.Open))
                    //using (var br = new BinaryReader(fsSoubor))
                    //    for (long i = 0; i < fi.Length; i++)
                    //        bw.Write(br.ReadByte());

                    // VERZE 2 - Přepis po blocích dat (1kB)
                    //using (var fsSoubor = new FileStream(soubor, FileMode.Open))
                    //{
                    //    byte[] buffer = new byte[1024]; // Blok pro přenos dat
                    //    int bytesRead; // Počet bajtů skutečně načtených do bufferu
                    //    while ((bytesRead = fsSoubor.Read(buffer, 0, buffer.Length)) > 0)
                    //        gz.Write(buffer, 0, bytesRead); // Přepiš načtený blok (či jeho zbytek)
                    //}

                    // VERZE 3 - Kopie celého proudu
                    using (var fsSoubor = new FileStream(soubor, FileMode.Open))
                        fsSoubor.CopyTo(gz);
                }
            }
        }


        public static void RozdelSoubory(string vstupniSoubor, string vystupniSlozka)
        {
            vystupniSlozka = vystupniSlozka.TrimEnd('\\') + "\\";

            using (var fs = new FileStream(vstupniSoubor, FileMode.Open))
            using (var gz = new GZipStream(fs, CompressionMode.Decompress))
            using (var br = new BinaryReader(gz))
            {
                int pocetSouboru = br.ReadInt32();  // Počet souborů

                for (int i = 0; i < pocetSouboru; i++)
                {
                    string nazevSouboru = br.ReadString();
                    long velikostSouboru = br.ReadInt64();

                    // Přepis obshau do nového souboru

                    // VERZE 1 - Přepisování po bajtech
                    //using (var fsSoubor = new FileStream(vystupniSlozka + nazevSouboru, FileMode.Create))
                    //using (var bw = new BinaryWriter(fsSoubor))
                    //    for (long j = 0; j < velikostSouboru; j++)
                    //        bw.Write(br.ReadByte());

                    // VERZE 2 - Přepis po blocích dat (1kB)
                    using (var fsSoubor = new FileStream(Path.Combine(vystupniSlozka, nazevSouboru), FileMode.Create))
                    {
                        byte[] buffer = new byte[1024]; // Blok pro přenos dat
                        while (velikostSouboru > 0)     // Dokud nebude soubor přepsán celý
                        {
                            int cistBytu = (int)Math.Min(velikostSouboru, buffer.Length); // Kolik B načíst
                            gz.Read(buffer, 0, cistBytu);        // Přečíst blok (nebo zbytek) dat
                            fsSoubor.Write(buffer, 0, cistBytu); // Zapsat načtený blok (či zbytek) dat
                            velikostSouboru -= cistBytu;         // Odečíst od zbytku kolik se přeneslo
                        }
                    }
                }
            }
        }

        #region Varianta se šifrováním

        // Verze, která archiv i zašifruje na základě hesla
        public static void SlucSoubory(string slozkaSeVstupnimiSoubory, string vystupniSoubor, string heslo)
        {
            var soubory = Directory.GetFiles(slozkaSeVstupnimiSoubory);
            using (Aes aes = Aes.Create())   // System.Security.Cryptography
            {
                aes.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(heslo)); // Hash hesla
                aes.IV = new byte[16];
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var fs = new FileStream(vystupniSoubor, FileMode.Create))
                using (var cs = new CryptoStream(fs, encryptor, CryptoStreamMode.Write))
                using (var gz = new GZipStream(cs, CompressionLevel.Optimal))
                using (var bw = new BinaryWriter(gz))
                {
                    bw.Write(soubory.Length);               // Počet souborů
                    foreach (var soubor in soubory)
                    {
                        bw.Write(Path.GetFileName(soubor)); // Název souboru
                        var fi = new FileInfo(soubor);
                        bw.Write(fi.Length);                // Velikost souboru (počet B)
                        using (var fsSoubor = new FileStream(soubor, FileMode.Open))
                            fsSoubor.CopyTo(gz);            // Obsah souboru
                    }
                }
            }
        }

        // Verze, která dokáže rozbalit zašifrovaný archiv (musí být zadáno správné heslo)
        public static void RozdelSoubory(string vstupniSoubor, string vystupniSlozka, string heslo)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(heslo)); // Hash hesla
                aes.IV = new byte[16];
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (var fs = new FileStream(vstupniSoubor, FileMode.Open))
                using (var cs = new CryptoStream(fs, decryptor, CryptoStreamMode.Read))
                using (var gz = new GZipStream(cs, CompressionMode.Decompress))
                using (var br = new BinaryReader(gz))
                {
                    int pocetSouboru = br.ReadInt32();         // Počet souborů
                    for (int i = 0; i < pocetSouboru; i++)
                    {
                        string nazevSouboru = br.ReadString(); // Název souboru
                        long velikostSouboru = br.ReadInt64(); // Velikost souboru
                        using (var fsSoubor = new FileStream(Path.Combine(vystupniSlozka, nazevSouboru), FileMode.Create))
                        {
                            byte[] buffer = new byte[1024]; // Blok pro přenos dat
                            while (velikostSouboru > 0)     // Dokud nebude soubor přepsán celý
                            {
                                int cistBytu = (int)Math.Min(velikostSouboru, buffer.Length); // Kolik B načíst
                                gz.Read(buffer, 0, cistBytu);        // Přečíst blok (nebo zbytek) dat
                                fsSoubor.Write(buffer, 0, cistBytu); // Zapsat načtený blok (či zbytek) dat
                                velikostSouboru -= cistBytu;         // Odečíst od zbytku kolik se přeneslo
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Varianta pro klasický ZIP archiv (komprimuje i podsložky)

        public static void SlucSouboryZip(string slozkaSeVstupnimiSoubory, string vystupniSoubor)
            => ZipFile.CreateFromDirectory(slozkaSeVstupnimiSoubory, vystupniSoubor, CompressionLevel.Optimal, false);

        public static void RozdelSouboryZip(string vstupniSoubor, string vystupniSlozka)
            => ZipFile.ExtractToDirectory(vstupniSoubor, vystupniSlozka, true);

        #endregion

        #endregion

        #endregion
    }
}

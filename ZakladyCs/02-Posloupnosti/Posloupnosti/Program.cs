using System;

namespace Posloupnosti
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            // Deklarace posloupnosti (1D pole)
            int[] a = new int[10];  // indexy 0-9 = 10 hodnot (členů)

            // Načtení od uživatele
            //for (int i = 0; i < a.Length; i++)
            //    a[i] = Convert.ToInt32(Console.ReadLine());

            // Načtení hodnot do 1 do N
            //for (int i = 0; i < a.Length; i++)
            //    a[i] = i + 1;

            // Načtení náhodných hodnot 
            for (int i = 0; i < a.Length; i++)
                a[i] = random.Next(0, 10);  // náhodné číslo od 0 do 9

            VypisPosloupnost(a);

            // Výpis posloupnosti - pod sebe
            //for (int i = 0; i < a.Length; i++)
            //    Console.WriteLine("{0}. {1}", i, a[i]);

            // Součet členů posloupnosti
            int soucet = 0;
            for (int i = 0; i < a.Length; i++)
                soucet += a[i]; // soucet = soucet + a[i];
            Console.WriteLine("součet = {0}", soucet);
            Console.WriteLine("průměr = {0}", soucet / (double)a.Length);

            // Počet sudých členů (bez 0)
            int pocet = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] % 2 == 0 && a[i] != 0)
                    pocet++;  // pocet = pocet + 1;
            Console.WriteLine("počet sudých hodnot (bez 0) = {0}", pocet);

            // Nalezení minimální hondoty
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
                if (a[i] < min)
                    min = a[i];
            Console.WriteLine("minimum = {0}", min);

            // Počet minim
            int pocetMinim = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] == min)
                    pocetMinim++;  // pocet = pocet + 1;
            Console.WriteLine("minimum = {0} a je tam {1}x", min, pocetMinim);

            // Index prvního minima
            int iMin = 0;
            for (int i = 1; i < a.Length; i++)
                if (a[i] < a[iMin])
                    iMin = i;
            Console.WriteLine("minimum = {0} a poprvé je na indexu {1}", a[iMin], iMin);

            // Odebrání člena posloupnosti
            //Console.Write("Zadej index člena pro odbrání: ");
            //int k = Convert.ToInt32(Console.ReadLine());
            //VypisPosloupnost(a);
            //for (int i = k; i < a.Length - 1; i++)
            //    a[i] = a[i + 1];
            //Array.Resize(ref a, a.Length-1);
            //VypisPosloupnost(a);

            // Vložení nového člena do posloupnosti
            //Console.Write("Zadej index člena pro vložení: ");
            //int k = Convert.ToInt32(Console.ReadLine()); 
            //Console.Write("Zadej hodnotu nového člena: ");
            //int h = Convert.ToInt32(Console.ReadLine());
            //VypisPosloupnost(a);
            //Array.Resize(ref a, a.Length + 1);
            //for (int i = a.Length - 1; i > k; i--)
            //    a[i] = a[i - 1];
            //a[k] = h;
            //VypisPosloupnost(a);

            // Cyklický posun vpřed (doleva)
            VypisPosloupnost(a);
            int p = a[0];
            for (int i = 0; i < a.Length - 1; i++)
                a[i] = a[i + 1];
            a[a.Length - 1] = p;
            VypisPosloupnost(a);

            // Cyklický posun vzad (doleva)
            p = a[a.Length - 1];
            for (int i = a.Length - 1; i > 0; i--)
                a[i] = a[i - 1];
            a[0] = p;
            VypisPosloupnost(a);

            // Zkopírování sudých členů z A do B
            int[] b = new int[0];
            for (int i = 0; i < a.Length; i++)
                if (a[i] % 2 == 0)
                {
                    Array.Resize(ref b, b.Length + 1);
                    b[b.Length - 1] = a[i];
                }
            VypisPosloupnost(b);

            // Spojení posloupností A a B do C
            int[] c = new int[a.Length + b.Length];
            for (int i = 0; i < a.Length; i++)
                c[i] = a[i];
            for (int i = 0; i < b.Length; i++)
                c[a.Length + i] = b[i];
            VypisPosloupnost(c);

            Console.ReadLine();
        }

        static void VypisPosloupnost(int[] a)
        {
            // Výpis posloupnosti - vedle sebe
            for (int i = 0; i < a.Length; i++)
                Console.Write("{0}, ", a[i]);
            Console.WriteLine();
        }
    }
}

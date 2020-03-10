using System;
using System.Numerics;

namespace ZakladniPrikazy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hello You!
            //Console.Write("Zadej své jméno: ");
            //string jmeno = Console.ReadLine();
            //Console.WriteLine("Ahoj " + jmeno + "!");
            //Console.WriteLine("Ahoj {0}!", jmeno);
            //Console.WriteLine($"Ahoj {jmeno}!");

            // Číselný vstup a formát výstupu
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //int c = a + b;
            //Console.WriteLine(c);
            //Console.WriteLine("{0} + {1} = {2}", a, b, c);
            //Console.WriteLine($"{a} + {b} = {c}");
            //Console.WriteLine("{0} + {1} = {2}", a, b, a+b);
            //Console.WriteLine($"{a} + {b} = {a+b}");

            // Operace se dvěma čísly
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Součet = {0}", a + b);
            //Console.WriteLine("Součin = {0}", a * b);
            //Console.WriteLine("Rozdíl = {0}", a - b);
            //Console.WriteLine("Podíl  = {0}", a / (double)b);
            //Console.WriteLine("Celočíselné dělení = {0}", a / b); // div
            //Console.WriteLine("Zbytek po dělení   = {0}", a % b); // mod
            //Console.WriteLine("Sin(pi/2) = {0}", Math.Sin(Math.PI / 2.0));

            // Větší ze dvou hodnot
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //if (a == b)
            //    Console.WriteLine("Čísla jsou stejná {0}", a);
            //else if (a > b)
            //    Console.WriteLine("Větší je {0}", a);
            //else
            //    Console.WriteLine("Větší je {0}", b);

            // Největší ze čtyř hodnot
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //int c = Convert.ToInt32(Console.ReadLine());
            //int d = Convert.ToInt32(Console.ReadLine());
            //int max = a;
            //if (b > max) max = b;
            //if (c > max) max = c;
            //if (d > max) max = d;
            //Console.WriteLine("Najvětší je {0}", max);

            // Prohození dvou proměnných
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("{0}, {1}", a, b);
            //int p = a;
            //a = b;
            //b = p;
            //Console.WriteLine("{0}, {1}", a, b);

            // Cyklický posun vpřed (1, 2, 3 => 2, 3, 1)
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //int c = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("{0}, {1}, {2}", a, b, c);
            //int p = a;
            //a = b;
            //b = c;
            //c = p;
            //Console.WriteLine("{0}, {1}, {2}", a, b, c);

            // Cyklický posun vzad (1, 2, 3 => 3, 1, 2)
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //int c = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("{0}, {1}, {2}", a, b, c);
            //int p = c;
            //c = b;
            //b = a;
            //a = p;
            //Console.WriteLine("{0}, {1}, {2}", a, b, c);

            // Cyklus DOKUD
            //int i = 1;
            //while (i <= 10)
            //{
            //    Console.WriteLine(i);
            //    i++;  // i += 1;   // i = i + 1;
            //}

            // Cyklus PRO
            //for (int i = 1; i <= 10; i++)
            //    Console.WriteLine(i);

            // Zahelsovaný přístup
            //Console.Write("Zadej heslo: ");
            //string heslo = Console.ReadLine();
            //while (heslo != "123")
            //{
            //    Console.Write("Neplatné heslo, zkus to znovu: ");
            //    heslo = Console.ReadLine();
            //}
            //Console.Write("Tajná informace...");

            // Zahelsovaný přístup - 3 pokusy
            //Console.Write("Zadej heslo: ");
            //string heslo = Console.ReadLine();
            //int i = 1;
            //while (heslo != "123" && i < 3)
            //{
            //    Console.Write("Neplatné heslo, zkus to znovu: ");
            //    heslo = Console.ReadLine();
            //    i++;
            //}
            //if (heslo == "123")
            //    Console.WriteLine("Tajná informace...");
            //else
            //    Console.WriteLine("Počet pokusů byl překročen...");

            // Fibonacciho posloupnost (0, 1, 1, 2, 3, 5, 8, 13, ...)
            Console.Write("Po kolikátý člen Fibonacciho posloupnosti (1-93): ");
            int n = Convert.ToInt32(Console.ReadLine());
            // Vypsání prvních dvou členů posl. (index 0 a 1)
            BigInteger a1 = 0, a2 = 1;
            Console.WriteLine("{0,2}. = {1,26:N0}", 0, a1);
            Console.WriteLine("{0,2}. = {1,26:N0}", 1, a2);
            // Vypsání zbytku
            for (int i = 2; i <= n; i++)
            {
                BigInteger a3 = a1 + a2;
                Console.WriteLine("{0,2}. = {1,26:N0}", i, a3);
                a1 = a2;
                a2 = a3;
            }

            Console.ReadLine();
        }
    }
}

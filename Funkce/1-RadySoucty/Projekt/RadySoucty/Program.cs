using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadySoucty
{
    class Program
    {
        static void Main(string[] args)
        {
            // Aritmetická posloupnost: a[n] = a[n-1] + d
            // a[0], d, n, a[n] = ?

            Console.Write("d = ");
            long d = Convert.ToInt64(Console.ReadLine());
            Console.Write("n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("a[0] = ");
            long a0 = Convert.ToInt64(Console.ReadLine());

            long an = AritmetickaPosloupnost(a0, d, n, false, false);
            Console.WriteLine("a[" + n + "] = " + an);




            // Geometrická posloupnost: a[n] = a[n-1] * q
            // a[0], q, n, a[n] = ?

            //Console.Write("q = ");
            //decimal q = Convert.ToDecimal(Console.ReadLine());
            //Console.Write("n = ");
            //long n = Convert.ToInt64(Console.ReadLine());
            //Console.Write("a[0] = ");
            //decimal a0 = Convert.ToDecimal(Console.ReadLine());

            //decimal an = GeometrickaPosloupnost(a0, q, n, true, true);
            //Console.WriteLine("a[" + n + "] = " + an);




            // Faktoriál: n!  =  1 * 2 * 3 * ... * n  =  n * (n-1)!    kde  1! = 1, pouze pro n >= 1
            // n = ?

            //Console.Write("n = ");
            //int n = Convert.ToInt32(Console.ReadLine());

            //long f = Faktorial(n);
            //Console.WriteLine(n + "! = " + f);




            // Fibonacciho posloupnost: a[n] = a[n-1] + a[n-2]   kde a[0] = a[1] = 1
            // n = ?

            //Console.Write("n = ");
            //int n = Convert.ToInt32(Console.ReadLine());

            //long fb = FibonaccihoPosloupnost(n, true, true);
            //Console.WriteLine("a[" + n + "] = " + fb);

            Console.ReadLine();
        }

        static long FibonaccihoPosloupnost(int n, bool vypsatRadu, bool vypsatSumu)
        {
            long a0 = 1, a1 = 1;
            if (vypsatRadu)
            {
                Console.WriteLine("a[0] = " + a0);
                Console.WriteLine("a[1] = " + a1);
            }
            long an = a0 + a1;
            long suma = a0 + a1;
            for (int i = 2; i <= n; i++)
            {
                an = a0 + a1;
                a0 = a1;
                a1 = an;
                if (vypsatRadu)
                    Console.WriteLine("a[" + i + "] = " + an);
                suma += an;
            }
            if (vypsatSumu)
                Console.WriteLine("suma = " + suma);
            return an;
        }

        static long AritmetickaPosloupnost(long a0, long d, int n, bool vypsatRadu, bool vypsatSumu)
        {
            long an = a0;
            long suma = a0;
            for (int i = 1; i <= n; i++)
            {
                an = an + d;
                if (vypsatRadu)
                    Console.WriteLine("a[" + i + "] = " + an);
                suma += an;
            }
            if (vypsatSumu)
                Console.WriteLine("suma = " + suma);
            return an;
        }

        static decimal GeometrickaPosloupnost(decimal a0, decimal q, int n, bool vypsatRadu, bool vypsatSumu)
        {
            decimal an = a0;
            decimal suma = a0;
            for (int i = 1; i <= n; i++)
            {
                an = an * q;
                if (vypsatRadu)
                    Console.WriteLine("a[" + i + "] = " + an);
                suma += an;
            }
            if (vypsatSumu)
                Console.WriteLine("suma = " + suma);
            return an;
        }

        static long Faktorial(int n)
        {
            if (n < 1)
                throw new Exception("Neplatná hodnota");
            if (n == 1)
                return 1;
            return n * Faktorial(n - 1);
        }

    }
}

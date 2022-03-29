using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuloveBody
{
    class Program
    {
        static ulong sk = 0, pi = 0, ms = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Kořen je na ".PadRight(20) + (Math.PI / 2.0));

            double x1, x2;
            if (SeparaceKorenu(min, max, 10000000, out x1, out x2))
            {
                Console.WriteLine("Kořen leží mezi ".PadRight(20) + x1);
                Console.WriteLine(" a ".PadRight(20) + x2);
            }
            else
                Console.WriteLine("Kořen nenalezen");

            double x = PuleniIntervalu(min, max, 0.0000001);
            Console.WriteLine("Půlení intervalu ".PadRight(20) + x);

            x = MetodaSecen(min, max, 0.0000001);
            Console.WriteLine("Metoda sečen ".PadRight(20) + x);

            Console.WriteLine();
            Console.WriteLine("Separace kořenů ".PadRight(20) + sk);
            Console.WriteLine("Půlení intervalu ".PadRight(20) + pi);
            Console.WriteLine("Metoda sečen ".PadRight(20) + ms);

            Console.ReadLine();
        }

        static double MetodaSecen(double x1, double x2, double e)
        {
            double y1 = Function(x1);
            double y2 = Function(x2);
            double x = x1;

            while (Math.Abs(x1 - x2) > e)
            {
                x = (x1 * y2 - x2 * y1) / (y2 - y1);
                double yx = Function(x);

                if (y1 * yx <= 0)
                {
                    x2 = x;
                    y2 = yx;
                } else
                {
                    x1 = x;
                    y1 = yx;
                }
                ms++;
            }
            return (x1 * y2 - x2 * y1) / (y2 - y1);
        }


        static double PuleniIntervalu(double Xmin, double Xmax, double e)
        {
            double x = (Xmin + Xmax) / 2.0;
            if (Math.Abs(Xmax - Xmin) <= e)
                return x;

            if (Function(Xmin) * Function(x) <= 0)
                Xmax = x;
            else
                Xmin = x;

            pi++;
            return PuleniIntervalu(Xmin, Xmax, e);
        }

        static bool SeparaceKorenu(double Xmin, double Xmax, double n,
            out double x1, out double x2)
        {
            double h = (Xmax - Xmin) / n;
            double x = Xmin;
            double Ynew = Function(x);
            double Yold = Ynew;

            while (Ynew * Yold > 0 && x <= Xmax)
            {
                Yold = Ynew;
                x += h;
                Ynew = Function(x);
                sk++;
            }

            x1 = x - h;
            x2 = x;

            return x <= Xmax;
        }


        static double min = 0, max = Math.PI * 1.4;
        static double Function(double x)
        {
            return Math.Cos(x);
        }
    }
}

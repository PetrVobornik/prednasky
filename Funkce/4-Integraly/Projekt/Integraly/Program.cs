using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integraly
{
    class Program
    {
        static double min = 0, max = Math.PI;
        static double Function(double x)
        {
            return Math.Sin(x);
        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Restart();
            double integral = LichobeznikovaMetoda(min, max, 1000000);
            Debug.WriteLine("LichobeznikovaMetoda: {0} ms", sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("LichobeznikovaMetoda: {0}", integral);

            sw.Restart();
            integral = ParabolickaMetoda(min, max, 1000000);
            Debug.WriteLine("ParabolickaMetoda:    {0} ms", sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("ParabolickaMetoda:    {0}", integral);

            sw.Restart();
            integral = TecnovaMetoda(min, max, 1000000);
            Debug.WriteLine("TecnovaMetoda:        {0} ms", sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("TecnovaMetoda:        {0}", integral);

            sw.Restart();
            integral = PozadovanaPresnot(min, max, 0.0000000001);
            Debug.WriteLine("PozadovanaPresnot:    {0} ms", sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("PozadovanaPresnot:    {0}", integral);

            Console.ReadLine();
        }

        static double PozadovanaPresnot(double Xmin, double Xmax, double e)
        {
            double n = 4;
            double iNew = 0;
            double iOld = 2 * e;

            int pocet = 0;
            while (Math.Abs(iNew - iOld) > e)
            {
                iOld = iNew;
                iNew = ParabolickaMetoda(Xmin, Xmax, n);
                pocet += (int)n - 2;
                Debug.WriteLine("dilku: {0}", n);
                n *= 2;
            }
            Debug.WriteLine("PozadovanaPresnot (ParabolickaMetoda): {0}", pocet);

            return iNew;
        }


        static double TecnovaMetoda(double Xmin, double Xmax, double n)
        {
            if (n % 2 != 0) n++;
            double h = (Xmax - Xmin) / n;
            double s = 0;
            double x = Xmin + h;

            for (int i = 1; i <= n/2; i++)
            {
                s += Function(x);
                x += 2 * h;
            }

            return s * 2 * h;
        }

        static double ParabolickaMetoda(double Xmin, double Xmax, double n)
        {
            double h = (Xmax - Xmin) / n;
            double s = Function(Xmin) + Function(Xmax);
            double m = 1;

            for (int i = 1; i < n; i++)
            {
                s += (3 + m) * Function(Xmin + h * i);
                m = -m;
            }

            return s * (Xmax - Xmin) / (3 * n);
        }

        static double LichobeznikovaMetoda(double Xmin, double Xmax, double n)
        {
            double h = (Xmax - Xmin) / n;
            double s = (Function(Xmin) + Function(Xmax)) / 2.0;

            for (int i = 1; i < n; i++)
                s += Function(Xmin + h * i);

            return s * h;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Extremy
{
    class Program
    {
        static double min = 0.1, max = Math.PI * 1.4;
        static double Function(double x)
        {
            return Math.Cos(x);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Minimum je v          {0}", Math.PI);
            double e = 0.0000001;

            Thread.Sleep(1000);


            Stopwatch watch = new Stopwatch();
            double x = 0;

            watch.Restart();
            x = MetodaZpetnehoKroku(min, max, e);
            Debug.WriteLine("MetodaZpetnehoKroku: {0} ms", watch.Elapsed.TotalMilliseconds);
            Console.WriteLine("MetodaZpetnehoKroku   {0}", x);

            watch.Restart();
            x = MetodaZpetnehoKroku(min, max, e);
            Debug.WriteLine("MetodaZpetnehoKroku: {0} ms", watch.Elapsed.TotalMilliseconds);
            Console.WriteLine("MetodaZpetnehoKroku   {0}", x);

            watch.Restart();
            x = MetodaPuleniIntervalu(min, max, e);
            Debug.WriteLine("MetodaPuleniIntervalu: {0} ms", watch.Elapsed.TotalMilliseconds);
            Console.WriteLine("MetodaPuleniIntervalu {0}", x);

            watch.Restart();
            x = MetodaFibonaccihoRady(min, max, e);
            Debug.WriteLine("MetodaFibonaccihoRady: {0} ms", watch.Elapsed.TotalMilliseconds);
            Console.WriteLine("MetodaFibonaccihoRady {0}", x);

            Console.ReadLine();
        }

        static double MetodaFibonaccihoRady(double Xmin, 
            double Xmax, double e)
        {
            double m = (Xmax - Xmin) / e;

            ulong f0 = 1, f1 = 1, f2 = 2;
            while (f2 < m)
            {
                f0 = f1;
                f1 = f2;
                f2 = f0 + f1;
            }

            double d = (Xmax - Xmin) / (double)f2;
            double y = Function(Xmin);
            double x = Xmin + d * f1;
            double yx = Function(x);

            int i = 0;
            while (f2 > 1)
            {
                if (yx >= y)
                    d = -d;
                y = yx;
                f2 = f1;
                f1 = f0;
                f0 = f2 - f1;
                x += d * f1;
                yx = Function(x);
                i++;
            }
            Debug.WriteLine("MetodaFibonaccihoRady: {0:N0}", i);
            return x;
        }

        struct XY
        {
            public double Y { get; private set; }

            private double x;
            public double X
            {
                get { return x; }
                set { x = value; Y = Function(x); }
            }

            public static void NastavBody(ref XY[] body, 
                double Xmin, double Xmax)
            {
                body[0].X = Xmin;                          //   0%
                body[4].X = Xmax;                          // 100%
                body[2].X = (body[0].X + body[4].X) / 2.0; //  50%
                body[1].X = (body[0].X + body[2].X) / 2.0; //  25%
                body[3].X = (body[2].X + body[4].X) / 2.0; //  75%
            }

            public static int NajdiIndexMinima(XY[] body)
            {
                int min = 1;
                for (int i = 2; i < body.Length - 1; i++)
                    if (body[i].Y < body[min].Y)
                        min = i;
                return min;
            }
        }

        static double MetodaPuleniIntervalu(double Xmin, double Xmax, double e)
        {
            XY[] body = new XY[5]; // 5 členů, indexy 0-4
            XY.NastavBody(ref body, Xmin, Xmax);
            int iMin = XY.NajdiIndexMinima(body);

            int i = 0;
            while (Math.Abs(body[1].X - body[3].X) > e)
            {
                XY.NastavBody(ref body, body[iMin - 1].X, body[iMin + 1].X);
                iMin = XY.NajdiIndexMinima(body);
                i++;
            }
            Debug.WriteLine("MetodaPuleniIntervalu: {0:N0}", i);
            return body[iMin].X;
        }

        static double MetodaZpetnehoKroku(double Xmin, double Xmax, double e)
        {
            double d = 0.4 * (Xmax - Xmin);
            double y0 = Function(Xmin);
            double x = Xmin + d;
            double y1 = Function(x);

            int i = 0;
            while (Math.Abs(d) > e)
            {
                if (y1 >= y0)
                    d = -d / 3.0;
                y0 = y1;
                x += d;
                y1 = Function(x);
                i++;
            }
            Debug.WriteLine("MetodaZpetnehoKroku:   {0:N0}", i);
            return x;
        }
    }
}

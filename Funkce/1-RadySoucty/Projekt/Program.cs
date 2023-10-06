
using System.Numerics;

// Aritmetická posloupnost: a[n] = a[n-1] + d
// a[0], d, n, a[n] = ?

//Console.Write("a[0] = ");
//long a0 = Convert.ToInt64(Console.ReadLine());
//Console.Write("d = ");
//long d = Convert.ToInt64(Console.ReadLine());
//Console.Write("n = ");
//int n = Convert.ToInt32(Console.ReadLine());

//long an = AritmetickaPosloupnost(a0, d, n, true);
//Console.WriteLine("a[{0}] = {1}", n, an);

long AritmetickaPosloupnost(long a0, long d, int n, 
    bool vypsatRadu = false, bool vypsatSumu = false)
{
    if (vypsatRadu)
        Console.WriteLine("a[0] = {0}", a0);
    long an = a0;
    long sum = a0;
    for (int i = 1; i <= n; i++)
    {
        an = an + d;
        if (vypsatRadu)
            Console.WriteLine("a[{0}] = {1}", i, an);
        sum += an;
    }
    if (vypsatSumu)
        Console.WriteLine("suma = {0}", sum);
    return an;
}


// Geometrická posloupnost: a[n] = a[n-1] * q
// a[0], q, n, a[n] = ?

//Console.Write("a[0] = ");
//decimal ga0 = Convert.ToDecimal(Console.ReadLine());
//Console.Write("q = ");
//decimal gq = Convert.ToDecimal(Console.ReadLine());
//Console.Write("n = ");
//int gn = Convert.ToInt32(Console.ReadLine());

//GeometrickaPosloupnost(ga0, gq, gn, true, true);

decimal GeometrickaPosloupnost(decimal a0, decimal q, int n,
    bool vypsatRadu = false, bool vypsatSumu = false)
{
    if (vypsatRadu)
        Console.WriteLine("a[0] = {0}", a0);
    decimal an = a0;
    decimal sum = a0;
    for (int i = 1; i <= n; i++)
    {
        an = an * q;
        if (vypsatRadu)
            Console.WriteLine("a[{0}] = {1}", i, an);
        sum += an;
    }
    if (vypsatSumu)
        Console.WriteLine("suma = {0}", sum);
    return an;
}


// Faktoriál: n!  =  1 * 2 * 3 * ... * n  =  n * (n-1)!    kde  1! = 1, pouze pro n >= 1
// n = ?

//Console.Write("n = ");
//int n = Convert.ToInt32(Console.ReadLine());

//BigInteger f = Faktorial(n);
//Console.WriteLine("{0}! = {1:N0}", n, f);

BigInteger Faktorial(int n)
{
    if (n < 1)
        throw new Exception("Neplatná hodnota");
    if (n == 1) 
        return 1;
    return n * Faktorial(n - 1);
}


// Fibonacciho posloupnost: a[n] = a[n-1] + a[n-2]   kde a[0] = 0, a[1] = 1
// n = ?

Console.Write("n = ");
int n = Convert.ToInt32(Console.ReadLine());

long fb = FibonaccihoPosloupnost(n, true, true);
Console.WriteLine("a[{0}] = {1:N0}", n, fb);


static long FibonaccihoPosloupnost(int n, bool vypsatRadu, bool vypsatSumu)
{
    long a0 = 0, a1 = 1;
    if (vypsatRadu)
    {
        Console.WriteLine("a[0] = {0}", a0);
        Console.WriteLine("a[1] = {0}", a1);
    }
    long an = a0 + a1;
    long suma = an;
    for (int i = 2; i <= n; i++)
    {
        an = a0 + a1;
        a0 = a1;
        a1 = an;
        if (vypsatRadu)
            Console.WriteLine("a[{0}] = {1:N0}", i, an);
        suma += an;
    }
    if (vypsatSumu)
        Console.WriteLine("suma = {0:N0}", suma);
    return an;
}
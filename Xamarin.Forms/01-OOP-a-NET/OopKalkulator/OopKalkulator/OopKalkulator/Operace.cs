using System;
using System.Collections.Generic;
using System.Text;

namespace OopKalkulator
{
    public abstract class Operace
    {
        public double A { get; set; }
        public double B { get; set; }

        public abstract char Znamenko { get; }

        public abstract double Vypocti();
        public override string ToString()
        {
            return String.Format("{0} {1} {2} = {3:N2}", A, Znamenko, B, Vypocti());
        }
    }

    public class Soucet : Operace
    {
        public override char Znamenko => '+';
        public override double Vypocti() => A + B; 
    }

    public class Rozdil : Operace
    {
        public override char Znamenko => '-';
        public override double Vypocti() => A - B;
    }

    public class Soucin : Operace
    {
        public override char Znamenko => '*';
        public override double Vypocti() => A * B;
    }

    public class Podil : Operace
    {
        public override char Znamenko => '/';
        public override double Vypocti() => A / B;
    }

}

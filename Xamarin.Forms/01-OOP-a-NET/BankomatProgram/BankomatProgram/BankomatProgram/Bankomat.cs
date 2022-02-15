using System;
using System.Collections.Generic;
using System.Text;

namespace BankomatProgram
{
    public class Bankomat
    {
        // Konstruktor
        public Bankomat(int vklad)
        {
            castka = vklad;
        }

        // Konstanty
        public const int Maximum = 2000000;

        // Datové položky a vlastnosti
        private int castka;
        public int Castka
        {
            get { return castka; }
            private set
            {
                castka = value;
                ZmenaCastky?.Invoke(this, EventArgs.Empty);
            }
        }

        // Metody
        public bool Vyber(int castka)
        {
            if (castka <= Castka)
            {
                Castka -= castka;
                return true;
            }
            return false;
        }

        public bool Vloz(int castka)
        {
            if (Castka + castka > Maximum)
                return false;
            Castka += castka;
            return true;
        }

        // Událost
        public event EventHandler ZmenaCastky;
    }
}

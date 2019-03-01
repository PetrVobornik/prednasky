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

        public void Vloz(int castka)
        {
            Castka += castka;
        }

        // Událost
        public event EventHandler ZmenaCastky;
    }
}

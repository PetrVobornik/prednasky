using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace UkladaniDat
{
    public class Nastaveni : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        static Nastaveni aktualni;
        static public Nastaveni Aktualni
        {
            get
            {
                if (aktualni == null)
                    aktualni = new Nastaveni();
                return aktualni;
            }
        }

        private Nastaveni()
        {
            jmeno = Preferences.Get(nameof(Jmeno), "");
            prihlasitOdber = Preferences.Get(nameof(PrihlasitOdber), false);
        }

        private string jmeno;
        public string Jmeno
        {
            get { return jmeno; }
            set { jmeno = value; OnPropertyChanged(); Preferences.Set(nameof(Jmeno), value); }
        }


        private bool prihlasitOdber;
        public bool PrihlasitOdber
        {
            get { return prihlasitOdber; }
            set { prihlasitOdber = value; OnPropertyChanged(); Preferences.Set(nameof(PrihlasitOdber), value); }
        }

    }
}

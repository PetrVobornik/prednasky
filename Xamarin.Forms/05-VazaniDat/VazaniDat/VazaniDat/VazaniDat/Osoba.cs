using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace VazaniDat
{
    public class Osoba : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        private string jmeno;
        public string Jmeno
        {
            get { return jmeno; }
            set { jmeno = value; OnPropertyChanged(); }
        }

        private DateTime datumNarozeni;
        public DateTime DatumNarozeni
        {
            get { return datumNarozeni; }
            set { datumNarozeni = value; OnPropertyChanged(); }
        }

        private int vyska;
        public int Vyska
        {
            get { return vyska; }
            set { vyska = value; OnPropertyChanged(); }
        }


    }
}

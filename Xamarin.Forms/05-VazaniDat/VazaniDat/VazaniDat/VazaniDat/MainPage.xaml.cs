using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VazaniDat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var osoba = new Osoba()
            {
                Jmeno = "Alois",
                DatumNarozeni = DateTime.Today.AddDays(-2),
                Vyska = 170,
            };
            sLayout.BindingContext = osoba;

            eJmeno2.SetBinding(Entry.TextProperty, "Jmeno");

            lStupnu.SetBinding(Label.TextProperty, "Value", stringFormat: "{0:N1}°");
            lStupnu.BindingContext = sStupnu;
        }
    }
}

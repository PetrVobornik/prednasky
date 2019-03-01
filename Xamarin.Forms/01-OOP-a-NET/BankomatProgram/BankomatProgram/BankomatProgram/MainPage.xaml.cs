using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BankomatProgram
{
    public partial class MainPage : ContentPage
    {
        Bankomat bankomat;

        public MainPage()
        {
            InitializeComponent();
            bankomat = new Bankomat(0);
            bankomat.ZmenaCastky += Bankomat_ZmenaCastky;
            bankomat.Vloz(500000);
        }

        private void Bankomat_ZmenaCastky(object sender, EventArgs e)
        {
            eStav.Text = bankomat.Castka.ToString("N0") + ",-";
        }

        private void BVlozit_Clicked(object sender, EventArgs e)
        {
            bankomat.Vloz(Convert.ToInt32(eCastka.Text));
        }

        private void BVybrat_Clicked(object sender, EventArgs e)
        {
            bool povedloSe = bankomat.Vyber(Convert.ToInt32(eCastka.Text));
            if (!povedloSe)
                DisplayAlert("Výběr", "V bankomatu není dost peněz", "OK");
        }
    }
}

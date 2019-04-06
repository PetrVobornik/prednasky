using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UkladaniDat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            string fileName = Preferences.Get("pozadi", "");
            if (File.Exists(fileName))
                iPozadi.Source = ImageSource.FromFile(fileName);
        }

        private void BNastaveni_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NastaveniPage());
        }

        private void BSoubory_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SouboryPage());
        }

        private void BPozadi_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PozadiPage());
        }

        private void BKnihy_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KnihyPage());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigace
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void BAhoj_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Ahoj", "To je ale pěkná appka, že jo?", "Ano", "Ne"))
                BackgroundColor = Color.LightPink;
            else
                BackgroundColor = Color.Silver;
        }

        private void BZalozky_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Zalozky());
        }

        private void BMD_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MDPage());
        }

        private void BCarousel_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CarPage());
        }

        private async void BDruha_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DruhaStranka());
        }

        bool isJmeno = false;
        InputDialog dlg;
        private async void Binput_Clicked(object sender, EventArgs e)
        {
            dlg = new InputDialog();
            dlg.Jmeno = "Tvé Jméno";
            isJmeno = true;
            await Navigation.PushModalAsync(new NavigationPage(dlg));
        }

        protected override void OnAppearing()
        {
            if (isJmeno)
            {
                Title = "Vítej " + dlg.Jmeno;
                isJmeno = false;
            }
            base.OnAppearing();
        }
    }
}

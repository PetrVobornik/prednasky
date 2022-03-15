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

        private void BCarousel_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CarPage());
        }

        private async void bFlyout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FlyPage());
        }

        bool isJmeno = false;
        InputDialog dlg;
        private async void BInputPage_Clicked(object sender, EventArgs e)
        {
            dlg = new InputDialog();
            dlg.Jmeno = "Tvé Jméno";
            isJmeno = true;
            await Navigation.PushModalAsync(new NavigationPage(dlg));
            Title = "Vítej " + dlg.Jmeno;
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

        private async void bInputDlg_Clicked(object sender, EventArgs e)
        {
            string jmeno = await DisplayPromptAsync("Tvé Jméno", "Zadej své jméno");
            if (!String.IsNullOrEmpty(jmeno)) // Pokud se dialog uzavře jinak než přes OK, metoda vrátí prázdný string
                Title = "Vítej " + jmeno;
        }

        private async void BDruha_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DruhaStranka());
        }
    }
}

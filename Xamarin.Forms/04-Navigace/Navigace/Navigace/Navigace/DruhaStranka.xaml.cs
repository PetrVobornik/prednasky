using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigace
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DruhaStranka : ContentPage
	{
		public DruhaStranka ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            await DisplayAlert("Vstup", "Vítejte na stránce", "OK");
            base.OnAppearing();
        }

        protected async override void OnDisappearing()
        {
            //await DisplayAlert("Výstup", "Vy už odcházíte?", "Ano");
            base.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            DisplayAlert("Zpět", "Tudy to nepůjde!", "OK");
            return true;
            //return base.OnBackButtonPressed();
        }
    }
}
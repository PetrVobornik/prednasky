using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UkladaniDat
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KnihaPage : ContentPage
	{
		public KnihaPage ()
		{
			InitializeComponent ();
		}

        public int IdKnihy { get; set; } = 0;

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (IdKnihy == 0)
                BindingContext = new Kniha();
            else
            {
                BindingContext = await App.DbKnihy.GetAsync<Kniha>(IdKnihy);
                bSmazat.IsVisible = true;
            }
        }

        private async void BUlozit_Clicked(object sender, EventArgs e)
        {
            if (IdKnihy == 0)
                await App.DbKnihy.InsertAsync(BindingContext as Kniha);
            else
            {
                await App.DbKnihy.UpdateAsync(BindingContext as Kniha);
                //var k = BindingContext as Kniha;
                //await App.DbKnihy.ExecuteAsync("update Knihy set Nazev = ? where Id = ?", k.Nazev, IdKnihy);
            }

            await Navigation.PopAsync();
        }

        private async void BZrusit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BSmazat_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Smazat", "Opravdu si přejete smazat tuto knihu?", "Ano", "Ne"))
            {
                await App.DbKnihy.DeleteAsync<Kniha>(IdKnihy);
                await Navigation.PopAsync();
            }
        }
    }
}
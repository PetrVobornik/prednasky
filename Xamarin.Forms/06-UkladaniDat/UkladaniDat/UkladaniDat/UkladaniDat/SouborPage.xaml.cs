using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UkladaniDat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SouborPage : ContentPage
    {
        public string Soubor { get; private set; }

        public SouborPage(string soubor = "")
        {
            InitializeComponent();

            Soubor = soubor;
            slozka = Path.Combine(FileSystem.AppDataDirectory, "soubory");

            if (!String.IsNullOrEmpty(Soubor))
            {
                eNazev.Text = Soubor;
                eNazev.IsReadOnly = true;
                eObsah.Text = File.ReadAllText(Path.Combine(slozka, Soubor + ".txt"));
                bSmazat.IsVisible = true;
            }
        }

        string slozka;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Kód přesunut do konstruktoru, zde by hrozila ztráta práce při přepnutí aplikace
        }

        private void BUlozit_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(eNazev.Text))
            {
                if (!Directory.Exists(slozka))
                    Directory.CreateDirectory(slozka);
                File.WriteAllText(Path.Combine(slozka, eNazev.Text + ".txt"), eObsah.Text);
                Navigation.PopAsync();
            }
        }

        private void BZrusit_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void BSmazat_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Smazat", "Opravdu si přejete tento soubor smazat?", "Ano", "Ne"))
            {
                File.Delete(Path.Combine(slozka, eNazev.Text + ".txt"));
                await Navigation.PopAsync();
            }
        }
    }
}
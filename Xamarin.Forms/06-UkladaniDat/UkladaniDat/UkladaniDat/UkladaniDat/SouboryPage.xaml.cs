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
    public partial class SouboryPage : ContentPage
    {
        public SouboryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            string slozka = Path.Combine(FileSystem.AppDataDirectory, "soubory");
            if (Directory.Exists(slozka))
                lSeznam.ItemsSource = Directory.GetFiles(slozka).Select(s => Path.GetFileNameWithoutExtension(s));
        }

        private void LSeznam_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new SouborPage(e.Item as string));
        }

        private void BNovy_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SouborPage());
        }
    }
}
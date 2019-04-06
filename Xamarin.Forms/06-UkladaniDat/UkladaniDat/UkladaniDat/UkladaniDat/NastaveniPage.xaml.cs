using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UkladaniDat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NastaveniPage : ContentPage
    {
        public NastaveniPage()
        {
            InitializeComponent();

            BindingContext = Nastaveni.Aktualni;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            eHeslo.Text = await SecureStorage.GetAsync("heslo");

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SecureStorage.SetAsync("heslo", eHeslo.Text);
        }
    }
}
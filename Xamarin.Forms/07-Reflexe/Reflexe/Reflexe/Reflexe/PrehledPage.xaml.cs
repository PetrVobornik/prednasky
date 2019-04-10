using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reflexe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrehledPage : ContentPage
    {
        public Type Trida { get; set; }

        public PrehledPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Title = DbUtils.Popisek(Trida);

            lPrehled.ItemsSource = await DbUtils.DataTabulky(Trida);
        }

        private void LPrehled_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new DetailPage(e.Item as IData));
        }

        private void BNovy_Clicked(object sender, EventArgs e)
        {
            var obj = Activator.CreateInstance(Trida) as IData;
            Navigation.PushAsync(new DetailPage(obj));
        }
    }
}
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
    public partial class KnihyPage : ContentPage
    {
        public KnihyPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lSeznam.ItemsSource = await App.DbKnihy.Table<Kniha>().OrderBy(x => x.Nazev).ToListAsync();
            //lSeznam.ItemsSource = await App.DbKnihy.QueryAsync<Kniha>("select * from Knihy order by Nazev");
        }

        private void LSeznam_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new KnihaPage() { IdKnihy = (e.Item as Kniha)?.Id ?? 0 });
        }

        private void BNovy_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KnihaPage());
        }
    }
}
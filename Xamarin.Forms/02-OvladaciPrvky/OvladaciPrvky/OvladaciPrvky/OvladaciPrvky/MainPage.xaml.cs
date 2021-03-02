using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OvladaciPrvky
{
    public partial class MainPage : ContentPage
    {
        static Random random = new Random();
        Color RandomColor => Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));

        public MainPage()
        {
            InitializeComponent();

            sLineBreak.Text = Environment.NewLine; // Label

            pSvetadil.SelectedIndex = 0; // Picker

            // ListView
            lSeznam.ItemsSource = "Leden,Únor,Březen,Duben,Květen,Červen,Červenec,Srpen,Září,Říjen,Listopad,Prosinec"
                .Split(',').Select(x => new { Name = x, Color = RandomColor });

            //cCarousel.ItemsSource = lSeznam.ItemsSource; // CarouselView (na Androidu to je v XF5 třeba nastavit až v pozdější fázi => přesunuto do OnAppearing)

            cCollect.ItemsSource = lSeznam.ItemsSource; // CollectionView
        }

        protected override void OnAppearing() // Spustí se při vstupu na tuto stránku
        {
            base.OnAppearing();
            cCarousel.ItemsSource = lSeznam.ItemsSource; // CarouselView
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void siUlozit_Invoked(object sender, EventArgs e)
        {

        }

        // RefreshView
        private async void rRefresher_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            xRefreshBox.BackgroundColor = RandomColor;
            rRefresher.IsRefreshing = false;
        }

        
        private void WWeb_Navigated(object sender, WebNavigatedEventArgs e)
        {
            eUrl.Text = e.Url; // WebView
        }

        private void EUrl_Completed(object sender, EventArgs e)
        {
            wWeb.Source = eUrl.Text; // WebView
        }

        private void cCarousel_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            int i = e.CurrentPosition;
        }
    }
}

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
        public MainPage()
        {
            InitializeComponent();

            sLineBreak.Text = Environment.NewLine;
            pSvetadil.SelectedIndex = 0;

            lSeznam.ItemsSource = "Leden,Únor,Březen,Duben,Květen,Červen,Červenec,Srpen,Září,Říjen,Listopad,Prosinec"
                .Split(',').Select(x => new { Name = x });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void WWeb_Navigated(object sender, WebNavigatedEventArgs e)
        {
            eUrl.Text = e.Url;
        }

        private void EUrl_Completed(object sender, EventArgs e)
        {
            wWeb.Source = eUrl.Text;
        }
    }
}

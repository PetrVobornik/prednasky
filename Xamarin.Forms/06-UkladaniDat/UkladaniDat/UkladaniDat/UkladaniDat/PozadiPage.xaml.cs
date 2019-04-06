using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UkladaniDat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PozadiPage : ContentPage
    {
        public PozadiPage()
        {
            InitializeComponent();
        }

        string url;
        private void WWeb_Navigated(object sender, WebNavigatedEventArgs e)
        {
            url = e.Url;
            bOk.IsVisible = url.EndsWith(".jpg") && !url.Contains('?');
        }

        private async void BOk_Clicked(object sender, EventArgs e)
        {
            string fileName = Path.Combine(FileSystem.AppDataDirectory, Guid.NewGuid().ToString() + ".jpg");
            var wc = new WebClient();
            await wc.DownloadFileTaskAsync(url, fileName);
            Preferences.Set("pozadi", fileName);
            await Navigation.PopAsync();
        }
    }
}
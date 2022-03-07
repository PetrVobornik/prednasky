using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PolohovaciPrvky
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadImages();
        }

        [DataContract]
        class Images
        {
            [DataMember(Name = "photos")]
            public List<string> Photos;
        }

        async void LoadImages()
        {
            using (var wc = new WebClient())
            {
                var data = await wc.DownloadDataTaskAsync("https://raw.githubusercontent.com/xamarin/docs-archive/master/Images/stock/small/stock.json");

                using (var stream = new MemoryStream(data))
                {
                    var jSer = new DataContractJsonSerializer(typeof(Images));
                    var images = (Images)jSer.ReadObject(stream);

                    foreach (string fileUrl in images.Photos.Take(12))
                        flFlex.Children.Add(new Image() {
                            Source = ImageSource.FromUri(new Uri(fileUrl)),
                            Margin = new Thickness(5)
                        });
                }
            }
        }
    }

    public class DvojityRamecek : ContentView
    {
        public Color Ram1 { get; set; } = Color.Blue;
        public Color Ram2 { get; set; } = Color.Green;
    }
}

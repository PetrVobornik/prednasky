using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Reflexe
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            DbUtils.VsechnyDbTridy.ForEach(t => {
                sMain.Children.Add(new Button()
                {
                    Text = DbUtils.Popisek(t),
                    Command = new Command(a => Navigation.PushAsync(new PrehledPage() { Trida = t }))
                });
            });
        }
    }
}

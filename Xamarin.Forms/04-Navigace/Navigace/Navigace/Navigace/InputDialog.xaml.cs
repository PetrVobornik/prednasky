using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigace
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InputDialog : ContentPage
	{
		public InputDialog ()
		{
			InitializeComponent ();
		}

        public string Jmeno
        {
            get => eJmeno.Text;
            set => eJmeno.Text = value;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
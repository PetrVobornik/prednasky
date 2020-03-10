using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OopKalkulator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Operace> historie = new ObservableCollection<Operace>();

        public MainPage()
        {
            InitializeComponent();
            lvSeznam.ItemsSource = historie;
            pZnamenko.SelectedIndex = 0;
        }

        private void bVypocet_Clicked(object sender, EventArgs e)
        {
            Operace op = null;
            switch (pZnamenko.SelectedItem as string)
            {
                case "+": op = new Soucet(); break;
                case "-": op = new Rozdil(); break;
                case "*": op = new Soucin(); break;
                case "/": op = new Podil(); break;
            }

            if (op != null)
            {
                op.A = Convert.ToDouble(eA.Text);
                op.B = Convert.ToDouble(eB.Text);
                lVyledek.Text = op.Vypocti().ToString("N2");
                historie.Add(op);
            }
            else
                lVyledek.Text = "?";
        }

        private void lvSeznam_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var op = lvSeznam.SelectedItem as Operace;
            if (op == null) return;
            eA.Text = op.A.ToString();
            eB.Text = op.B.ToString();
            pZnamenko.SelectedItem = op.Znamenko.ToString();
            lVyledek.Text = op.Vypocti().ToString("N2");
        }
    }
}

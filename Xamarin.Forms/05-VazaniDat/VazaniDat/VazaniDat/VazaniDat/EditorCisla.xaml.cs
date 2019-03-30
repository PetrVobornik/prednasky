using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VazaniDat
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditorCisla : ContentView
	{
        public static readonly BindableProperty CisloProperty = BindableProperty.Create(nameof(Cislo),
            typeof(int), typeof(EditorCisla), 0, BindingMode.TwoWay, propertyChanged: CisloChanged);

        private static void CisloChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((int)oldValue != (int)newValue)
            {
                var editor = bindable as EditorCisla;
                editor.eCislo.Text = ((int)newValue).ToString();
                editor.sCislo.Value = (int)newValue;
            }
        }


        public int Cislo
        {
            get { return (int)GetValue(CisloProperty); }
            set { if (Cislo != value) SetValue(CisloProperty, value); }
        }


        public EditorCisla()
		{
			InitializeComponent();
		}

        private void ECislo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(e.NewTextValue, out int cislo))
                Cislo = cislo;
        }

        private void SCislo_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Cislo = (int)e.NewValue;
        }
    }
}
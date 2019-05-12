using Amporis.Xamarin.Forms.ColorPicker;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Kresleni
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density < 500)
                lSeznam.WidthRequest = 80;

            StavIkon(false);
            lSeznam.ItemsSource = obrazce;
            AktualniSoubor = "";
        }

        bool editujiRozmer = false;

        Obrazec aktualniObrazec;
        Obrazec AktualniObrazec
        {
            get => aktualniObrazec;
            set
            {
                aktualniObrazec = value;
                StavIkon(aktualniObrazec != null);
                editujiRozmer = false;
            }
        }

        readonly ObservableCollection<Obrazec> obrazce = new ObservableCollection<Obrazec>();

        private void StavIkon(bool? editace)
        {
            bPridat.IsEnabled = editace == false;
            bTloustkaCary.IsEnabled = editace == true;
            bBarvaCary.IsEnabled = editace == true;
            bBarvaVyplne.IsEnabled = editace == true;
            bConfirm.IsEnabled = editace == true;
            bNovaKresba.IsEnabled = editace == false;
            bUlozit.IsEnabled = editace == false;
            bOtevrit.IsEnabled = editace == false;
            bKopie.IsEnabled = editace == false;
        }


        private Dictionary<string, Type> obrTypy;
        public Dictionary<string, Type> ObrTypy
        {
            get {
                if (obrTypy == null)
                    obrTypy = GetType().Assembly.GetTypes()
                        .Where(t => t.IsSubclassOf(typeof(Obrazec)))
                        .OrderBy(t => t.Name)
                        .ToDictionary(k => k.Name, v => v);
                return obrTypy;
            }
        }


        private async void BPridat_Clicked(object sender, EventArgs e)
        {
            var typNazev = await DisplayActionSheet("Přidat obrazec", "Zrušit", null, ObrTypy.Keys.ToArray());

            if (ObrTypy.ContainsKey(typNazev??""))
            {
                AktualniObrazec = Activator.CreateInstance(ObrTypy[typNazev]) as Obrazec;
                cPlocha.InvalidateSurface();
            }
        }

        private void CPlocha_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            e.Surface.Canvas.Clear();

            foreach (var obr in obrazce)
                obr.Kresli(e.Surface.Canvas);

            AktualniObrazec?.Kresli(e.Surface.Canvas);
        }

        private void CPlocha_Touch(object sender, SkiaSharp.Views.Forms.SKTouchEventArgs e)
        {
            if (AktualniObrazec == null) return;

            if (e.ActionType == SKTouchAction.Pressed)
                if (!editujiRozmer)
                {
                    AktualniObrazec.Left = e.Location.X;
                    AktualniObrazec.Top = e.Location.Y;
                    editujiRozmer = true;
                } else
                {
                    AktualniObrazec.Width = e.Location.X - AktualniObrazec.Left;
                    AktualniObrazec.Height = e.Location.Y - AktualniObrazec.Top;
                    editujiRozmer = false;
                }
            cPlocha.InvalidateSurface();
        }

        private void BConfirm_Clicked(object sender, EventArgs e)
        {
            if (AktualniObrazec != null && !obrazce.Contains(AktualniObrazec))
                obrazce.Add(AktualniObrazec);
            AktualniObrazec = null;
            lSeznam.SelectedItem = null;
            cPlocha.InvalidateSurface();
        }

        private async void LSeznam_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (AktualniObrazec != null || e.Item == null) return;
            var obr = (Obrazec)e.Item;
            string typ = await DisplayActionSheet(obr.ToString(), "Zrušit", "Vymazat", "Upravit");
            if (typ == "Upravit")
                AktualniObrazec = obr;
            else if (typ == "Vymazat")
                obrazce.Remove(obr);
            cPlocha.InvalidateSurface();
        }

        private async void BTloustkaCary_Clicked(object sender, EventArgs e)
        {
            if (AktualniObrazec == null) return;
            string tloustka = await DisplayActionSheet("Tloušťka čáry", "Zrušit", null,
                "0,1,2,3,5,7,10,15,20,30,50".Split(','));
            if (int.TryParse(tloustka, out int t))
                AktualniObrazec.TloustkaCary = t;
            cPlocha.InvalidateSurface();
        }

        private async void BBarvaCary_Clicked(object sender, EventArgs e)
        {
            if (AktualniObrazec == null) return;
            StavIkon(null);
            AktualniObrazec.BarvaCary = (await ColorPickerDialog.Show(gMain, "Barva čáry",
                AktualniObrazec.BarvaCary.ToFormsColor())).ToSKColor();
            StavIkon(true);
            cPlocha.InvalidateSurface();
        }

        private async void BBarvaVyplne_Clicked(object sender, EventArgs e)
        {
            if (AktualniObrazec == null) return;
            StavIkon(null);
            AktualniObrazec.BarvaVyplne = (await ColorPickerDialog.Show(gMain, "Barva výplně",
                AktualniObrazec.BarvaVyplne.ToFormsColor())).ToSKColor();
            StavIkon(true);
            cPlocha.InvalidateSurface();
        }

        private string slozka;
        public string Slozka
        {
            get {
                if (String.IsNullOrEmpty(slozka))
                {
                    slozka = Path.Combine(FileSystem.AppDataDirectory, "Vykresy");
                    if (!Directory.Exists(slozka))
                        Directory.CreateDirectory(slozka);
                }
                return slozka;
            }
        }


        private string aktualniSoubor;
        public string AktualniSoubor
        {
            get { return aktualniSoubor; }
            set {
                aktualniSoubor = value;
                Title = String.IsNullOrEmpty(aktualniSoubor) ? "Nový výkres" : aktualniSoubor;
            }
        }



        private async void BNovaKresba_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Nový výkres", "Skutečně si přejete zavřít tento výkres a začít nový?", "Ano", "Ne"))
            {
                obrazce.Clear();
                AktualniObrazec = null;
                AktualniSoubor = "";
                cPlocha.InvalidateSurface();
            }
        }

        private async void BUlozit_Clicked(object sender, EventArgs e)
        {
            string soubor = AktualniSoubor;
            if (String.IsNullOrEmpty(soubor))
            {
                StavIkon(null);
                soubor = await InputDialog.Show(gMain, "Uložit", "Název nového souboru", "Nový výkres");
                StavIkon(false);
            }
            if (String.IsNullOrEmpty(soubor)) return;

            string path = Path.Combine(Slozka, soubor + ".xml");
            var doc = new XDocument(new XElement("Vykres"));
            obrazce.ForEach(o => doc.Root.Add(o.ToXml()));
            doc.Save(path);
            AktualniSoubor = soubor;
        }

        private async void BOtevrit_Clicked(object sender, EventArgs e)
        {
            var soubory = Directory.GetFiles(Slozka).Select(s => Path.GetFileNameWithoutExtension(s)).OrderBy(s => s).ToArray();
            string soubor = await DisplayActionSheet("Otevřít výkres", "Zrušit", null, soubory);
            if (soubory.Contains(soubor))
            {
                obrazce.Clear();
                AktualniObrazec = null;

                var doc = XDocument.Load(Path.Combine(Slozka, soubor + ".xml"));
                foreach (var elm in doc.Root.Elements())
                {
                    if (!ObrTypy.ContainsKey(elm.Name.LocalName)) continue;
                    var obr = Activator.CreateInstance(ObrTypy[elm.Name.LocalName]) as Obrazec;
                    obr.FromXml(elm);
                    obrazce.Add(obr);
                }

                AktualniSoubor = soubor;
                cPlocha.InvalidateSurface();
            }
        }

        private void BKopie_Clicked(object sender, EventArgs e)
        {
            AktualniSoubor = "";
        }

    }
}

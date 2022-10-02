using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Kresleni22Maui;

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
            if (aktualniObrazec != null)
                aktualniObrazec.Animace(false);
            aktualniObrazec = value;
            StavIkon(aktualniObrazec != null);
            if (aktualniObrazec != null)
                aktualniObrazec.Animace(true);
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
        bNovyVykres.IsEnabled = editace == false;
        bUlozitVykres.IsEnabled = editace == false;
        bNacistVykres.IsEnabled = editace == false;
        bKopieVykresu.IsEnabled = editace == false;
    }


    private Dictionary<string, Type> obrTypy;
    public Dictionary<string, Type> ObrTypy
    {
        get
        {
            if (obrTypy == null)
                obrTypy = GetType().Assembly.GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(Obrazec)))
                    .OrderBy(t => t.Name)
                    .ToDictionary(k => k.Name, v => v);
            return obrTypy;
        }
    }


    private async void bPridat_Clicked(object sender, EventArgs e)
    {
        //var typNazev = await DisplayActionSheet("Přidat obrazec", "Zrušit", null, ObrTypy.Keys.ToArray());
        var typNazev = await DisplayPromptAsync("Přidat obrazec", "Název obrazce", initialValue: "Obdelnik");

        if (ObrTypy.ContainsKey(typNazev ?? ""))
            AktualniObrazec = VytvorObrazec(typNazev);
    }

    private Obrazec VytvorObrazec(string typNazev)
    {
        var obrazec = Activator.CreateInstance(ObrTypy[typNazev]) as Obrazec;
        alPlocha.Children.Add(obrazec.Prvek);
        // Dotyky
        var pan = new PanGestureRecognizer();
        pan.Parent = alPlocha;
        pan.PanUpdated += Pan_PanUpdated;
        obrazec.Prvek.GestureRecognizers.Add(pan);
        // Dvojklik
        var dvojklik = new TapGestureRecognizer();
        dvojklik.NumberOfTapsRequired = 2;
        dvojklik.Tapped += Dvojklik_Tapped;
        obrazec.Prvek.GestureRecognizers.Add(dvojklik);
        return obrazec;
    }

    double? startX = null, startY = null;
    private void Pan_PanUpdated(object sender, PanUpdatedEventArgs e)
    {
        if (AktualniObrazec == null) return;
        
        if (e.StatusType == GestureStatus.Started && sender == AktualniObrazec.Prvek)
        {
            startX = editujiRozmer ? AktualniObrazec.Sirka : AktualniObrazec.Zleva;
            startY = editujiRozmer ? AktualniObrazec.Vyska : AktualniObrazec.Shora;
        }
        else if (e.StatusType == GestureStatus.Running && sender == alPlocha)
        {
            if (editujiRozmer)
            {
                if (startX.HasValue)
                    AktualniObrazec.Sirka = startX.Value + e.TotalX;
                if (startY.HasValue)
                    AktualniObrazec.Vyska = startY.Value + e.TotalY;
            }
            else
            {
                if (startX.HasValue)
                    AktualniObrazec.Zleva = e.TotalX + (double)startX;
                if (startY.HasValue)
                    AktualniObrazec.Shora = e.TotalY + (double)startY;
            }
        }
        else if (e.StatusType == GestureStatus.Completed || e.StatusType == GestureStatus.Canceled)
            (startX, startY) = (null, null);
    }

    private void Dvojklik_Tapped(object sender, EventArgs e)
    {
        if (AktualniObrazec == null) return;
        editujiRozmer = !editujiRozmer;
        AktualniObrazec?.Animace(true, editujiRozmer);
    }


    private async void bTloustkaCary_Clicked(object sender, EventArgs e)
    {
        if (AktualniObrazec == null) return;
        //string tloustka = await DisplayActionSheet("Tloušťka čáry", "Zrušit", null,
        //    "0,1,2,3,5,7,10,15,20,30,50".Split(','));
        var tloustka = await DisplayPromptAsync("Tloušťka čáry", "Pixelů", initialValue: AktualniObrazec.TloustkaCary.ToString());
        if (int.TryParse(tloustka, out int t))
            AktualniObrazec.TloustkaCary = t;
    }

    //ColorDialogSettings cds;
    //ColorDialogSettings GetCDS()
    //    => cds ?? (cds = new ColorDialogSettings()
    //    {
    //        DialogColor = Xamarin.Forms.Color.FromUint((AppInfo.RequestedTheme == AppTheme.Dark ? Color.FromArgb("#FF111111") : Color.FromArgb("#FFEEEEEE")).ToUint()),
    //        TextColor = Xamarin.Forms.Color.FromUint((AppInfo.RequestedTheme == AppTheme.Dark ? Colors.White : Colors.Black).ToUint()),
    //        EditorsColor = Xamarin.Forms.Color.FromUint((AppInfo.RequestedTheme == AppTheme.Dark ? Color.FromArgb("#FF404040") : Colors.White).ToUint()),
    //    });

    private async void bBarvaCary_Clicked(object sender, EventArgs e)
    {
        if (AktualniObrazec == null) return;
        StavIkon(null);
        //AktualniObrazec.BarvaCary = await ColorPickerDialog.Show(gMain, "Barva čáry",
        //    Xamarin.Forms.Color.FromUint(AktualniObrazec.BarvaCary.ToUint()), GetCDS());
        string barva = await DisplayPromptAsync("Barva čáry", "", initialValue: AktualniObrazec.BarvaCary.ToHex());
        try { AktualniObrazec.BarvaCary = Color.FromArgb(barva); } catch { }
        StavIkon(true);
    }

    private async void bBarvaVyplne_Clicked(object sender, EventArgs e)
    {
        if (AktualniObrazec == null) return;
        StavIkon(null);
        //AktualniObrazec.BarvaVyplne = await ColorPickerDialog.Show(gMain, "Barva výplně",
        //    Xamarin.Forms.Color.FromUint(AktualniObrazec.BarvaVyplne.ToUint()), GetCDS());
        string barva = await DisplayPromptAsync("Barva výplně", "", initialValue: AktualniObrazec.BarvaVyplne.ToHex());
        try { AktualniObrazec.BarvaVyplne = Color.FromArgb(barva); } catch { }
        StavIkon(true);
    }

    private void bConfirm_Clicked(object sender, EventArgs e)
    {
        if (AktualniObrazec != null && !obrazce.Contains(AktualniObrazec))
            obrazce.Add(AktualniObrazec);
        AktualniObrazec.Animace(false);
        AktualniObrazec = null;
        lSeznam.SelectedItem = null;
    }

    private async void lSeznam_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (AktualniObrazec != null || e.Item == null) return;
        var obr = (Obrazec)e.Item;
        string typ = await DisplayActionSheet(obr.ToString(), "Zrušit", "Vymazat", "Upravit");
        if (typ == "Upravit")
        {
            AktualniObrazec = obr;
            AktualniObrazec.Animace(true);
        }
        else if (typ == "Vymazat")
        {
            obrazce.Remove(obr);
            alPlocha.Children.Remove(obr.Prvek);
        }
    }


    private string slozka;
    public string Slozka
    {
        get
        {
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
        set
        {
            aktualniSoubor = value;
            Title = String.IsNullOrEmpty(aktualniSoubor) ? "Nový výkres" : aktualniSoubor;
        }
    }

    private async void bNovyVykres_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Nový výkres", "Skutečně si přejete zavřít tento výkres a začít nový?", "Ano", "Ne"))
        {
            obrazce.Clear();
            alPlocha.Children.Clear();
            AktualniObrazec = null;
            AktualniSoubor = "";
        }
    }

    private async void bUlozitVykres_Clicked(object sender, EventArgs e)
    {
        string soubor = AktualniSoubor;
        if (String.IsNullOrEmpty(soubor))
            soubor = await DisplayPromptAsync("Uložit", "Název nového souboru", initialValue: "Nový výkres");
        if (String.IsNullOrEmpty(soubor)) return;

        string path = Path.Combine(Slozka, soubor + ".xml");
        var doc = new XDocument(new XElement("Vykres"));
        //obrazce.ForEach(o => doc.Root.Add(o.UlozDoXml()));
        foreach (var o in obrazce)
            doc.Root.Add(o.UlozDoXml());
        doc.Save(path);
        AktualniSoubor = soubor;
    }

    private async void bNacistVykres_Clicked(object sender, EventArgs e)
    {
        var soubory = Directory.GetFiles(Slozka).Select(s => Path.GetFileNameWithoutExtension(s)).OrderBy(s => s).ToArray();
        string soubor = await DisplayActionSheet("Načíst výkres", "Zrušit", null, soubory);
        if (soubory.Contains(soubor))
        {
            obrazce.Clear();
            alPlocha.Children.Clear();
            AktualniObrazec = null;

            var doc = XDocument.Load(Path.Combine(Slozka, soubor + ".xml"));
            foreach (var elm in doc.Root.Elements())
            {
                if (!ObrTypy.ContainsKey(elm.Name.LocalName)) continue;
                var obr = VytvorObrazec(elm.Name.LocalName);
                obr.NactiZXml(elm);
                obrazce.Add(obr);
            }

            AktualniSoubor = soubor;
        }
    }

    private void bKopieVykresu_Clicked(object sender, EventArgs e)
    {
        AktualniSoubor = "";
    }
}


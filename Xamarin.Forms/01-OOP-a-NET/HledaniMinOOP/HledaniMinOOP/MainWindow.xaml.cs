using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HledaniMinOOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random Rnd = new Random();
        //Pole[,] mapa;

        Pole PoleNa(int y, int x) => gPlocha.Children.OfType<Pole>()
            .FirstOrDefault(p => p.PoziceY == y && p.PoziceX == x);

        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        void Start(int radku = 15, int sloupcu = 15, int pocetMin = 10)
        {
            // Vyčistit pole
            gPlocha.Children.Clear();
            gPlocha.RowDefinitions.Clear();
            gPlocha.ColumnDefinitions.Clear();

            // Příprava mřížky
            for (int i = 0; i < radku; i++)
                gPlocha.RowDefinitions.Add(new RowDefinition());
            for (int j = 0; j < sloupcu; j++)
                gPlocha.ColumnDefinitions.Add(new ColumnDefinition());

            // Rozmístit miny
            Pole p;
            for (int k = 0; k < pocetMin; k++)
            {
                (int y, int x) = (Rnd.Next(radku), Rnd.Next(sloupcu));
                while ((p = PoleNa(y, x)) is PoleMina)
                    (y, x) = (Rnd.Next(radku), Rnd.Next(sloupcu));
                if (p != null)
                    gPlocha.Children.Remove(p); // Už tam bylo PoleCislo, tak jej odebrat, než se nahradí minou
                gPlocha.Children.Add(new PoleMina(y, x));
                // Čísla okolo miny
                for (int i = y - 1; i <= y + 1; i++)
                    for (int j = x - 1; j <= x + 1; j++)
                        if (i >= 0 && i < radku && j >= 0 && j < sloupcu)
                            if ((p = PoleNa(i, j)) == null)
                                gPlocha.Children.Add(new PoleCislo(i, j));
                            else if (p is PoleCislo)
                                ((PoleCislo)p).Cislo++;
            }

            // Doplnění prázdných polí
            for (int i = 0; i < radku; i++)
                for (int j = 0; j < sloupcu; j++)
                {
                    if ((p = PoleNa(i, j)) == null)
                        gPlocha.Children.Add(p = new PolePrazdne(i, j));
                    p.Odkryti += Pole_Odkryti;
                }
        }

        private void Pole_Odkryti(object sender, EventArgs e)
        {
            var pole = sender as Pole;

            if (pole is PolePrazdne)
            {
                for (int i = pole.PoziceY - 1; i <= pole.PoziceY + 1; i++)
                    for (int j = pole.PoziceX - 1; j <= pole.PoziceX + 1; j++)
                        PoleNa(i, j)?.Odkryj();
            }
            else if (pole is PoleMina)
            {
                ((PoleMina)pole).Vybuch();
                OdkryjVse();
                MessageBox.Show("Prohrál jsi!", "Konec hry");
                Start();
                return;
            }

            if (TestVyhry())
            {
                MessageBox.Show("Vyhrál jsi!", "Vítězství");
                Start();
            }
        }

        void OdkryjVse()
        {
            foreach (Pole p in gPlocha.Children)
                if (p is PoleMina)
                {
                    p.Odkryti -= Pole_Odkryti;
                    p.Odkryj();
                }
                else if (!p.Odkryto)
                    p.ZobazChybneOznaceni();
        }

        bool TestVyhry()
        {
            foreach (Pole p in gPlocha.Children)
                if (!p.Odkryto && !(p is PoleMina))
                    return false;
            return true;
        }
    }
}

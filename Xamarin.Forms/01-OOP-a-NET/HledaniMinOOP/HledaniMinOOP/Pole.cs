using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HledaniMinOOP
{
    public abstract class Pole : Grid
    {
        public readonly int PoziceY;
        public readonly int PoziceX;
        Button tlacitko;
        static ImageSource otaznik = new BitmapImage(new Uri("/HledaniMinOOP;component/img/otaznik.png", UriKind.Relative));
        static ImageSource vlajka = new BitmapImage(new Uri("/HledaniMinOOP;component/img/vlajka.png", UriKind.Relative));
        static ImageSource vlajkaZelena = new BitmapImage(new Uri("/HledaniMinOOP;component/img/vlajka_zelena.png", UriKind.Relative));

        public Pole(int poziceY, int poziceX)
        {
            PoziceY = poziceY;
            PoziceX = poziceX;
            Init();
        }

        protected virtual void Init()
        {
            // Umístění v mřížce
            Grid.SetRow(this, PoziceY);
            Grid.SetColumn(this, PoziceX);
            // Rámeček pole
            Children.Add(new Frame()
            {
                BorderThickness = new Thickness(1),
                BorderBrush = new SolidColorBrush(Colors.Black),
            });
            // Tlačítko pro odkrytí
            tlacitko = new Button()
            {
                Content = new Image() { Source = otaznik, Margin = new Thickness(5) },
                Background = new SolidColorBrush(Colors.Gray),
                Cursor = Cursors.Hand,
            };
            tlacitko.Click += Tlacitko_Click;
            tlacitko.MouseRightButtonDown += Tlacitko_MouseRightButtonDown;
            Children.Add(tlacitko);
            Background = new SolidColorBrush(BarvaPozadi);
        }

        private void Tlacitko_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Oznaceno = !Oznaceno;
            ((Image)tlacitko.Content).Source = Oznaceno ? vlajka : otaznik;
            tlacitko.Background = new SolidColorBrush(Oznaceno ? Colors.Silver : Colors.Gray);
        }

        public bool Oznaceno { get; private set; } = false;

        protected abstract Color BarvaPozadi { get; }

        private void Tlacitko_Click(object sender, RoutedEventArgs e)
        {
            Odkryj();
        }

        public virtual void Odkryj()
        {
            if (Odkryto || Oznaceno) return;
            Odkryto = true;
            tlacitko.Visibility = Visibility.Collapsed;

            Odkryti?.Invoke(this, EventArgs.Empty);
        }

        public bool Odkryto { get; private set; } = false;

        public event EventHandler Odkryti;

        public void ZobazChybneOznaceni()
        {
            if (Oznaceno)
                ((Image)tlacitko.Content).Source = vlajkaZelena;
        }
    }
}

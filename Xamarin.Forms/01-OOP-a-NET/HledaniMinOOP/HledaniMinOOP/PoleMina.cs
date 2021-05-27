using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HledaniMinOOP
{
    public class PoleMina : Pole
    {
        public PoleMina(int poziceY, int poziceX) : base(poziceY, poziceX) { }

        protected override Color BarvaPozadi => Colors.LightSalmon;

        protected override void Init()
        {
            Children.Add(new Image() { 
                Margin = new Thickness(5),
                Source = new BitmapImage(new Uri("/HledaniMinOOP;component/img/mina.png", UriKind.Relative)),
            });

            base.Init();
        }

        public void Vybuch()
        {
            Background = new SolidColorBrush(Colors.Red);
        }     
    }
}

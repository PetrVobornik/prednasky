using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace HledaniMinOOP
{
    public class PoleCislo : Pole
    {
        public PoleCislo(int poziceY, int poziceX) : base(poziceY, poziceX) { }

        protected override Color BarvaPozadi => Colors.Azure;

        TextBlock textBlock;

        protected override void Init()
        {
            textBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 30,
                FontWeight = FontWeights.Bold,
            };
            Cislo = 1;
            Children.Add(textBlock);

            base.Init();
        }

        public byte Cislo
        {
            get
            {
                if (byte.TryParse(textBlock.Text, out byte x))
                    return x;
                return 0;
            }
            set
            {
                textBlock.Text = value.ToString();
                if (value >= 1 && value <= 8)
                    textBlock.Foreground = new SolidColorBrush(barvyCisel[value]);
            }
        }

        Dictionary<int, Color> barvyCisel = new Dictionary<int, Color>() {
            { 1, Colors.Blue },
            { 2, Colors.Green },
            { 3, Colors.Red },
            { 4, Colors.Navy },
            { 5, Colors.DarkRed },
            { 6, Colors.Cyan },
            { 7, Colors.Violet },
            { 8, Colors.Black },
        };
    }
}

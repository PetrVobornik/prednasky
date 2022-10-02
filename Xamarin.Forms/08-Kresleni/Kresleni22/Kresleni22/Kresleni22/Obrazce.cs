using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Shapes;
using Rec = Xamarin.Forms.Rectangle;

namespace Kresleni22
{
    public abstract class Obrazec
    {
        void ChangeRec(double? x=null, double? y = null, double? width = null, double? height = null)
        {
            var rec = AbsoluteLayout.GetLayoutBounds(Prvek);
            AbsoluteLayout.SetLayoutBounds(Prvek, 
                new Rec(x??rec.X, y??rec.Y, width??rec.Width, height??rec.Height));
        }

        public virtual double Zleva { 
            get => AbsoluteLayout.GetLayoutBounds(Prvek).X;
            set => ChangeRec(x: value); }

        public virtual double Shora {
            get => AbsoluteLayout.GetLayoutBounds(Prvek).Y;
            set => ChangeRec(y: value); }

        public virtual double Sirka {
            get => AbsoluteLayout.GetLayoutBounds(Prvek).Width;
            set => ChangeRec(width: value); }

        public virtual double Vyska {
            get => AbsoluteLayout.GetLayoutBounds(Prvek).Height;
            set => ChangeRec(height: value); }

        public virtual double TloustkaCary { 
            get => Prvek.StrokeThickness; 
            set => Prvek.StrokeThickness = value; }

        public virtual Color BarvaCary { 
            get => (Prvek.Stroke as SolidColorBrush).Color; 
            set => Prvek.Stroke = value; }

        public virtual Color BarvaVyplne { 
            get => (Prvek.Fill as SolidColorBrush).Color; 
            set => Prvek.Fill = value; }

        protected abstract Shape Kresli();

        public Shape Prvek { get; protected set; }

        public Obrazec()
        {
            Prvek = Kresli();
            AbsoluteLayout.SetLayoutFlags(Prvek, AbsoluteLayoutFlags.None);
            AbsoluteLayout.SetLayoutBounds(Prvek, new Rec());
            Zleva = 10;
            Shora = 10;
            Sirka = 120;
            Vyska = 90;
            BarvaCary = Color.Blue;
            BarvaVyplne = Color.Yellow;
            TloustkaCary = 3;
        }

        bool animaceProbiha = false;
        uint animaceRychlost = 1000;
        public async void Animace(bool animovat, bool rychle = false)
        {
            if (!animovat || (rychle && animaceRychlost != 1000) || rychle && animaceRychlost != 250)
                Prvek.CancelAnimations();
            animaceProbiha = animovat;
            animaceRychlost = rychle ? (uint)250 : 1000;

            Prvek.Opacity = 1;
            while (animaceProbiha)
            {
                if (await Prvek.FadeTo(0.5, animaceRychlost, Easing.SinInOut)) break;
                if (animaceProbiha)
                    if (await Prvek.FadeTo(1, animaceRychlost, Easing.SinInOut)) break;
            }
            Prvek.Opacity = 1;
        }

        public override string ToString() => $"{GetType().Name} [{Zleva:N0}, {Shora:N0}] {Sirka:N0}x{Vyska:N0}";

        public virtual XElement UlozDoXml()
        {
            var elm = new XElement(GetType().Name);
            GetType().GetProperties()
                .Where(p => p.CanRead && p.CanWrite && p.SetMethod.IsPublic)
                .ForEach(p => elm.SetAttributeValue(p.Name, 
                    p.PropertyType == typeof(Color) ? ((Color)p.GetValue(this)).ToHex() : p.GetValue(this)));
            return elm;
        }

        public virtual void NactiZXml(XElement elm)
        {
            GetType().GetProperties()
                .Where(p => p.CanRead && p.CanWrite && p.SetMethod.IsPublic && elm.Attribute(p.Name) != null)
                .ForEach(p => {
                    if (p.PropertyType == typeof(double)) p.SetValue(this, (double)elm.Attribute(p.Name));
                    else if (p.PropertyType == typeof(string)) p.SetValue(this, (string)elm.Attribute(p.Name));
                    else if (p.PropertyType == typeof(Color)) p.SetValue(this, Color.FromHex(elm.Attribute(p.Name).Value));
                });
        }
    }

    public class Obdelnik : Obrazec
    {
        protected override Shape Kresli()
            => new Xamarin.Forms.Shapes.Rectangle();
    }

    public class Elipsa : Obrazec
    {
        protected override Shape Kresli()
            => new Ellipse();
    }

    public class Usecka : Obrazec
    {
        protected override Shape Kresli()
            => new Line();

        public override double Sirka
        {
            get => base.Sirka;
            set { 
                base.Sirka = value;
                ((Line)Prvek).X2 = value;
            }
        }

        public override double Vyska
        {
            get => base.Vyska;
            set
            {
                base.Vyska = value;
                ((Line)Prvek).Y2 = value;
            }
        }
    }

    public class Trojuhelnik : Obrazec
    {
        Polyline obr;

        void PridejBody()
        {
            obr.Points.Clear();
            obr.Points.Add(new Point(Sirka/2.0, TloustkaCary));
            obr.Points.Add(new Point(Sirka- TloustkaCary, Vyska-TloustkaCary/2.0));
            obr.Points.Add(new Point(TloustkaCary, Vyska - TloustkaCary/2.0));
            obr.Points.Add(new Point(Sirka/2.0, TloustkaCary));
            //obr.StrokeLineCap = PenLineCap.Square;
        }

        protected override Shape Kresli()
            => (obr = new Polyline());

        public override double Sirka
        {
            get => base.Sirka;
            set
            {
                base.Sirka = value;
                PridejBody();
            }
        }

        public override double Vyska
        {
            get => base.Vyska;
            set
            {
                base.Vyska = value;
                PridejBody();
            }
        }
    }
}

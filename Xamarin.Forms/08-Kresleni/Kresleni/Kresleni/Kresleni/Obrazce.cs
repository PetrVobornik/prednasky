using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Xamarin.Forms.Internals;

namespace Kresleni
{
    public abstract class Obrazec
    {
        public float Left { get; set; }
        public float Top { get; set; }
        public float Width { get; set; } = 120;
        public float Height { get; set; } = 90;

        public float TloustkaCary { get; set; } = 2;
        public SKColor BarvaCary { get; set; } = SKColors.Black;
        public SKColor BarvaVyplne { get; set; } = SKColors.White;

        public SKPaint PanitCary => new SKPaint()
        {
            Style = SKPaintStyle.Stroke,
            Color = BarvaCary,
            StrokeWidth = TloustkaCary,
        };

        public SKPaint PanitVyplne => new SKPaint()
        {
            Style = SKPaintStyle.Fill,
            Color = BarvaVyplne,
            StrokeWidth = TloustkaCary,
        };

        public abstract void Kresli(SKCanvas canvas);

        public override string ToString() => $"{GetType().Name} [{Left:N0}, {Top:N0}] {Width:N0}x{Height:N0}";

        public virtual XElement ToXml()
        {
            var elm = new XElement(GetType().Name);
            GetType().GetProperties()
                .Where(p => p.CanRead && p.CanWrite && p.SetMethod.IsPublic)
                .ForEach(p => elm.SetAttributeValue(p.Name, p.GetValue(this)));
            return elm;
        }

        public virtual void FromXml(XElement elm)
        {
            GetType().GetProperties()
                .Where(p => p.CanRead && p.CanWrite && p.SetMethod.IsPublic && elm.Attribute(p.Name) != null)
                .ForEach(p => {
                    if (p.PropertyType == typeof(float)) p.SetValue(this, (float)elm.Attribute(p.Name));
                    else if (p.PropertyType == typeof(string)) p.SetValue(this, (string)elm.Attribute(p.Name));
                    else if (p.PropertyType == typeof(SKColor)) p.SetValue(this, SKColor.Parse(elm.Attribute(p.Name).Value));
                });
        }
    }

    public class Obdelnik : Obrazec
    {
        public override void Kresli(SKCanvas canvas)
        {
            canvas.DrawRect(Left, Top, Width, Height, PanitVyplne);
            if (TloustkaCary > 0)
                canvas.DrawRect(Left, Top, Width, Height, PanitCary);
        }
    }

    public class Elipsa : Obrazec
    {
        public override void Kresli(SKCanvas canvas)
        {
            canvas.DrawOval(SKRect.Create(Left, Top, Width, Height), PanitVyplne);
            if (TloustkaCary > 0)
                canvas.DrawOval(SKRect.Create(Left, Top, Width, Height), PanitCary);
        }
    }


    public class Cara : Obrazec
    {
        public override void Kresli(SKCanvas canvas)
        {
            canvas.DrawLine(Left, Top, Left+Width, Top+Height, PanitCary);
        }
    }
}

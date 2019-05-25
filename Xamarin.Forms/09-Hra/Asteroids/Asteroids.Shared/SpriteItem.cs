using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids.Shared
{
    public class SpriteItem : Sprite
    {
        public Vector2 Pozice { get; set; }
        public float UhelPohybu { get; set; } = 0;
        public float UhelOtoceni { get; set; } = 0;
        public float RychlostPohybu { get; set; } = 0;
        public float RychlostRotace { get; set; } = 0;
        public float Meritko { get; set; } = 0;
        public Vector2 Stred { get; set; }
        public int PocetObrazkuSirka { get; set; } = 1;
        public int PocetObrazkuVyska { get; set; } = 1;
        public int IndexObrazku { get; set; } = 0;
        public float RychlostAnimace { get; set; } = 0;
        public bool OpakovatAnimaci { get; set; } = false;

        public int SirkaObrzaku { get => Textura.Width / PocetObrazkuSirka; }
        public int VyskaObrzaku { get => Textura.Height / PocetObrazkuVyska; }
        public bool JeMimo { get; set; } = false;
        public Rectangle VyrezZTextury { get; set; }
        public float Layer { get; set; } = 0.1f;

        private double postupAnimace = 0;

        public SpriteItem(Texture2D textura, int pocetObrazkuSirka = 1, int pocetObrazkuVyska = 1) : base(textura)
        {
            PocetObrazkuSirka = pocetObrazkuSirka;
            PocetObrazkuVyska = pocetObrazkuVyska;
            Stred = new Vector2(SirkaObrzaku / 2.0f, VyskaObrzaku * 0.5f);
        }

        protected Vector2 VektorPosunuPoUhlu()
            => new Vector2((float)Math.Cos(UhelPohybu), (float)Math.Sin(UhelPohybu));

        public override void Update(double elapsedSeconds, Rectangle recFull)
        {
            base.Update(elapsedSeconds, recFull);

            // Animace
            if (RychlostAnimace > 0)
            {
                if (postupAnimace >= PocetObrazkuSirka * PocetObrazkuVyska)
                {
                    if (OpakovatAnimaci)
                    {
                        IndexObrazku = 0;
                        postupAnimace = 0;
                    }
                    else
                    {
                        JeMimo = true;
                        return;
                    }
                }
                else
                    IndexObrazku = (int)postupAnimace;
                postupAnimace += RychlostAnimace * elapsedSeconds;
            }

            // Výřez z obrázku
            VyrezZTextury = new Rectangle(
                SirkaObrzaku * (IndexObrazku % PocetObrazkuSirka),
                VyskaObrzaku * (IndexObrazku / PocetObrazkuSirka),
                SirkaObrzaku, VyskaObrzaku);

            // Výpočet nové pozice
            var novaPozice = Pozice + VektorPosunuPoUhlu() * RychlostPohybu * (float)elapsedSeconds;

            // Otočení
            UhelOtoceni = MathHelper.WrapAngle(UhelOtoceni + RychlostRotace * (float)elapsedSeconds);

            // Přepočet hranic obrazovky
            recFull.X -= (int)(Stred.X * Meritko);
            recFull.Y -= (int)(Stred.Y * Meritko);
            recFull.Width += (int)(Stred.X * Meritko * 2);
            recFull.Height += (int)(Stred.Y * Meritko * 2);
            // Kontrola, je-li mimo hranice obrazovky
            JeMimo = !recFull.Contains(novaPozice);
            if (!JeMimo)
                Pozice = novaPozice;
        }

        public override void Draw(SpriteBatch sb)
        {
            if (!JeMimo)
                sb.Draw(Textura, Pozice, VyrezZTextury, Color.White, 
                    UhelOtoceni, Stred, Meritko, SpriteEffects.None, Layer);
        }

    }
}

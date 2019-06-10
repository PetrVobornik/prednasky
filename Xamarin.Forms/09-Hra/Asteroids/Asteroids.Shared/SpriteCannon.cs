using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids.Shared
{
    public class SpriteCannonBase : SpriteItem
    {
        public SpriteCannonBase(Texture2D textura) : base(textura)
        {
            Meritko = 0.5f;
            Layer = 0.92f;
        }

        public override void Update(double elapsedSeconds, Rectangle recFull)
        {
            base.Update(elapsedSeconds, recFull);
            Pozice = new Vector2(recFull.Width * 0.5f, recFull.Height);
            JeMimo = false;
        }
    }

    public class SpriteCannonTube : SpriteItem
    {
        public Vector2 TapPos { get; set; }

        public SpriteCannonTube(Texture2D textura) : base(textura)
        {
            Meritko = 0.5f;
            Layer = 0.91f;
            Stred = new Vector2(SirkaObrzaku * 0.5f, VyskaObrzaku);
        }

        public override void Update(double elapsedSeconds, Rectangle recFull)
        {
            base.Update(elapsedSeconds, recFull);
            Pozice = new Vector2(recFull.Width * 0.5f, recFull.Height);
            JeMimo = false;
            if (TapPos != Vector2.Zero)
                UhelOtoceni = -(float)Math.Atan((Pozice.X - TapPos.X) / (Pozice.Y - TapPos.Y));
        }
    }


    public class SpriteCannonMissile : SpriteItem
    {
        public static Texture2D Texture;

        public SpriteCannonMissile(SpriteCannonTube cannon) : base(Texture)
        {
            Meritko = cannon.Meritko;
            Layer = 0.90f;
            //Stred = new Vector2(SirkaObrzaku * 0.5f, VyskaObrzaku * 0.5f);
            UhelOtoceni = cannon.UhelOtoceni;
            UhelPohybu = UhelOtoceni - (float)Math.PI * 0.5f;
            RychlostPohybu = 500;
            Pozice = cannon.Pozice + VektorPosunuPoUhlu() * cannon.VyskaObrzaku * Meritko;
        }

        public override void Update(double elapsedSeconds, Rectangle recFull)
        {
            base.Update(elapsedSeconds, recFull);
            RychlostPohybu = Math.Max(RychlostPohybu - (float)(elapsedSeconds * 500), 100);
        }

        public bool ZasahAsteroidu(SpriteAsteroid a)
            => Vector2.Distance(a.Pozice, Pozice) <= a.SirkaObrzaku * a.Meritko * 0.5 + 
                                                       VyskaObrzaku *   Meritko * 0.5; 
    }
}

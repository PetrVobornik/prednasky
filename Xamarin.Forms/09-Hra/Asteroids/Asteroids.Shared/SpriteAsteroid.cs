using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids.Shared
{
    public class SpriteAsteroid : SpriteItem
    {
        public static Texture2D Texture;
        float baseSpeed;

        public SpriteAsteroid(Rectangle recFull) : base(Texture, 3, 2)
        {
            IndexObrazku = RND.Next(PocetObrazkuSirka * PocetObrazkuVyska);
            Meritko = (float)(RND.NextDouble() * 0.25 + 0.1);
            Pozice = new Vector2(RND.Next(recFull.Width), -Stred.Y * Meritko + 1);
            UhelOtoceni = (float)(RND.NextDouble() * 2 * Math.PI);
            UhelPohybu = (float)(RND.NextDouble() * Math.PI * 0.5 + Math.PI * 0.25);
            baseSpeed = RND.Next(5, 60);
            RychlostPohybu = baseSpeed;
            RychlostRotace = (float)(RND.NextDouble() * 0.25);
            Layer = Meritko;
        }

        public override void Update(double elapsedSeconds, Rectangle recFull)
        {
            RychlostPohybu = baseSpeed * (1 + (Pozice.Y / recFull.Height));
            base.Update(elapsedSeconds, recFull);
        }
    }
}

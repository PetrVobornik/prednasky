using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids.Shared
{
    public class SpriteExplosionHit : SpriteItem
    {
        public static Texture2D Texture;

        public SpriteExplosionHit(SpriteCannonMissile missile) : base(Texture, 8, 6)
        {
            Meritko = 0.6f;
            Layer = 0.99f;
            UhelPohybu = missile.UhelPohybu;
            Pozice = missile.Pozice + VektorPosunuPoUhlu() * missile.VyskaObrzaku * missile.Meritko * 0.5f;
            RychlostAnimace = 25f;
        }
    }

    public class SpriteExplosionImpact : SpriteItem
    {
        public static Texture2D Texture;

        public SpriteExplosionImpact(SpriteAsteroid asteroid) : base(Texture, 5, 5)
        {
            Meritko = 0.6f;
            Layer = 0.99f;
            Stred = new Vector2(SirkaObrzaku * 0.5f, VyskaObrzaku);
            Pozice = asteroid.Pozice + new Vector2(0, asteroid.VyskaObrzaku * asteroid.Meritko * 0.5f);
            RychlostAnimace = 25f;
        }
    }

}

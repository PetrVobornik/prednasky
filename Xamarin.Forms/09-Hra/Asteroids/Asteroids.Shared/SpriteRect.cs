using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids.Shared
{
    public class SpriteRect : Sprite
    {
        public SpriteRect(Texture2D textura) : base(textura) { }

        public Rectangle Cil { get; set; }

        public Color Barva { get; set; } = Color.White;

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Textura, Cil, Barva);
        }
    }
}

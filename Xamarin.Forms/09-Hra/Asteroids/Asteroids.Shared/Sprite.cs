using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroids.Shared
{
    public class Sprite
    {
        public static Random RND = new Random();

        public Texture2D Textura { get; set; }

        public Sprite(Texture2D textura)
        {
            Textura = textura;
        }

        public virtual void Update(double elapsedSeconds, Rectangle recFull) {  }

        public virtual void Draw(SpriteBatch sb) { }
    }
}

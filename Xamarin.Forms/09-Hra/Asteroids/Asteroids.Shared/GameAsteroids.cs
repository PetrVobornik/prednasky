using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids.Shared
{
    public class GameAsteroids : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteRect sky, town;
        Rectangle recFull;
        SpriteCannonBase cannonBase;
        SpriteCannonTube cannonTube;

        List<SpriteAsteroid> asteroids;
        List<SpriteCannonMissile> missiles;
        List<SpriteExplosionHit> hits;
        List<SpriteExplosionImpact> impacts;

        SpriteFont font;

        SoundEffect sndShoot, sndHit, sndImpact;
        Song hudba;

        double odpocetDalsihoAsteroidu = 2, interval = 2;

        int score = 0, lives = 5;

        public GameAsteroids()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
            asteroids = new List<SpriteAsteroid>();
            missiles = new List<SpriteCannonMissile>();
            hits = new List<SpriteExplosionHit>();
            impacts = new List<SpriteExplosionImpact>();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            spriteBatch = new SpriteBatch(GraphicsDevice);

            sky = new SpriteRect(Content.Load<Texture2D>("sky"));
            town = new SpriteRect(Content.Load<Texture2D>("town"));

            SpriteAsteroid.Texture = Content.Load<Texture2D>("asteroids");
            SpriteCannonMissile.Texture = Content.Load<Texture2D>("cannon_missile");
            SpriteExplosionHit.Texture = Content.Load<Texture2D>("explosion_hit");
            SpriteExplosionImpact.Texture = Content.Load<Texture2D>("explosion_impact");

            cannonBase = new SpriteCannonBase(Content.Load<Texture2D>("cannon_base"));
            cannonTube = new SpriteCannonTube(Content.Load<Texture2D>("cannon_tube"));

            font = Content.Load<SpriteFont>("font");

            sndShoot = Content.Load<SoundEffect>("snd_shoot");
            sndHit = Content.Load<SoundEffect>("snd_hit");
            sndImpact = Content.Load<SoundEffect>("snd_impact");
            hudba = Content.Load<Song>("song1");

            MediaPlayer.Play(hudba);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.2f;
        }

        bool wasTaped = false;
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            double es = gameTime.ElapsedGameTime.TotalSeconds;

            recFull = new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);

            Vector2 tapPos = Vector2.Zero;
            // Dotyk
            tapPos = TouchPanel.GetState().FirstOrDefault(tl => tl.State == TouchLocationState.Pressed).Position;
            // Myš
            var ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
                tapPos = new Vector2(ms.X, ms.Y);

            // Obloha
            sky.Cil = recFull;
            // Město
            int townHeight = town.Textura.Height * recFull.Width / town.Textura.Width;
            town.Cil = new Rectangle(0, recFull.Height - townHeight, recFull.Width, townHeight);
            // Zahájení dotyku (výstřel)
            bool tapStart = !wasTaped && tapPos != Vector2.Zero;
            wasTaped = tapPos != Vector2.Zero;
            // Game Over
            if (lives == 0)
            {
                tapStart = false;
                tapPos = Vector2.Zero;
            }

            // Kanón
            cannonBase.Update(es, recFull);
            cannonTube.TapPos = tapPos;
            cannonTube.Update(es, recFull);

            // Asteroidy - nový
            odpocetDalsihoAsteroidu -= es;
            if (odpocetDalsihoAsteroidu <= 0)
            {
                if (interval > 0.5)
                    interval *= 0.98;
                odpocetDalsihoAsteroidu = interval;
                asteroids.Add(new SpriteAsteroid(recFull));
            }
            foreach (var a in asteroids)
            {
                if (a.Pozice.Y + a.VyskaObrzaku * a.Meritko >= recFull.Height - (townHeight * 0.08f))
                {
                    a.JeMimo = true;
                    impacts.Add(new SpriteExplosionImpact(a));
                    sndImpact.Play();
                    lives = Math.Max(lives - 1, 0);
                }
                else
                    a.Update(es, recFull);
            }

            // Střely
            if (tapStart)
            {
                missiles.Add(new SpriteCannonMissile(cannonTube));
                sndShoot.Play();
            }
            // Střely - zásah
            foreach (var m in missiles)
            {
                m.Update(es, recFull);
                var ast = asteroids.FirstOrDefault(a => m.ZasahAsteroidu(a));
                if (ast != null)
                {
                    ast.JeMimo = true;
                    m.JeMimo = true;
                    hits.Add(new SpriteExplosionHit(m));
                    sndHit.Play();
                    score++;
                }
            }

            hits.ForEach(a => a.Update(es, recFull));
            impacts.ForEach(a => a.Update(es, recFull));

            asteroids.RemoveAll(a => a.JeMimo);
            missiles.RemoveAll(a => a.JeMimo);
            hits.RemoveAll(a => a.JeMimo);
            impacts.RemoveAll(a => a.JeMimo);

            // Barva zkázy
            sky.Barva = new Color(lives / 5.0f, lives / 5.0f, lives / 5.0f);
            town.Barva = new Color(1, lives / 5.0f, lives / 5.0f);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black); // Barva podkladu na pozadí
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend); // Začátek vykreslování

            sky.Draw(spriteBatch);
            town.Draw(spriteBatch);

            cannonBase.Draw(spriteBatch);
            cannonTube.Draw(spriteBatch);

            asteroids.ForEach(a => a.Draw(spriteBatch));
            missiles.ForEach(a => a.Draw(spriteBatch));
            hits.ForEach(a => a.Draw(spriteBatch));
            impacts.ForEach(a => a.Draw(spriteBatch));

            // Výpis score
            string text = $"score {score}, lives {lives}";
            var textSize = font.MeasureString(text) * 0.5f;
            spriteBatch.DrawString(font, text,
                new Vector2(recFull.Width - textSize.X - 20, recFull.Height - textSize.Y),
                Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 1);

            // Game Over
            if (lives == 0)
            {
                text = "GAME OVER";
                textSize = font.MeasureString(text);
                spriteBatch.DrawString(font, text,
                    new Vector2((recFull.Width - textSize.X) * 0.5f, (recFull.Height - textSize.Y) * 0.5f),
                    Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }

            spriteBatch.End(); // Konec vykreslování
            base.Draw(gameTime);
        }
    }
}

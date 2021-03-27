using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wheats_and_Wands.Levels
{
    public class CreditScreen : Level
    {
        Texture2D _creditScreen { get; set; }

        SpriteFont _font { get; set; }

        public CreditScreen(Texture2D creditScreen, SpriteFont font)//GameTime gameTime, Texture2D creditsScreen)
        {
            _font = font;
            _creditScreen = creditScreen;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_creditScreen, new Vector2(0, 0), Color.Black);
            //DrawString commands
            spriteBatch.DrawString(_font, "Credits", new Vector2(900 /2, 20), Color.White); //Added
            spriteBatch.DrawString(_font, "Coding by Luke Schnetlage & Scott Lam", new Vector2(80, 100), Color.White);
            spriteBatch.DrawString(_font, "Lead artist: Scott Lam", new Vector2(80, 200), Color.White);
            spriteBatch.DrawString(_font, "Lead architect:", new Vector2(80, 300), Color.White);
            spriteBatch.DrawString(_font, "Music and sound effects courtesy of Zapsplat.com", new Vector2(80, 400), Color.White);
            spriteBatch.DrawString(_font, "Created using the MonoGame Framework", new Vector2(80, 500), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}

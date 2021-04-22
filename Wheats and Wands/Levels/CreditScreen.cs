using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Wheats_and_Wands.Graphics;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands.Levels
{
    public class CreditScreen : Level
    {
        public Texture2D _creditScreen { get; set; }
        public SpriteFont _font { get; set; }
        private GameState _gameState;

        private Sprite _menuButtonSprite;
        private Button _menuButton;
        public CreditScreen(Texture2D creditScreen, SpriteFont font, Texture2D titleScreenSheet, GameState gameState)//GameTime gameTime, Texture2D creditsScreen)
        {
            _font = font;
            _creditScreen = creditScreen;
            _gameState = gameState;

            _menuButtonSprite = new Sprite(titleScreenSheet, 357, 644, 250, 70, new Vector2(700, 400 + 540));
            _menuButton = new Button(_menuButtonSprite);
            _menuButton.Click += _menuButton_Click;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_creditScreen, new Vector2(0, 0), Color.Black);
            //DrawString commands
            spriteBatch.DrawString(_font, "Credits", new Vector2(900 / 2, 20), Color.White); //Added
            spriteBatch.DrawString(_font, "Coding by Luke Schnetlage & Scott Lam", new Vector2(80, 100), Color.White);
            spriteBatch.DrawString(_font, "Lead artist: Scott Lam", new Vector2(80, 200), Color.White);
            spriteBatch.DrawString(_font, "Lead architect: Luke Schnetlage", new Vector2(80, 300), Color.White);
            spriteBatch.DrawString(_font, "Music and sound effects courtesy of Zapsplat.com", new Vector2(80, 400), Color.White);
            spriteBatch.DrawString(_font, "Created using the MonoGame Framework", new Vector2(80, 500), Color.White);

            _menuButton.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(_font, "MENU", new Vector2(700 + 100, 400 + 25), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _menuButton.Update(gameTime);
        }

        public void _menuButton_Click(object sender, EventArgs e)
        {
            _gameState.state = States.TitleScreen;
        }
    }
}

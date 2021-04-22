using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using Wheats_and_Wands.Graphics;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands.Levels
{
    class OptionScreen : Level
    {

        private GameState _gameState;

        private Texture2D _optionsScreen;
        private Texture2D _titleScreenSheet;
        private SpriteFont _font;

        private Sprite _muteButtonSprite;
        private Button _muteButton;

        private Sprite _menuButtonSprite;
        private Button _menuButton;

        public OptionScreen(GameState gameState, Texture2D optionsScreen, Texture2D titleScreenSheet, SpriteFont font)
        {
            _gameState = gameState;
            _font = font;
            _optionsScreen = optionsScreen;
            _titleScreenSheet = titleScreenSheet;

            _menuButtonSprite = new Sprite(titleScreenSheet, 357, 644, 250, 70, new Vector2(50, 990));
            _menuButton = new Button(_menuButtonSprite);
            _menuButton.Click += _menuButton_Click;

            _muteButtonSprite = new Sprite(titleScreenSheet, 357, 644, 250, 70, new Vector2(WheatandWandsGame.WINDOW_WIDTH / 2 - 125, 540 + 200));
            _muteButton = new Button(_muteButtonSprite);
            _muteButton.Click += _muteButton_Click;

        }
        public void _muteButton_Click(object sender, EventArgs e)
        {
            if (MediaPlayer.IsMuted)
            {
                MediaPlayer.IsMuted = false;
            }
            else
            {
                MediaPlayer.IsMuted = true;
            }

        }

        public void _menuButton_Click(object sender, EventArgs e)
        {
            _gameState.state = States.TitleScreen;
        }

        public void _plusButton_Click(object sender, EventArgs e)
        {

            MediaPlayer.Volume = MediaPlayer.Volume + 0.1f;

        }
        public void _minusButton_Click(object sender, EventArgs e)
        {


            MediaPlayer.Volume = MediaPlayer.Volume - 0.1f;

        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_optionsScreen, new Vector2(0, 0), Color.Black);

            _menuButton.Draw(gameTime, spriteBatch);
            _muteButton.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(_font, "MENU", new Vector2(150, 990 - 510), Color.White);
            spriteBatch.DrawString(_font, "MUTE", new Vector2(990 / 2 - 30, 225), Color.White);

        }

        public override void Update(GameTime gameTime)
        {

            _menuButton.Update(gameTime);
            _muteButton.Update(gameTime);

        }


    }
}

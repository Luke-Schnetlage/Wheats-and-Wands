using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Wheats_and_Wands.Graphics;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands.Levels
{
    class StageSelectMenu : Level
    {
        GameState _gameState;
        GameState _playerProgress;
        Button _farmButton;
        Button _caveButton;
        Button _castleButton;
        Texture2D _background;
        public StageSelectMenu(GameState playerProgress, GameState gameState, Texture2D background, Texture2D farm, Texture2D Cave, Texture2D Castle)
        {
            _playerProgress = playerProgress;
            _gameState = gameState;
            _background = background;
            _farmButton = new Button(new Sprite(farm, 0, 0, 320, 180, new Vector2(0, 540)));
            _farmButton.Click += _farmButton_Click;
            _caveButton = new Button(new Sprite(Cave, 0, 0, 320, 180, new Vector2(320, 180 + 540)));
            _caveButton.Click += _caveButton_Click;
            _castleButton = new Button(new Sprite(Castle, 0, 0, 320, 180, new Vector2(640, 360 + 540)));
            _castleButton.Click += _castleButton_Click;

        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_background, new Vector2(0, 0), Color.Black);
            _farmButton.Draw(gameTime, spriteBatch);


            if (_playerProgress.state >= States.Cave)
                _caveButton.Draw(gameTime, spriteBatch);
            else
                _caveButton.Draw(gameTime, spriteBatch, Color.DarkOrchid);

            if (_playerProgress.state >= States.Castle)
                _castleButton.Draw(gameTime, spriteBatch);
            else
                _castleButton.Draw(gameTime, spriteBatch, Color.DarkRed);

        }

        public override void Update(GameTime gameTime)
        {

            _farmButton.Update(gameTime);
            _caveButton.Update(gameTime);
            _castleButton.Update(gameTime);


        }


        public void _farmButton_Click(object sender, EventArgs e)
        {
            _gameState.state = States.Tutorial;
        }
        public void _caveButton_Click(object sender, EventArgs e)
        {
            if (_playerProgress.state >= States.Cave)
                _gameState.state = States.Cave;


        }
        public void _castleButton_Click(object sender, EventArgs e)
        {
            if (_playerProgress.state >= States.Castle)
                _gameState.state = States.Castle;
        }

    }
}

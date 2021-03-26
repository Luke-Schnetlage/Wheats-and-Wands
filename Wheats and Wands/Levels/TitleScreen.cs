using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands.Levels
{
    public class TitleScreen : Level
    {

        Texture2D _spriteSheet { get; set; }
        SpriteBatch _spriteBatch { get; set; }
        Rectangle _frame = new Rectangle(0, 0, WheatandWandsGame.WINDOW_WIDTH, WheatandWandsGame.WINDOW_HEIGHT);
        Sprite _backGround;

        Sprite _newButton;
        Sprite _loadButton;
        Sprite _optionsButton;
        Sprite _creditsButton;
        Sprite _quitButton;
        MouseState mouseState;
        GameState _gameState;
        //int _levelVal;

        public TitleScreen (Texture2D spriteSheet, GameState gameState)
        {
            _gameState = gameState;
            //_levelVal = levelVal;
            _spriteSheet = spriteSheet;
            _backGround = new Sprite(spriteSheet, 0, 0, 960, 540);
            mouseState = new MouseState();

            _newButton = new Sprite(spriteSheet, 120, 800, 250, 70);
            _loadButton = new Sprite(spriteSheet, 120, 885, 250, 70);
            _optionsButton = new Sprite(spriteSheet, 590, 800, 250, 70);
            _creditsButton = new Sprite(spriteSheet, 590, 885, 250, 70);
            _quitButton = new Sprite(spriteSheet, 355, 970, 250, 70);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

  

            _spriteBatch = spriteBatch;
            _backGround.Draw(spriteBatch, new Vector2(0, 0));


            _newButton.Draw(spriteBatch, new Vector2(120, 260));
            _loadButton.Draw(spriteBatch, new Vector2(120, 345));
            _optionsButton.Draw(spriteBatch, new Vector2(590, 260));
            _creditsButton.Draw(spriteBatch, new Vector2(590, 345));
            _quitButton.Draw(spriteBatch, new Vector2(355, 425));
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
             if( mouseState.X >= _newButton.X && mouseState.X <= _newButton.X + _newButton.Width
                && mouseState.Y >= _newButton.Y && mouseState.Y <= _newButton.Y + _newButton.Height)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    _gameState.gameStates = GameStates.Tutorial;
                }
            }

        }
    }
}

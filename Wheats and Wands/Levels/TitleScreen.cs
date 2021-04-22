using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Wheats_and_Wands.Graphics;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands.Levels
{
    public class TitleScreen : Level
    {
        Texture2D _spriteSheet { get; set; }
        SpriteBatch _spriteBatch { get; set; }


        GameState _gameState;
        Rectangle _frame = new Rectangle(0, 0, WheatandWandsGame.WINDOW_WIDTH, WheatandWandsGame.WINDOW_HEIGHT);
        Sprite _backGround;

        Sprite _newButtonSprite;
        Sprite _optionsButtonSprite;
        Sprite _creditsButtonSprite;
        Sprite _quitButtonSprite;
        Sprite _stageSelectSprite;

        Button _newButton;
        Button _optionsButton;
        Button _creditsButton;
        Button _quitButton;
        Button _stageSelectButton;

        private List<Component> _buttonList;


        public TitleScreen(Texture2D spriteSheet, GameState gameState)
        {
            _spriteSheet = spriteSheet;
            _gameState = gameState;


            _backGround = new Sprite(spriteSheet, 0, 0, 960, 540);


            _newButtonSprite = new Sprite(spriteSheet, 120, 800, 250, 70, new Vector2(120, 800));
            _creditsButtonSprite = new Sprite(spriteSheet, 590, 800, 250, 70, new Vector2(590, 800));
            _optionsButtonSprite = new Sprite(spriteSheet, 590, 885, 250, 70, new Vector2(590, 885));
            _quitButtonSprite = new Sprite(spriteSheet, 120, 885, 250, 70, new Vector2(120, 885));
            _stageSelectSprite = new Sprite(spriteSheet, 59, 637, 250, 70, new Vector2(960 / 2 - 125, 885 + 85));


            _newButton = new Button(_newButtonSprite);
            _newButton.Click += NewButton_Click;


            _optionsButton = new Button(_optionsButtonSprite);
            _optionsButton.Click += OptionsButton_Click;

            _creditsButton = new Button(_creditsButtonSprite);
            _creditsButton.Click += CreditsButton_Click;

            _quitButton = new Button(_quitButtonSprite);
            _quitButton.Click += QuitButton_Click;

            _stageSelectButton = new Button(_stageSelectSprite);
            _stageSelectButton.Click += _stageSelectButton_Click;

            _buttonList = new List<Component>()
            {
                _newButton,
                _optionsButton,
                _creditsButton,
                _quitButton,
                _stageSelectButton
            };

        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _spriteBatch = spriteBatch;
            _backGround.Draw(spriteBatch, new Vector2(0, 0));
            foreach (Button button in _buttonList)
            {
                button.Draw(gameTime, spriteBatch);
            }

        }

        public void NewButton_Click(object sender, EventArgs e)
        {
            _gameState.state = States.Tutorial;
        }

        public void OptionsButton_Click(object sender, EventArgs e)
        {
            _gameState.state = States.OptionsScreen;
        }

        public void CreditsButton_Click(object sender, EventArgs e)
        {
            _gameState.state = States.CreditScreen;
        }

        public void QuitButton_Click(object sender, EventArgs e)
        {
            WheatandWandsGame._game.Exit();
        }
        public void _stageSelectButton_Click(object sender, EventArgs e)
        {
            _gameState.state = States.StageSelectMenu;
        }
        public override void Update(GameTime gameTime)
        {
            foreach (var componenet in _buttonList)
            {
                componenet.Update(gameTime);
            }

        }

    }
}

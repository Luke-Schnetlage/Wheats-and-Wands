using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        Sprite _newButtonSprite;
        Sprite _loadButtonSprite;
        Sprite _optionsButtonSprite;
        Sprite _creditsButtonSprite;
        Sprite _quitButtonSprite;

        Button _newButton;
        Button _loadButton;
        Button _optionsButton;
        Button _creditsButton;
        Button _quitButton;

        private List<Component> _buttonList;


        public TitleScreen (Texture2D spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _backGround = new Sprite(spriteSheet, 0, 0, 960, 540);


            _newButtonSprite = new Sprite(spriteSheet, 120, 800, 250, 70);
            _loadButtonSprite = new Sprite(spriteSheet, 120, 885, 250, 70);
            _optionsButtonSprite = new Sprite(spriteSheet, 590, 800, 250, 70);
            _creditsButtonSprite = new Sprite(spriteSheet, 590, 885, 250, 70);
            _quitButtonSprite = new Sprite(spriteSheet, 355, 970, 250, 70);

            _newButton = new Button(_newButtonSprite);
            _newButton.Click += NewButton_Click;
            
            _loadButton = new Button(_loadButtonSprite);
            _loadButton.Click += LoadButton_Click;

            _optionsButton = new Button(_optionsButtonSprite);
            _optionsButton.Click += OptionsButton_Click;

            _creditsButton = new Button(_creditsButtonSprite);
            _creditsButton.Click += CreditsButton_Click;

            _quitButton = new Button(_quitButtonSprite);
            _quitButton.Click += QuitButton_Click;
            
            _buttonList = new List<Component>()
            {
                _newButton,
                _loadButton,
                _optionsButton,
                _creditsButton,
                _quitButton,
            };

        }

        

        public override void Draw(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _backGround.Draw(spriteBatch, new Vector2(0, 0));
            foreach(Button button in _buttonList)
            {
                button.Draw(spriteBatch);
            }

        }

        public void NewButton_Click(object sender, EventArgs e)
        {
            //Add new button stuff here
        }

        public void LoadButton_Click(object sender, EventArgs e)
        {
            //Load game stuff here
        }

        public void OptionsButton_Click(object sender, EventArgs e)
        {
            //Options stuff here
        }

        public void CreditsButton_Click(object sender, EventArgs e)
        {
            //Credits stuff
        }

        public void QuitButton_Click(object sender, EventArgs e)
        {
            //Quit game
            _game.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var componenet in _buttonList)
                componenet.Update(gameTime);

        }
    }
}

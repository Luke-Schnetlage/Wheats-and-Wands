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

        Sprite _newButton;
        Sprite _loadButton;
        Sprite _optionsButton;
        Sprite _creditsButton;
        Sprite _quitButton;

        private List<Component> _buttonList;


        public TitleScreen (Texture2D spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _backGround = new Sprite(spriteSheet, 0, 0, 960, 540);


            _newButton = new Sprite(spriteSheet, 120, 800, 250, 70);
            _loadButton = new Sprite(spriteSheet, 120, 885, 250, 70);
            _optionsButton = new Sprite(spriteSheet, 590, 800, 250, 70);
            _creditsButton = new Sprite(spriteSheet, 590, 885, 250, 70);
            _quitButton = new Sprite(spriteSheet, 355, 970, 250, 70);

            var newButton = new Button(_newButton.Texture)
            {
                Position = new Vector2(120, 8000) //Don't need to put these lines here just for testing
            };
            newButton.Click += NewButton_Click;
            var loadButton = new Button(_loadButton.Texture)
            {
                Position = new Vector2(120, 885)
            };
            loadButton.Click += LoadButton_Click;
            var optionsButton = new Button(_optionsButton.Texture)
            {
                Position = new Vector2(590, 800)
            };
            optionsButton.Click += OptionsButton_Click;
            var creditsButton = new Button(_creditsButton.Texture)
            {
                Position = new Vector2(590, 885)
            };
            creditsButton.Click += CreditsButton_Click;
            var quitButton = new Button(_quitButton.Texture)
            {
                Position = new Vector2(355, 970)
            };
            quitButton.Click += QuitButton_Click;

            _buttonList = new List<Component>()
            {
                newButton,
                loadButton,
                optionsButton,
                creditsButton,
                quitButton,
            };

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

            foreach(var component in _buttonList)
            {
                component.Draw(spriteBatch);
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

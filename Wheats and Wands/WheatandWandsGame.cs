
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Wheats_and_Wands.Entities;
using Wheats_and_Wands.Levels;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands
{
    public class WheatandWandsGame : Game
    {

        public const int WINDOW_WIDTH = 960;
        public const int WINDOW_HEIGHT = 540;

        public int _levelVal;
        Level _level;
        TitleScreen _titleScreen;
        TutorialFarm _tutorial;


        Texture2D _titleScreenSprite;
        Texture2D _tutorialFarmBackground;
        Texture2D _farmerSpriteSheet;
        Vector2 playerPosition;
        //float playerSpeed;

        Texture2D _creditScreenSprite; //Added
        SpriteFont _creditFont; //Added
        //SpriteFont _artFont; //Added, Not implemented
        //SpriteFont _musicFont; //Added, Not implemented
        //SpriteFont _programFont; //Added, Not implemented
        //SpriteFont _scottFont; //Added, Not implemented
        //SpriteFont _lukeFont; //Added, Not implemented

        InputController _inputController;
        Display_Options _displayOptions;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Farmer _farmer;

        public WheatandWandsGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            _graphics.ApplyChanges();

            

            playerPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, (_graphics.PreferredBackBufferHeight / 2) + 15 ); //defaults player to center of the screen
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            _titleScreenSprite = Content.Load<Texture2D>("Title screen");
            _tutorialFarmBackground = Content.Load<Texture2D>("Farmer Background 2D -1");

            _creditScreenSprite = Content.Load<Texture2D>("Credits Screen"); //Added
            _creditFont = Content.Load<SpriteFont>("Credits"); //Added

            _farmerSpriteSheet = Content.Load<Texture2D>("Farmer walk cycle");

            _farmer = new Farmer(_farmerSpriteSheet, playerPosition);
            _displayOptions = new Display_Options(_graphics);
            _inputController = new InputController(_farmer, _displayOptions);


            _levelVal = 0;
            _titleScreen = new TitleScreen(_titleScreenSprite);

            _tutorial = new TutorialFarm(_tutorialFarmBackground);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { 
            Exit();
            }


            
            
                _level = _titleScreen;
            
            if (_levelVal == 1)
            {
                _level = _tutorial;
            }

            _titleScreen.Update(gameTime);

                base.Update(gameTime);
            _inputController.ProcessControls(gameTime);
            _farmer.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {


            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.White);
            _titleScreen.Draw(_spriteBatch);

            _level.Draw(_spriteBatch);
            //_tutorial.Draw(_spriteBatch);
            _farmer.Draw(_spriteBatch, gameTime);

            //DrawString commands
            //_spriteBatch.DrawString(_creditFont, "Credits", new Vector2(100, 20), Color.White); //Added

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Wheats_and_Wands.Entities;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands
{
    public class WheatandWandsGame : Game
    {

        public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 600;


        Texture2D _background;
        Texture2D _farmerSpriteSheet;
        Vector2 playerPosition;
        //float playerSpeed;

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

            playerPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, (_graphics.PreferredBackBufferHeight / 2) + 60); //defaults player to center of the screen
            //playerSpeed = 100f;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            _background = Content.Load<Texture2D>("Farmer Background 2D -1");
            _farmerSpriteSheet = Content.Load<Texture2D>("Farmer walk cycle");

            _farmer = new Farmer(_farmerSpriteSheet, playerPosition);
            _displayOptions = new Display_Options(_graphics);
            _inputController = new InputController(_farmer, _displayOptions);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { 
            Exit();
            }
            

            


            base.Update(gameTime);
            _inputController.ProcessControls(gameTime);

            _farmer.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);



            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Draw(_background, new Rectangle(0,0,WINDOW_WIDTH, WINDOW_HEIGHT), Color.White);

            _farmer.Draw(_spriteBatch, gameTime);

           
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

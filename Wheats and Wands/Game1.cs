using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Wheats_and_Wands
{
    public class Game1 : Game
    {

        Texture2D background;
        Texture2D knightTexture;
        Rectangle frame;
        Vector2 knightPosition;
        float knightSpeed;
        bool movingLeft;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            frame.X = 0;
            frame.Y = 0;
            frame.Width = 800;
            frame.Height = 600;
            // Window wants to maintain a 800 x 500 aspect ratio, changing height or width strechess out art
            //
            knightPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
            _graphics.PreferredBackBufferHeight / 2);
            knightSpeed = 100f;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            knightTexture = Content.Load<Texture2D>("Farmer walk cycle-1");
            background = Content.Load<Texture2D>("Farmer Background 2D -1");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            //move right
            if (kstate.IsKeyDown(Keys.Right))
            {
                this.knightPosition.X += this.knightSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                movingLeft = false;
            }
            //move left
            if (kstate.IsKeyDown(Keys.Left))
            {
                knightPosition.X -= knightSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                movingLeft = true;
            }
            //move up
            if (kstate.IsKeyDown(Keys.Up))
            {
                knightPosition.Y -= knightSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            // move down
            if (kstate.IsKeyDown(Keys.Down))
            {
                knightPosition.Y += knightSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            //Boundry Colision Block
            if (knightPosition.X > _graphics.PreferredBackBufferWidth - knightTexture.Width / 2)
            {
                knightPosition.X = _graphics.PreferredBackBufferWidth - knightTexture.Width / 2;
            }
            else if (knightPosition.X < knightTexture.Width / 2)
            {
                knightPosition.X = knightTexture.Width / 2;
            }
            if (knightPosition.Y > _graphics.PreferredBackBufferHeight - knightTexture.Height / 2)
            {
                knightPosition.Y = _graphics.PreferredBackBufferHeight - knightTexture.Height / 2;
            }
            else if (knightPosition.Y < knightTexture.Height / 2)
            {
                knightPosition.Y = knightTexture.Height / 2;
            }
            //End Boundry Colision Block



            // Press/Hold F1 to become a borderless window.
            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                Window.IsBorderless = true;
                _graphics.ApplyChanges();
            }
            // Press/Hold F2 to become a normal window.
            if (Keyboard.GetState().IsKeyDown(Keys.F2))
            {
                Window.IsBorderless = false;
                _graphics.ApplyChanges();
            }
            // Press/Hold F3 to enter fullscreen.
            if (Keyboard.GetState().IsKeyDown(Keys.F3))
            {
                _graphics.IsFullScreen = true;
                _graphics.ApplyChanges();
            }
            // Press/Hold F4 to exit fullscreen.
            if (Keyboard.GetState().IsKeyDown(Keys.F4))
            {
                _graphics.IsFullScreen = false;
                _graphics.ApplyChanges();
            }




            base.Update(gameTime);// this line should remain at the very bottom of Update
            }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteEffects effect;
            if (movingLeft == true)
            {
                effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                effect = SpriteEffects.None;
            }

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, frame, Color.White);
            _spriteBatch.Draw(
                knightTexture,
                knightPosition,
                null,
                Color.White,
                0f,
                new Vector2(knightTexture.Width / 2, knightTexture.Height / 2),
                Vector2.One,
                effect,
                0f
           );
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

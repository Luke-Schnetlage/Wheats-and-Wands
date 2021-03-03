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
            frame.Height = 500;
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
            background = Content.Load<Texture2D>("Farm-2.png");

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

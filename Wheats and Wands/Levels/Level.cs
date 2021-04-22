using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Wheats_and_Wands.Levels
{
    public abstract class Level
    {
        public double levelTime;

        Texture2D _backGround { get; set; }
        public Rectangle _frame = new Rectangle(0, 0, WheatandWandsGame.WINDOW_WIDTH, WheatandWandsGame.WINDOW_HEIGHT);
        SpriteBatch _spriteBatch;

        public virtual void Update(GameTime gameTime)
        {
            levelTime += gameTime.ElapsedGameTime.TotalSeconds;
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _spriteBatch = spriteBatch;
            _spriteBatch.Draw(_backGround, _frame, Color.White);
        }

    }
}

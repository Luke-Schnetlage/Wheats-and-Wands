using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class Cow : IGameEntity
    {

        public const float GRAVITY = 1600f;
        private const float JUMP_START_VELOCITY = -500f;

        public Sprite _sprite;
        private SpriteEffects effect = SpriteEffects.None;

        public int DrawOrder { get; set; }
        public Vector2 Position { get; set; }
        public float _verticalVelocity;

        public Cow(Sprite sprite)
        {

            _sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            if (gameTime.TotalGameTime.TotalSeconds % 2 == 0)
                if (effect == SpriteEffects.None)
                {
                    effect = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    effect = SpriteEffects.None;
                }
            _sprite.Draw(spriteBatch, _sprite.position, effect);
        }

        public void Update(GameTime gameTime)
        {

            if (_sprite.position.Y > 340)
            {
                _verticalVelocity = JUMP_START_VELOCITY;
            }
            _verticalVelocity += GRAVITY * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _sprite.position = new Vector2(_sprite.position.X, _sprite.position.Y + _verticalVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }


    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class Cow : IGameEntity
    {
        private const float MIN_JUMP_HEIGHT = 20f;
        public const float GRAVITY = 1600f;
        private const float JUMP_START_VELOCITY = -500f;
        private const float CANCEL_JUMP_VELOCITY = -100f;

        public Sprite _cow;

        public Vector2 Position { get; set; }
        public int DrawOrder { get; set; }
        bool goingUp;
        public float _verticalVelocity;

        public Cow(Texture2D cow, Vector2 position)
        {
            _cow = new Sprite(cow, 0, 0, 102, 65);
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _cow.Draw(spriteBatch, Position, SpriteEffects.None);
        }

        public void Update(GameTime gameTime)
        {
            if (_cow.position.Y > 290)
            {
                _verticalVelocity = JUMP_START_VELOCITY;
            }
            _verticalVelocity += GRAVITY * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _cow.position = new Vector2(_cow.position.X, _cow.position.Y + _verticalVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }


    }
}

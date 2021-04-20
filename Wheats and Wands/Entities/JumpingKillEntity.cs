using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class JumpingKillEntity : CollisionEntity
    {
        bool goingUp;
        private float _verticalVelocity;
        private const float GRAVITY = 800;
        private const float JUMP_START_VELOCITY = -800f;

        public JumpingKillEntity(Sprite sprite, Farmer farmer) : base(sprite, farmer)
        {
            _sprite = sprite;
            _farmer = farmer;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (goingUp)
            {
                _sprite.Draw(spriteBatch, _sprite.position, SpriteEffects.None);
            }
            else if (!goingUp)
            {
                _sprite.Draw(spriteBatch, _sprite.position, SpriteEffects.FlipVertically);
            }
        }


        public override void Update(GameTime gameTime)
        {
            
            Kill(_farmer);
            if (_sprite.position.Y > 420)
            {
                _verticalVelocity = JUMP_START_VELOCITY;
            }
            _verticalVelocity += GRAVITY * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _sprite.position = new Vector2(_sprite.position.X, _sprite.position.Y + _verticalVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);

            if (_verticalVelocity < 0)
            {
                goingUp = true;
            }
            else
            {
                goingUp = false;
            }
        }
    }
}

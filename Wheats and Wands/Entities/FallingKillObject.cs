using Microsoft.Xna.Framework;
using System;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class FallingKillObject : CollisionEntity
    {
        public TimeSpan _hangTime;
        TimeSpan _lastFallTime;
        float _verticalVelocity;
        bool falling;
        Vector2 startPos;
        int groundY;
        public FallingKillObject(Sprite sprite, Farmer farmer, TimeSpan hangTime) : base(sprite, farmer)
        {
            _sprite = sprite;
            _farmer = farmer;
            _hangTime = hangTime;
            falling = false;
            startPos = sprite.position;
            groundY = 400;
            _lastFallTime = new TimeSpan(0, 0, 0, 0);
        }

        public void Update(GameTime gameTime)
        {
            if (_lastFallTime + _hangTime < gameTime.TotalGameTime)
            {
                falling = true;
                _lastFallTime = gameTime.TotalGameTime;
            }
            Fall(gameTime);
            if (Collision(_farmer))
            {
                _farmer.IsAlive = false;
            }
            Kill(_farmer);
            //_farmer.Respawn();
            Reset();
        }

        private void Fall(GameTime gameTime)
        {
            if (falling)
            {
                _verticalVelocity += 1000f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                _sprite.position = new Vector2(_sprite.position.X, _sprite.position.Y + _verticalVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

        }

        private void Reset()
        {
            if (_sprite.position.Y - _sprite.Height > groundY)
            {

                _sprite.position = startPos;
                falling = false;
                _verticalVelocity = 0;
            }

        }
    }
}

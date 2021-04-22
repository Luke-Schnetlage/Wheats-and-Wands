using Microsoft.Xna.Framework;
using System;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class HorizontalKillObject : CollisionEntity
    {
        public TimeSpan _shiftTime;
        private TimeSpan _lastShiftTime;
        public float _horizontalVelocity;
        private bool shifting;
        private Vector2 startPos;
        private int leftX;
        public HorizontalKillObject(Sprite sprite, Farmer farmer, TimeSpan shiftTime) : base(sprite, farmer)
        {
            _sprite = sprite;
            _farmer = farmer;
            _shiftTime = shiftTime;
            shifting = false;
            startPos = sprite.position;
            leftX = -10;
            _lastShiftTime = new TimeSpan(0, 0, 0, 0);
        }

        public void Update(GameTime gameTime)
        {
            if (_lastShiftTime + _shiftTime < gameTime.TotalGameTime)
            {
                shifting = true;
                _lastShiftTime = gameTime.TotalGameTime;
            }
            Fall(gameTime);
            if (Collision(_farmer))
            {
                _farmer.IsAlive = false;
            }

            Kill(_farmer);
            Reset();
        }

        private void Reset()
        {
            if (-_sprite.position.X - _sprite.Width > leftX)
            {

                _sprite.position = startPos;
                shifting = false;
                _horizontalVelocity = 0;
            }

        }

        private void Fall(GameTime gameTime)
        {
            if (shifting)
            {
                _horizontalVelocity -= 750 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                _sprite.position = new Vector2(_sprite.position.X + _horizontalVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds, _sprite.position.Y);
            }

        }
    }
}

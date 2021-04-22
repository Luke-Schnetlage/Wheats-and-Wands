using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class HorizontalKillObject : CollisionEntity
    {
        public TimeSpan _shiftTime;
        TimeSpan _lastShiftTime;
        float _horizontalVelocity;
        bool shifting;
        Vector2 startPos;
        int leftX;
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
            //_farmer.Respawn();
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
                _sprite.position = new Vector2(_sprite.position.X +_horizontalVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds, _sprite.position.Y);
            }

        }
    }
}

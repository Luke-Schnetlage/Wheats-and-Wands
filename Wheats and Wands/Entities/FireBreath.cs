using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class FireBreath : CollisionEntity
    {
        private SpriteAnimation _fireBreathAnimation;
        public FireBreath(Sprite sprite, Farmer farmer,Texture2D spriteSheet) : base(sprite, farmer)
        {
            //960
            //540

            _fireBreathAnimation = new SpriteAnimation();
            _fireBreathAnimation.AddFrame(new Sprite(spriteSheet, 1698, 357 , 44 , 24, new Vector2(1698 % 960, 357  % 540)), 0);
            _fireBreathAnimation.AddFrame(new Sprite(spriteSheet, 708 , 882 , 72 , 54, new Vector2(708  % 960, 882  % 540)), 1 / 10f);
            _fireBreathAnimation.AddFrame(new Sprite(spriteSheet, 1635, 876 , 105, 60, new Vector2(1635 % 960, 876  % 540)), 2 / 10f);
            _fireBreathAnimation.AddFrame(new Sprite(spriteSheet, 618 , 1413, 162, 66, new Vector2(618  % 960, 1413 % 540)), 3 / 10f);
            _fireBreathAnimation.AddFrame(new Sprite(spriteSheet, 1464, 1413, 276, 68, new Vector2(1464 % 960, 1413 % 540)), 4 / 10f);
            _fireBreathAnimation.AddFrame(new Sprite(spriteSheet, 318 , 1956, 463, 68, new Vector2(318  % 960, 1956 % 540)), 5 / 10f);
            _fireBreathAnimation.AddFrame(new Sprite(spriteSheet, 1134, 1965, 606, 69, new Vector2(1134 % 960, 1965 % 540)), 6 / 10f);
            _fireBreathAnimation.AddFrame(new Sprite(spriteSheet, 174 , 2496, 606, 66, new Vector2(174  % 960, 2496 % 540)), 7 / 10f);
            _fireBreathAnimation.AddFrame(new Sprite(spriteSheet, 1134, 2496, 606, 66, new Vector2(1134 % 960, 2496 % 540)), 8 / 10f);
            _fireBreathAnimation.AddFrame(_fireBreathAnimation[0].Sprite, 9 / 10f);
            //_fireBreathAnimation.Play();
            _fireBreathAnimation.ShouldLoop = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_fireBreathAnimation.PlaybackProgress == _fireBreathAnimation.Duration)
                _fireBreathAnimation.Stop();
            _fireBreathAnimation.Draw(spriteBatch, _fireBreathAnimation.CurrentFrame.Sprite.position, SpriteEffects.None);
        }

        public void Update(GameTime gameTime)
        {
            _fireBreathAnimation.Update(gameTime);
            _sprite = _fireBreathAnimation.CurrentFrame.Sprite;
            
            
             Kill(_farmer);
        }
        public void BreathFire()
        {
            _fireBreathAnimation.Play();
        }
    }
}

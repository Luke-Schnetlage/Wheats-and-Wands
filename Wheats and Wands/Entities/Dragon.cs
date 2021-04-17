using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class Dragon : CollisionEntity
    {
        private SpriteAnimation _blinkAnimation;
        public bool IsAlive;
        public Dragon(Sprite sprite, Farmer farmer, Texture2D spriteSheet) : base(sprite, farmer)
        {
            //960
            //540
            IsAlive = true;


            _blinkAnimation = new SpriteAnimation();
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 750 , 183 , 210, 222, new Vector2(750 % 960 , 183  % 540)), 0);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 1710, 186 , 210, 222, new Vector2(1710 % 960, 186  % 540)), 1 / 10f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 750 , 732 , 210, 222, new Vector2(750 % 960 , 732  % 540)), 2 / 10f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 1710, 726 , 210, 222, new Vector2(1710 % 960, 726  % 540)), 3 / 10f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 750 , 1263, 210, 222, new Vector2(750 % 960 , 1263 % 540)), 4 / 10f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 1710, 1260, 210, 222, new Vector2(1710 % 960, 1260 % 540)), 5 / 10f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 750 , 1803, 210, 222, new Vector2(750 % 960 , 1803 % 540)), 6 / 10f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 1710, 1803, 210, 222, new Vector2(1710 % 960, 1803 % 540)), 7 / 10f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 750 , 2343, 210, 222, new Vector2(750 % 960 , 2343 % 540)), 8 / 10f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 1710, 2343, 210, 222, new Vector2(1710 % 960, 2343 % 540)), 9 / 10f);
            _blinkAnimation.AddFrame(_blinkAnimation[0].Sprite, 10 / 10f);
            _blinkAnimation.Play();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
                _blinkAnimation.Draw(spriteBatch, _blinkAnimation.CurrentFrame.Sprite.position, SpriteEffects.None);
        }

        public void Update(GameTime gameTime)
        {
            
            _blinkAnimation.Update(gameTime);
            _sprite = _blinkAnimation.CurrentFrame.Sprite;
            //RejectMovment(_farmer, gameTime);
            
            if (Collision(_farmer))
            {
                if (!TopCollision(_farmer))
                {
                    Kill(_farmer);
                }
                else
                {
                    IsAlive = false;
                }     
            }
        }
    }
}

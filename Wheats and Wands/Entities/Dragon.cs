using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class Dragon : CollisionEntity
    {
        private SpriteAnimation _blinkAnimation;
        Sprite _deadDragon;
        public bool IsAlive;
        public Dragon(Sprite sprite, Farmer farmer, Texture2D spriteSheet) : base(sprite, farmer)
        {
            //960
            //540
            IsAlive = true;

            _deadDragon = new Sprite(spriteSheet, 750, 183, 210, 222, new Vector2(750 % 960, 183 % 540));


            _blinkAnimation = new SpriteAnimation();
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 750, 183, 210, 222, new Vector2(750 % 960, 183 % 540)), 0);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 1710, 186, 210, 222, new Vector2(1710 % 960, 186 % 540)), 1 / 2f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 750, 732, 210, 222, new Vector2(750 % 960, 732 % 540)), 2 / 2f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 1710, 726, 210, 222, new Vector2(1710 % 960, 726 % 540)), 3 / 2f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 750, 1263, 210, 222, new Vector2(750 % 960, 1263 % 540)), 4 / 2f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 1710, 1260, 210, 222, new Vector2(1710 % 960, 1260 % 540)), 5 / 2f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 750, 1803, 210, 222, new Vector2(750 % 960, 1803 % 540)), 6 / 2f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 1710, 1803, 210, 222, new Vector2(1710 % 960, 1803 % 540)), 7 / 2f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 750, 2343, 210, 222, new Vector2(750 % 960, 2343 % 540)), 8 / 2f);
            _blinkAnimation.AddFrame(new Sprite(spriteSheet, 1710, 2343, 210, 222, new Vector2(1710 % 960, 2343 % 540)), 9 / 2f);
            _blinkAnimation.AddFrame(_blinkAnimation[0].Sprite, 10 / 10f);
            _blinkAnimation.Play();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Random rand = new Random();

            if (IsAlive)
                _blinkAnimation.Draw(spriteBatch, _blinkAnimation.CurrentFrame.Sprite.position, SpriteEffects.None);
            if (!IsAlive)
            {
                Vector2 pos = new Vector2(_deadDragon.position.X + rand.Next(-5, 5), _deadDragon.position.Y + rand.Next(-5, 5));
                _deadDragon.Draw(spriteBatch, pos, Color.Red);

            }
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

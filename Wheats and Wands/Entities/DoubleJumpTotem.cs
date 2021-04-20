using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class DoubleJumpTotem : CollisionEntity
    {
        SpriteAnimation _totemAwaken;
        Sprite sprite1;
        Sprite sprite2;
        Sprite sprite3;
        Sprite sprite4;
        //760,248
        public DoubleJumpTotem(Sprite sprite, Farmer farmer, Texture2D spritesheet) : base(sprite, farmer)
        {
            //_totemAwaken = new SpriteAnimation();
            //_sprite = new Sprite(spritesheet, 0, 0, 160, 160, new Vector2(760, 258));
            sprite1 = new Sprite(spritesheet, 0  , 0  , 160, 160, new Vector2(760,258));
            _sprite = sprite1;
            sprite2 = new Sprite(spritesheet, 160, 0  , 160, 160, new Vector2(760, 258));
            sprite3 = new Sprite(spritesheet, 0  , 160, 160, 160, new Vector2(760, 258));
            sprite4 = new Sprite(spritesheet, 160, 160, 160, 160, new Vector2(760, 258));
            //_totemAwaken.ShouldLoop = false;
            //_totemAwaken.Play();
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            _sprite.Draw(spriteBatch, _sprite.position, SpriteEffects.None);
        }

        public void Update(GameTime gameTime)
        {

            if (Collision(_farmer))
            {
                
                _sprite = sprite4;
                _farmer.doubleJump = true;
            }
        }

    }
}

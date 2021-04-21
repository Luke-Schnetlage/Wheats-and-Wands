using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class SkinSwapOrb : CollisionEntity
    {
        Farmer.Skins _skin;
        public SkinSwapOrb(Sprite sprite, Farmer farmer,Farmer.Skins skin) : base(sprite, farmer)
        {
            _sprite = sprite;
            _farmer = farmer;
            _skin = skin;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_farmer.skin != _skin)
                _sprite.Draw(spriteBatch, _sprite.position);
            
        }

       

        public override void Update(GameTime gameTime)
        {
            if (Collision(_farmer))
            {
                _farmer.skin = _skin;
            }
        }
    }
}

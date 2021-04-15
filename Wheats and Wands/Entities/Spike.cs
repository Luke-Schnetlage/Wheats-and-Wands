using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class Spike : CollisionEntity
    {
        
        public Spike(Sprite sprite, Farmer farmer) : base(sprite,farmer)
        {
            _sprite = sprite;
        }
        

        public override void Update(GameTime gameTime)
        {
            Kill(_farmer );
        }
    }
}

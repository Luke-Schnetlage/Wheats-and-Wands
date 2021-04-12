using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class HayBale : CollisionEntity
    {
        Sprite _sprite;
        Farmer _farmer;
        
        public HayBale(Sprite sprite, Farmer farmer) : base(sprite)
        {
            _sprite = sprite;
            _farmer = farmer;
        }
        
        
    }
}

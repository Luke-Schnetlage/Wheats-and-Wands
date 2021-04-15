using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class SquareBlock : CollisionEntity
    {
        public Sprite _sprite;
        private Farmer _farmer;
        public SquareBlock(Sprite sprite, Farmer farmer) : base(sprite,farmer)
        {
            _sprite = sprite;
            _farmer = farmer;
        }

        public override void Update(GameTime gameTime)
        {
            RejectMovment(_farmer, gameTime);
        }

    }
}

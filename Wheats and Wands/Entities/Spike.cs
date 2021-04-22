using Microsoft.Xna.Framework;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class Spike : CollisionEntity
    {

        public Spike(Sprite sprite, Farmer farmer) : base(sprite, farmer)
        {
            _sprite = sprite;
        }


        public override void Update(GameTime gameTime)
        {
            Kill(_farmer);
        }
    }
}

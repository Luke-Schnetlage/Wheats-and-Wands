using Microsoft.Xna.Framework;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class Pit : CollisionEntity
    {
        public Sprite _sprite;
        private Farmer _farmer;
        public Pit(Sprite sprite, Farmer farmer) : base(sprite, farmer)
        {
            _sprite = sprite;
            _farmer = farmer;
        }

        public override void Update(GameTime gameTime)
        {
            if (Collision(_farmer))
            {
                _farmer._groundY = WheatandWandsGame.WINDOW_HEIGHT - 5;
            }
        }
    }
}

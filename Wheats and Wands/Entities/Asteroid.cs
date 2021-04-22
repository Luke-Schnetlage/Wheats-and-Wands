using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class Asteroid : CollisionEntity
    {
        public Sprite _asteroid;
        public Asteroid(Sprite sprite, Farmer farmer, Texture2D spriteSheet) : base(sprite, farmer)
        {
            _asteroid = new Sprite(spriteSheet, 0, 0, 150, 98);
        }

        public override void Update(GameTime gameTime)
        {
            Kill(_farmer);
        }
    }
}

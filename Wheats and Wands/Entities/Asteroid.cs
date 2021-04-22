using Microsoft.Xna.Framework.Graphics;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class Asteroid : CollisionEntity
    {
        public Asteroid(Sprite sprite, Farmer farmer, Texture2D spriteSheet) : base(sprite, farmer)
        {

        }
    }
}

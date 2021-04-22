using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class DoubleJumpTotem : CollisionEntity
    {
        private Sprite sprite1;
        private Sprite sprite4;
        //760,248
        public DoubleJumpTotem(Sprite sprite, Farmer farmer, Texture2D spritesheet) : base(sprite, farmer)
        {

            sprite1 = new Sprite(spritesheet, 0, 0, 160, 160, new Vector2(760, 258));
            _sprite = sprite1;
            sprite4 = new Sprite(spritesheet, 160, 160, 160, 160, new Vector2(760, 258));

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

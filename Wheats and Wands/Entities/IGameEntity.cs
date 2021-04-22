using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Wheats_and_Wands.Entities
{
    interface IGameEntity
    {
        int DrawOrder { get; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}

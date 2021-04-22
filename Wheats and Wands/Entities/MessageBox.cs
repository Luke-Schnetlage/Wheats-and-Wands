using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class MessageBox //: IGameEntity
    {
        public int DrawOrder { get; set; }
        private Sprite _sprite;
        private SpriteFont _font;

        public MessageBox(Sprite sprite, SpriteFont font)
        {
            _sprite = sprite;
            _font = font;

        }

        public void Draw(SpriteBatch spriteBatch, string _message)
        {
            spriteBatch.DrawString(_font, _message, new Vector2(((WheatandWandsGame.WINDOW_WIDTH / 2) - (_sprite.Width / 2) + 10), 108), Color.Black);
            _sprite.Draw(spriteBatch, new Vector2((WheatandWandsGame.WINDOW_WIDTH / 2) - (_sprite.Width / 2), 75));

        }

        public void Update(GameTime gameTime)
        {

        }


    }
}

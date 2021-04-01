using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class MessageBox// : IGameEntity
    {
        public int DrawOrder { get; set; }
        Sprite _sprite;
        SpriteFont _font;

        public MessageBox(Sprite sprite, SpriteFont font)
        {
            _sprite = sprite;
            _font = font;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, string messsage)
        {
            _sprite.Draw(spriteBatch, new Vector2(_sprite.X, _sprite.Y));
            spriteBatch.DrawString(_font, messsage, new Vector2(_sprite.X + 15, _sprite.Y- 50), Color.White);

        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}

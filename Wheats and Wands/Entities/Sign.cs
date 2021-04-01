using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    public class Sign : CollisionEntity
    {
        Sprite _sprite;
        MessageBox _messageBox;
        string _message;
        bool collision;
        public Sign(Sprite sprite, Texture2D msgbox,SpriteFont font, string message) : base(sprite)
        {
            _sprite = sprite;
            _messageBox = new MessageBox(new Sprite(msgbox, 0, 0, 347, 77), font);
            _message = message;
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _sprite.Draw(spriteBatch, new Vector2(_sprite.X, _sprite.Y));
            if (collision)
                _messageBox.Draw(spriteBatch, gameTime, _message);
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class MessageBox : IGameEntity
    {
        public int DrawOrder { get; set; }
        Sprite _sprite;
        SpriteFont _font;
        string _messsage;

        public MessageBox(Sprite sprite, SpriteFont font, string message)
        {
            _sprite = sprite;
            _font = font;
            _messsage = message;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _sprite.Draw(spriteBatch, new Vector2((WheatandWandsGame.WINDOW_WIDTH/2) - (_sprite.Width/2), 75));
            spriteBatch.DrawString(_font, _messsage, new Vector2((WheatandWandsGame.WINDOW_WIDTH / 2), 75), Color.White);

        }

        public void Update(GameTime gameTime)
        {
            
        }

        
    }
}

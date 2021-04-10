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
            collision = false;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            _sprite.Draw(spriteBatch, position);
            if (collision)
            {
                _messageBox.Draw(spriteBatch, _message);
            }
                
        }

        public void Update(GameTime gameTime, Farmer farmer)
        {

            collision = (LeftCollision(farmer._sprite)); //|| RightCollision(farmer.rectangle) ||
                //TopCollision(farmer.rectangle) || BottomCollision(farmer.rectangle);
            
            
        }
    }
}

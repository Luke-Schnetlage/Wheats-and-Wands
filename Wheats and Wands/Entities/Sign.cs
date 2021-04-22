using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    public class Sign : CollisionEntity
    {
        public Sprite _sprite;
        MessageBox _messageBox;
        string _message;
        bool collision;
        private Farmer _farmer;
        public Sign(Sprite sprite, Texture2D msgbox, SpriteFont font, Farmer farmer, string message) : base(sprite, farmer)
        {
            _sprite = sprite;
            _messageBox = new MessageBox(new Sprite(msgbox, 0, 0, 347, 77), font);
            _message = message;
            _farmer = farmer;
            collision = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch, _sprite.position);
            if (Collision(_farmer))
            {
                DrawMessage(spriteBatch);
            }
        }

        public void DrawMessage(SpriteBatch spriteBatch)
        {
            _messageBox.Draw(spriteBatch, _message);
        }

        public void Update(GameTime gameTime, Farmer farmer)
        {
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wheats_and_Wands.Graphics
{
    public class SpriteLayer : Component
    {

        protected float _layer;
        protected Texture2D _texture;
        public Vector2 Position;

        public SpriteLayer(Texture2D texture)
        {
            _texture = texture;
        }

        public float Layer
        {
            get { return _layer; }
            set { _layer = value; }
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); }
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, _layer);
        }

        public override void Update(GameTime gameTime)
        {
            //
        }
    }
}

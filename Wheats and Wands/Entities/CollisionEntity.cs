using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    public class CollisionEntity : IGameEntity
    {
        public int DrawOrder { set; get; }
        //private Farmer _farmer;
        Sprite _sprite;
        bool collision;

        public CollisionEntity(Sprite sprite)//, Farmer farmer)
        {
            _sprite = sprite;
            //_farmer = farmer;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _sprite.Draw(spriteBatch, new Vector2(_sprite.X, _sprite.Y));
        }

        public void Update(GameTime gameTime)
        {
            //collision = LeftCollision()
        }
        
        
        public bool LeftCollision(Sprite sprite)
        {
            return _sprite.X + _sprite.Width > sprite.X && //right edge greater than left edge
                   _sprite.X < sprite.X + sprite.Width&& //left edge less than right edge
                   _sprite.Y + _sprite.Height > sprite.Y &&
                   _sprite.Y < sprite.Y + sprite.Height;
        }

        public bool RightCollision(Rectangle rectangle)
        {
            return this._sprite.rectangle.Left < rectangle.Right &&
                   this._sprite.rectangle.Right > rectangle.Right &&
                   this._sprite.rectangle.Bottom > rectangle.Top &&
                   this._sprite.rectangle.Top < rectangle.Bottom;
        }

        public bool TopCollision(Rectangle rectangle)
        {
            return this._sprite.rectangle.Bottom > rectangle.Top &&
                   this._sprite.rectangle.Top < rectangle.Top &&
                   this._sprite.rectangle.Right > rectangle.Left &&
                   this._sprite.rectangle.Left < rectangle.Right;
        }

        public bool BottomCollision(Rectangle rectangle)
        {
            return this._sprite.rectangle.Top  < rectangle.Bottom &&
                   this._sprite.rectangle.Bottom > rectangle.Bottom &&
                   this._sprite.rectangle.Right > rectangle.Left &&
                   this._sprite.rectangle.Left < rectangle.Right;
        }
    }
}

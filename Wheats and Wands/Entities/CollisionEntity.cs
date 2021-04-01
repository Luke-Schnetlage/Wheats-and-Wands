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
            return this._sprite.rectangle.Right  > sprite.rectangle.Left &&
                   this._sprite.rectangle.Left < sprite.rectangle.Left &&
                   this._sprite.rectangle.Bottom > sprite.rectangle.Top &&
                   this._sprite.rectangle.Top < sprite.rectangle.Bottom;
        }

        public bool RightCollision(Sprite sprite)
        {
            return this._sprite.rectangle.Left < sprite.rectangle.Right &&
                   this._sprite.rectangle.Right > sprite.rectangle.Right &&
                   this._sprite.rectangle.Bottom > sprite.rectangle.Top &&
                   this._sprite.rectangle.Top < sprite.rectangle.Bottom;
        }

        public bool TopCollision(Sprite sprite)
        {
            return this._sprite.rectangle.Bottom > sprite.rectangle.Top &&
                   this._sprite.rectangle.Top < sprite.rectangle.Top &&
                   this._sprite.rectangle.Right > sprite.rectangle.Left &&
                   this._sprite.rectangle.Left < sprite.rectangle.Right;
        }

        public bool BottomCollision(Sprite sprite)
        {
            return this._sprite.rectangle.Top  < sprite.rectangle.Bottom &&
                   this._sprite.rectangle.Bottom > sprite.rectangle.Bottom &&
                   this._sprite.rectangle.Right > sprite.rectangle.Left &&
                   this._sprite.rectangle.Left < sprite.rectangle.Right;
        }
    }
}

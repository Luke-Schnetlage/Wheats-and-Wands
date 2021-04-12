using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    public class CollisionEntity// : IGameEntity
    {
        public int DrawOrder { set; get; }
        //private Farmer _farmer;
        Sprite _sprite;
        bool collision;
        //private Sprite sprite;

        public CollisionEntity(Sprite sprite, Farmer farmer)
        {
            _sprite = sprite;
            //_farmer = farmer;
        }

        public CollisionEntity(Sprite sprite)
        {
            this._sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _sprite.Draw(spriteBatch, new Vector2(_sprite.position.X, _sprite.position.Y));
        }

        public void Update(GameTime gameTime)
        {
            //collision = LeftCollision()
        }

        

        public void RejectMovment(Farmer _farmer,GameTime gameTime)
        {
            if (Collision(_farmer))
            {
                
                Vector2 position = _farmer.Position;

                if (LeftCollision(_farmer))
                {
                    position.X = _farmer.Position.X - (250f * (float)gameTime.ElapsedGameTime.TotalSeconds);
                    
                }
                else if (RightCollision(_farmer))
                {
                    position.X = _farmer.Position.X + (250f * (float)gameTime.ElapsedGameTime.TotalSeconds);
                    
                }
                else if (BottomCollision(_farmer))
                {
                    _farmer.CancelJump();
                }
                else if (TopCollision(_farmer))
                {
                    _farmer.OnGround = true;
                }
                

                _farmer.Position = position;
            }
        }

        public bool Collision(Farmer _farmer)
        {
            return (_farmer.Position.X + _farmer._sprite.Width >= _sprite.position.X                    //farmer right edge greater than object left edge 
                                         && _farmer.Position.X <= _sprite.position.X + _sprite.Width && //farmer left edge less than object right edge 
                   _farmer.Position.Y + _farmer._sprite.Height >= _sprite.position.Y                    //farmer bottom edge greater than object top edge  
                                         && _farmer.Position.Y <= _sprite.position.Y + _sprite.Height); //farmer top edge less than object bottom edge
        }

        private bool LeftCollision(Farmer _farmer) //checks if farmer right edge behind center of sprite
        {
            return _farmer.Position.X + _farmer._sprite.Width < _sprite.position.X + (_sprite.Width / 2);
        }

        private bool RightCollision(Farmer _farmer)
        {
            return _farmer.Position.X > _sprite.position.X + (_sprite.Width / 2);
        }

        private bool TopCollision(Farmer _farmer)
        {
            return _farmer.Position.Y + _farmer._sprite.Height >= _sprite.position.Y;
        }

        private bool BottomCollision(Farmer _farmer)
        {
            return _farmer.Position.Y  < _sprite.position.Y +_sprite.Height;
        }
        
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    public class Farmer : IGameEntity
    {

        private const float MIN_JUMP_HEIGHT = 20f;

        private const float GRAVITY = 1600f;
        private const float JUMP_START_VELOCITY = -480f;

        private const float CANCEL_JUMP_VELOCITY = -100f;

        public Vector2 HorizontalVelocity;

        public Vector2 SpawnPosition { get; set; }
        public FarmerState State { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle rectangle { get; set; }
        
        public int DrawOrder { set; get; }
        public bool IsAlive { get; set; }
        public bool OnGround { get; set; }
        public bool MovingLeft { get; set; }
        private Sprite _FarmerIdlePose;
        private SpriteAnimation _farmerWalkCycle;
        public Sprite _sprite { get; private set; }


        private float _verticalVelocity;
        public float _groundY { get; set; }

        public Vector2 prevPosition;


        public Farmer(Texture2D spriteSheet, Vector2 position)
        {
            Position = position;

            _FarmerIdlePose = new Sprite(spriteSheet, 0, 0, 64, 128);
            _sprite = _FarmerIdlePose;
            rectangle = new Rectangle((int)Position.X, (int)Position.Y, 64, 128);
            State = FarmerState.Idle;
            _groundY = position.Y;

            OnGround = false;
            IsAlive = true;
            MovingLeft = false;

            _farmerWalkCycle = new SpriteAnimation();
            _farmerWalkCycle.AddFrame(new Sprite(spriteSheet, (64 * 1)  ,0, 64, 128), 0);
            _farmerWalkCycle.AddFrame(new Sprite(spriteSheet, (64 * 2) , 0, 64, 128), 1/10f);
            _farmerWalkCycle.AddFrame(new Sprite(spriteSheet, (64 * 3) , 0, 64, 128), 2/10f);
            _farmerWalkCycle.AddFrame(new Sprite(spriteSheet, (64 * 0) , (128 * 1), 64, 128), 3/10f);
            _farmerWalkCycle.AddFrame(new Sprite(spriteSheet, (64 * 1) , (128 * 1), 64, 128), 4/10f);
            _farmerWalkCycle.AddFrame(new Sprite(spriteSheet, (64 * 2) , (128 * 1), 64, 128), 5/10f);
            _farmerWalkCycle.AddFrame(new Sprite(spriteSheet, (64 * 3) , (128 * 1), 64, 128), 6/10f);
            _farmerWalkCycle.AddFrame(new Sprite(spriteSheet, (64 * 0) , (128 * 2), 64, 128), 7/10f);
            _farmerWalkCycle.AddFrame(_farmerWalkCycle[0].Sprite, 8/10f);
            _farmerWalkCycle.Play();

        }



        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            SpriteEffects _effect;
            if (MovingLeft)
            {
                _effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                _effect = SpriteEffects.None;
            }

            if (State == FarmerState.Idle)
            {
                _FarmerIdlePose.Draw(spriteBatch, Position, _effect);
                _sprite = _FarmerIdlePose;

            }
            else if (State == FarmerState.Jumping || State == FarmerState.Falling)
            {
                _FarmerIdlePose.Draw(spriteBatch, Position,_effect);
                _sprite = _FarmerIdlePose;
            }
            if (State == FarmerState.Running)
            {
                _farmerWalkCycle.Draw(spriteBatch, Position, _effect);
                _sprite = _farmerWalkCycle.CurrentFrame.Sprite;
            }
        }

        public void Update(GameTime gameTime)
        {

            //if (Position.X < prevPosition.X)
            //    HorizontalVelocity.X = -3f;
            //else if (Position.X > prevPosition.X)
            //    HorizontalVelocity.X = 3f;
            //else
            //    HorizontalVelocity.X = 0f;


            if (Position.Y  < _groundY)
            {
                OnGround = false;
            }
            if (!OnGround)
            {
                Fall(gameTime);
            }
            if (State != FarmerState.Idle)
            {
                _farmerWalkCycle.Update(gameTime);
            }
            if (Position.Y > _groundY)
            {
                Land();
            }
            Respawn();

            rectangle = new Rectangle((int)Position.X, (int)Position.Y, 64, 128);
            prevPosition = Position;
        }
        public bool BeginJump()
        {
            
            if (State == FarmerState.Jumping || State == FarmerState.Falling)
            {
                return false;
            }
            
            State = FarmerState.Jumping;
            OnGround = false;
            _verticalVelocity = JUMP_START_VELOCITY;
            return true;
        }
        /*
        public bool CancelJump()
        {

            if (OnGround || (_startPosY - Position.Y) < MIN_JUMP_HEIGHT)
            {
                return false;
            }

            State = FarmerState.Falling;
            
            _verticalVelocity = _verticalVelocity < CANCEL_JUMP_VELOCITY ? CANCEL_JUMP_VELOCITY : 0;
            return true;
        }
        */
        public void Fall(GameTime gameTime)
        {
            _verticalVelocity += GRAVITY * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position = new Vector2(Position.X, Position.Y + _verticalVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public void Land()
        {
            Position = new Vector2(Position.X, _groundY);
            _verticalVelocity = 0;
            OnGround = true;
            State = FarmerState.Idle;
        }

        public void Respawn()
        {
            if(IsAlive == false)
            {
                Position = SpawnPosition;
                IsAlive = true;
            }
        }

    }
}

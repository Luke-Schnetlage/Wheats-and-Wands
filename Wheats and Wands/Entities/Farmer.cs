using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Entities
{
    class Farmer : IGameEntity
    {

        private const float MIN_JUMP_HEIGHT = 20f;

        private const float GRAVITY = 1600f;
        private const float JUMP_START_VELOCITY = -480f;

        private const float CANCEL_JUMP_VELOCITY = -100f;
       
        private const float WALK_SPEED = 100f;


        public FarmerState State { get; set; }
        public Vector2 Position { get; set; }
        public bool IsAlive { get; private set; }
        //public float Speed { get; private set; } = 100;
        public int DrawOrder { set; get; }
        public bool OnGround { get; set; }

        private Sprite _FarmerIdlePose;
        private SpriteAnimation _farmerWalkCycle;


        private float _verticalVelocity;
        private float _startPosY;




        public Farmer(Texture2D spriteSheet, Vector2 position)
        {
            Position = position;

            _FarmerIdlePose = new Sprite(spriteSheet, 0, 0, 64, 128);
            State = FarmerState.Idle;
            _startPosY = position.Y;

            OnGround = true;


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
            if (State == FarmerState.Idle)
            {
                _FarmerIdlePose.Draw(spriteBatch, this.Position);

            }
            else if (State == FarmerState.Jumping || State == FarmerState.Falling)
            {
                _FarmerIdlePose.Draw(spriteBatch, Position);
            }
            else if (State == FarmerState.Running)
            {
                _farmerWalkCycle.Draw(spriteBatch, Position);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (State == FarmerState.Idle)
            {

            }
            else if (!OnGround)
            {
                Position = new Vector2(Position.X, Position.Y + _verticalVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
                _verticalVelocity += GRAVITY * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (_verticalVelocity >= 0)
                {
                    State = FarmerState.Falling;
                }

                if (Position.Y >= _startPosY)
                {
                    Position = new Vector2(Position.X, _startPosY);
                    _verticalVelocity = 0;
                    OnGround = true;
                    State = FarmerState.Idle;
                }
            }
            else if (State == FarmerState.Running)
            {
                _farmerWalkCycle.Update(gameTime);
            }
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

        public bool CancelJump()
        {

            if (State != FarmerState.Jumping || (_startPosY - Position.Y) < MIN_JUMP_HEIGHT)
            {
                return false;
            }

            State = FarmerState.Falling;
            
            _verticalVelocity = _verticalVelocity < CANCEL_JUMP_VELOCITY ? CANCEL_JUMP_VELOCITY : 0;
            return true;
        }

        /*
        public void MoveLeft()
        {

            //Position = new Vector2(Position.X - (PLAYER_SPEED * (float)gameTime.ElapsedGameTime.TotalSeconds), Position.Y);

            //this.Position.X -= Speed;// * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //position.X -= WALK_SPEED * (float)gameTime.ElapsedGameTime.TotalSeconds;
            State = FarmerState.Running;
        }
        */

    }
}

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
        public const float GRAVITY = 1600f;
        private const float JUMP_START_VELOCITY = -500f;
        private const float CANCEL_JUMP_VELOCITY = -100f;

        public Vector2 HorizontalVelocity;
        public Vector2 SpawnPosition { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 prevPosition;
        public FarmerState State { get; set; }
        
        public Rectangle rectangle { get; set; }
        
        public int DrawOrder { set; get; }
        public bool IsAlive { get; set; }
        public bool OnGround { get; set; }
        public bool doubleJump { get; set; }
        public bool doubleJumpUsed { get; set; }
        public bool MovingLeft { get; set; }
        private Sprite _FarmerIdlePose;
        private Sprite _fancyIdlePose;
        private Sprite _wizardIdlePose;
        private Sprite IdlePose;

        private SpriteAnimation _farmerWalkCycle;
        private SpriteAnimation _fancyWalkCycle;
        private SpriteAnimation _wizardWalkCycle;
        private SpriteAnimation _WalkCycle;

        private SpriteAnimation _deathAnimation;
        public Sprite _sprite { get; private set; }


        private float _verticalVelocity;
        public float _groundY { get; set; }

        


        public Farmer(Texture2D spriteSheet, Vector2 position, Texture2D _heartSheet, Texture2D _fancyFarmerSheet, Texture2D _wizardFarmerSheet)
        {
            Position = position;

            _FarmerIdlePose = new Sprite(spriteSheet, 0, 0, 64, 128);
            _fancyIdlePose = new Sprite(_fancyFarmerSheet, 0, 0, 64, 128);
            _wizardIdlePose = new Sprite(_wizardFarmerSheet, 0, 0, 64, 128);

            IdlePose = _FarmerIdlePose;
            IdlePose = _fancyIdlePose;
            _sprite = IdlePose;

            rectangle = new Rectangle((int)Position.X, (int)Position.Y, 64, 128);
            State = FarmerState.Idle;
            _groundY = position.Y;

            OnGround = false;
            IsAlive = true;
            MovingLeft = false;
            doubleJump = false;

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

            _fancyWalkCycle = new SpriteAnimation();
            _fancyWalkCycle.AddFrame(new Sprite(_fancyFarmerSheet, (64 * 1), 0, 64, 128), 0);
            _fancyWalkCycle.AddFrame(new Sprite(_fancyFarmerSheet, (64 * 2), 0, 64, 128), 1 / 10f);
            _fancyWalkCycle.AddFrame(new Sprite(_fancyFarmerSheet, (64 * 3), 0, 64, 128), 2 / 10f);
            _fancyWalkCycle.AddFrame(new Sprite(_fancyFarmerSheet, (64 * 0), (128 * 1), 64, 128), 3 / 10f);
            _fancyWalkCycle.AddFrame(new Sprite(_fancyFarmerSheet, (64 * 1), (128 * 1), 64, 128), 4 / 10f);
            _fancyWalkCycle.AddFrame(new Sprite(_fancyFarmerSheet, (64 * 2), (128 * 1), 64, 128), 5 / 10f);
            _fancyWalkCycle.AddFrame(new Sprite(_fancyFarmerSheet, (64 * 3), (128 * 1), 64, 128), 6 / 10f);
            _fancyWalkCycle.AddFrame(new Sprite(_fancyFarmerSheet, (64 * 0), (128 * 2), 64, 128), 7 / 10f);
            _fancyWalkCycle.AddFrame(_fancyWalkCycle[0].Sprite, 8 / 10f);
            _fancyWalkCycle.Play();

            _wizardWalkCycle = new SpriteAnimation();
            _wizardWalkCycle.AddFrame(new Sprite(_wizardFarmerSheet, (64 * 1), 0, 64, 128), 0);
            _wizardWalkCycle.AddFrame(new Sprite(_wizardFarmerSheet, (64 * 2), 0, 64, 128), 1 / 10f);
            _wizardWalkCycle.AddFrame(new Sprite(_wizardFarmerSheet, (64 * 3), 0, 64, 128), 2 / 10f);
            _wizardWalkCycle.AddFrame(new Sprite(_wizardFarmerSheet, (64 * 0), (128 * 1), 64, 128), 3 / 10f);
            _wizardWalkCycle.AddFrame(new Sprite(_wizardFarmerSheet, (64 * 1), (128 * 1), 64, 128), 4 / 10f);
            _wizardWalkCycle.AddFrame(new Sprite(_wizardFarmerSheet, (64 * 2), (128 * 1), 64, 128), 5 / 10f);
            _wizardWalkCycle.AddFrame(new Sprite(_wizardFarmerSheet, (64 * 3), (128 * 1), 64, 128), 6 / 10f);
            _wizardWalkCycle.AddFrame(new Sprite(_wizardFarmerSheet, (64 * 0), (128 * 2), 64, 128), 7 / 10f);
            _wizardWalkCycle.AddFrame(_wizardWalkCycle[0].Sprite, 8 / 10f);
            _wizardWalkCycle.Play();

            _WalkCycle = _farmerWalkCycle;
            _WalkCycle = _fancyWalkCycle;




            _deathAnimation = new SpriteAnimation();
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (0 * 120), (0 * 120), 120, 120), 1 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (1 * 120), (0 * 120), 120, 120), 2 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (2 * 120), (0 * 120), 120, 120), 3 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (3 * 120), (0 * 120), 120, 120), 4 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (0 * 120), (1 * 120), 120, 120), 5 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (1 * 120), (1 * 120), 120, 120), 6 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (2 * 120), (1 * 120), 120, 120), 7 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (3 * 120), (1 * 120), 120, 120), 8 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (0 * 120), (2 * 120), 120, 120), 9 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (1 * 120), (2 * 120), 120, 120), 10 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (2 * 120), (2 * 120), 120, 120), 11 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (3 * 120), (2 * 120), 120, 120), 12 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (0 * 120), (3 * 120), 120, 120), 13 / 7f);
            _deathAnimation.AddFrame(new Sprite(_heartSheet, (1 * 120), (3 * 120), 120, 120), 14 / 7f);
            
            _deathAnimation.ShouldLoop = false;


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
                IdlePose.Draw(spriteBatch, Position, _effect);
                _sprite = IdlePose;

            }
            else if (State == FarmerState.Jumping || State == FarmerState.Falling)
            {
                IdlePose.Draw(spriteBatch, Position,_effect);
                _sprite = IdlePose;
            }
            if (State == FarmerState.Running)
            {
                _WalkCycle.Draw(spriteBatch, Position, _effect);
                _sprite = _WalkCycle.CurrentFrame.Sprite;
            }
            
            
            if (_deathAnimation.PlaybackProgress == _deathAnimation.Duration )
                _deathAnimation.Stop();
            
            _deathAnimation.Draw(spriteBatch, new Vector2(960 / 2 - 60, 540 / 2 - 60), SpriteEffects.None);
        }

        public void Update(GameTime gameTime)
        {
            _deathAnimation.Update(gameTime);
            IsAlive = true;
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
                _WalkCycle.Update(gameTime);
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

        public bool DoubleJump()
        {

            //if (!doubleJump || doubleJumpUsed || OnGround)
            //{
            //    return false;
            //}

            //State = FarmerState.Jumping;
            //OnGround = false;
            doubleJumpUsed = true;
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
            doubleJumpUsed = false;
            State = FarmerState.Idle;
        }

        public void Respawn()
        {
            if(IsAlive == false)
            {
                Position = SpawnPosition;
                _deathAnimation.Stop();
                _deathAnimation.Play();
            }
        }
    }
}

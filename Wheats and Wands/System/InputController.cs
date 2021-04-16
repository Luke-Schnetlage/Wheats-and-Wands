using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Entities;


namespace Wheats_and_Wands.System
{
    class InputController
    {

        public const float PLAYER_SPEED = 250f;
        Vector2 position = new Vector2(0,0);
        private Farmer _farmer;
        private KeyboardState _previousKeyboardState;
        private Display_Options _displayOptions;
        SoundEffect _jumpSound;

        public InputController(Farmer farmer ,Display_Options displayOptions, SoundEffect jumpSound )
        {
            _farmer = farmer;
            _displayOptions = displayOptions;
            _jumpSound = jumpSound;
        }

        public void ProcessControls(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            //jump
            if ((keyboardState.IsKeyDown(Keys.Up)) || (_previousKeyboardState.IsKeyDown(Keys.W)))
            {
                if (_farmer.OnGround )//&& _farmer.Position.Y >= 0)
                {
                    _farmer.BeginJump(); //state = jumping
                    _jumpSound.Play((float)0.2, 0, 0);
                }
            }

            //cancel jump
            else if (!keyboardState.IsKeyDown(Keys.Up) && _farmer.State == FarmerState.Jumping) 
            {
                //_farmer.CancelJump(); // FarmerState = falling
            }

            //move right
            if ((keyboardState.IsKeyDown(Keys.Right)) || (_previousKeyboardState.IsKeyDown(Keys.D)))
            {
                if (_farmer.Position.X <= WheatandWandsGame.WINDOW_WIDTH - 64 )
                {
                    
                    position.X = _farmer.Position.X + (PLAYER_SPEED * (float)gameTime.ElapsedGameTime.TotalSeconds);
                    position.Y = _farmer.Position.Y;
                    _farmer.Position = position;
                    _farmer.MovingLeft = false;

                }
                _farmer.State = FarmerState.Running;
                
            } 

            //move left
            if ((keyboardState.IsKeyDown(Keys.Left)) || (_previousKeyboardState.IsKeyDown(Keys.A)))
            {
                if (_farmer.Position.X >= 0)
                {
                    
                    position.X = _farmer.Position.X - (PLAYER_SPEED * (float)gameTime.ElapsedGameTime.TotalSeconds);
                    position.Y = _farmer.Position.Y;
                    _farmer.Position = position;
                    _farmer.MovingLeft = true;
                    
                   
                }
                _farmer.State = FarmerState.Running;
            }

            //idle trigger block            
            if (keyboardState.GetPressedKeyCount() == 0 && _farmer.OnGround) 
                //&& _farmer.State != FarmerState.Running)
            {
                _farmer.State = FarmerState.Idle;
            }

            //fullscreen toggle
            if (keyboardState.IsKeyDown(Keys.F3))
            {
                _displayOptions.FullScreenMode();

            }


            _previousKeyboardState = keyboardState;

        }


    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Entities;


namespace Wheats_and_Wands.System
{
    class InputController
    {

        const float PLAYER_SPEED = 250f;

        Vector2 position = new Vector2(0,0);

        private Farmer _farmer;

        private KeyboardState _previousKeyboardState;

        private Display_Options _displayOptions;


        public InputController(Farmer farmer ,Display_Options displayOptions)
        {
            _farmer = farmer;
            _displayOptions = displayOptions;
        }

        public void ProcessControls(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) && !_previousKeyboardState.IsKeyDown(Keys.Up))
            {
                if (_farmer.OnGround && _farmer.Position.Y >= 0)
                {
                    _farmer.BeginJump(); //state = jumping
                }
            }
            else if (!keyboardState.IsKeyDown(Keys.Up) && _farmer.State == FarmerState.Jumping)
            {
                _farmer.CancelJump(); // FarmerState = falling
            }
            //move right
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                if (_farmer.Position.X <= WheatandWandsGame.WINDOW_WIDTH - 64 )
                {
                    
                    position.X = _farmer.Position.X + (PLAYER_SPEED * (float)gameTime.ElapsedGameTime.TotalSeconds);
                    position.Y = _farmer.Position.Y;
                    _farmer.Position = position;
                    
                }
                _farmer.State = FarmerState.Running;
                
            }
            //move left
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                if (_farmer.Position.X >= 0)
                {
                    
                    position.X = _farmer.Position.X - (PLAYER_SPEED * (float)gameTime.ElapsedGameTime.TotalSeconds);
                    position.Y = _farmer.Position.Y;
                    _farmer.Position = position;
                    
                   
                }
                _farmer.State = FarmerState.Running;
            }
            
            if (keyboardState.GetPressedKeyCount() == 0 && _farmer.State != FarmerState.Falling && _farmer.State != FarmerState.Jumping 
               // && _farmer.State != FarmerState.Running
                && ( _previousKeyboardState.IsKeyDown(Keys.Left) || _previousKeyboardState.IsKeyDown(Keys.Right)))
            {
                _farmer.State = FarmerState.Idle;
            }

            if (keyboardState.IsKeyDown(Keys.F4))
            {
                _displayOptions.FullScreenMode();

            }
            
            _previousKeyboardState = keyboardState;

        }


    }
}

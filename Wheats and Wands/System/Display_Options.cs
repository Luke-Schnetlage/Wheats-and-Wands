using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Wheats_and_Wands;
namespace Wheats_and_Wands
{
    class Display_Options
    {

        private GraphicsDeviceManager _graphics { get; set; }

        public Display_Options(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
        }

        public void FullScreenMode()
        {
            if (_graphics.IsFullScreen != true)
            {
                //_graphics.PreferredBackBufferHeight = 540;
                //_graphics.PreferredBackBufferWidth = 960;
                
                _graphics.IsFullScreen = true;
                _graphics.ApplyChanges();
            } else
            {
                //_graphics.PreferredBackBufferHeight = 540 ;
                //_graphics.PreferredBackBufferWidth = 960;
                _graphics.IsFullScreen = false;
                _graphics.ApplyChanges();
            }
            
        }
        
    }
}

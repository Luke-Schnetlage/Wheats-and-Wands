﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Graphics;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands.Levels
{
    class OptionScreen : Level
    {
        //Fullscreen option (less important)
        //Volume Option
        //start with mute/unmute
        //if time allows, variable volume 

        GameState _gameState;

        Texture2D _optionsScreen;
        Texture2D _titleScreenSheet;
        SpriteFont _font;

        Sprite _muteButtonSprite;
        Button _muteButton;

        Sprite _menuButtonSprite;
        Button _menuButton;

        public OptionScreen(GameState gameState,Texture2D optionsScreen,Texture2D titleScreenSheet, SpriteFont font)
        {
            _gameState = gameState;
            _font = font;
            _optionsScreen = optionsScreen;
            _titleScreenSheet = titleScreenSheet;

            _menuButtonSprite = new Sprite(titleScreenSheet, 357, 644, 250, 70, new Vector2(50, 990));
            _menuButton = new Button(_menuButtonSprite);
            _menuButton.Click += _menuButton_Click;

            _muteButtonSprite = new Sprite(titleScreenSheet, 357, 644, 250, 70, new Vector2(WheatandWandsGame.WINDOW_WIDTH/2 -125, 540+200));
            _muteButton = new Button(_muteButtonSprite);
            _muteButton.Click += _muteButton_Click;






        }
        public void _muteButton_Click(object sender, EventArgs e)
        {
            if (MediaPlayer.IsMuted)
            {
                MediaPlayer.IsMuted = false;
            } 
            else
            {
                MediaPlayer.IsMuted = true;
            }

        }
        
        public void _menuButton_Click(object sender, EventArgs e)
        {
            _gameState.state = States.TitleScreen;
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_optionsScreen, new Vector2(0, 0), Color.Black);
            
            _menuButton.Draw(gameTime,spriteBatch);
            _muteButton.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(_font, "MENU", new Vector2(150, 990 - 510), Color.White);
            spriteBatch.DrawString(_font, "MUTE", new Vector2(990 / 2 - 30, 225), Color.White); 
            //I have NO idea why, but if you change the text, only the last 2 letters print, DO NOT CHANGE TEXT

        }

        public override void Update(GameTime gameTime)
        {

            _menuButton.Update(gameTime);
            _muteButton.Update(gameTime);
        }


    }
}
﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Entities;
using Wheats_and_Wands.Graphics;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands.Levels
{
    class TutorialFarm : Level
    {
        private Vector2 _farmerStartPos = new Vector2(200, 325);
        private Farmer _farmer { get ; set ; }
        //SpriteBatch _spriteBatch;
        Sign _sign;
        HayBale _hayBale1;
        HayBale _hayBale2;
        HayBale _hayBale3;
        HayBale _hayBale4;
        List<HayBale> hayBales;
        GameState _gameState;

        public TutorialFarm( Farmer farmer, Texture2D signTexture, Texture2D msgBoxTexture, Texture2D haybale , SpriteFont font, GameState gameState)
        {
            _farmer = farmer;
            _sign = new Sign(new Sprite(signTexture, 0, 0, 83, 103, new Vector2(250, 325)), msgBoxTexture, font,_farmer, "Use WASD to move");
            _hayBale1 = new HayBale(new Sprite(haybale, 0, 0, 64, 64, new Vector2(525, 400)), farmer);
            _hayBale2 = new HayBale(new Sprite(haybale, 0, 0, 64, 64, new Vector2(650, 400)), farmer);
            _hayBale3 = new HayBale(new Sprite(haybale, 0, 0, 64, 64, new Vector2(650, 400-64)), farmer);
            _hayBale4 = new HayBale(new Sprite(haybale, 0, 0, 64, 64, new Vector2(650+64, 400)), farmer);
            hayBales = new List<HayBale>();
            hayBales.Add(_hayBale1);
            hayBales.Add(_hayBale2);
            hayBales.Add(_hayBale3);
            hayBales.Add(_hayBale4);
            _gameState = gameState;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //_spriteBatch = spriteBatch;
            _farmer.Draw(spriteBatch, gameTime);
            _sign.Draw(spriteBatch);
            foreach (HayBale haybale in hayBales)
            {
                haybale.Draw(spriteBatch, gameTime);
            }
            _hayBale1.Draw(spriteBatch, gameTime);



        }

        public override void Update(GameTime gameTime)
        {
            _farmer.Update(gameTime);
            
            
            _farmer._groundY = _farmerStartPos.Y;
            
            

            foreach (HayBale haybale in hayBales)
            {
                if (haybale.Collision(_farmer))
                {
                haybale.RejectMovment(_farmer, gameTime);
                }
            }
            
            _sign.Update(gameTime, _farmer);

            if( _farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                _gameState.state = States.Cave;
                _farmer.Position = new Vector2(50, 325);
            }


        }

        
    }
}

using Microsoft.Xna.Framework;
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
        private Vector2 _farmerStartPos = new Vector2(150, 325 - 35);
        private Farmer _farmer { get ; set ; }
        //SpriteBatch _spriteBatch;
        Sign _sign1;
        Sign _sign2;
        SquareBlock _hayBale1;
        SquareBlock _hayBale2;
        SquareBlock _hayBale3;
        SquareBlock _hayBale4;
        List<SquareBlock> hayBales;
        GameState _gameState;

        private List<ScrollBackground> _scrollBackgrounds;

        public TutorialFarm(Farmer farmer, Texture2D signTexture, Texture2D msgBoxTexture, Texture2D haybale , SpriteFont font, GameState gameState, 
            Texture2D barn, Texture2D farmBackground, Texture2D secondLayer, Texture2D thirdLayer, Texture2D lastLayer, 
            Texture2D farClouds, Texture2D fastClouds)
        {
            _farmer = farmer;
            _farmer.SpawnPosition = _farmerStartPos;
            _sign1 = new Sign(new Sprite(signTexture, 0, 0, 83, 103, new Vector2(200, 325)), msgBoxTexture, font,_farmer, "Use WASD to move");
            _sign2 = new Sign(new Sprite(signTexture, 0, 0, 83, 103, new Vector2(400, 325)), msgBoxTexture, font, _farmer, "Where is your cow ?");
            _hayBale1 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(515, 400 - 35)), farmer);
            _hayBale1 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(515, 400 - 35)), farmer);
            _hayBale2 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(650, 400 - 35)), farmer);
            _hayBale3 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(650, 400-64 - 35)), farmer);
            _hayBale4 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(650+64, 400 - 35)), farmer);
            hayBales = new List<SquareBlock>();
            hayBales.Add(_hayBale1);
            hayBales.Add(_hayBale2);
            hayBales.Add(_hayBale3);
            hayBales.Add(_hayBale4);
            _gameState = gameState;

            _scrollBackgrounds = new List<ScrollBackground>()
            {
                new ScrollBackground(barn, _farmer, 0f)
                {
                    Layer = 0.1f //Front Layer
                },
                new ScrollBackground(farmBackground, _farmer, 0f)
                {
                    Layer = 0.1f
                },
                new ScrollBackground(secondLayer, _farmer, 0f)
                {
                    Layer = 0.11f
                },
                new ScrollBackground(thirdLayer, _farmer, 0f)
                {
                    Layer = 0.12f
                },
                new ScrollBackground(fastClouds, _farmer, 3f, true)
                {
                    Layer = 0.4f
                },
                new ScrollBackground(farClouds, _farmer, .5f, true)
                {
                    Layer = 0.4f
                },
                new ScrollBackground(lastLayer, _farmer, 0f)
                {
                    Layer = 1f //Back Layer
                }
            };
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //_spriteBatch = spriteBatch;
            _farmer.Draw(spriteBatch, gameTime);
            _sign1.Draw(spriteBatch);
            _sign2.Draw(spriteBatch);
            foreach (SquareBlock haybale in hayBales)
            {
                haybale.Draw(spriteBatch, gameTime);
            }
            //_hayBale1.Draw(spriteBatch, gameTime);

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Draw(gameTime, spriteBatch);


        }

        public override void Update(GameTime gameTime)
        {
            _farmer.Update(gameTime);
                       
            _farmer._groundY = _farmerStartPos.Y;
            foreach (SquareBlock haybale in hayBales)
            {
                haybale.Update(gameTime);
            }
            _sign1.Update(gameTime, _farmer);
            _sign2.Update(gameTime, _farmer);
            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Update(gameTime);

            
            //level leaving logic
            if( _farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                _gameState.state = States.FarmToCave;
                _farmer.Position = new Vector2(50, 325 - 35);
            }
        }  
    }
}

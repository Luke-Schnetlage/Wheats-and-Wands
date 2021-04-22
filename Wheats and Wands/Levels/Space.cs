using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Wheats_and_Wands.Entities;
using Wheats_and_Wands.Graphics;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands.Levels
{
    class Space : Level
    {
        private Vector2 _farmerStartPos;
        private GameState _gameState;
        private Farmer _farmer;

        FallingKillObject _asteroid1;
        FallingKillObject _asteroid2;
        FallingKillObject _asteroid3;
        FallingKillObject _asteroid4;
        FallingKillObject _asteroid5;

        private List<ScrollBackground> _scrollBackgrounds;

        Random rand;

        public Space(Texture2D background, Farmer farmer, GameState gameState, Texture2D asteroid, SpriteFont font)
        {
            _gameState = gameState;
            _farmer = farmer;
            _farmerStartPos = new Vector2(50, 325 - 35);

            rand = new Random();

            _asteroid1 = new FallingKillObject(new Sprite(asteroid, 0, 0, 100, 115, new Vector2(270, -120)), _farmer, new TimeSpan(0, 0, rand.Next(1, 1)));
            _asteroid2 = new FallingKillObject(new Sprite(asteroid, 0, 0, 100, 115, new Vector2(350, -120)), _farmer, new TimeSpan(0, 0, rand.Next(1, 4)));
            _asteroid3 = new FallingKillObject(new Sprite(asteroid, 0, 0, 100, 115, new Vector2(480, -120)), _farmer, new TimeSpan(0, 0, rand.Next(2, 3)));
            _asteroid4 = new FallingKillObject(new Sprite(asteroid, 0, 0, 100, 115, new Vector2(600, -120)), _farmer, new TimeSpan(0, 0, rand.Next(1, 1)));
            _asteroid5 = new FallingKillObject(new Sprite(asteroid, 0, 0, 100, 115, new Vector2(640, -120)), _farmer, new TimeSpan(0, 0, rand.Next(2, 6)));


            _scrollBackgrounds = new List<ScrollBackground>()
            {
                new ScrollBackground(background, _farmer, 0f)
                {
                    Layer = 0.1f
                }
            };


        }

        public override void Update(GameTime gameTime)
        {
            _farmer.Update(gameTime);
            if (_farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                _gameState.state = States.CreditScreen;
                _farmer.Position = new Vector2(50, 325 - 35);
            }

            _asteroid1.Update(gameTime);
            _asteroid2.Update(gameTime);
            _asteroid3.Update(gameTime);
            _asteroid4.Update(gameTime);
            _asteroid5.Update(gameTime);

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _farmer.Draw(spriteBatch, gameTime);

            _asteroid1.Draw(spriteBatch, gameTime);
            _asteroid2.Draw(spriteBatch, gameTime);
            _asteroid3.Draw(spriteBatch, gameTime);
            _asteroid4.Draw(spriteBatch, gameTime);
            _asteroid5.Draw(spriteBatch, gameTime);

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Draw(gameTime, spriteBatch);
        }
    }
}

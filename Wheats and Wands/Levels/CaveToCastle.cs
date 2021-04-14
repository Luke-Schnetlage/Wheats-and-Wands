using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Entities;
using Wheats_and_Wands.Graphics;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands.Levels
{
    class CaveToCastle : Level
    {
        private Vector2 _farmerStartPos;

        private GameState _gameState;
        private Farmer _farmer;

        private List<ScrollBackground> _scrollBackgrounds;

        public CaveToCastle(Farmer farmer, GameState gameState, Texture2D front, Texture2D back, Texture2D secondLayer, Texture2D thirdLayer,
            Texture2D fourthLayer, Texture2D fifthLayer, Texture2D sixthLayer)
        {
            _farmer = farmer;
            _gameState = gameState;
            _farmerStartPos = new Vector2(50, 325);

            _scrollBackgrounds = new List<ScrollBackground>()
            {
                new ScrollBackground(front, _farmer, 0f)
                {
                    Layer = 0.1f
                },
                new ScrollBackground(back, _farmer, 0f)
                {
                    Layer = 0.11f
                },
                new ScrollBackground(secondLayer, _farmer, 0f)
                {
                    Layer = 0.2f
                },
                new ScrollBackground(thirdLayer, _farmer, 0f)
                {
                    Layer = 0.21f
                },
                new ScrollBackground(fourthLayer, _farmer, 0f)
                {
                    Layer = 0.22f
                },
                new ScrollBackground(fifthLayer, _farmer, 0f)
                {
                    Layer = 0.23f
                },
                new ScrollBackground(sixthLayer, _farmer, 0f)
                {
                    Layer = 1f
                }
            };
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _farmer.Draw(spriteBatch, gameTime);

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Draw(gameTime, spriteBatch);
        }
        public override void Update(GameTime gameTime)
        {
            _farmer.Update(gameTime);
            _farmer._groundY = _farmerStartPos.Y;


            if (_farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                _gameState.state = States.Castle;
                _farmer.Position = new Vector2(50, 325);
            }

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Update(gameTime);
        }
    }
}

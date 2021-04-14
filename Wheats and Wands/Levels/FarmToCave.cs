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
    class FarmToCave : Level
    {
        private Vector2 _farmerStartPos;

        private GameState _gameState;
        private Farmer _farmer;

        private List<ScrollBackground> _scrollBackgrounds;

        public FarmToCave(Farmer farmer, GameState gameState, Texture2D floor, Texture2D secondLayer, Texture2D thirdLayer, 
            Texture2D farClouds, Texture2D fastClouds, Texture2D sky)
        {
            _farmer = farmer;
            _gameState = gameState;
            _farmerStartPos = new Vector2(50, 325);

            _scrollBackgrounds = new List<ScrollBackground>()
            {
                new ScrollBackground(floor, _farmer, 0f)
                {
                    Layer = 0.1f
                },
                new ScrollBackground(secondLayer, _farmer, 0f)
                {
                    Layer = 0.15f
                },
                new ScrollBackground(thirdLayer, _farmer, 0f)
                {
                    Layer = 0.16f
                },
                new ScrollBackground(farClouds, _farmer, .5f, true)
                {
                    Layer = 0.2f
                },
                new ScrollBackground(fastClouds, _farmer, 3f, true)
                {
                    Layer = 0.2f
                },
                new ScrollBackground(sky, _farmer, 0f)
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
            //if (_farmer.Position.X < _farmer.prevPosition.X)
            //    _farmer.HorizontalVelocity.X = -3f;
            //else if (_farmer.Position.X > _farmer.prevPosition.X)
            //    _farmer.HorizontalVelocity.X = 3f;
            //else
            //    _farmer.HorizontalVelocity.X = 0f;

            _farmer.Update(gameTime);
            _farmer._groundY = _farmerStartPos.Y;


            if (_farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                _gameState.state = States.Cave;
                _farmer.Position = new Vector2(50, 325);
            }

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Update(gameTime);
        }
    }
}

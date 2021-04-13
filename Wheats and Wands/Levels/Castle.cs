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
    class Castle : Level
    {
        private Vector2 _farmerStartPos;
        private GameState _gameState;
        private Farmer _farmer;

        private List<ScrollBackground> _scrollBackgrounds;

        public Castle(Farmer farmer, GameState gameState, Texture2D floor, Texture2D firstLayer, Texture2D secondLayer, Texture2D thirdLayer,
            Texture2D fourthLayer, Texture2D fifthLayer, Texture2D sixthLayer, Texture2D seventhLayer, Texture2D lastLayer)
        {
            _gameState = gameState;
            _farmer = farmer;
            _farmerStartPos = new Vector2(50, 325);

            _scrollBackgrounds = new List<ScrollBackground>()
            {
                new ScrollBackground(floor, _farmer, 0f)
                {
                    Layer = 0.1f
                },
                new ScrollBackground(firstLayer, _farmer, 0f)
                {
                    Layer = 0.11f
                },
                new ScrollBackground(secondLayer, _farmer, 0f)
                {
                    Layer = 0.12f
                },
                new ScrollBackground(thirdLayer, _farmer, 0f)
                {
                    Layer = 0.13f
                },
                new ScrollBackground(fourthLayer, _farmer, 0f)
                {
                    Layer = 0.14f
                },
                new ScrollBackground(fifthLayer, _farmer, 0f)
                {
                    Layer = 0.15f
                },
                new ScrollBackground(sixthLayer, _farmer, 0f)
                {
                    Layer = 0.16f
                },
                new ScrollBackground(seventhLayer, _farmer, 0f)
                {
                    Layer = 0.17f
                },
                new ScrollBackground(lastLayer, _farmer, 0f)
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

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Update(gameTime);
        }
    }
}

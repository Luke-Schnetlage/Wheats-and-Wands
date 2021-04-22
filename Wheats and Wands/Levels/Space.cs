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
    class Space : Level
    {
        private Vector2 _farmerStartPos;
        private GameState _gameState;
        private Farmer _farmer;

        private List<ScrollBackground> _scrollBackgrounds;

        public Space(Texture2D background, Farmer farmer, GameState gameState, SpriteFont font)
        {
            _gameState = gameState;
            _farmer = farmer;
            _farmerStartPos = new Vector2(50, 325 - 35);

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

            if (_farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                _gameState.state = States.CreditScreen;
                _farmer.Position = new Vector2(50, 325 - 35);
            }

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Draw(gameTime, spriteBatch);
        }
    }
}

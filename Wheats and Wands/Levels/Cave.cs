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
    class Cave : Level
    {
        Texture2D _background;
        Vector2 _farmerStartPos;

        GameState _gameState;
        Farmer _farmer;
        public Cave(Farmer farmer, GameState gameState, Texture2D background)
        {
            _gameState = gameState;
            _farmer = farmer;
            _background = background;
            _farmerStartPos = new Vector2(50,325);


        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_background, _frame, Color.White);
            _farmer.Draw(spriteBatch, gameTime);
            
        }

        public override void Update(GameTime gameTime)
        {
            _farmer.Update(gameTime);
            _farmer._groundY = _farmerStartPos.Y;

            if (_farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                //_gameState.state = States.CreditScreen;
            }


        }


    }
}

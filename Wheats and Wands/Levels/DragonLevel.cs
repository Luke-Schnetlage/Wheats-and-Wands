using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Wheats_and_Wands.Entities;
using Wheats_and_Wands.Graphics;
using Wheats_and_Wands.System;

namespace Wheats_and_Wands.Levels
{
    class DragonLevel : Level
    {
        private Vector2 _farmerStartPos;
        private GameState _gameState;
        private Farmer _farmer;

        private Dragon _dragon;
        private FireBreath _fire;

        private SquareBlock _platform1;
        private SquareBlock _platform2;
        private SquareBlock _platform3;

        private List<ScrollBackground> _scrollBackgrounds;

        public DragonLevel(Farmer farmer, GameState gameState, Texture2D floor, Texture2D firstLayer, Texture2D secondLayer, Texture2D thirdLayer,
            Texture2D fourthLayer, Texture2D fifthLayer, Texture2D sixthLayer, Texture2D seventhLayer, Texture2D lastLayer, Texture2D dragonTexture,
            Texture2D firebreath)
        {
            _gameState = gameState;
            _farmer = farmer;
            _farmerStartPos = new Vector2(50, 325 - 35);

            _dragon = new Dragon(null, _farmer, dragonTexture);
            _fire = new FireBreath(null, farmer, firebreath);

            _platform1 = new SquareBlock(new Sprite(floor, 430, 408, 145, 30, new Vector2(200, 325)), _farmer);
            _platform2 = new SquareBlock(new Sprite(floor, 430, 408, 145, 30, new Vector2(425, 245)), _farmer);
            _platform3 = new SquareBlock(new Sprite(floor, 430, 408, 145, 30, new Vector2(600, 235)), _farmer);

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

            _dragon.Draw(spriteBatch);
            if (_dragon.IsAlive)
                _fire.Draw(spriteBatch);

            _platform1.Draw(spriteBatch, gameTime);
            _platform2.Draw(spriteBatch, gameTime);
            _platform3.Draw(spriteBatch, gameTime);

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (_farmer.Position.X > _farmer.prevPosition.X)
                _farmer.HorizontalVelocity.X = 3f;
            else
                _farmer.HorizontalVelocity.X = 0f;

            _farmer.Update(gameTime);
            _farmer._groundY = _farmerStartPos.Y;

            if (_farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                _gameState.state = States.Castle2;
                _farmer.Position = new Vector2(50, 325 - 35);
            }

            if ((int)gameTime.TotalGameTime.TotalSeconds % 3 == 0)
            {
                _fire.BreathFire();
            }

            _dragon.Update(gameTime);
            if (_dragon.IsAlive)
                _fire.Update(gameTime);

            _platform1.Update(gameTime);
            _platform2.Update(gameTime);
            _platform3.Update(gameTime);

            if ((int)gameTime.TotalGameTime.TotalSeconds % 2 == 0)
            {
                _platform1._sprite.position = new Vector2(_platform1._sprite.position.X, _platform1._sprite.position.Y - (float)1.8);
                _platform2._sprite.position = new Vector2(_platform2._sprite.position.X, _platform2._sprite.position.Y + (float)3);
                _platform3._sprite.position = new Vector2(_platform3._sprite.position.X, _platform3._sprite.position.Y - (float)1.8);
            }
            if ((int)gameTime.TotalGameTime.TotalSeconds % 2 == 1)
            {
                _platform1._sprite.position = new Vector2(_platform1._sprite.position.X, _platform1._sprite.position.Y + (float)1.8);
                _platform2._sprite.position = new Vector2(_platform2._sprite.position.X, _platform2._sprite.position.Y - (float)3);
                _platform3._sprite.position = new Vector2(_platform3._sprite.position.X, _platform3._sprite.position.Y + (float)1.8);
            }

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Update(gameTime);
        }

    }
}

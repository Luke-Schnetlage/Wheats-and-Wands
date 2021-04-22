using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
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

        private SquareBlock _hayBale1;
        private SquareBlock _hayBale2;
        private SquareBlock _hayBale3;
        private SquareBlock _hayBale4;
        private SquareBlock _hayBale5;
        private SquareBlock _hayBale6;
        private SquareBlock _floatinghayBale1;
        private SquareBlock _floatinghayBale2;

        private List<SquareBlock> haybales;
        private List<SquareBlock> floatinghaybales;

        public FarmToCave(Farmer farmer, GameState gameState, Texture2D floor, Texture2D secondLayer, Texture2D thirdLayer,
            Texture2D farClouds, Texture2D fastClouds, Texture2D sky, Texture2D haybale)
        {
            _farmer = farmer;
            _gameState = gameState;
            _farmerStartPos = new Vector2(50, 325 - 35);

            _hayBale1 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(150, 400 - 35)), farmer);
            _hayBale2 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(150 + 64, 400 - 35)), farmer);
            _hayBale3 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(150 + 64, 400 - 64 - 35)), farmer);
            _hayBale4 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(600, 400 - 35)), farmer);
            _hayBale5 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(600, 400 - 64 - 35)), farmer);
            _hayBale6 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(600 + 64, 400 - 35)), farmer);
            _floatinghayBale1 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(150 + 128 + 45, 400 - 64 - 35)), farmer);//+75
            _floatinghayBale2 = new SquareBlock(new Sprite(haybale, 0, 0, 64, 64, new Vector2(600 - 64 - 45, 400 - 64 - 35)), farmer);//-75

            haybales = new List<SquareBlock>();
            haybales.Add(_hayBale1);
            haybales.Add(_hayBale2);
            haybales.Add(_hayBale3);
            haybales.Add(_hayBale4);
            haybales.Add(_hayBale5);
            haybales.Add(_hayBale6);
            haybales.Add(_floatinghayBale1);
            haybales.Add(_floatinghayBale2);

            floatinghaybales = new List<SquareBlock>();
            floatinghaybales.Add(_floatinghayBale1);
            floatinghaybales.Add(_floatinghayBale2);

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
            foreach (SquareBlock haybale in haybales)
            {
                haybale.Draw(spriteBatch, gameTime);
            }
            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Draw(gameTime, spriteBatch);
        }
        public override void Update(GameTime gameTime)
        {

            _farmer.Update(gameTime);
            _farmer._groundY = _farmerStartPos.Y;

            int movmentspeed = 0;

            if ((int)gameTime.TotalGameTime.TotalSeconds % 4 == 0)
            {
                movmentspeed = 2;
            }
            if ((int)gameTime.TotalGameTime.TotalSeconds % 4 == 2)
            {
                movmentspeed = -2;
            }

            if (_floatinghayBale1._sprite.position.X + movmentspeed > 150 + 64 + 64 && _floatinghayBale1._sprite.position.X + movmentspeed + 64 < 150 + 64 + 225)
            {
                _floatinghayBale1._sprite.position = new Vector2(_floatinghayBale1._sprite.position.X + movmentspeed, _floatinghayBale1._sprite.position.Y);
                if (_floatinghayBale1.TopCollision(_farmer))
                {
                    _farmer.Position = new Vector2(_farmer.Position.X + movmentspeed, _farmer.Position.Y);
                }
                _floatinghayBale2._sprite.position = new Vector2(_floatinghayBale2._sprite.position.X - movmentspeed, _floatinghayBale2._sprite.position.Y);
                if (_floatinghayBale2.TopCollision(_farmer))
                {
                    _farmer.Position = new Vector2(_farmer.Position.X - movmentspeed, _farmer.Position.Y);
                }
            }

            if (_farmer.Position.Y + _farmer._sprite.Height > 400 &&
                _farmer.Position.X > 150 + 64 &&
                _farmer.Position.X < 600)
            {
                _farmer.IsAlive = false;
                _farmer.Respawn();
            }

            foreach (SquareBlock haybale in haybales)
            {
                haybale.Update(gameTime);
            }

            if (_farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                _gameState.state = States.Cave;
                _farmer.Position = new Vector2(50, 325 - 35);
            }

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Update(gameTime);
        }
    }
}

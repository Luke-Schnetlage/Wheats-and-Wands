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

        Spike _pit1;
        Spike _pit2;
        Spike _pit3;

        List<Spike> pits;


        JumpingKillEntity fireball1;
        JumpingKillEntity fireball2;


        float _speed;


        private List<ScrollBackground> _scrollBackgrounds;

        public Castle(Farmer farmer, GameState gameState, Texture2D floor, Texture2D firstLayer, Texture2D secondLayer, Texture2D thirdLayer,
            Texture2D fourthLayer, Texture2D fifthLayer, Texture2D sixthLayer, Texture2D seventhLayer, Texture2D lastLayer,Texture2D lava, Texture2D fireball)
        {
            _gameState = gameState;
            _farmer = farmer;
            _farmerStartPos = new Vector2(50, 325 - 35);

            _pit1 = new Spike(new Sprite(lava, 0, 0, 80, 128, new Vector2(375, 412)), _farmer);
            _pit2 = new Spike(new Sprite(lava, 0, 0, 75, 128, new Vector2(570, 412)), _farmer);
            _pit3 = new Spike(new Sprite(lava, 0, 0, 95, 128, new Vector2(750, 412)), _farmer);
            pits = new List<Spike>();
            pits.Add(_pit1);
            pits.Add(_pit2);
            pits.Add(_pit3);

            fireball1 = new JumpingKillEntity(new Sprite(fireball, 16, 8, 32, 37, new Vector2(400, 412)), farmer);
            fireball2 = new JumpingKillEntity(new Sprite(fireball, 16, 8, 32, 37, new Vector2(750 + 25, 412)), farmer);


            _scrollBackgrounds = new List<ScrollBackground>()
            {
                new ScrollBackground(floor, _farmer, 30f/2)
                {
                    Layer = 0.1f
                },
                new ScrollBackground(firstLayer, _farmer, 30f/2)
                {
                    Layer = 0.11f
                },
                new ScrollBackground(secondLayer, _farmer, 12f)
                {
                    Layer = 0.12f
                },
                new ScrollBackground(thirdLayer, _farmer, 10f)
                {
                    Layer = 0.13f
                },
                new ScrollBackground(fourthLayer, _farmer, 8f)
                {
                    Layer = 0.14f
                },
                new ScrollBackground(fifthLayer, _farmer, 6f)
                {
                    Layer = 0.15f
                },
                new ScrollBackground(sixthLayer, _farmer, 4f)
                {
                    Layer = 0.16f
                },
                new ScrollBackground(seventhLayer, _farmer, 3f)
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
           
            foreach (Spike p in pits){
                p.Draw(spriteBatch, gameTime);
            }
            fireball1.Draw(spriteBatch, gameTime);
            fireball2.Draw(spriteBatch, gameTime);






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


            _speed = (float)(_farmer.HorizontalVelocity.X * gameTime.ElapsedGameTime.TotalSeconds * 5f);
            _speed *= _farmer.HorizontalVelocity.X;

            foreach (Spike p in pits)
            {
                if (_farmer.Position.X + _farmer._sprite.Width / 2 > p._sprite.position.X &&
                _farmer.Position.X + _farmer._sprite.Width / 2 < p._sprite.position.X + p._sprite.Width)
                {
                    p.Update(gameTime);
                }

                p._sprite.position = new Vector2(p._sprite.position.X - _speed, p._sprite.position.Y);
                if (p._sprite.position.X < _farmerStartPos.X + _farmer._sprite.Width && p._sprite.position.X + p._sprite.Width > _farmerStartPos.X) //+ _farmer._sprite.Width/2)
                {
                    _farmerStartPos = new Vector2(p._sprite.position.X + p._sprite.Width + 50, _farmerStartPos.Y);
                }
            }

            fireball1.Update(gameTime);
            fireball1._sprite.position = new Vector2(fireball1._sprite.position.X - _speed, fireball1._sprite.position.Y);
            fireball2.Update(gameTime);
            fireball2._sprite.position = new Vector2(fireball2._sprite.position.X - _speed, fireball2._sprite.position.Y);

            if (_farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                _gameState.state = States.DragonLevel;
                _farmer.Position = new Vector2(50, 325 - 35);
            }

            

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Update(gameTime);
        }
    }
}

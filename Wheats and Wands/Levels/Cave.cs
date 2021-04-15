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
        //Texture2D _background;
        private Vector2 _farmerStartPos;

        private GameState _gameState;
        private Farmer _farmer;

        private Spike _bigSpike;
        private Spike _smallSpike;
        private List<Spike> spikes;

        private SquareBlock brick1;

        private List<ScrollBackground> _scrollBackgrounds;
        public Cave(Farmer farmer, GameState gameState, Texture2D floor, Texture2D firstLayer, Texture2D secondLayer,
            Texture2D thirdLayer, Texture2D fourthLayer, Texture2D fifthLayer, Texture2D sixthLayer, Texture2D spikeTextures)
        {
            _gameState = gameState;
            _farmer = farmer;
            _farmerStartPos = new Vector2(50, 290);
            _bigSpike = new Spike(new Sprite(spikeTextures, 122, 0, 81, 69, new Vector2(200, 360)),_farmer);
            _smallSpike = new Spike(new Sprite(spikeTextures, 0, 0, 87, 63, new Vector2(700, 360)),_farmer);

            brick1 = new SquareBlock(new Sprite(floor, 495, 408, 64, 64, new Vector2(200 - 64, 290 + 64)), _farmer);
            //495,408

            spikes = new List<Spike>();
            spikes.Add(_smallSpike);
            spikes.Add(_bigSpike);

            _scrollBackgrounds = new List<ScrollBackground>()
            {
                new ScrollBackground(floor, _farmer, 30f)
                {
                    Layer = 0.1f
                },
                new ScrollBackground(firstLayer, _farmer, 30f)
                {
                    Layer = 0.11f
                },
                new ScrollBackground(secondLayer, _farmer, 20f)
                {
                    Layer = 0.12f
                },
                new ScrollBackground(thirdLayer, _farmer, 10f)
                {
                    Layer = 0.13f
                },
                new ScrollBackground(fourthLayer, _farmer, 7f)
                {
                    Layer = 0.14f
                },
                new ScrollBackground(fifthLayer, _farmer, 5f)
                {
                    Layer = 0.15f
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

            foreach (Spike s in spikes)
            {
                s.Draw(spriteBatch, gameTime);
            }
            brick1.Draw(spriteBatch, gameTime);


            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Draw(gameTime, spriteBatch);

            
        }

        public override void Update(GameTime gameTime)
        {
            _farmer.SpawnPosition = _farmerStartPos;
            //_farmer.Respawn();
            //_farmer.Position = _farmerStartPos;
            //_farmer.IsAlive = true;
                
            
            _farmer._groundY = _farmerStartPos.Y;

            if (_farmer.Position.X < _farmer.prevPosition.X)
                _farmer.HorizontalVelocity.X = -3f;
            else if (_farmer.Position.X > _farmer.prevPosition.X)
                _farmer.HorizontalVelocity.X = 3f;
            else
                _farmer.HorizontalVelocity.X = 0f;

            _farmer.Update(gameTime);
            _farmer._groundY = _farmerStartPos.Y;



            if (_farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                _gameState.state = States.CaveToCastle;
                _farmer.Position = new Vector2(50, 325);
            }

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Update(gameTime);

            foreach (Spike s in spikes)
            {
                s.Kill(_farmer);
            }
            brick1.Update(gameTime);


        }
    }
}

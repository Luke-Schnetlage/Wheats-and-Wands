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

        private Pit _smallPit;
        private Pit _bigPit;
        private List<Pit> pits;

        SkinSwapOrb _orb;
        
        float _speed;
        

        private List<ScrollBackground> _scrollBackgrounds;
        public Cave(Farmer farmer, GameState gameState, Texture2D floor, Texture2D firstLayer, Texture2D secondLayer,
            Texture2D thirdLayer, Texture2D fourthLayer, Texture2D fifthLayer, Texture2D sixthLayer, Texture2D spikeTextures,
            Texture2D pitTextures, Texture2D orb)
        {
            _gameState = gameState;
            _farmer = farmer;
            _farmerStartPos = new Vector2(50, 290);//290
            _smallSpike = new Spike(new Sprite(spikeTextures, 0, 0, 87, 63, new Vector2(603, WheatandWandsGame.WINDOW_HEIGHT-63)),_farmer);
            _bigSpike = new Spike(new Sprite(spikeTextures, 122, 0, 81, 69, new Vector2(330, WheatandWandsGame.WINDOW_HEIGHT - 69)), _farmer);

            _smallPit = new Pit(new Sprite(pitTextures, 330, 408, 75, 132, new Vector2(330, 408)), _farmer);
            _bigPit = new Pit(new Sprite(pitTextures, 603, 408, 93, 123, new Vector2(603, 408)), _farmer);

            pits = new List<Pit>();
            pits.Add(_smallPit);
            pits.Add(_bigPit);

            spikes = new List<Spike>();
            spikes.Add(_smallSpike);
            spikes.Add(_bigSpike);

            _orb = new SkinSwapOrb(new Sprite(orb, 0, 0, 64, 64, new Vector2(470, 310)), farmer, Farmer.Skins.fancy);



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
                new ScrollBackground(secondLayer, _farmer, 20f/2)
                {
                    Layer = 0.12f
                },
                new ScrollBackground(thirdLayer, _farmer, 10f/2)
                {
                    Layer = 0.13f
                },
                new ScrollBackground(fourthLayer, _farmer, 7f/2)
                {
                    Layer = 0.14f
                },
                new ScrollBackground(fifthLayer, _farmer, 5f/2)
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

            foreach (Pit p in pits)
            {
                p.Draw(spriteBatch, gameTime);

            }
            _orb.Draw(spriteBatch);



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



            int smallPitEdge = (int)_smallPit._sprite.position.X;
            int bigPitEdge = (int)_bigPit._sprite.position.X;

            if ((_farmer.Position.X + _farmer._sprite.Width / 2 > smallPitEdge &&
                _farmer.Position.X + _farmer._sprite.Width / 2 < smallPitEdge + _smallPit._sprite.Width) ||
                (_farmer.Position.X + _farmer._sprite.Width / 2 > bigPitEdge &&
                _farmer.Position.X + _farmer._sprite.Width / 2 < bigPitEdge + _bigPit._sprite.Width))
            {
                _farmer._groundY = WheatandWandsGame.WINDOW_HEIGHT - 10;
            }
            if(smallPitEdge < _farmerStartPos.X + _farmer._sprite.Width && smallPitEdge + _smallPit._sprite.Width > _farmerStartPos.X) //+ _farmer._sprite.Width/2)
            {
                _farmerStartPos = new Vector2(smallPitEdge + _smallPit._sprite.Width + 50, _farmerStartPos.Y);
            }
            if (bigPitEdge < _farmerStartPos.X + _farmer._sprite.Width && bigPitEdge + _bigPit._sprite.Width > _farmerStartPos.X) //+ _farmer._sprite.Width/2)
            {
                _farmerStartPos = new Vector2(bigPitEdge + _bigPit._sprite.Width + 50, _farmerStartPos.Y);
            }

            if (_farmer.Position.X > _farmer.prevPosition.X)
                _farmer.HorizontalVelocity.X = 3f;
            else
                _farmer.HorizontalVelocity.X = 0f;

            _farmer.Update(gameTime);
            _farmer._groundY = _farmerStartPos.Y;

            if (_farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                _gameState.state = States.CaveToCastle;
                _farmer.Position = new Vector2(50, 325 - 35);
            }

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Update(gameTime);

            foreach (Spike s in spikes)
            {
                s.Update(gameTime);

                s._sprite.position = new Vector2(s._sprite.position.X - _speed, s._sprite.position.Y);
            }
            
            foreach (Pit p in pits)
            {
                p.Update(gameTime);
                p._sprite.position = new Vector2(p._sprite.position.X - _speed, p._sprite.position.Y);
            }

            _orb.Update(gameTime);
            _orb._sprite.position = new Vector2(_orb._sprite.position.X - _speed, _orb._sprite.position.Y);
            _speed = (float)(_farmer.HorizontalVelocity.X * gameTime.ElapsedGameTime.TotalSeconds * 5f);
            _speed *= _farmer.HorizontalVelocity.X;


        }
    }
}

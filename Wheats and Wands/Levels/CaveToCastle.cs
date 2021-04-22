using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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

        private FallingKillObject _wideStalactite;
        private FallingKillObject _skinnyStalactite;
        private FallingKillObject _bigStalactite;

        private DoubleJumpTotem _totem;

        private MessageBox _jumpmessage;

        private List<ScrollBackground> _scrollBackgrounds;
        private Random rand;

        public CaveToCastle(Farmer farmer, GameState gameState, Texture2D front, Texture2D back, Texture2D secondLayer, Texture2D thirdLayer,
            Texture2D fourthLayer, Texture2D fifthLayer, Texture2D sixthLayer, Texture2D spikes, Texture2D totemHead, Texture2D messageBox, SpriteFont font)
        {
            _farmer = farmer;
            _gameState = gameState;
            _farmerStartPos = new Vector2(50, 290);

            rand = new Random();
            _wideStalactite = new FallingKillObject(new Sprite(spikes, 338, 0, 45, 44, new Vector2(290, 0)), _farmer, new TimeSpan(0, 0, rand.Next(1, 3)));
            _skinnyStalactite = new FallingKillObject(new Sprite(spikes, 393, 0, 41, 62, new Vector2(420, 0)), _farmer, new TimeSpan(0, 0, rand.Next(1, 3)));
            _bigStalactite = new FallingKillObject(new Sprite(spikes, 442, 0, 50, 70, new Vector2(640, 0)), _farmer, new TimeSpan(0, 0, rand.Next(2, 4)));
            _totem = new DoubleJumpTotem(null, farmer, totemHead);
            _jumpmessage = new MessageBox(new Sprite(messageBox, 0, 0, 348, 124), font);

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

            _wideStalactite.Draw(spriteBatch, gameTime);
            _skinnyStalactite.Draw(spriteBatch, gameTime);
            _bigStalactite.Draw(spriteBatch, gameTime);

            _totem.Draw(spriteBatch);
            if (_totem.Collision(_farmer))
            {
                _jumpmessage.Draw(spriteBatch, "Double-Jump Unlocked");
            }
            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Draw(gameTime, spriteBatch);
        }
        public override void Update(GameTime gameTime)
        {
            _farmer.SpawnPosition = _farmerStartPos;
            _farmer.Update(gameTime);

            _wideStalactite.Update(gameTime);
            _skinnyStalactite.Update(gameTime);
            _bigStalactite.Update(gameTime);
            _wideStalactite._hangTime = new TimeSpan(0, 0, rand.Next(1, 3));
            _skinnyStalactite._hangTime = new TimeSpan(0, 0, rand.Next(1, 3));
            _bigStalactite._hangTime = new TimeSpan(0, 0, rand.Next(1, 3));

            _totem.Update(gameTime);


            _farmer._groundY = _farmerStartPos.Y;
            if (_farmer.Position.X + _farmer._sprite.Width > WheatandWandsGame.WINDOW_WIDTH - 10)
            {
                _gameState.state = States.Castle;
                _farmer.Position = new Vector2(50, 325 - 35);
            }

            foreach (var scrollBackground in _scrollBackgrounds)
                scrollBackground.Update(gameTime);
        }
    }
}

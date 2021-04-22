using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Wheats_and_Wands.Entities;

namespace Wheats_and_Wands.Graphics
{
    public class ScrollBackground : Component
    {

        private bool _constantSpeed; //Determines if the sprite moves even if the player is not moving
        private float _layer; //background
        private float _scrollingSpeed; //speed of the sprite
        private List<SpriteLayer> _spritesLayers;
        private readonly Farmer _farmer; //keeps track of the velocity of the player
        private float _speed; //Calculation of scrollingSpeed, player velocity, and gameTime
        public float Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
                foreach (var spriteLayer in _spritesLayers) //Loops through a list to assign each sprite to _layer
                    spriteLayer.Layer = _layer;
            }
        }
        public ScrollBackground(Texture2D texture, Farmer farmer, float scrollingSpeed, bool constantSpeed = false)
            : this(new List<Texture2D>() { texture, texture }, farmer, scrollingSpeed, constantSpeed) //basically initializes from second constructor
        {

        }
        public ScrollBackground(List<Texture2D> textures, Farmer farmer, float scrollingSpeed, bool constantSpeed = false)
        {
            _farmer = farmer;
            _scrollingSpeed = scrollingSpeed;
            _spritesLayers = new List<SpriteLayer>(); //Initialization
            _constantSpeed = constantSpeed;

            for (int i = 0; i < textures.Count; i++)
            {
                var texture = textures[i];

                _spritesLayers.Add(new SpriteLayer(texture)
                {
                    //Allows the sprites to move a different times (-1 prevents sprite tear, but it doesn't work
                    Position = new Vector2(i * texture.Width - 1, WheatandWandsGame.WINDOW_HEIGHT - texture.Height) //Keeps sprites bottom-locked
                });
            }

        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var spriteLayer in _spritesLayers)
                spriteLayer.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            CalculateSpeed(gameTime);
            PositionChecker();
        }

        private void CalculateSpeed(GameTime gameTime)
        {
            _speed = (float)(_scrollingSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            if (!_constantSpeed || _farmer.HorizontalVelocity.X != 0) //If players moves, the background will move faster
                _speed *= _farmer.HorizontalVelocity.X;

            foreach (var spriteLayer in _spritesLayers) //background moves opposite of player
                spriteLayer.Position.X -= _speed;
        }

        private void PositionChecker()
        {
            for (int i = 0; i < _spritesLayers.Count; i++)
            {
                var sprite = _spritesLayers[i];

                if (sprite.Rectangle.Right <= 0) //If the sprite ends to the left of screen, reload sprite from right of screen 
                {
                    var index = i - 1;
                    if (index <= 0)
                        index = _spritesLayers.Count - 1;

                    sprite.Position.X = _spritesLayers[index].Rectangle.Right - (_speed * 2); //(_speed * 2) prevents white line between sprites
                }
            }
        }
    }
}

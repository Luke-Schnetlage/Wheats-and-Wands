using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Entities;
using Wheats_and_Wands.Graphics;

namespace Wheats_and_Wands.Levels
{
    class TutorialFarm : Level
    {
        //public Vector2 _farmerStartPos { get ; set ; }
        public Texture2D _backGround { get ; set ; }
        public Farmer _farmer { get ; set ; }
        SpriteBatch _spriteBatch;
        Sign _sign;

        public TutorialFarm(Texture2D backGround, Farmer farmer, Texture2D signTexture, Texture2D msgBoxTexture, SpriteFont font)
        {
            _backGround = backGround;
            _farmer = farmer;
            _sign = new Sign(new Sprite(signTexture, 0, 0, 83, 103), msgBoxTexture, font, "Press W A D to move");
            

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _spriteBatch = spriteBatch;
            _spriteBatch.Draw(_backGround, _frame, Color.White);
            _sign.Draw(spriteBatch, new Vector2(500, 325));
            _farmer.Draw(spriteBatch, gameTime);
        }

        public override void Update(GameTime gameTime)
        {

            
            _farmer.Update(gameTime);
            _sign.Update(gameTime, _farmer);
        }


    }
}

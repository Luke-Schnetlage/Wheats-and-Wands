using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wheats_and_Wands.Entities;

namespace Wheats_and_Wands.Levels
{
    class TutorialFarm : Level
    {
        public Vector2 _farmerStartPos { get ; set ; }
        public Texture2D _backGround { get ; set ; }
        public Farmer _farmer { get ; set ; }
        SpriteBatch _spriteBatch;
        public TutorialFarm(Texture2D backGround)
        {
            _backGround = backGround;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _spriteBatch.Draw(_backGround, _frame, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}

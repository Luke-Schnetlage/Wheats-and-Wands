using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wheats_and_Wands.Graphics
{
    public class Sprite
    {
        public Texture2D Texture { get; private set; } 
        public int X { get; set; }
        public int Y { get; set; }
        public Vector2 position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color TintColor { get; set; } = Color.White;
        public Rectangle rectangle { get; set; }
        //public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;

        public Sprite(Texture2D texture, int x, int y, int width, int height)
        {
            this.Texture = texture;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
        
        public Sprite(Texture2D texture, int x, int y, int width, int height, Vector2 vector)
        {
            this.Texture = texture;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.position = vector;
            this.rectangle = new Rectangle((int)vector.X, (int)vector.Y, width, height);
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 position )
        {
            spriteBatch.Draw(Texture, position, new Rectangle(X, Y, Width, Height), TintColor); //, SpriteEffects
        }

        
        public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effect)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)position.X + Width/2, (int)position.Y + Height/2, Width, Height), new Rectangle(X, Y, Width, Height), TintColor,0f,new Vector2(Width/2,Height/2), effect,0f);
            //spriteBatch.Draw()
            //spriteBatch.Draw(knightTexture,knightPosition,null,Color.White,0f,new Vector2(knightTexture.Width / 2, knightTexture.Height / 2),Vector2.One,effect,0f);
        }
        
    }
}

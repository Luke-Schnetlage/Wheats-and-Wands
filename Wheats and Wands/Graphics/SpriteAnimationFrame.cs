using System;

namespace Wheats_and_Wands.Graphics
{
    public class SpriteAnimationFrame
    {
        private Sprite _sprite;
        public float TimeStamp { get; }

        public Sprite Sprite
        {
            get
            {
                return _sprite;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "The sprite cannot be null");
                }

                _sprite = value;
            }
        }

        public SpriteAnimationFrame(Sprite sprite, float timestamp)
        {
            Sprite = sprite;
            TimeStamp = timestamp;
        }
    }
}

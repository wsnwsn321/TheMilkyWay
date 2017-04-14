using Microsoft.Xna.Framework;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sprites.UFOSprite;
using Sprint6.Sprites;
using System;

namespace Sprint6.ElementClasses

{
    public class StarryNight : IBackground

    {
        public ISprite starrySprite { get; set; }
        public Vector2 position { get; set; }

        public ISprite backgroundSprite { get; set; }

        public StarryNight(Vector2 pos)
        {
            position = pos;

            starrySprite = SpriteFactories.BackgroundSpriteFactory.Instance.CreateStarryNightSprite();

        }

        public void Draw()
        {
              starrySprite.Draw(position);
        }

        public void Update()
        {
            starrySprite.Update();
        }
    }
}

using Microsoft.Xna.Framework;
using TheMilkyWay.ElementClasses.ElementInterfaces;
using TheMilkyWay.Sprites.UFOSprite;
using TheMilkyWay.Sprites;
using System;

namespace TheMilkyWay.ElementClasses

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

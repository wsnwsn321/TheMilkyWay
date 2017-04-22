using Microsoft.Xna.Framework;
using TheMilkyWay.ElementClasses.ElementInterfaces;
using TheMilkyWay.Sprites.UFOSprite;
using TheMilkyWay.Sprites;
using System;

namespace TheMilkyWay.ElementClasses

{
    public class DarkerNight : IBackground

    {
        public ISprite DarkerSprite { get; set; }
        public Vector2 position { get; set; }

        public ISprite backgroundSprite { get; set; }

        public DarkerNight(Vector2 pos)
        {
            position = pos;

            DarkerSprite = SpriteFactories.BackgroundSpriteFactory.Instance.CreateDarkerNightSprite();

        }

        public void Draw()
        {
            DarkerSprite.Draw(position);
        }

        public void Update()
        {
            DarkerSprite.Update();
        }
    }
}

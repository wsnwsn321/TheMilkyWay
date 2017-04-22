using Microsoft.Xna.Framework;
using TheMilkyWay.ElementClasses.ElementInterfaces;
using TheMilkyWay.Sprites.UFOSprite;
using TheMilkyWay.Sprites;
using System;

namespace TheMilkyWay.ElementClasses

{
    public class DarkestNight : IBackground

    {
        public ISprite DarkestSprite { get; set; }
        public Vector2 position { get; set; }

        public ISprite backgroundSprite { get; set; }

        public DarkestNight(Vector2 pos)
        {
            position = pos;

            DarkestSprite = SpriteFactories.BackgroundSpriteFactory.Instance.CreateDarkestNightSprite();

        }

        public void Draw()
        {
            DarkestSprite.Draw(position);
        }

        public void Update()
        {
            DarkestSprite.Update();
        }
    }
}

using Microsoft.Xna.Framework;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sprites.UFOSprite;
using Sprint6.Sprites;
using System;

namespace Sprint6.ElementClasses

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

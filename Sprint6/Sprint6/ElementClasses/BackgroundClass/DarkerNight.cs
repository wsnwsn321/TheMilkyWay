using Microsoft.Xna.Framework;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sprites.UFOSprite;
using Sprint6.Sprites;
using System;

namespace Sprint6.ElementClasses

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

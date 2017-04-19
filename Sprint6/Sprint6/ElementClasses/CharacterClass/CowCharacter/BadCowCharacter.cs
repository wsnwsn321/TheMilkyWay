using Microsoft.Xna.Framework;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sprites.UFOSprite;
using Sprint6.Sprites;
using System;

namespace Sprint6.ElementClasses

{
    public class BadCowCharacter : IItem

    {
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }

        public ISprite itemSprite { get; set; }

        public int gravity { get; set; }

        public BadCowCharacter(Vector2 pos)
        {
            position = pos;
            gravity = 3;
            itemSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBadCowSprite();
            isVisible = true;

        }

        public void Draw()
        {
            if (isVisible)
            {

                itemSprite.Draw(position);
            }

        }

        public void Update()
        {
            if (isVisible)
            {

            }

            itemSprite.Update();
        }
    }
}

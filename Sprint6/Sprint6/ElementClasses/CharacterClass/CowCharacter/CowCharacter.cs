using Microsoft.Xna.Framework;
using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.Sprites.UFOSprite;
using Sprint6.Sprites;
using System;

namespace Sprint6.ElementClasses

{
    public class CowCharacter : IItem

    {
        public ISprite blockSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }

        public ISprite itemSprite { get; set; }

        public int gravity { get; set; }

        public CowCharacter(Vector2 pos)
        {
            position = pos;

            blockSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateLivingCowSprite();
            isVisible = true;

        }

        public void Draw()
        {
            if (isVisible)
            {

                blockSprite.Draw(position);
            }

        }

        public void Update()
        {
            if (isVisible)
            {

            }

            blockSprite.Update();
        }

        public void ItemChangeDirection()
        {
            throw new NotImplementedException();
        }
    }
}

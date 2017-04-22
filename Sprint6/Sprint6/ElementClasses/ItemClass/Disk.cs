using Microsoft.Xna.Framework;
using TheMilkyWay.ElementClasses.ElementInterfaces;
using TheMilkyWay.Sprites.UFOSprite;
using TheMilkyWay.Sprites;
using System;

namespace TheMilkyWay.ElementClasses

{
    public class Disk : IItem

    {
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }

        public ISprite itemSprite { get; set; }

        public int gravity { get; set; }

        public Disk(Vector2 pos)
        {
            position = pos;
            gravity = 0;
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateDiskSprite();
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

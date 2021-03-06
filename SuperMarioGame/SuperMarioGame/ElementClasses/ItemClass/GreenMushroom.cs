﻿using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ItemClass
{
    public class GreenMushroom : ElementInterfaces.IItem

    {
        public ISprite itemSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public int gravity { get; set; }
        public bool changeDirection { get; set; }
        private int Two = 2;
        public GreenMushroom(Vector2 pos)
        {
            position = pos;
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateGreenMushroomSprite();
            isVisible = true;
            gravity = 3;
            changeDirection = true;
        }
        public void ItemChangeDirection()
        {
            changeDirection = !changeDirection;
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
            itemSprite.Update();
            if (changeDirection)
            {
                position = new Vector2(position.X + Two, position.Y);
            }
            else
            {
                position = new Vector2(position.X - Two, position.Y);
            }
        }
    }
}

using Microsoft.Xna.Framework;
using TheMilkyWay.ElementClasses.ElementInterfaces;
using TheMilkyWay.Sprites.UFOSprite;
using TheMilkyWay.Sprites;
using System;
using TheMilkyWay.SpriteFactories;

namespace TheMilkyWay.ElementClasses

{
    public class Bomb : IItem

    {
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public bool canMove { get; set; }
        private int bombAccel;
        public ISprite itemSprite { get; set; }

        public int gravity { get; set; }

        public Bomb(Vector2 pos)
        {
            position = pos;
            gravity = 0;
            itemSprite = SpriteFactories.CharacterSpriteFactory.Instance.CreateBombSprite();
            isVisible = false;
            canMove = false;
            bombAccel = 0;
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
            if (isVisible && canMove)
            {
                position = new Vector2(position.X,position.Y+bombAccel);
                if (bombAccel < GameConstants.MaxBombSpeed)
                {
                    bombAccel++;
                }
            }
            else
            {
                bombAccel = 0;
            }

            itemSprite.Update();
        }

        public void resetPos(Vector2 pos)
        {
            position = pos;
            itemSprite = CharacterSpriteFactory.Instance.CreateBombSprite();
        }
    }
}

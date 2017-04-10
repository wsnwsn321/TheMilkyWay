using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ItemClass
{
    public class Star : ElementInterfaces.IItem

    {
        public ISprite itemSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public bool changeDirection { get; set; }
        public int gravity { get; set; }
        private int jumpCounter;
        private bool increment;
        private int Two = 2;

        private int Ten=  10;
        public Star(Vector2 pos)
        {
            position = pos;
            jumpCounter = 0;
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateStarSprite();
            isVisible = true;
            increment = true;
            changeDirection = true;
            gravity = 3;
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


            if(increment)
            {
                jumpCounter++;
            } else
            {
                jumpCounter--;
            }

            if(jumpCounter == Ten || jumpCounter == -(Two*Two))
            {
                increment = !increment;
            }

            if (changeDirection)
            {
                position = new Vector2(position.X +Two, position.Y - jumpCounter);
            }
            else
            {
                position = new Vector2(position.X - Two, position.Y - jumpCounter);
            }

 

        }
    }
}

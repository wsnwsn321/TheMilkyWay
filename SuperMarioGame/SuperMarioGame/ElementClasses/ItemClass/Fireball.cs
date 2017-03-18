using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ItemClass
{
    public class Fireball : ElementInterfaces.IItem

    {
        public ISprite itemSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public bool changeDirection { get; set; }
        public int gravity { get; set; }
        public bool onTop { get; set; }

        private int jumpCounter;
        private bool increment;

        public Fireball(Vector2 pos)
        {
            position = pos;
            jumpCounter = 0;
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateFireballSprite();
            isVisible = true;
            increment = true;
            changeDirection = true;
            gravity = 3;
            onTop = false;
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


            if (increment)
            {
                jumpCounter++;
            }
            else
            {
                jumpCounter--;
            }

            if (jumpCounter == 8 || jumpCounter == -1)
            {
                increment = !increment;
            }

            if (changeDirection)
            {
                position = new Vector2(position.X + 2, position.Y - jumpCounter);
            }
            else
            {
                position = new Vector2(position.X - 2, position.Y - jumpCounter);
            }
        }
    }
}

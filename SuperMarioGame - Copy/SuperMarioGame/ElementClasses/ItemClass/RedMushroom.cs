using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses.ItemClass
{
    public class RedMushroom : ElementInterfaces.IItem

    {
        public ISprite itemSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public bool changeDirection { get; set; }
        public int gravity { get; set; }
        private int Two = 2;
        public RedMushroom(Vector2 pos)
        {
            position = pos;
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateRedMushroomSprite();
            isVisible = true;
            changeDirection = true;
            gravity = 3;
        }

        public void ItemChangeDirection()
        {
            changeDirection = !changeDirection;
        }

        public void Draw()
        {
            if(isVisible)
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

using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses.ItemClass
{
    public class Coin : ElementInterfaces.IItem

    {
        public ISprite itemSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public bool jump { get; set; }

        private int jumpCount = 0;

        public int gravity { get; set; }
        private int Three = 3; 

        public Coin(Vector2 pos)
        {
            position = pos;
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateCoinSprite();
            isVisible = true;
            gravity = 3;
        }

        public void ItemChangeDirection()
        {
           
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
            if (isVisible && jump)
            {
                if (jumpCount < 20)
                {
                    position = new Vector2(position.X, position.Y - Three);
                    itemSprite.Draw(position);
                }
                else
                {
                    position = new Vector2(position.X, position.Y + Three);
                    itemSprite.Draw(position);
                }
                if (jumpCount == 35)
                {
                    jumpCount = 0;
                    isVisible = false;
                }
                jumpCount++;
            }
            itemSprite.Update();
        }
    }
}

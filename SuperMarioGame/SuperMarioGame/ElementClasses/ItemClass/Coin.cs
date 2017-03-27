using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ItemClass
{
    public class Coin : ElementInterfaces.IItem

    {
        public ISprite itemSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public bool jump { get; set; }

        private int jumpCount = 0;

        public int gravity { get; set; }

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
            if (isVisible && jump)
            {
                if(jumpCount < 20)
                {
                    position = new Vector2(position.X, position.Y - 3);
                    itemSprite.Draw(position);
                }
                else
                {
                    position = new Vector2(position.X, position.Y + 3);
                    itemSprite.Draw(position);
                }
                if (jumpCount == 35)
                {
                    jumpCount = 0;
                    isVisible = false;
                }
                jumpCount++;
            }
            else if (isVisible)
            {
                itemSprite.Draw(position);
            }

        }

        public void Update()
        {
            itemSprite.Update();
        }
    }
}

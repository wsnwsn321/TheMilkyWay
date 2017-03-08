using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ItemClass
{
    public class Coin : ElementInterfaces.IItem

    {
        public ISprite itemSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }

        public Coin(Vector2 pos)
        {
            position = pos;
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateCoinSprite();
            isVisible = true;
        }

        public void ItemChangeDirection()
        {
           
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
        }
    }
}

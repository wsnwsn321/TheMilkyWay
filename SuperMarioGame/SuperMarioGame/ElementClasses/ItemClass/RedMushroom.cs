using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ItemClass
{
    public class RedMushroom : ElementInterfaces.IItem

    {
        public ISprite itemSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public RedMushroom(Vector2 pos)
        {
            position = pos;
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateRedMushroomSprite();
            isVisible = true;
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
        }
    }
}

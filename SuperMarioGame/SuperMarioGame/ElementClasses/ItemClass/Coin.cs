using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

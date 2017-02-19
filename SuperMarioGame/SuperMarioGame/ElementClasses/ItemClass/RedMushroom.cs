using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.ItemClass
{
    public class RedMushroom : ElementInterfaces.IItem

    {
        public ISprite itemSprite { get; set; }
        public Vector2 position { get; set; }
        public bool noD { get; set; }
        public RedMushroom(Vector2 pos)
        {
            position = pos;
            itemSprite = SpriteFactories.ItemSpriteFactory.Instance.CreateRedMushroomSprite();
        }

        public void Draw()
        {
            if(noD == false)
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

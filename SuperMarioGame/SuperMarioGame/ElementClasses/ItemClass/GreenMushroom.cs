using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.ItemClass
{
    public class GreenMushroom : ElementInterfaces.IItem

    {
        Sprites.ISprite greenMushroom;
        public Vector2 position { get; set; }

        public GreenMushroom(Vector2 pos)
        {
            position = pos;
            greenMushroom = SpriteFactories.ItemSpriteFactory.Instance.CreateGreenMushroomSprite();
        }

        public void Draw()
        {
            greenMushroom.Draw(position);
        }

        public void Update()
        {
            greenMushroom.Update();
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.ItemClass
{
    public class RedMushroom : StateInterface.IItem

    {
        Sprites.ISprite redMushroom;
        public Vector2 position { get; set; }

        public RedMushroom(Vector2 pos)
        {
            position = pos;
            redMushroom = SpriteFactories.ItemSpriteFactory.Instance.CreateRedMushroomSprite();
        }

        public void Draw()
        {
            redMushroom.Draw(position);
        }

        public void Update()
        {
            redMushroom.Update();
        }
    }
}

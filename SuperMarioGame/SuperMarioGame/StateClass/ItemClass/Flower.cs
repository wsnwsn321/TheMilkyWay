using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.ItemClass
{
    public class Flower : StateInterface.IItem

    {
        Sprites.ISprite flower;
        public Vector2 position { get; set; }

        public Flower(Vector2 pos)
        {
            position = pos;
            flower = SpriteFactories.ItemSpriteFactory.Instance.CreateFlowerSprite();
        }

        public void Draw()
        {
            flower.Draw(position);
        }

        public void Update()
        {
            flower.Update();
        }
    }
}

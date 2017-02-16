using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.ItemClass
{
    public class Coin : StateInterface.IItem

    {
        Sprites.ISprite coin;
        public Vector2 position { get; set; }

        public Coin(Vector2 pos)
        {
            position = pos;
            coin = SpriteFactories.ItemSpriteFactory.Instance.CreateCoinSprite();
        }

        public void Draw()
        {
            coin.Draw(position);
        }

        public void Update()
        {
            coin.Update();
        }
    }
}

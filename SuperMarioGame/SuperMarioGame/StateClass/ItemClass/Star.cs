using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.ItemClass
{
    public class Star : StateInterface.IItem

    {
        Sprites.ISprite star;
        public Vector2 position { get; set; }

        public Star(Vector2 pos)
        {
            position = pos;
            star = SpriteFactories.ItemSpriteFactory.Instance.CreateStarSprite();
        }

        public void Draw()
        {
            star.Draw(position);
        }

        public void Update()
        {
            star.Update();
        }
    }
}

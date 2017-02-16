using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.EnvironmentClass
{
    public class GroundBlock : ElementInterfaces.IBlock

    {
        Sprites.ISprite groundBlock;
        public Vector2 position { get; set; }
        public GroundBlock(Vector2 pos)
        {
            groundBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateGroundBlockSprite();
            position = pos;
        }

        public void Draw()
        {
            groundBlock.Draw(position);
        }

        public void Update()
        {
            groundBlock.Update();
        }
    }
}

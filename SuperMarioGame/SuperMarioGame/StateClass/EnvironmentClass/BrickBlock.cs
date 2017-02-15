using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.EnvironmentClass
{
    public class BrickBlock : StateInterface.IBlock

    {
        Sprites.ISprite brickBlock;
        public Vector2 position { get; set; }

        public BrickBlock(Vector2 pos)
        {
            position = pos;
            brickBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateBrickBlockSprite();
        }

        public void Draw()
        {
            brickBlock.Draw(position);
        }

        public void Update()
        {
            brickBlock.Update();
        }
    }
}

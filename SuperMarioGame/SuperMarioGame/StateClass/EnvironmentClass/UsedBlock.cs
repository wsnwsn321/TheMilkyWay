using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.EnvironmentClass
{
    public class UsedBlock : StateInterface.IBlock

    {
        Sprites.ISprite usedBlock;
        public Vector2 position { get; set; }

        public UsedBlock(Vector2 pos)
        {
            position = pos;
            usedBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
        }

        public void Draw()
        {
            usedBlock.Draw(position);
        }

        public void Update()
        {
            usedBlock.Update();
        }
    }
}

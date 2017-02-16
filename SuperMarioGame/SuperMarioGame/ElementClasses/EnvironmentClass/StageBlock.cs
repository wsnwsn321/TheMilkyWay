using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.EnvironmentClass
{
    public class StageBlock : ElementInterfaces.IBlock

    {
        Sprites.ISprite stageBlock;
        public Vector2 position { get; set; }

        public StageBlock(Vector2 pos)
        {
            position = pos;
            stageBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateStageBlockSprite();
        }

        public void Draw()
        {
            stageBlock.Draw(position);
        }

        public void Update()
        {
            stageBlock.Update();
        }
    }
}

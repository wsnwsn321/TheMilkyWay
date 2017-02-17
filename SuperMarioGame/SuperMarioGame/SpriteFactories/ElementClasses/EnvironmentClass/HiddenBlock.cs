using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.EnvironmentClass
{
    public class HiddenBlock : ElementInterfaces.IBlock

    {
        Sprites.ISprite hiddenBlock;
        public Vector2 position { get; set; }

        public HiddenBlock(Vector2 pos)
        {
            position = pos;
            hiddenBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateHiddenBlockSprite();
        }

        public void Draw()
        {
            hiddenBlock.Draw(position);
        }

        public void Update()
        {
            hiddenBlock.Update();
        }
    }
}

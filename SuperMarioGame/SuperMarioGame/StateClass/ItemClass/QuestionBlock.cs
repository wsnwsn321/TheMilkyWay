using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.ItemClass
{
    class QuestionBlock
    {
        Sprites.ISprite block { get; set; }

        public void getHit()
        {
            block = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateHiddenBlockSprite();

        }
    }
}

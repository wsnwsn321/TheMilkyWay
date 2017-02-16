using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.EnvironmentClass
{
    public class QuestionBlock : ElementInterfaces.IBlock

    {
        Sprites.ISprite questionBlock;
        public Vector2 position { get; set; }

        public QuestionBlock(Vector2 pos)
        {
            position = pos;
            questionBlock = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateQuestionBlockSprite();
        }

        public void Draw()
        {
            questionBlock.Draw(position);
        }

        public void Update()
        {
            questionBlock.Update();
        }
    }
}

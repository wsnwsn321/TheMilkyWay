using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.EnvironmentClass
{
    public class QuestionBlockC : ElementInterfaces.IBlock

    {
        public ISprite blockSprite { get; set; }
        public Vector2 position { get; set; }

        public bool isVisible { get; set; }

        public QuestionBlockC(Vector2 pos)
        {
            position = pos;
            blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateQuestionBlockSprite();
            isVisible = true;
        }

        public void Draw()
        {
            if (isVisible)
            {
                blockSprite.Draw(position);
            }
        }

        public void Update()
        {
            blockSprite.Update();
        }
    }
}

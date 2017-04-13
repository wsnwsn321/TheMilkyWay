using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses.EnvironmentClass
{
    public class StageBlock : ElementInterfaces.IBlock

    {
        public ISprite blockSprite { get; set; }
        public Vector2 position { get; set; }

        public bool isVisible { get; set; }
        public bool isBroken { get; set; }
        public bool isBumped { get; set; }
        public int bumpCount { get; set; }
        public StageBlock(Vector2 pos)
        {
            position = pos;
            blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateStageBlockSprite();
            isVisible = true;
            isBroken = false;
        }

        public void Draw()
        {
            if (isVisible)
            {
                blockSprite.Draw(position);
            }
        }
        public void Bump()
        {
            isBumped = true;
            bumpCount = 11;
        }

        public void Update()
        {
            blockSprite.Update();
        }
    }
}

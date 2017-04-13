using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses.EnvironmentClass
{
    public class BrickBlockC : ElementInterfaces.IBlock

    {
        public ISprite blockSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public bool isBroken { get; set; }
        public bool isBumped { get; set; }
        public int bumpCount { get; set; }
        private int Three = 3;
        private int Five = 5;
        private int Eleven = 11;
        public BrickBlockC(Vector2 pos)
        {
            position = pos;
            blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateBrickBlockSprite();
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
            bumpCount = Eleven;
        }

        public void Update()
        {
            if (isVisible && isBumped)
            {
                if (bumpCount > Five)
                {
                    position = new Vector2(position.X, position.Y - Three);
                    blockSprite.Draw(position);
                }
                else
                {
                    position = new Vector2(position.X, position.Y + Three);
                    blockSprite.Draw(position);
                }
                if (bumpCount == 0)
                {
                    isBumped = !isBumped;
                }
                bumpCount--;
            }
            blockSprite.Update();
        }
    }
}

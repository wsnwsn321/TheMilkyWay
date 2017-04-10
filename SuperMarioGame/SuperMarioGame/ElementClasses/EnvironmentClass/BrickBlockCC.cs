using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.EnvironmentClass
{
    public class BrickBlockCC : ElementInterfaces.IBlock

    {
        public ISprite blockSprite { get; set; }
        public Vector2 position { get; set; }
        public int coinCount { get; set; }
        public bool isVisible { get; set; }
        public bool isBroken { get; set; }
        public bool isBumped { get; set; }
        public int bumpCount { get; set; }
        private int Three = 3;
        private int Five = 5;
        private int Eleven = 11;
        public BrickBlockCC(Vector2 pos)
        {
            position = pos;
            blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateBrickBlockSprite();
            isVisible = true;
            isBroken = false;
            coinCount = Three * Three;
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

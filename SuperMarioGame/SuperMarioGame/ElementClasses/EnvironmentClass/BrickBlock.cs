using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.EnvironmentClass
{
    public class BrickBlock : ElementInterfaces.IBlock

    {
        public ISprite blockSprite { get; set; }
        public Vector2 position { get; set; }
        public int bumpCount { get; set; }
        public bool isVisible { get; set; }
        public bool isBroken { get; set; }
        public bool isBumped { get; set; }
        private int Three = 3;
        private int Five = 5;
        private int Eleven = 11;
        public BrickBlock(Vector2 pos, bool isBlue)
        {
            position = pos;
            if (isBlue)
            {
                blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateBlueBrickBlockSprite();
            } else
            {
                blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateBrickBlockSprite();

            }

            isVisible = true;
            isBroken = false;
            isBumped = false;

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

        public void Bump()
        {
            isBumped = true;
            bumpCount = Eleven;
        }
    }
}

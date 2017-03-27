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
        public BrickBlock(Vector2 pos)
        {
            position = pos;
            blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateBrickBlockSprite();
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
                if (bumpCount > 5)
                {
                    position = new Vector2(position.X, position.Y - 3);
                    blockSprite.Draw(position);
                }
                else
                {
                    position = new Vector2(position.X, position.Y + 3);
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
            bumpCount = 11;
        }
    }
}

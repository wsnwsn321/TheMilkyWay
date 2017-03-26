using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.EnvironmentClass
{
    public class UsedBlock : ElementInterfaces.IBlock

    {
        public ISprite blockSprite { get; set; }
        public Vector2 position { get; set; }

        public bool isVisible { get; set; }
        public bool isBroken { get; set; }
        public UsedBlock(Vector2 pos)
        {
            position = pos;
            blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateUsedBlockSprite();
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

        public void Update()
        {
            blockSprite.Update();
        }
    }
}

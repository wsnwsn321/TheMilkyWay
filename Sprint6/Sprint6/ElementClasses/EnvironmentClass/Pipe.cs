using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses.EnvironmentClass
{
    public class Pipe : ElementInterfaces.IBlock

    {
        public ISprite blockSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public bool isBroken { get; set; }
        public bool isBumped { get; set; }
        public int bumpCount { get; set; }
        public int size { get; set; }

        public bool special { get; set; }

        public Pipe(Vector2 pos, int size, bool special)
        {
            position = pos;
            this.size = size;
            blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreatePipeSprite(this.size);
            isVisible = true;
            isBroken = false;
            this.special = special;
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
            bumpCount = 9;
        }

        public void Update()
        {
            blockSprite.Update();
        }
    }
}

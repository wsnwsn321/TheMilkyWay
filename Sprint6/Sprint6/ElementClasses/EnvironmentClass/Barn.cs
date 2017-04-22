using Microsoft.Xna.Framework;
using TheMilkyWay.ElementClasses.ElementInterfaces;
using TheMilkyWay.Sprites.UFOSprite;
using TheMilkyWay.Sprites;

namespace TheMilkyWay.ElementClasses

{
    public class Barn : ElementInterfaces.IBlock

    {
        public ISprite blockSprite { get; set; }
        public Vector2 position { get; set; }
        public bool isVisible { get; set; }
        public Barn(Vector2 pos)
        {
            position = pos;
            blockSprite = SpriteFactories.EnvironmentSpriteFactory.Instance.CreateBarnSprite();
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
            if (isVisible)
            {

            }

            blockSprite.Update();
        }
    }
}

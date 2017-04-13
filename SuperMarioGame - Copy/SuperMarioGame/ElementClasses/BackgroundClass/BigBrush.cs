using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses.BackgroundClass
{
    public class BigBrush : ElementInterfaces.IBackground
    {
        public ISprite backgroundSprite { get; set; }
        public Vector2 position { get; set; }

        public bool moveDown { get; set; }

        public BigBrush(Vector2 pos)
        {
            position = pos;
            backgroundSprite = SpriteFactories.BackgroundSpriteFactory.Instance.CreateBigBrushSprite();
        }

        public void Draw()
        {
            backgroundSprite.Draw(position);
        }

        public void Update()
        {
            backgroundSprite.Update();
        }
    }
}

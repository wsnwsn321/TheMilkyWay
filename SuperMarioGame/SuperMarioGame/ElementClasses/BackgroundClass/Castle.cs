using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.BackgroundClass
{
    public class Castle : ElementInterfaces.IBackground
    {
        public ISprite backgroundSprite { get; set; }
        public Vector2 position { get; set; }

        public Castle(Vector2 pos)
        {
            position = pos;
            backgroundSprite = SpriteFactories.BackgroundSpriteFactory.Instance.CreateCastleSprite();
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

using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.BackgroundClass
{
    public class Flagpole : ElementInterfaces.IBackground
    {
        public ISprite backgroundSprite { get; set; }
        public Vector2 position { get; set; }
        public bool moveDown { get; set; }

        public Flagpole(Vector2 pos)
        {
            position = pos;
            backgroundSprite = SpriteFactories.BackgroundSpriteFactory.Instance.CreateFlagpoleSprite();
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

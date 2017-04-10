using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.BackgroundClass
{
    public class Flag : ElementInterfaces.IBackground
    {
        public ISprite backgroundSprite { get; set; }
        public Vector2 position { get; set; }
        public bool moveDown { get; set; }
        public bool isDown { get; set; }
        public Flag(Vector2 pos)
        {
            position = pos;
            backgroundSprite = SpriteFactories.BackgroundSpriteFactory.Instance.CreateFlagSprite();
            moveDown = isDown = false;
        }

        public void Draw()
        {
            backgroundSprite.Draw(position);
        }

        public void Update()
        {
            if(moveDown)
            {
                if (position.Y < GameConstants.ScreenHeight - 132)
                {
                    position = new Vector2(position.X, position.Y + 4);
                }else
                {
                    moveDown = false;
                    isDown = true;
                }

            }
            backgroundSprite.Update();
        }
    }
}

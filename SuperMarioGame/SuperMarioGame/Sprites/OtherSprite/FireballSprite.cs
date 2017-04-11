using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    public class FireballSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }

        int currentFrame;
        int totalFrame;
        int currentWidth;
        int currentUpdate;
        int slowSpeedDown;

        public FireballSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
            currentFrame = 0;
            totalFrame = GameConstants.Four;
            currentUpdate = 0;
            slowSpeedDown = GameConstants.Five;
            currentWidth = 0;
        }
        public void Update()
        {
            currentUpdate++;
            if (currentUpdate == slowSpeedDown)
            {
                currentUpdate = 0;
                currentFrame++;
                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                    currentWidth = 0;
                }else
                {
                    currentWidth = GameConstants.Two;
                }
            }
        }

        public Vector2 returnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(currentFrame * (GameConstants.Nine+currentWidth), 0, GameConstants.Nine+ currentWidth, GameConstants.Nine);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, GameConstants.Two* GameConstants.Ten, GameConstants.Two * GameConstants.Ten);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}



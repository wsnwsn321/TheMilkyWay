using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint6.Sprites
{
    public class KoopaLeftSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }

        int currentFrame;
        int totalFrame;
        int currentUpdate;
        int slowSpeedDown;
        public KoopaLeftSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
            currentFrame = 0;
            totalFrame = GameConstants.Two;
            currentUpdate = 0;
            slowSpeedDown = GameConstants.Eight;

        }
        public void Update()
        {
            currentUpdate++;
            if (currentUpdate == slowSpeedDown)
            {
                currentUpdate = 0;
                currentFrame++;
                if (currentFrame == totalFrame)
                    currentFrame = 0;
            }
        }

        public Vector2 returnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(37 + 17 * currentFrame, 0, 17, 23);
            desRectangle = new Rectangle((int)position.X, (int)position.Y,GameConstants.SquareWidth, 43);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}



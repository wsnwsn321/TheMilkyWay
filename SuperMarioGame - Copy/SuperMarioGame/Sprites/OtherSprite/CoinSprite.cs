using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint6.Sprites
{
    public class CoinSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }

        int currentFrame;
        int totalFrames;
        int counter = 0;
        int currentWidth;

        public CoinSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
            currentFrame = 0;
            totalFrames = 4;
            currentWidth = 6;
        }
        public void Update()
        {
            if (counter % 2 == 0)
            {
                currentFrame++;
            }
            if (currentFrame == 0)
            {
                currentWidth = 9;
            }
            else
            {
                currentWidth = 6;
            }

            counter++;
            if (counter > 99)
            {
                counter = 0;
            }
            if (currentFrame == (totalFrames))
            {
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
            Rectangle sourceRectangle = new Rectangle(((GameConstants.Eight+1) * currentFrame), 0, currentWidth, 14);
            if (currentFrame == GameConstants.Two || currentFrame == GameConstants.Three)
            {
                desRectangle = new Rectangle((int)position.X+ GameConstants.Four, (int)position.Y, GameConstants.Ten+GameConstants.Eight, GameConstants.Twenty+GameConstants.Eight);
                sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            }
            else
            {
                desRectangle = new Rectangle((int)position.X, (int)position.Y, 18, 28);
                sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);

            }
            
            p = position;
            sb.End();
        }
    }
}



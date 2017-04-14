using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint6.Sprites.UFOSprite
{
    public class UFOJumpingSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        public int currentFrame { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }

        private int totalFrames;
        private int counter;

        Vector2 p;

        public UFOJumpingSprite(Texture2D texture,SpriteBatch sb,int currentF)
        {
            Texture = texture;
            currentFrame = currentF;
            this.sb = sb;
            totalFrames = 4;
            currentFrame = currentF;
            tintColor = Color.White;
        }
        public void Update()
        {
            counter++;
            if (counter % 10 == 0)
            {
                currentFrame++;
            }
            if (currentFrame >= totalFrames)
            {
                currentFrame = 0;
            }
        }

        public Vector2 ReturnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(60 * currentFrame, 54, 60, 55);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 100, 95);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();

        }
    }
}

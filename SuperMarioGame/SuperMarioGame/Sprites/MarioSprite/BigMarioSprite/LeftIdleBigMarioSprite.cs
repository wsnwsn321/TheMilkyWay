using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioGame.Sprites.MarioSprite.BigMarioSprite
{
    public class LeftIdleBigMarioSprite : IMarioSprite

    {
        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }


        Vector2 p;

        public LeftIdleBigMarioSprite(Texture2D texture,SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
            tintColor = Color.White;
        }
        public void Update()
        {

        }

        public Vector2 returnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(18, 0, 18,GameConstants.SquareWidth);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 36, 64);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();

        }
    }
}

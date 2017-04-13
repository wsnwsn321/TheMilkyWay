using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint6.Sprites.MarioSprite.BigMarioSprite
{
    public class LeftCrouchingBigMarioSprite : IMarioSprite

    {
        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }

        public Color tintColor { get; set; }

        Vector2 p;

        public LeftCrouchingBigMarioSprite(Texture2D texture, SpriteBatch sb)
        {
            this.sb = sb;
            Texture = texture;
            tintColor = Color.White;
        }
        public void Update()
        {

        }

        public Vector2 returnPosition()
        {
            return p;
        }

        public void Draw( Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(0, 0, 18,GameConstants.SquareWidth);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 36, 64);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();
        }
    }
}

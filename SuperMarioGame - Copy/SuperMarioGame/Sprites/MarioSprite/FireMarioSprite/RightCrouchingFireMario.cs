using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint6.Sprites.MarioSprite.FireMarioSprite
{
    public class RightCrouchingFireMarioSprite : IMarioSprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }

        public RightCrouchingFireMarioSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
            this.tintColor = Color.White;
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
            Rectangle sourceRectangle = new Rectangle(57, 0, 19,GameConstants.SquareWidth);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 38, 64);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();
        }
    }
}



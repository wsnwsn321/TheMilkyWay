using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint6.Sprites.MarioSprite.SmallMarioSprite
{
    public class RightJumpingSmallMarioSprite : IMarioSprite
    {

        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        private Vector2 p;
        public Color tintColor { get; set; }

        public Rectangle desRectangle { get; set; }


        public RightJumpingSmallMarioSprite(Texture2D texture, SpriteBatch sb)
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

        public void Draw(Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(17, 0, 16, 16);
            desRectangle = new Rectangle((int)position.X, (int)position.Y,GameConstants.SquareWidth,GameConstants.SquareWidth);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();
        }
    }
}

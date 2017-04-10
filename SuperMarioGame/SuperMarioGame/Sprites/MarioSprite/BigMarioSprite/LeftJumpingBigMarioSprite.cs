using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioGame.Sprites.MarioSprite.BigMarioSprite
{
    public class LeftJumpingBigMarioSprite : IMarioSprite

    {
        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }


        Vector2 p;

        public LeftJumpingBigMarioSprite(Texture2D texture,SpriteBatch sb)
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

        public void Draw( Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(0, 0, 16, 31);
            desRectangle = new Rectangle((int)position.X, (int)position.Y,GameConstants.SquareWidth, 62);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();
        }
    }
}

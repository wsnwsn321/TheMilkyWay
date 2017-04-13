using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint6.Sprites.MarioSprite.BigMarioSprite
{
    public class LeftFlagBigMarioSprite: IMarioSprite
    {
        private SpriteBatch sb;
        public Texture2D Texture { get; set; }
        private Vector2 p;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }


        public LeftFlagBigMarioSprite(Texture2D texture,SpriteBatch sb)
        {
            this.sb = sb;
            tintColor = Color.White;
            Texture = texture;
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
            Rectangle sourceRectangle = new Rectangle(0, 0, 15, 30);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 34, 62);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            this.p = position;
            sb.End();
        }
    }
}

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSprite.SmallMarioSprite
{
    public class RightIdleSmallMarioSprite : ISprite
    {
        
        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        Vector2 p;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }


        public RightIdleSmallMarioSprite(Texture2D texture, SpriteBatch sb)
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
            Rectangle sourceRectangle = new Rectangle(12, 0, 13, 16);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 26, 32);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            this.p = position;
            sb.End();
        }
    }
}

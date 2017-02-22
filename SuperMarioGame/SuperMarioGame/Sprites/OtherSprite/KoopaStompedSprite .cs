using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    public class KoopaStompedSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public KoopaStompedSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;

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
            Rectangle sourceRectangle = new Rectangle(0, 0, 17, 23);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 34, 44);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}



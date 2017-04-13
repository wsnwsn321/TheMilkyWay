using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint6.Sprites
{
    public class KoopaFlippedSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public KoopaFlippedSprite(Texture2D texture, SpriteBatch sb)
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
            Rectangle sourceRectangle = new Rectangle(0, 0, GameConstants.Fourteen, GameConstants.Fourteen+1);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 25, 30);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}



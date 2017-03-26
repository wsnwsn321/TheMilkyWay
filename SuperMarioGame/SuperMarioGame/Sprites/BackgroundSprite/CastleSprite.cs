using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    public class CastleSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }

        public bool toDraw { get; set; }

        public CastleSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
            toDraw = true;
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
            if (toDraw)
            {
                sb.Begin();
                Rectangle sourceRectangle = new Rectangle(246, 861, 82, 83);
                desRectangle = new Rectangle((int)position.X, (int)position.Y, 160, 160);
                sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
                p = position;
                sb.End();
            }
        }
    }
}



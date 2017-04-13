using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint6.Sprites
{
    public class FlagSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }

        public bool toDraw { get; set; }

        public FlagSprite(Texture2D texture, SpriteBatch sb)
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
                Rectangle sourceRectangle = new Rectangle(0, 0, 17, 18);
                desRectangle = new Rectangle((int)position.X, (int)position.Y, GameConstants.SquareWidth, GameConstants.SquareWidth);
                sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
                p = position;
                sb.End();
            }
        }
    }
}



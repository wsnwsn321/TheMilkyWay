using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    public class SmallMountainSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }

        public bool toDraw { get; set; }

        public SmallMountainSprite(Texture2D texture, SpriteBatch sb)
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
                Rectangle sourceRectangle = new Rectangle(168, 20, 50, 20);
                desRectangle = new Rectangle((int)position.X, (int)position.Y, 96, GameConstants.SquareWidth);
                sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
                p = position;
                sb.End();
            }
        }
    }
}



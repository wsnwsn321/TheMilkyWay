using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint6.Sprites
{
    public class FireballExplosionSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }


        public FireballExplosionSprite(Texture2D texture, SpriteBatch sb)
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
            Rectangle sourceRectangle = new Rectangle(2 * GameConstants.Eight* GameConstants.Two, 0, GameConstants.Eight * GameConstants.Two, GameConstants.Eight * GameConstants.Two);
            desRectangle = new Rectangle((int)position.X, (int)position.Y,GameConstants.Ten* GameConstants.Two, GameConstants.Ten* GameConstants.Two);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}



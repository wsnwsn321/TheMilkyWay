using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint6.Sprites.MarioSprite.FireMarioSprite
{
    public class LeftAttackingMarioSprite : IMarioSprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }

        public LeftAttackingMarioSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
            this.tintColor = Color.White;
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
            Rectangle sourceRectangle = new Rectangle(0, 0, 16, 31);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 34, 64);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor,0,new Vector2(0, 0), SpriteEffects.FlipHorizontally,0);
            p = position;
            sb.End();
        }
    }
}



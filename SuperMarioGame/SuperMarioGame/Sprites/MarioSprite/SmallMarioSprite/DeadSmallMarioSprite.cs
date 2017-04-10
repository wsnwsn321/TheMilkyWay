using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSprite.SmallMarioSprite
{
    public class DeadSmallMarioSprite: IMarioSprite
    {
        
        public Texture2D Texture { get; set; }
        private Vector2 p;
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }


        public DeadSmallMarioSprite(Texture2D texture,SpriteBatch sb)
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
            this.p = position;
            Rectangle sourceRectangle = new Rectangle(0, 0, 14, 14);
            desRectangle = new Rectangle((int)position.X, (int)position.Y,GameConstants.SquareWidth,GameConstants.SquareWidth);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            sb.End();
        }
    }
}

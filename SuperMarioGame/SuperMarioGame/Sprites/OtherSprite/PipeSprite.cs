using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    public class PipeSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public int size { get; set; }
        public Rectangle desRectangle { get; set; }

        public PipeSprite(Texture2D texture, SpriteBatch sb, int size)
        {
            Texture = texture;
            this.sb = sb;
            this.size = size;
        }

        public PipeSprite(Texture2D texture, SpriteBatch underPipeSB)
        {
            Texture = texture;
            this.sb = underPipeSB;
            this.size = GameConstants.UnderPipe;
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
            Rectangle sourceRectangle;
            sb.Begin();
            if (size == GameConstants.SmallPipe)
            {
                sourceRectangle = new Rectangle(224, 96, 34, 33);
                desRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 60);
            }
            else if(size == GameConstants.MedPipe)
            {
                sourceRectangle = new Rectangle(185, 80, 35, 49);
                desRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 80);
            }
            else if(size == GameConstants.UnderPipe)
            {
                sourceRectangle = new Rectangle(0, 0, 48, 32);
                desRectangle = new Rectangle((int)position.X, (int)position.Y, 80, 75);
            }
            else
            {
                sourceRectangle = new Rectangle(145, 63, 34, 65);
                desRectangle = new Rectangle((int)position.X, (int)position.Y, 60, 100);
            }

            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}



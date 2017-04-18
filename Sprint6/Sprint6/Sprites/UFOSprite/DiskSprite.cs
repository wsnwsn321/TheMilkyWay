using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame;

namespace Sprint6.Sprites.UFOSprite
{
    public class DiskSprite : ISprite
    {
        public List<Circle> circles { get; set; }
        public Texture2D Texture { get; set; }
        public int currentFrame { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }

        private int totalFrames;

        private int counter;

        Vector2 p;

        public DiskSprite(Texture2D texture, SpriteBatch sb, int currentF)
        {
            Texture = texture;
            this.sb = sb;
            totalFrames = 1;
            counter = 0;
            currentFrame = currentF;
            tintColor = Color.White;
        }
        public void Update()
        {
            
                currentFrame = 0;
  
        }

        public Vector2 ReturnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(64 * currentFrame, 0, 64, 64);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();

        }
    }
}

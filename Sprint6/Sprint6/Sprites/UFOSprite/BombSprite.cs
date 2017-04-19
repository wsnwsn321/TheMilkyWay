using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame;

namespace Sprint6.Sprites.UFOSprite
{
    public class BombSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        public int currentFrame { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }
        public List<Circle> circles { get; set; }

        private float length;
        Vector2 p;


        public BombSprite(Texture2D texture,SpriteBatch sb, int currentF)
        {
            Texture = texture;
            this.sb = sb;
            currentFrame = currentF;
            tintColor = Color.White;
        }
        public void Update()
        {

        }

        public Vector2 ReturnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            length = position.Y;
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(0, 0, 256, 256);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();

        }
    }
}

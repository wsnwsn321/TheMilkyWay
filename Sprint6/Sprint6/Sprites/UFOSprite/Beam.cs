using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame;

namespace Sprint6.Sprites.UFOSprite
{
    public class Beam : ISprite

    {
        public Texture2D Texture { get; set; }
        public int currentFrame { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }
        public List<Circle> circles { get; set; }

        Vector2 p;

        public Beam(Texture2D texture,SpriteBatch sb, int currentF)
        {
            Texture = texture;
            this.sb = sb;
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
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(60 * currentFrame, 0, 60, 36);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 100, 61);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();

        }
    }
}

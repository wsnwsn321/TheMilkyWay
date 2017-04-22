using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame;
using System.Collections.ObjectModel;

namespace TheMilkyWay.Sprites.UFOSprite
{
    public class DiskSprite : ISprite
    {
        public Rectangle desRectangle { get; set; }
        public bool canMove { get; set; }
        public Texture2D Texture { get; set; }
        public int currentFrame { get; set; }
        private SpriteBatch sb;
        public Collection<Circle> circles { get; }
        public Color tintColor { get; set; }

        Vector2 p;

        public DiskSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
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
            Rectangle sourceRectangle = new Rectangle(0, 0, 64, 64);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();

        }
    }
}

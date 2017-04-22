using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame;
using System.Collections.ObjectModel;

namespace TheMilkyWay.Sprites.UFOSprite
{
    public class DarkestNightSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        public bool canMove { get; set; }

        public int currentFrame { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }
        public Collection<Circle> circles { get; }

        Vector2 p;

        public DarkestNightSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
            currentFrame = 0;
            tintColor = Color.MediumPurple;
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
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, GameConstants.ScreenWidth, GameConstants.ScreenHeight);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();

        }
    }
}

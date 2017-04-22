using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame;
using System.Collections.ObjectModel;

namespace TheMilkyWay.Sprites.UFOSprite
{
    public class BombSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        public bool canMove { get; set; }

        public int currentFrame { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }
        public Collection<Circle> circles { get; }
        private Vector2 circleCenter1;

        Vector2 p;


        public BombSprite(Texture2D texture,SpriteBatch sb, int currentF)
        {
            Texture = texture;
            this.sb = sb;
            currentFrame = currentF;
            circles = new Collection<Circle>();
            circleCenter1 = new Vector2(p.X + desRectangle.Width / 2.0f, p.Y + desRectangle.Height / 2.0f);
            circles.Add(new Circle(circleCenter1, desRectangle.Height / 2.0f));
            tintColor = Color.White;
            canMove = true;
        }
        public void Update()
        {
            circleCenter1 = new Vector2(p.X + desRectangle.Width / 2.0f, p.Y + desRectangle.Height / 2.0f);
            circles[0].Center = circleCenter1;
        }

        public Vector2 ReturnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(0, 0, 256, 256);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();

        }
    }
}

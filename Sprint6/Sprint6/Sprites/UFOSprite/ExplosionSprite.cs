using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame;

namespace Sprint6.Sprites.UFOSprite
{
    public class ExplosionSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        public int currentFrame { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }
        public List<Circle> circles { get; set; }
        private int totalColumn,totalRow,currentColumn,currentRow;
        public Vector2 circleCenter1, circleCenter2, circleCenter3;
        private int counter;
        Vector2 p;


        public ExplosionSprite(Texture2D texture,SpriteBatch sb, int currentF)
        {
            Texture = texture;
            this.sb = sb;
            totalColumn = 4;
            totalRow = 4;
            currentColumn = currentF;
            currentRow = currentF;
            tintColor = Color.White;
            circles = new List<Circle>();
            circleCenter1 = new Vector2(p.X + desRectangle.Width / 2.0f, p.Y + desRectangle.Height / 2.0f);
            circles.Add(new Circle(circleCenter1, desRectangle.Height / 2.0f));
            circleCenter2 = new Vector2(p.X + desRectangle.Width / 4.0f, p.Y + desRectangle.Height / 2.0f);
            circles.Add(new Circle(circleCenter2, desRectangle.Height / 3.0f));
            circleCenter3 = new Vector2(p.X + desRectangle.Width * 3.0f / 4.0f, p.Y + desRectangle.Height / 2.0f);
            circles.Add(new Circle(circleCenter3, desRectangle.Height / 3.0f));
        }
        public void Update()
        {
            for (int i = 0; i < circles.Count; i++)
            {
                if (circles[i].Center == circleCenter1)
                {
                    circleCenter1 = new Vector2(p.X + desRectangle.Width / 2.0f, p.Y + desRectangle.Height / 2.0f);
                    circles[i].Center = circleCenter1;
                }
                else if (circles[i].Center == circleCenter2)
                {
                    circleCenter2 = new Vector2(p.X + desRectangle.Width / 4.0f, p.Y + desRectangle.Height / 2.0f);
                    circles[i].Center = circleCenter2;
                }
                else if (circles[i].Center == circleCenter3)
                {
                    circleCenter3 = new Vector2(p.X + desRectangle.Width * 3.0f / 4.0f, p.Y + desRectangle.Height / 2.0f);
                    circles[i].Center = circleCenter3;
                }
            }
                counter++;
            if (counter % 10 == 0)
            {
                currentColumn++;
            }
            if (currentColumn >= totalColumn)
            {
                currentRow ++;
            }
            if(currentRow>= totalRow)
            {
                currentRow = 0;
                currentColumn = 0;
            }

        }

        public Vector2 ReturnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(128 * currentRow, 128*currentColumn, 128, 128);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 128, 128);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();

        }
    }
}

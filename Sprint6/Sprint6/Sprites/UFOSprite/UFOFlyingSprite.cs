﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame;
using System.Collections.ObjectModel;

namespace TheMilkyWay.Sprites.UFOSprite
{
    public class UFOFlyingSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        public bool canMove { get; set; }

        public int currentFrame { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }
        public Collection<Circle> circles { get; }
        private Vector2 circleCenter1;
        private Vector2 circleCenter2;
        private Vector2 circleCenter3;

        private int totalFrames;

        private int counter;

        Vector2 p;

        public UFOFlyingSprite(Texture2D texture,SpriteBatch sb, int currentF)
        {
            Texture = texture;
            this.sb = sb;
            totalFrames = 4;
            counter = 0;
            p = new Vector2(-1000, -1000);
            currentFrame = currentF;
            tintColor = Color.White;
            circles = new Collection<Circle>(); 
            circleCenter1 = new Vector2(p.X + desRectangle.Width / 2.0f, p.Y + desRectangle.Height / 2.0f);
            circles.Add(new Circle(circleCenter1, desRectangle.Height / 2.0f));
            circleCenter2 = new Vector2(p.X + desRectangle.Width / 4.0f, p.Y + desRectangle.Height / 2.0f);
            circles.Add(new Circle(circleCenter2, desRectangle.Height / 3.0f));
            circleCenter3 = new Vector2(p.X + desRectangle.Width*3.0f/ 4.0f, p.Y + desRectangle.Height / 2.0f);
            circles.Add(new Circle(circleCenter3, desRectangle.Height /3.0f));
        }
        public void Update()
        {
            for(int i = 0; i<circles.Count;i++)
            {
                if (circles[i].Center==circleCenter1)
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
                    circleCenter3 = new Vector2(p.X + desRectangle.Width*3.0f / 4.0f, p.Y + desRectangle.Height / 2.0f);
                    circles[i].Center = circleCenter3;
                }
            }
            counter++;
            if (counter % 10==0)
            {
                currentFrame++;
            }
            if (currentFrame >= totalFrames)
            {
                currentFrame = 0;
            }
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

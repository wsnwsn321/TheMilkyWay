﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame;
using System.Collections.ObjectModel;

namespace TheMilkyWay.Sprites.UFOSprite
{
    public class BadCowSprite : ISprite
    {
        public Collection<Circle> circles { get; }
        public bool canMove { get; set; }
        public Texture2D Texture { get; set; }
        public int currentFrame { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }

        private int totalFrames;

        private int counter;

        Vector2 p;

        public BadCowSprite(Texture2D texture,SpriteBatch sb, int currentF)
        {
            Texture = texture;
            this.sb = sb;
            totalFrames = 4;
            counter = 0;
            currentFrame = currentF;
            tintColor = Color.LightGreen;
        }
        public void Update()
        {
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
            Rectangle sourceRectangle = new Rectangle(64 * currentFrame, 22, 64, 43);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 43);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();

        }
    }
}

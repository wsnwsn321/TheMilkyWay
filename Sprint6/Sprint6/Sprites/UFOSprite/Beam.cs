﻿using System.Collections.Generic;
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
        private int totalFrames;

        private int counter;

        Vector2 p;


        public Beam(Texture2D texture,SpriteBatch sb, int currentF)
        {
            Texture = texture;
            this.sb = sb;
            totalFrames = 2;
            counter = 0;
            currentFrame = currentF;
            tintColor = Color.White;
        }
        public void Update()
        {
            counter++;
            if (counter % 10 == 0)
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
            sb.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend);
            Rectangle sourceRectangle = new Rectangle(76 * currentFrame, 0, 76, 135);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 76, 135);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();

        }
    }
}

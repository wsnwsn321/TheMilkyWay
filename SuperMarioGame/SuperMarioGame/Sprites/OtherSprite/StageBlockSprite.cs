﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    public class StageBlockSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }

        public Boolean doDraw { get; set; }

        public StageBlockSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
            doDraw = true;
        }
        public void Update()
        {

        }

        public Vector2 returnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            if (doDraw)
            {
                sb.Begin();
                Rectangle sourceRectangle = new Rectangle(0, 0, 16, 16);
                desRectangle = new Rectangle((int)position.X, (int)position.Y,GameConstants.SquareWidth,GameConstants.SquareWidth);
                sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
                p = position;
                sb.End();
            }
        }
    }
}



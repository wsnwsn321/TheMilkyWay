﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSprite.BigMarioSprite
{
    public class RightRunningBigMarioSprite : IMarioSprite
    {

        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }


        Vector2 p;
        int currentFrame;
        int totalFrame;
        int currentUpdate;
        int slowSpeedDown;

        public RightRunningBigMarioSprite(Texture2D texture, SpriteBatch sb)
        {
            this.sb = sb;
            Texture = texture;
            currentFrame = 0;
            totalFrame = 3;
            currentUpdate = 4;
            slowSpeedDown = 5;
            tintColor = Color.White;
        }
        public void Update()
        {
            currentUpdate++;
            if (currentUpdate == slowSpeedDown)
            {
                currentUpdate = 0;
                currentFrame++;
                if (currentFrame == totalFrame)
                    currentFrame = 0;
            }

        }

        public Vector2 returnPosition()
        {
            return p;
        }

        public void Draw( Vector2 position)
        {
            sb.Begin();

            int currentWidth = 17;
            Rectangle sourceRectangle = new Rectangle((currentFrame * currentWidth) + 54, 0, 17,GameConstants.SquareWidth);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 34, 64);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();
        }
    }
}

﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSprite.SmallMarioSprite
{
    public class LeftRunningSmallMarioSprite : IMarioSprite
    {

        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        Vector2 p;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }


        int currentFrame;
        int totalFrame;
        int currentUpdate;
        int slowSpeedDown;

        public LeftRunningSmallMarioSprite(Texture2D texture,SpriteBatch sb)
        {
            this.sb = sb;
            Texture = texture;
            tintColor = Color.White;
            currentFrame = 4;
            totalFrame = 4;
            currentUpdate = 0;
            slowSpeedDown = 5;
        }
        public void Update()
        {
            currentUpdate++;
            if (currentUpdate == slowSpeedDown)
            {
                currentUpdate = 0;
                currentFrame--;
                if (currentFrame == 1)
                    currentFrame = totalFrame;
            }

        }

        public Vector2 returnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            sb.Begin();
            
            int currentWidth = 15;
            Rectangle sourceRectangle = new Rectangle((currentFrame-1)*currentWidth, 0,15, 16);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 30,GameConstants.SquareWidth);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();
        }
    }
}

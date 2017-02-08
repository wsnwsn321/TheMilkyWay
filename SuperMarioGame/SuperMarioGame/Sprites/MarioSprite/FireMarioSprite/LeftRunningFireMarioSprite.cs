﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSprite.FireMarioSprite
{
    class LeftRunningFireMarioSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        Vector2 p;
        int height;
        int width;
        int currentFrame;
        int totalFrame;
        int currentUpdate;
        int slowSpeedDown;

        public LeftRunningFireMarioSprite(Texture2D texture, SpriteBatch sb)
        {
            this.sb = sb;
            Texture = texture;
            height = texture.Height;
            width = texture.Width / 8;
            totalFrame = 1;
            currentFrame = 3;
            currentUpdate = 4;
            slowSpeedDown = 5;
        }
        public void Update()
        {
            currentUpdate++;
            if (currentUpdate == slowSpeedDown)
            {
                currentUpdate = 0;
                currentFrame--;
                if (currentFrame ==0)
                    currentFrame = 3;
            }

        }

        public Vector2 returnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            sb.Begin();

            int currentWidth = 17;
            int column = currentFrame % totalFrame;
            Rectangle sourceRectangle = new Rectangle((currentFrame * currentWidth)+2, 0, 18, 33);
            Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 36, 66);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}

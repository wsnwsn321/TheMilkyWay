using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSpite.SmallMarioSprite
{
    class LeftRunningSmallMarioSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        Vector2 p;
        int height;
        int width;
        int currentFrame;
        int totalFrame;
        int currentUpdate;
        int slowSpeedDown;

        public LeftRunningSmallMarioSprite(Texture2D texture)
        {
            Texture = texture;
            height = texture.Height;
            width = texture.Width/2;
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

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Begin();

            int currentWidth = 15;
            int column = currentFrame % totalFrame;
            Rectangle sourceRectangle = new Rectangle((currentFrame-1)*currentWidth, 0,15, 16);
            Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 16, 16);
            spriteBatch.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            spriteBatch.End();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSprite.SmallMarioSprite
{
    class LeftRunningSmallMarioSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        Vector2 p;
        int currentFrame;
        int totalFrame;
        int currentUpdate;
        int slowSpeedDown;

        public LeftRunningSmallMarioSprite(Texture2D texture,SpriteBatch sb)
        {
            this.sb = sb;
            Texture = texture;
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
            int column = currentFrame % totalFrame;
            Rectangle sourceRectangle = new Rectangle((currentFrame-1)*currentWidth, 0,15, 16);
            Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 30, 32);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}

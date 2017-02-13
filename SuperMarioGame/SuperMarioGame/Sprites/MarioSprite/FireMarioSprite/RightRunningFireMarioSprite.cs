using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSprite.FireMarioSprite
{
    class RightRunningFireMarioSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        Vector2 p;
        int currentFrame;
        int totalFrame;
        int currentUpdate;
        int slowSpeedDown;

        public RightRunningFireMarioSprite(Texture2D texture, SpriteBatch sb)
        {
            this.sb = sb;
            Texture = texture;
            currentFrame = 0;
            totalFrame = 3;
            currentUpdate = 4;
            slowSpeedDown = 5;
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

        public void Draw(Vector2 position)
        {
            sb.Begin();

            int currentWidth = 17;
            Rectangle sourceRectangle = new Rectangle((currentFrame * currentWidth) + 73, 0, 18, 32);
            Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 36, 64);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}

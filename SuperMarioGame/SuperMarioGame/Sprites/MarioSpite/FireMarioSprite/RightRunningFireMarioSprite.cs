using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    class RightRunningFireMarioSprite: ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        int height;
        int width;
        int currentFrame;
        int totalFrame;
        int currentUpdate;
        int slowSpeedDown;

        public RightRunningFireMarioSprite(Texture2D texture)
        {
            Texture = texture;
            Texture = texture;
            height = texture.Height;
            width = texture.Width / 6;
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

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Begin();
            int currentWidth = 17;
            Rectangle sourceRectangle = new Rectangle((currentFrame * currentWidth) + 54, 0, 17, 32);
            Rectangle desRectangle = new Rectangle((int)position.X,(int)position.Y,18,28);
            spriteBatch.Draw(Texture, desRectangle,sourceRectangle, Color.White);
            p = position;
            spriteBatch.End();
        }
    }
}



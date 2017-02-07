using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    class CoinSprite: ISprite

    {
        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        Vector2 p;
        int currentFrame;
        int totalFrames;
        int counter = 0;
        int currentWidth;

        public CoinSprite(Texture2D texture,SpriteBatch sb)
        {
            this.sb = sb;
            Texture = texture;
            currentFrame = 0;
            totalFrames = 4;
            currentWidth = 6;            
        }
        public void Update()
        {
            if (counter % 7 == 0)
            {
                currentFrame++;
            }
            if(currentFrame == 0)
            {
                currentWidth = 9;
            }
            else
            {
                currentWidth = 6;
            }

            counter++;
            if (counter > 99)
            {
                counter = 0;
            }
            if (currentFrame == (totalFrames-1))
            {
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
            Rectangle sourceRectangle = new Rectangle((9*currentFrame),0,currentWidth,14);
            Rectangle desRectangle = new Rectangle((int)position.X,(int)position.Y,18,28);
            sb.Draw(Texture, desRectangle,sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}



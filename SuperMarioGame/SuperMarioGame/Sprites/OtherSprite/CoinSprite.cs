using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    public class CoinSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        int currentFrame;
        int totalFrames;
        int counter = 0;
        int currentWidth;

        public CoinSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
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
            if (currentFrame == 0)
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
            if (currentFrame == (totalFrames))
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
            Rectangle sourceRectangle = new Rectangle((9 * currentFrame), 0, currentWidth, 14);
            if (currentFrame == 2 || currentFrame == 3)
            {
                Rectangle desRectangle = new Rectangle((int)position.X+4, (int)position.Y, 18, 28);
                sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            }
            else
            {
                Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 18, 28);
                sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);

            }
            
            p = position;
            sb.End();
        }
    }
}



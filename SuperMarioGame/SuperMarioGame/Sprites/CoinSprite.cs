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
        Vector2 p;
        int currentFrame;
        int totalFrames;
        int counter = 0;

        public CoinSprite(Texture2D texture)
        {
            Texture = texture;
            currentFrame = 0;
            totalFrames = 4;


            
        }
        public void Update()
        {
            if (counter % 9 == 0)
            {
                currentFrame++;
            }
            counter++;
            if (counter > 99)
            {
                counter = 0;
            }

            if (currentFrame == (totalFrames - 1))
            {
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
            Rectangle sourceRectangle = new Rectangle((9*currentFrame),0,9,14);
            Rectangle desRectangle = new Rectangle((int)position.X,(int)position.Y,18,28);
            spriteBatch.Draw(Texture, desRectangle,sourceRectangle, Color.White);
            p = position;
            spriteBatch.End();
        }
    }
}



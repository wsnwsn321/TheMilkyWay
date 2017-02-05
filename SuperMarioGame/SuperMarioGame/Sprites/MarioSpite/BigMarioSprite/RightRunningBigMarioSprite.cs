using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Sprites.MarioSpite.BigMarioSprite
{
    class RightRunningBigMarioSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;

        public RightRunningBigMarioSprite(Texture2D texture)
        {
            Texture = texture;
        }
        public void Update()
        {

        }

        public Vector2 returnPosition()
        {
            return p;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Begin();
            Rectangle sourceRectangle = new Rectangle(36, 0, 18, 32);
            Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 36, 64);
            spriteBatch.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            spriteBatch.End();
        }
    }
}

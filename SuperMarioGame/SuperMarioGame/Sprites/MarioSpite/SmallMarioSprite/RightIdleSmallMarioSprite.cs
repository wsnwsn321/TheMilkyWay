using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSpite.SmallMarioSprite
{
    class RightIdleSmallMarioSprit : ISprite
    {
        
        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        Vector2 position;

        public RightIdleSmallMarioSprit(Texture2D texture, SpriteBatch sb)
        {
            this.sb = sb;
            Texture = texture;
        }
        public void Update()
        {

        }

        public Vector2 returnPosition()
        {
            return position;
        }

        public void Draw( Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(12, 0, 13, 16);
            Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 26, 32);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            this.position = position;
            sb.End();
        }
    }
}

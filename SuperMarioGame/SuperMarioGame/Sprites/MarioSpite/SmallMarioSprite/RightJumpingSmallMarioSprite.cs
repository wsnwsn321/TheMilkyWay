using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSpite.SmallMarioSprite
{
    class RightJumpingSmallMarioSprit : ISprite
    {

        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;

        public RightJumpingSmallMarioSprit(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
        }
        public void Update()
        {

        }

        public Vector2 returnPosition()
        {
            return p;
        }

        public void Draw( Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(17, 0, 16, 16);
            Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}

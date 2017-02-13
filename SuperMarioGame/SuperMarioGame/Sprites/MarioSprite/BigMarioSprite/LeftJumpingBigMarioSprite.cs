using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Sprites.MarioSprite.BigMarioSprite
{
    public class LeftJumpingBigMarioSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        Vector2 p;

        public LeftJumpingBigMarioSprite(Texture2D texture,SpriteBatch sb)
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
            Rectangle sourceRectangle = new Rectangle(0, 0, 16, 31);
            Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 62);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    public class BrickBlockSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Boolean toDraw { get; set; }

        public BrickBlockSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
            toDraw = true;
        }
        public void Update()
        {

        }

        public Vector2 returnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            if (toDraw)
            {
                sb.Begin();
                Rectangle sourceRectangle = new Rectangle(0, 0, 16, 16);
                Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);
                sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
                p = position;
                sb.End();
            }
        }
    }
}



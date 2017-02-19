﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Sprites.MarioSprite.BigMarioSprite
{
    public class RightIdleBigMarioSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }

        Vector2 p;

        public RightIdleBigMarioSprite(Texture2D texture,SpriteBatch sb)
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

        public void Draw(Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(36, 0, 18, 32);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 36, 64);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}

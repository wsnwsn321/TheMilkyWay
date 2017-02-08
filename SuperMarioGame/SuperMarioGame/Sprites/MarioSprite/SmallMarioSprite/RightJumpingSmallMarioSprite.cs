﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSprite.SmallMarioSprite
{
    class RightJumpingSmallMarioSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private SpriteBatch sb;
        public Vector2 position;

        public RightJumpingSmallMarioSprite(Texture2D texture, SpriteBatch sb)
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

        public void Draw(Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(17, 0, 16, 16);
            Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            this.position = position;
            sb.End();
        }
    }
}
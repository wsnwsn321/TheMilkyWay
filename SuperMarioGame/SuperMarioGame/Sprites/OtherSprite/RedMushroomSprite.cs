﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.Sprites
{
    public class RedMushroomSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        bool noD = true;
        public Rectangle desRectangle { get; set; }


        public RedMushroomSprite(Texture2D texture, SpriteBatch sb)
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
            if (noD == true)
            {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(0, 0, 16, 16);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
            }
          
        }
    }
}

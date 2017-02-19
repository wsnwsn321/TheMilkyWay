﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSprite.SmallMarioSprite
{
    public class DeadSmallMarioSprite:ISprite
    {
        
        public Texture2D Texture { get; set; }
        private Vector2 p;
        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }


        public DeadSmallMarioSprite(Texture2D texture,SpriteBatch sb)
        {
            this.sb = sb;
            Texture = texture;
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
            this.p = position;
            Rectangle sourceRectangle = new Rectangle(0, 0, 14, 14);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            sb.End();
        }
    }
}

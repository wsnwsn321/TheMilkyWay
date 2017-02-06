﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites.MarioSpite.SmallMarioSprite
{
    class LeftIdleSmallMarioSprit:ISprite
    {
        
            public Texture2D Texture { get; set; }
        Vector2 p;

        public LeftIdleSmallMarioSprit(Texture2D texture)
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
            Rectangle sourceRectangle = new Rectangle(0, 0, 12, 16);
            Rectangle desRectangle = new Rectangle((int)position.X, (int)position.Y, 24, 32);
            spriteBatch.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            spriteBatch.End();
        }
    }
}
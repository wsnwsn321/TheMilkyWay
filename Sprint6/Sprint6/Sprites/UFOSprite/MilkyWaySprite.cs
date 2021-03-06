﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame;
using TheMilkyWay.Sprites;
using System.Collections.ObjectModel;

namespace TheMilkyWay.Sprites.UFOSprite
{
    public class MilkyWaySprite : ISprite
    {
        public Rectangle desRectangle { get; set; }
        public bool canMove { get; set; }
        public Texture2D Texture { get; set; }
        public int currentFrame { get; set; }
        private SpriteBatch sb;
        public Collection<Circle> circles { get; }


        Vector2 p;

        public MilkyWaySprite(Texture2D texture,SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
        }
        public void Update()
        {

        }

        public Vector2 ReturnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(0, 0, 934, 728);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 360, 280);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();

        }
    }
}

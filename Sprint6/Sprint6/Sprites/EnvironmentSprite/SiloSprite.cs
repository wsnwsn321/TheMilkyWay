﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGame;
using System.Collections.ObjectModel;

namespace TheMilkyWay.Sprites.EnvironmentSprite
{
    public class SiloSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        public int currentFrame { get; set; }
        public bool canMove { get; set; }

        private SpriteBatch sb;
        public Rectangle desRectangle { get; set; }
        public Color tintColor { get; set; }
        public Collection<Circle> circles { get; }
        Vector2 p;

        public SiloSprite(Texture2D texture,SpriteBatch sb, int currentF)
        {
            Texture = texture;
            this.sb = sb;
            currentFrame = currentF;
            tintColor = Color.White;
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
            Rectangle sourceRectangle = new Rectangle(1690, 25, 340, 1332);
            desRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 260);
            sb.Draw(Texture, desRectangle, sourceRectangle, tintColor);
            p = position;
            sb.End();

        }
    }
}

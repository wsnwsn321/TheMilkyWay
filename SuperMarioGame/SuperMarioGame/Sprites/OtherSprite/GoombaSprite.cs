﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    public class GoombaSprite : ISprite

    {
        public Texture2D Texture { get; set; }
        Vector2 p;
        SpriteBatch sb;
        public Rectangle desRectangle { get; set; }

        int currentFrame;
        int totalFrame;
        int currentUpdate;
        int slowSpeedDown;

        public GoombaSprite(Texture2D texture, SpriteBatch sb)
        {
            Texture = texture;
            this.sb = sb;
            Texture = texture;
            currentFrame = 1;
            totalFrame = GameConstants.Three;
            currentUpdate = 0;
            slowSpeedDown = GameConstants.Eight;
        }
        public void Update()
        {
            currentUpdate++;
            if (currentUpdate == slowSpeedDown)
            {
                currentUpdate = 0;
                currentFrame++;
                if (currentFrame == totalFrame)
                    currentFrame = 1;
            }
        }

        public Vector2 returnPosition()
        {
            return p;
        }

        public void Draw(Vector2 position)
        {
            sb.Begin();
            Rectangle sourceRectangle = new Rectangle(18 * currentFrame, 0, GameConstants.Eight+ GameConstants.Ten, GameConstants.Sixteen);
            desRectangle = new Rectangle((int)position.X, (int)position.Y,GameConstants.SquareWidth, GameConstants.Twenty+ GameConstants.Eight);
            sb.Draw(Texture, desRectangle, sourceRectangle, Color.White);
            p = position;
            sb.End();
        }
    }
}



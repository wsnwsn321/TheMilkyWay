﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioGame.Sound.MarioSound;

namespace SuperMarioGame.HUDElements
{
    class PauseText
    {
        Game1 myGame;
        Vector2 FontPos;
        bool playOnce = true;

        public PauseText(Game1 game)
        {
            this.myGame = game;

            // TODO: Load your game content here            
            FontPos = new Vector2(GameConstants.ScreenWidth / 2,
                GameConstants.ScreenHeight / 2);
        }

        public void Draw()
        {
            if (playOnce)
            {
                playOnce = false;
            }

            FontPos = new Vector2(GameConstants.ScreenWidth / 2 - myGame.GraphicsDevice.Viewport.X,
                GameConstants.ScreenHeight / 2);

            // Draw Pause
            string output = "P A U S E D";

            // Find the center of the string
            Vector2 FontOrigin = myGame.font.MeasureString(output) / 2;

            // Draw the string. 3.0f represents the size
            myGame.spriteBatch.Begin();
            myGame.spriteBatch.DrawString(myGame.font, output, FontPos, Color.Black,
                0, FontOrigin, 3.0f, SpriteEffects.None, 0.5f);
            myGame.spriteBatch.End();
        }
    }
}
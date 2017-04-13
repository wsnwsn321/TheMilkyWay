using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.Sound.MarioSound;

namespace Sprint6.HUDElements
{
    class LifeText
    {
        Game1 myGame;
        Vector2 FontPos;
        bool playOnce = true;
        private int Two = 2;


        public LifeText(Game1 game)
        {
            this.myGame = game;

            // TODO: Load your game content here            
            FontPos = new Vector2(GameConstants.ScreenWidth / Two,
                GameConstants.ScreenHeight / Two);
        }

        public void Draw()
        {
            string output;
            if (playOnce)
            {
                playOnce = false;
            }

            FontPos = new Vector2(GameConstants.ScreenWidth / Two - myGame.GraphicsDevice.Viewport.X + GameConstants.Ten + GameConstants.Ten / GameConstants.Two,
                GameConstants.ScreenHeight / Two + GameConstants.Ten);

            // Draw Pause
            if (myGame.lifeCount > 0)
            {
                output = " x " + myGame.lifeCount;
                // Find the center of the string
                Vector2 FontOrigin = myGame.font.MeasureString(output) / Two;

                // Draw the string. 3.0f represents the size
                myGame.spriteBatch.Begin();
                myGame.spriteBatch.DrawString(myGame.font, output, FontPos, Color.White,
                    0, FontOrigin, 1.5f, SpriteEffects.None, 0.5f);
                myGame.spriteBatch.End();
            } else
            {
                output = " G A M E    O V E R";
                // Find the center of the string
                Vector2 FontOrigin = myGame.font.MeasureString(output) / Two;

                // Draw the string. 3.0f represents the size
                myGame.spriteBatch.Begin();
                myGame.spriteBatch.DrawString(myGame.font, output, FontPos, Color.White,
                    0, FontOrigin, 1.5f, SpriteEffects.None, 0.5f);
                myGame.spriteBatch.End();
                myGame.level.mario.isVisible = false;
               // myGame.Exit();
            }


        }
    }
}

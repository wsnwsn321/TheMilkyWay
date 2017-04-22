using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheMilkyWay.Sound.MarioSound;

namespace TheMilkyWay.HUDElements
{
    class PauseText
    {
        Game1 myGame;
        Vector2 FontPos;
        bool playOnce = true;
        private int Two = 2;


        public PauseText(Game1 game)
        {
            this.myGame = game;

            // TODO: Load your game content here            
            FontPos = new Vector2(GameConstants.ScreenWidth / Two,
                GameConstants.ScreenHeight / Two);
        }

        public void Draw()
        {
            if (playOnce)
            {
                playOnce = false;
            }

            FontPos = new Vector2(GameConstants.ScreenWidth / Two - myGame.GraphicsDevice.Viewport.X,
                GameConstants.ScreenHeight / Two);

            // Draw Pause
            string output = "P A U S E D";

            // Find the center of the string
            Vector2 FontOrigin = myGame.font.MeasureString(output) / Two;

            // Draw the string. 3.0f represents the size
            myGame.spriteBatch.Begin();
            myGame.spriteBatch.DrawString(myGame.font, output, FontPos, Color.Black,
                0, FontOrigin, 3.0f, SpriteEffects.None, 0.5f);
            myGame.spriteBatch.End();
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioGame.HUDElements
{
    class PauseText
    {
        Game1 myGame;
        Vector2 FontPos;

        public PauseText(Game1 game)
        {
            this.myGame = game;

            // TODO: Load your game content here            
            FontPos = new Vector2(GameConstants.ScreenWidth / 2,
                GameConstants.ScreenHeight / 2);
        }

        public void Draw()
        {
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

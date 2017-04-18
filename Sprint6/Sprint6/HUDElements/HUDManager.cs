using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.ElementClasses;
using Sprint6.SpriteFactories;
using System;

namespace Sprint6.HUDElements
{
    public class HUDManager
    {
        private Game1 mygame;
        public BeamMeter beamMeter;
        public CowHUD cowHUD;

        public HUDManager(Game1 game)
        {
            mygame = game;
            beamMeter = mygame.level.mainCharacter.beamMeter;
            cowHUD = new CowHUD(mygame);
        }

        public void DisplayHUDElements()
        {
            DisplayPlayerName();
            DisplayLevel();
            cowHUD.Display();
            beamMeter.Display();
        }
        private void DisplayPlayerName()
        {
            string player = mygame.playerName;

            Vector2 FontOrigin = mygame.font.MeasureString(player) / GameConstants.Two;

            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, player, new Vector2(GameConstants.ScreenWidth / GameConstants.Eight - mygame.GraphicsDevice.Viewport.X,
                (GameConstants.ScreenHeight / GameConstants.Eleven) - GameConstants.Ten), Color.White,
            0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }

        public void DisplayLevel()
        {
            String output1 = "FARM";
            String output2 = "1";
            Vector2 FontOrigin1 = mygame.font.MeasureString(output1) / GameConstants.Two;
            Vector2 FontOrigin2 = mygame.font.MeasureString(output2) / GameConstants.Two;

            mygame.spriteBatch.Begin();


            mygame.spriteBatch.End();
        }
    }

}

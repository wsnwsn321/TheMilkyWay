using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheMilkyWay.ElementClasses;
using TheMilkyWay.SpriteFactories;
using System;

namespace TheMilkyWay.HUDElements
{
    public class HUDManager
    {
        private Game1 mygame;
        private BeamMeter beamMeter;
        private CowHUD cowHUD;
        private BadCowHUD badcowHUD;
        public MainMenu menu { get; set; }
        private bool first = true;
        public bool displayMenu { get; set; }

        public HUDManager(Game1 game)
        {
            mygame = game;
            beamMeter = mygame.level.mainCharacter.beamMeter;
            cowHUD = new CowHUD(mygame);
            badcowHUD = new BadCowHUD(mygame);
            menu = new MainMenu(mygame);
            displayMenu = false;
        }

        public void DisplayHUDElements()
        {

            if (displayMenu)
            {
                menu.Display();
                if (first)
                {
                    menu.moveCharacter();
                    first = false;
                }
            }
            else
            {
                DisplayPlayerName();
                cowHUD.Display();
                badcowHUD.Display();
                beamMeter.Display();
            }
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

       
    }
}

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
        private GoalHUD goalHUD;
        public MainMenu menu { get; set; }
        public Credits credits { get; set; }
        public Collectibles collectibles { get; set; }
        private bool firstMenu = true;
        private bool firstCredits = true;
        private bool firstCollectibles = true;
        public bool displayMenu { get; set; }
        public bool displayCredits { get; set; }

        public bool displayCollectibles { get; set; }

        public HUDManager(Game1 game)
        {
            mygame = game;
            beamMeter = mygame.level.mainCharacter.beamMeter;
            cowHUD = new CowHUD(mygame);
            badcowHUD = new BadCowHUD(mygame);
            menu = new MainMenu(mygame);
            credits = new Credits(mygame);
            collectibles = new Collectibles(mygame);
            goalHUD = new GoalHUD(mygame);
            displayMenu = false;
            displayCredits = false;
            displayCollectibles = false;
        }

        public void DisplayHUDElements()
        {

            if (displayMenu)
            {
                menu.Display();
                if (firstMenu)
                {
                    menu.moveCharacter();
                    firstMenu = false;
                }
            } else if (displayCredits)
            {
                credits.Display();
                if (firstCredits)
                {
                    credits.moveCharacter();
                    firstCredits = !firstCredits;
                }
            }
            else if (displayCollectibles)
            {
                collectibles.Display();
                if (firstCollectibles)
                {
                    collectibles.moveCharacter();
                    firstCollectibles = !firstCollectibles;
                }
            }
            else
            {
                DisplayPlayerName();
                cowHUD.Display();
                badcowHUD.Display();
                beamMeter.Display();
                goalHUD.Display();


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

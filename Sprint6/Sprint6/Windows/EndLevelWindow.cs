using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheMilkyWay.Sprites;
using TheMilkyWay.Sprites.UFOSprite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMilkyWay.HUDElements
{
    public class EndLevelWindow : IWindow
    {
        private Game1 mygame;
        public Rectangle windowRect { get; set; }
        private Rectangle borderRect;
        private Texture2D pixel;

        private Vector2 menuItem1;
        private string messageToDisplay;
        private Vector2 FontOrigin1;
        private string levelPass, levelFail;

        public EndLevelWindow(Game1 game)
        {
            mygame = game;
            pixel = new Texture2D(mygame.GraphicsDevice, 1, 1);
            Color[] colorData = {
                Color.White,
            };
            pixel.SetData<Color>(colorData);
            levelPass = "Udderly Awesome! You Passed this level.\nPress 'r' to try again, or 'q' to return to the menu.";
            levelFail = "By Our Cowculations, you did not meet the goal.\nPress 'r' to try again, or 'q' to return to the menu.";
        }

        public void Display()
        {
            windowRect = new Rectangle((mygame.level.gameWidth-(GameConstants.ScreenWidth / 2)) - 200, (GameConstants.ScreenHeight / 2) - 75, 400, 150);
            borderRect = new Rectangle((mygame.level.gameWidth-(GameConstants.ScreenWidth / 2)) - 205, (GameConstants.ScreenHeight / 2) - 80, 410, 160);
            int cowCount = mygame.level.mainCharacter.GoodCowCount + mygame.level.mainCharacter.BadCowCount;
            int goal = (int)((mygame.level.maxGoodCowCount + mygame.level.maxBadCowCount) * 0.8);
            if (cowCount >= goal)
            {
                messageToDisplay = levelPass;
            }
            else
            {
                messageToDisplay = levelFail;
            }
            FontOrigin1 = mygame.font.MeasureString(messageToDisplay) / GameConstants.Two;
            menuItem1.X = (windowRect.X + windowRect.Width / 2) + 5;
            menuItem1.Y = windowRect.Y + windowRect.Height / 2;
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.Draw(pixel, borderRect, Color.White);
            mygame.spriteBatch.Draw(pixel, windowRect, Color.Gray);
            mygame.spriteBatch.DrawString(mygame.font, messageToDisplay, menuItem1, Color.White,
                0, FontOrigin1, 1f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }
    }
}

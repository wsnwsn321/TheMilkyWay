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
using TheMilkyWay.SpriteFactories;

namespace TheMilkyWay.HUDElements
{
    public class Collectibles
    {
        private Game1 mygame;
        private Vector2 levelOnePos;
        private Vector2 levelTwoPos;
        private Vector2 levelThreePos;
        private Vector2 quitPos;
        private Vector2 instPos;
        private Vector2 collectiblesPos;
        private Vector2 creditsPos;
        private Vector2 menuItem8;
        private Vector2 FontOrigin1;
        private Vector2 FontOrigin2;
        private Vector2 FontOrigin3;
        private Vector2 FontOrigin4;
        private Vector2 FontOrigin5;
        private Vector2 FontOrigin6;
        private Vector2 FontOrigin7;
        private string levelOne;
        private string levelTwo;
        private string levelThree;
        private string quit;
        private string collectibles;
        private string credits;
        private string inst;

        private ISprite logo;
        private Vector2 ufo;
        public int ufoPos { get; set; }

        public Collectibles(Game1 game)
        {
            mygame = game;
            logo = BackgroundSpriteFactory.Instance.CreateMilkyWaySprite();
            mygame.level.mainCharacter.GoodCowCount = 0;
            mygame.level.mainCharacter.BadCowCount = 0;
            levelOnePos.X = GameConstants.ScreenWidth/2;
            levelOnePos.Y = GameConstants.ScreenHeight/5;
            levelTwoPos.X = levelOnePos.X;
            levelTwoPos.Y = levelOnePos.Y + GameConstants.MenuItemSpacing;
            levelThreePos.X = levelOnePos.X;
            levelThreePos.Y = levelOnePos.Y + GameConstants.MenuItemSpacing * 2;
            quitPos.X = levelOnePos.X;
            quitPos.Y = levelOnePos.Y + GameConstants.MenuItemSpacing * 5;
            instPos.X = levelOnePos.X;
            instPos.Y = levelOnePos.Y + GameConstants.MenuItemSpacing * 6;
            collectiblesPos.X = levelOnePos.X;
            collectiblesPos.Y = levelOnePos.Y + GameConstants.MenuItemSpacing * 3;
            creditsPos.X = levelOnePos.X;
            creditsPos.Y = levelOnePos.Y + GameConstants.MenuItemSpacing * 4;
            menuItem8.X = 25;
            menuItem8.Y = 10;
            ufo.X = levelOnePos.X - 180;
            ufo.Y = levelOnePos.Y - 30;

            levelOne = "Collectibles";
            levelTwo = "Level 2";
            levelThree = "Level 3";
            collectibles = "Collectibles";
            credits = "Credits";
            quit = "Exit Game";
            inst = "Use the arrow keys to navigate\nHit enter to select your choice";

            FontOrigin1 = mygame.font.MeasureString(levelOne) / GameConstants.Two;
            FontOrigin2 = mygame.font.MeasureString(levelTwo) / GameConstants.Two;
            FontOrigin3 = mygame.font.MeasureString(levelThree) / GameConstants.Two;
            FontOrigin4 = mygame.font.MeasureString(quit) / GameConstants.Two;
            FontOrigin5 = mygame.font.MeasureString(inst) / GameConstants.Two;
            FontOrigin6 = mygame.font.MeasureString(collectibles) / GameConstants.Two;
            FontOrigin7 = mygame.font.MeasureString(credits) / GameConstants.Two;
            ufoPos = 1;
        }

        public void Display()
        {
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, levelOne, levelOnePos, Color.White,
            0, FontOrigin1, 2f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, levelTwo, levelTwoPos, Color.White,
                0, FontOrigin2, 2f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, levelThree, levelThreePos, Color.White,
                0, FontOrigin3, 2f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, quit, quitPos, Color.White,
                0, FontOrigin4, 2f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, inst, instPos, Color.White,
                0, FontOrigin5, 1f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, collectibles, collectiblesPos, Color.White,
                0, FontOrigin6, 2f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, credits, creditsPos, Color.White,
                0, FontOrigin7, 2f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
            logo.Draw(menuItem8);
        }

        public void moveCharacter()
        {
            mygame.level.mainCharacter.position = ufo;
        }
        public void moveCharacterUp()
        {
            Vector2 charPos = mygame.level.mainCharacter.position;
            if (charPos.Y > levelOnePos.Y-30 && ufoPos!=1)
            {
                ufoPos--;
                determinePos(ufoPos);
            }
        }
        public void moveCharacterDown()
        {
            Vector2 charPos = mygame.level.mainCharacter.position;
            if (charPos.Y < quitPos.Y && ufoPos!=6)
            {
                ufoPos++;
                determinePos(ufoPos);
            }
        }

        private void determinePos(int ufoPos)
        {
            switch (ufoPos)
            {
                case 1:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, levelOnePos.Y - 30);
                    break;
                case 2:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, levelTwoPos.Y - 30);
                    break;
                case 3:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, levelThreePos.Y - 30);
                    break;
                case 4:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, collectiblesPos.Y - 30);
                    break;
                case 5:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, creditsPos.Y - 30);
                    break;
                case 6:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, quitPos.Y - 30);
                    break;
            }
        }
    }
}

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
    public class Credits
    {
        private Game1 mygame;
        private Vector2 menuItem1, menuItem2, menuItem3, menuItem4, menuItem5, menuItem6;
        private Vector2 FontOrigin1, FontOrigin2, FontOrigin3, FontOrigin4, FontOrigin5;
        private string levelOne, levelTwo, levelThree, quit, inst;
        private ISprite logo;
        private Vector2 ufo;
        public int ufoPos { get; set; }

        public Credits(Game1 game)
        {
            mygame = game;
            logo = BackgroundSpriteFactory.Instance.CreateMilkyWaySprite();
            mygame.level.mainCharacter.GoodCowCount = 0;
            mygame.level.mainCharacter.BadCowCount = 0;

            menuItem1.X = (GameConstants.ScreenWidth * GameConstants.Three / GameConstants.Four) + 10;
            menuItem1.Y = GameConstants.ScreenHeight / GameConstants.Four;
            menuItem2.X = menuItem1.X;
            menuItem2.Y = menuItem1.Y + 75;
            menuItem3.X = menuItem1.X;
            menuItem3.Y = menuItem1.Y + 150;
            menuItem4.X = menuItem1.X;
            menuItem4.Y = menuItem1.Y + 225;
            menuItem5.X = menuItem1.X;
            menuItem5.Y = menuItem1.Y + 300;
            menuItem6.X = 25;
            menuItem6.Y = 10;
            ufo.X = menuItem1.X - 175;
            ufo.Y = menuItem1.Y - 30;


            levelOne = "Level 1";
            levelTwo = "Level 2";
            levelThree = "Level 3";
            quit = "Exit Game";
            inst = "Use the arrow keys to navigate\nHit enter to select your choice";

            FontOrigin1 = mygame.font.MeasureString(levelOne) / GameConstants.Two;
            FontOrigin2 = mygame.font.MeasureString(levelTwo) / GameConstants.Two;
            FontOrigin3 = mygame.font.MeasureString(levelThree) / GameConstants.Two;
            FontOrigin4 = mygame.font.MeasureString(quit) / GameConstants.Two;
            FontOrigin5 = mygame.font.MeasureString(inst) / GameConstants.Two;


            ufoPos = 1;
        }

        public void Display()
        {
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, levelOne, menuItem1, Color.White,
            0, FontOrigin1, 2f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, levelTwo, menuItem2, Color.White,
                0, FontOrigin2, 2f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, levelThree, menuItem3, Color.White,
                0, FontOrigin3, 2f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, quit, menuItem4, Color.White,
                0, FontOrigin4, 2f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, inst, menuItem5, Color.White,
                0, FontOrigin5, 1f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
            logo.Draw(menuItem6);
        }

        public void moveCharacter()
        {
            mygame.level.mainCharacter.position = ufo;
        }
        public void moveCharacterUp()
        {
            Vector2 charPos = mygame.level.mainCharacter.position;
            if (charPos.Y > menuItem1.Y - 30)
            {
                ufoPos--;
                switch (ufoPos)
                {
                    case 1:
                        mygame.level.mainCharacter.position = new Vector2(ufo.X, menuItem1.Y - 30);
                        break;
                    case 2:
                        mygame.level.mainCharacter.position = new Vector2(ufo.X, menuItem2.Y - 30);
                        break;
                    case 3:
                        mygame.level.mainCharacter.position = new Vector2(ufo.X, menuItem3.Y - 30);
                        break;
                    case 4:
                        mygame.level.mainCharacter.position = new Vector2(ufo.X, menuItem4.Y - 30);
                        break;
                }
            }
        }
        public void moveCharacterDown()
        {
            Vector2 charPos = mygame.level.mainCharacter.position;
            if (charPos.Y < menuItem1.Y + 150)
            {
                ufoPos++;
                switch (ufoPos)
                {
                    case 1:
                        mygame.level.mainCharacter.position = new Vector2(ufo.X, menuItem1.Y - 30);
                        break;
                    case 2:
                        mygame.level.mainCharacter.position = new Vector2(ufo.X, menuItem2.Y - 30);
                        break;
                    case 3:
                        mygame.level.mainCharacter.position = new Vector2(ufo.X, menuItem3.Y - 30);
                        break;
                    case 4:
                        mygame.level.mainCharacter.position = new Vector2(ufo.X, menuItem4.Y - 30);
                        break;
                }
            }
        }
    }
}

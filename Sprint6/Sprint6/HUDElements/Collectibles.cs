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
        private Vector2 collectiblePos;
        private Vector2 music1Pos;
        private Vector2 music2Pos;
        private Vector2 quitPos;
        private Vector2 music3Pos;
        private Vector2 music4Pos;
        private Vector2 music5Pos;
        private Vector2 music6Pos;
        private Vector2 FontOrigin1;
        private Vector2 FontOrigin2;
        private Vector2 FontOrigin3;
        private Vector2 FontOrigin4;
        private Vector2 FontOrigin5;
        private Vector2 FontOrigin6;
        private Vector2 FontOrigin7;
        private Vector2 FontOrigin8;
        private Vector2 FontOrigin9;
        private Vector2 menuItem8;
        private string collectibles;
        private string music1;
        private string music2;
        private string quit;
        private string music3;
        private string music4;
        private string music5;
        private string music6;
        private Vector2 ufo;
        public int ufoPos { get; set; }

        public Collectibles(Game1 game)
        {
            mygame = game;
            mygame.level.mainCharacter.GoodCowCount = 0;
            mygame.level.mainCharacter.BadCowCount = 0;
            collectiblePos.X = GameConstants.ScreenWidth/2;
            collectiblePos.Y = GameConstants.ScreenHeight/20;
            music1Pos.X = collectiblePos.X;
            music1Pos.Y = collectiblePos.Y + GameConstants.MenuItemSpacing;
            music2Pos.X = collectiblePos.X;
            music2Pos.Y = collectiblePos.Y + GameConstants.MenuItemSpacing * 2;
            music3Pos.X = collectiblePos.X;
            music3Pos.Y = collectiblePos.Y + GameConstants.MenuItemSpacing * 3;
            music4Pos.X = collectiblePos.X;
            music4Pos.Y = collectiblePos.Y + GameConstants.MenuItemSpacing * 4;
            music5Pos.X = collectiblePos.X;
            music5Pos.Y = collectiblePos.Y + GameConstants.MenuItemSpacing * 5;
            music6Pos.X = collectiblePos.X;
            music6Pos.Y = collectiblePos.Y + GameConstants.MenuItemSpacing * 6;
            quitPos.X = collectiblePos.X*2;
            quitPos.Y = collectiblePos.Y + GameConstants.MenuItemSpacing * 6;
            menuItem8.X = 25;
            menuItem8.Y = 10;
            ufo.X = collectiblePos.X - 180;
            ufo.Y = collectiblePos.Y - 30;

            collectibles = "Collectibles";
            music1 = "The Simpsons Hit & Run \"Nightmare on Evergreen\"";
            music2 = "Grabbed by the Ghoulies \"Main Theme\"";
            music3 = "Kelis \"MilkShake\"";
            music4 = "Destroy All Humans! 2 \"Furon Theme\"";
            music5 = "\"Benny Hill remix\"";
            music6 = "Kevin MacLeod \"Pixel Peeker\"";
            quit = "Press Q to go back to main menu";


            FontOrigin1 = mygame.font.MeasureString(collectibles) / GameConstants.Two;
            FontOrigin2 = mygame.font.MeasureString(music1) / GameConstants.Two;
            FontOrigin3 = mygame.font.MeasureString(music2) / GameConstants.Two;
            FontOrigin4 = mygame.font.MeasureString(music3) / GameConstants.Two;
            FontOrigin5 = mygame.font.MeasureString(music4) / GameConstants.Two;
            FontOrigin6 = mygame.font.MeasureString(music5) / GameConstants.Two;
            FontOrigin7 = mygame.font.MeasureString(music6) / GameConstants.Two;
            FontOrigin8 = mygame.font.MeasureString(quit) / GameConstants.Two;
            ufoPos = 1;
        }

        public void Display()
        {
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, collectibles, collectiblePos, Color.White,
            0, FontOrigin1, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, music1, music1Pos, Color.Gray,
                0, FontOrigin2, 1f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, music2, music2Pos, Color.Gray,
                0, FontOrigin3, 1f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, music3, music3Pos, Color.Gray,
                0, FontOrigin4, 1f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, music4, music4Pos, Color.Gray,
                0, FontOrigin5, 1f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, music5, music5Pos, Color.Gray,
              0, FontOrigin6, 1f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, music6, music6Pos, Color.Gray,
                0, FontOrigin7, 1f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, quit, quitPos, Color.White,
                0, FontOrigin8, 1f, SpriteEffects.None, 1f);
           
            mygame.spriteBatch.End();
        }

        public void moveCharacter()
        {
            mygame.level.mainCharacter.position = ufo;
        }
        public void moveCharacterUp()
        {
            Vector2 charPos = mygame.level.mainCharacter.position;
            if (charPos.Y > collectiblePos.Y-30 && ufoPos!=1)
            {
                ufoPos--;
                determinePos(ufoPos);
            }
        }
        public void moveCharacterDown()
        {
            Vector2 charPos = mygame.level.mainCharacter.position;
            if (charPos.Y < quitPos.Y && ufoPos!=8)
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
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, collectiblePos.Y - 30);
                    break;
                case 2:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, music1Pos.Y - 30);
                    break;
                case 3:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, music2Pos.Y - 30);
                    break;
                case 4:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, music3Pos.Y - 30);
                    break;
                case 5:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, music4Pos.Y - 30);
                    break;
                case 6:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, music5Pos.Y - 30);
                    break;
                case 7:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, music6Pos.Y - 30);
                    break;
                case 8:
                    mygame.level.mainCharacter.position = new Vector2(ufo.X, quitPos.Y - 30);
                    break;
               
            }
        }
    }
}

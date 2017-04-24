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
        private Vector2 creditsItem;
        private Vector2 creditsFontOrigin;
        private Vector2 exitItem;
        private Vector2 exitFontOrigin;
        private Vector2[] devItems;
        private Vector2[] devFontOrigins;
        private Vector2[] artItems;
        private Vector2[] artFontOrigins;
        private Vector2[] musicItems;
        private Vector2[] musicFontOrigins;
        private string exit, credits, developers, dev1, dev2, dev3, dev4, artwork, art1, art2;
        private string music, simpsons, simtitle, grabbed, grabtitle, kelis, kelistitle, destroy, desttitle, 
            kevin, kevintitle, d1, d1title;
        public Credits(Game1 game)
        {
            int i = 0;
            mygame = game;
            mygame.level.mainCharacter.GoodCowCount = 0;
            mygame.level.mainCharacter.BadCowCount = 0;

            creditsItem = new Vector2(GameConstants.ScreenWidth / GameConstants.Two, GameConstants.ScreenHeight / GameConstants.Ten);
            exitItem = new Vector2(GameConstants.ScreenWidth / GameConstants.Three * GameConstants.Two, GameConstants.ScreenHeight / GameConstants.Ten * GameConstants.Nine);

            devItems = new Vector2[5];
            devFontOrigins = new Vector2[5];
            artItems = new Vector2[3];
            artFontOrigins = new Vector2[3];
            musicItems = new Vector2[13];
            musicFontOrigins = new Vector2[13];

            for (i = 0; i < devItems.Length; i++)
            {
                devItems[i].X = (GameConstants.ScreenWidth / GameConstants.Two);
                devItems[i].Y = GameConstants.ScreenHeight / GameConstants.Five + i * 30;
            }

            for (i = 0; i < artItems.Length; i++)
            {
                artItems[i].X = (GameConstants.ScreenWidth / GameConstants.Four * GameConstants.Three);
                artItems[i].Y = GameConstants.ScreenHeight / GameConstants.Five + i * 30;
            }

            for (i = 0; i < musicItems.Length; i++)
            {
                musicItems[i].X = (GameConstants.ScreenWidth / GameConstants.Five);
                musicItems[i].Y = GameConstants.ScreenHeight / GameConstants.Five + i * 30;
            }

            credits = "Credits";
            exit = "Press Q to return to main menu!";
            developers = "Developers";
            dev1 = "Chris Crain";
            dev2 = "Nate Pratt";
            dev3 = "Oliver Wu";
            dev4 = "George Yang";
            artwork = "Artwork";
            art1 = "FlatRedBall";
            art2 = "Viscious - Speed";
            music = "Music";
            simpsons = "The Simpsons Hit & Run";
            simtitle = "\"Nightmare on Evergreen\"";
            grabbed = "Grabbed by the Ghoulies";
            grabtitle = "\"Main Theme\"";
            kelis = "Kelis";
            kelistitle = "\"Milkshake\"";
            destroy = "Overwatch";
            desttitle = "\"Junkensteins Revenge\"";
            kevin = "Kevin MacLeod";
            kevintitle = "\"Pixel Peeker Polka\"";
            d1 = "D1OfAquavibe";
            d1title = "\"Party Troll\"";


            creditsFontOrigin = mygame.font.MeasureString(credits) / GameConstants.Two;
            exitFontOrigin = mygame.font.MeasureString(exit) / GameConstants.Two;


            devFontOrigins[0] = mygame.font.MeasureString(developers) / GameConstants.Two;
            devFontOrigins[1] = mygame.font.MeasureString(dev1) / GameConstants.Two;
            devFontOrigins[2] = mygame.font.MeasureString(dev2) / GameConstants.Two;
            devFontOrigins[3] = mygame.font.MeasureString(dev3) / GameConstants.Two;
            devFontOrigins[4] = mygame.font.MeasureString(dev4) / GameConstants.Two;

            artFontOrigins[0] = mygame.font.MeasureString(artwork) / GameConstants.Two;
            artFontOrigins[1] = mygame.font.MeasureString(art1) / GameConstants.Two;
            artFontOrigins[2] = mygame.font.MeasureString(art2) / GameConstants.Two;

            musicFontOrigins[0] = mygame.font.MeasureString(music) / GameConstants.Two;
            musicFontOrigins[1] = mygame.font.MeasureString(simpsons) / GameConstants.Two;
            musicFontOrigins[2] = mygame.font.MeasureString(simtitle) / GameConstants.Two;
            musicFontOrigins[3] = mygame.font.MeasureString(grabbed) / GameConstants.Two;
            musicFontOrigins[4] = mygame.font.MeasureString(grabtitle) / GameConstants.Two;
            musicFontOrigins[5] = mygame.font.MeasureString(kelis) / GameConstants.Two;
            musicFontOrigins[6] = mygame.font.MeasureString(kelistitle) / GameConstants.Two;
            musicFontOrigins[7] = mygame.font.MeasureString(destroy) / GameConstants.Two;
            musicFontOrigins[8] = mygame.font.MeasureString(desttitle) / GameConstants.Two;
            musicFontOrigins[9] = mygame.font.MeasureString(kevin) / GameConstants.Two;
            musicFontOrigins[10] = mygame.font.MeasureString(kevintitle) / GameConstants.Two;
            musicFontOrigins[11] = mygame.font.MeasureString(d1) / GameConstants.Two;
            musicFontOrigins[12] = mygame.font.MeasureString(d1title) / GameConstants.Two;


        }

        public void Display()
        {
            mygame.level.mainCharacter.isVisible = false;
            mygame.level.mainCharacter.canMove = false;
            mygame.level.mainCharacter.position = new Vector2(-10000, -10000);
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, credits, creditsItem, Color.White,
            0, creditsFontOrigin, 3.0f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, exit, exitItem, Color.White,
            0, exitFontOrigin, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
            DisplayDevelopers();
            DisplayArtists();
            DisplayMusic();
        }

        private void DisplayDevelopers()
        {
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, developers, devItems[0], Color.LightGreen,
            0, devFontOrigins[0], 2.0f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, dev1, devItems[1], Color.LightGreen,
            0, devFontOrigins[1], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, dev2, devItems[2], Color.LightGreen,
            0, devFontOrigins[2], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, dev3, devItems[3], Color.LightGreen,
            0, devFontOrigins[3], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, dev4, devItems[4], Color.LightGreen,
            0, devFontOrigins[4], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }
        
        private void DisplayMusic()
        {
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, music, musicItems[0], Color.Red,
            0, musicFontOrigins[0], 2.0f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, simpsons, musicItems[1], Color.Red,
            0, musicFontOrigins[1], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, simtitle, musicItems[2], Color.HotPink,
            0, musicFontOrigins[2], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, grabbed, musicItems[3], Color.Red,
            0, musicFontOrigins[3], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, grabtitle, musicItems[4], Color.HotPink,
            0, musicFontOrigins[4], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, kelis, musicItems[5], Color.Red,
            0, musicFontOrigins[5], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, kelistitle, musicItems[6], Color.HotPink,
            0, musicFontOrigins[6], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, destroy, musicItems[7], Color.Red,
            0, musicFontOrigins[7], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, desttitle, musicItems[8], Color.HotPink,
            0, musicFontOrigins[8], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, kevin, musicItems[9], Color.Red,
            0, musicFontOrigins[9], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, kevintitle, musicItems[10], Color.HotPink,
            0, musicFontOrigins[10], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, d1, musicItems[11], Color.Red,
            0, musicFontOrigins[11], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, d1title, musicItems[12], Color.HotPink,
            0, musicFontOrigins[12], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }

        private void DisplayArtists()
        {
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, artwork, artItems[0], Color.White,
            0, artFontOrigins[0], 2.0f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, art1, artItems[1], Color.White,
            0, artFontOrigins[1], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, art2, artItems[2], Color.White,
            0, artFontOrigins[2], 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }

    }
}

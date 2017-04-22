using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheMilkyWay.Sprites;
using TheMilkyWay.Sprites.UFOSprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMilkyWay.HUDElements
{
    public class BadCowHUD
    {
        private ISprite badcowHead;
        private Game1 mygame;
        private int maxGoodCowCount;

        public int CowCount { get; set; }

        public BadCowHUD(Game1 game)
        {
            mygame = game;
            CowCount = 0;
            badcowHead = SpriteFactories.CharacterSpriteFactory.Instance.CreateBadCowHeadSprite();
        }

        public void Display()
        {
            Vector2 newPos;
            Vector2 newCowPos;
            CowCount = mygame.level.mainCharacter.BadCowCount;
            maxGoodCowCount = mygame.level.maxBadCowCount;
            newPos.X = (GameConstants.ScreenWidth - mygame.GraphicsDevice.Viewport.X) - GameConstants.Ten * GameConstants.Two * GameConstants.Two;
            newPos.Y = GameConstants.ScreenHeight / (GameConstants.Eight);
            newCowPos.X = newPos.X - badcowHead.desRectangle.Width * 2;
            newCowPos.Y = newPos.Y - badcowHead.desRectangle.Height / 2;
            String output = CowCount + "/" + maxGoodCowCount;


            Vector2 FontOrigin = mygame.font.MeasureString(output) / GameConstants.Two;
            badcowHead.Draw(newCowPos);
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, output, newPos, Color.White,
            0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }
    }
}

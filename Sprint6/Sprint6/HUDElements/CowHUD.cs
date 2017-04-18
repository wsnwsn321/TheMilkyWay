using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint6.HUDElements
{
    public class CowHUD
    {
        private ISprite cowHead;
        private Game1 mygame;

        public int CowCount { get; set; }

        public CowHUD(Game1 game)
        {
            mygame = game;
            CowCount = 0;
            cowHead = SpriteFactories.CharacterSpriteFactory.Instance.CreateCowHeadSprite();
        }

        public void Display()
        {
            Vector2 newPos;
            Vector2 newCowPos;
            CowCount = mygame.level.mainCharacter.CowCount;
            newPos.X = (GameConstants.ScreenWidth - mygame.GraphicsDevice.Viewport.X) - GameConstants.Ten * GameConstants.Two * GameConstants.Two;
            newPos.Y = GameConstants.ScreenHeight / (GameConstants.Ten + GameConstants.Eight);
            newCowPos.X = newPos.X - cowHead.desRectangle.Width * 2;
            newCowPos.Y = newPos.Y - cowHead.desRectangle.Height / 2;
            String zero = "0";
            String output;
            if (CowCount > (GameConstants.Ten - 1))
            {
                output = "X" + CowCount + "";
            }
            else
            {
                output = "X" + zero + CowCount + "";
            }

            Vector2 FontOrigin = mygame.font.MeasureString(output) / GameConstants.Two;
            cowHead.Draw(newCowPos);
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, output, newPos, Color.White,
            0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }
    }
}

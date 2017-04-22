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
    public class GoalHUD
    {
        private Game1 mygame;

        public int CowCount { get; set; }

        public GoalHUD(Game1 game)
        {
            mygame = game;
            CowCount = 0;
        }

        public void Display()
        {
            Vector2 newPos;
            Vector2 goalPos;
            CowCount = mygame.level.mainCharacter.GoodCowCount+ mygame.level.mainCharacter.BadCowCount;
            newPos.X = (GameConstants.ScreenWidth - mygame.GraphicsDevice.Viewport.X) - GameConstants.Ten * GameConstants.Two * GameConstants.Two;
            newPos.Y = GameConstants.ScreenHeight / (GameConstants.Five);
            goalPos.X = (GameConstants.ScreenWidth - mygame.GraphicsDevice.Viewport.X) - GameConstants.Ten * GameConstants.Two * GameConstants.Five;
            goalPos.Y = GameConstants.ScreenHeight / (GameConstants.Five);
            String success = "Goal: ";
            int goal = (int)((mygame.level.maxGoodCowCount+ mygame.level.maxBadCowCount) * 0.8);
            String output = CowCount + "/" + goal;
            Vector2 FontOrigin = mygame.font.MeasureString(output) / GameConstants.Two;
            mygame.spriteBatch.Begin();
            if (CowCount < goal)
            {
            mygame.spriteBatch.DrawString(mygame.font, success, goalPos, Color.Red,
            0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, output, newPos, Color.Red,
            0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
            }
            else
            {
                mygame.spriteBatch.DrawString(mygame.font, success, goalPos, Color.LawnGreen,
          0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
                mygame.spriteBatch.DrawString(mygame.font, output, newPos, Color.LawnGreen,
                0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
            }
            
            mygame.spriteBatch.End();
        }
    }
}

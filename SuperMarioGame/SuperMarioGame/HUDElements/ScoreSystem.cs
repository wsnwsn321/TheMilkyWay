using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.ElementClasses.ItemClass;
using SuperMarioGame.SpriteFactories;
using SuperMarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.HUDElements
{ 
    class ScoreSystem
    {
        Game1 mygame;
        Coin c;
        static int timeElapsed = 0;
        static int timeLeft = GameConstants.InitialTimerValue;
     
        public ScoreSystem(Game1 game)
        {
            this.mygame = game;
             c = new Coin(new Vector2(GameConstants.ScreenWidth / GameConstants.Three - mygame.GraphicsDevice.Viewport.X,
                GameConstants.ScreenHeight / GameConstants.Twelve));
        }

        public void DisplayScore(int score)
        {
            String mario = "MARIO";
            String zeros = "000";
            String output;
            if (score == 0)
            {
                output = "000000";
            }
            else if (score <= GameConstants.score900)
            {
                output = zeros+score + "";
            }
            else if(score> GameConstants.score900 && score <= GameConstants.score9900)
            {
                output = zeros.Substring(0,2) + score + "";
            }
            else if(score> GameConstants.score9900 && score < GameConstants.score99900)
            {
                output = zeros.Substring(0,1) + score + "";
            }
            else
            {
                output = score + "";
            } 
           
            Vector2 FontOrigin = mygame.font.MeasureString(output)/ GameConstants.Two;
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, mario, new Vector2(GameConstants.ScreenWidth /GameConstants.Eight - mygame.GraphicsDevice.Viewport.X,
                (GameConstants.ScreenHeight / GameConstants.Eleven)-GameConstants.Ten), Color.White,
            0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, output, new Vector2(GameConstants.ScreenWidth /GameConstants.Eight - mygame.GraphicsDevice.Viewport.X,
                (GameConstants.ScreenHeight / GameConstants.Eleven)+GameConstants.Ten), Color.White,
            0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }

        public void CoinSystem(int coin)
        {
            Vector2 newPos;
            newPos.X = (GameConstants.ScreenWidth / GameConstants.Three - mygame.GraphicsDevice.Viewport.X)- GameConstants.Ten* GameConstants.Two* GameConstants.Two;
            newPos.Y = GameConstants.ScreenHeight / (GameConstants.Ten+ GameConstants.Eight);
            c.position = newPos;
            c.Draw();
            c.Update();
            String zero = "0";
            String output;
            if (coin > (GameConstants.Ten-1))
            {
                output = "X" + coin + "";
            }else
            {
                output = "X"+zero+coin + "";
            }
             
            Vector2 FontOrigin = mygame.font.MeasureString(output)/ GameConstants.Two;
            mygame.spriteBatch.Begin(); 
            mygame.spriteBatch.DrawString(mygame.font, output, new Vector2(GameConstants.ScreenWidth / GameConstants.Three - mygame.GraphicsDevice.Viewport.X,
                GameConstants.ScreenHeight / GameConstants.Twelve), Color.White,
            0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }

        public void WorldSystem(bool undergruond)
        {
            String output1 = "WORLD";
            String output2 = "1-1";
            Vector2 FontOrigin1 = mygame.font.MeasureString(output1) / GameConstants.Two;
            Vector2 FontOrigin2 = mygame.font.MeasureString(output2) / GameConstants.Two;
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, output1, new Vector2(c.position.X+GameConstants.FourHund/2,
                (GameConstants.ScreenHeight / GameConstants.Eleven)-GameConstants.Ten), Color.White,
            0, FontOrigin1, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, output2, new Vector2(c.position.X + GameConstants.FourHund/2,
                (GameConstants.ScreenHeight / GameConstants.Eleven)+GameConstants.Ten), Color.White,
            0, FontOrigin2, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }

        public void Time()
        {
            String TIME = "TIME";
            timeElapsed++;
            if (timeElapsed % 60 == 0)
            {
                timeLeft--;
                timeElapsed = 0;
            }
            String timer_num = timeLeft.ToString() ;
            if (timeLeft == 0)
            {
                timeLeft = GameConstants.InitialTimerValue;
                timeElapsed = 0;
                mygame.level.mario.MarioDie();
            }
            Vector2 FontOrigin1 = mygame.font.MeasureString(TIME) / GameConstants.Two;
            Vector2 FontOrigin2 = mygame.font.MeasureString(timer_num) / GameConstants.Two;
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, TIME, new Vector2(c.position.X +  GameConstants.FourHund,
                (GameConstants.ScreenHeight / GameConstants.Eleven) -GameConstants.Ten), Color.White,
            0, FontOrigin1, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, timer_num, new Vector2(c.position.X +  GameConstants.FourHund,
                (GameConstants.ScreenHeight / GameConstants.Eleven) +GameConstants.Ten), Color.White,
            0, FontOrigin2, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.ElementClasses.ItemClass;
using SuperMarioGame.SpriteFactories;
using SuperMarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.HUDElements
{ 
    class ScoreSystem
    {
        Game1 mygame;
        Coin c;

        public ScoreSystem(Game1 game)
        {
            this.mygame = game;
             c = new Coin(new Vector2(GameConstants.ScreenWidth / 2 - mygame.GraphicsDevice.Viewport.X,
                GameConstants.ScreenHeight / 12));
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
            else if (score < 900)
            {
                output = zeros+score + "";
            }
            else if(score>=1000 &&score < 9900)
            {
                output = zeros.Substring(0,2) + score + "";
            }
            else if(score>=10000 &&score < 99900)
            {
                output = zeros.Substring(0,1) + score + "";
            }
            else
            {
                output = score + "";
            } 
           
            Vector2 FontOrigin = mygame.font.MeasureString(output)/2;
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, mario, new Vector2(GameConstants.ScreenWidth / 8 - mygame.GraphicsDevice.Viewport.X,
                (GameConstants.ScreenHeight / 11)-10), Color.White,
            0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, output, new Vector2(GameConstants.ScreenWidth / 8 - mygame.GraphicsDevice.Viewport.X,
                (GameConstants.ScreenHeight / 11)+10), Color.White,
            0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }

        public void CoinSystem(int coin)
        {
            Vector2 newPos;
            newPos.X = (GameConstants.ScreenWidth / 3 - mygame.GraphicsDevice.Viewport.X)-40;
            newPos.Y = GameConstants.ScreenHeight / 18;
            c.position = newPos;
            c.Draw();
            c.Update();
            String zero = "0";
            String output;
            if (coin > 9)
            {
                output = "X" + coin + "";
            }else
            {
                output = "X"+zero+coin + "";
            }
             
            Vector2 FontOrigin = mygame.font.MeasureString(output)/2;
            mygame.spriteBatch.Begin(); 
            mygame.spriteBatch.DrawString(mygame.font, output, new Vector2(GameConstants.ScreenWidth / 3 - mygame.GraphicsDevice.Viewport.X,
                GameConstants.ScreenHeight / 12), Color.White,
            0, FontOrigin, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }

        public void WorldSystem(bool undergruond)
        {
            String output1 = "WORLD";
            String output2 = "1-1";
            Vector2 FontOrigin1 = mygame.font.MeasureString(output1) / 2;
            Vector2 FontOrigin2 = mygame.font.MeasureString(output2) / 2;
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, output1, new Vector2(c.position.X+200,
                (GameConstants.ScreenHeight / 11)-10), Color.White,
            0, FontOrigin1, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, output2, new Vector2(c.position.X + 200,
                (GameConstants.ScreenHeight / 11)+10), Color.White,
            0, FontOrigin2, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }

        public void Time()
        {
            String output1 = "TIME";
            String output2 = "400";
            Vector2 FontOrigin1 = mygame.font.MeasureString(output1) / 2;
            Vector2 FontOrigin2 = mygame.font.MeasureString(output2) / 2;
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, output1, new Vector2(c.position.X + 400,
                (GameConstants.ScreenHeight / 11) - 10), Color.White,
            0, FontOrigin1, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.DrawString(mygame.font, output2, new Vector2(c.position.X + 400,
                (GameConstants.ScreenHeight / 11) + 10), Color.White,
            0, FontOrigin2, 1.5f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }
    }
}

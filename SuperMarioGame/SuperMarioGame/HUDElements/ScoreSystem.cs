using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioGame.ElementClasses;
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

        public ScoreSystem(Game1 game)
        {
            this.mygame = game;
        }

        public void DisplayScore(int score)
        {
            String output = score + "";
            Vector2 FontOrigin = mygame.font.MeasureString(output) / 2;
            mygame.spriteBatch.Begin();
            mygame.spriteBatch.DrawString(mygame.font, output, new Vector2(GameConstants.ScreenWidth / 11 - mygame.GraphicsDevice.Viewport.X,
                GameConstants.ScreenHeight / 11), Color.White,
            0, FontOrigin, 3.0f, SpriteEffects.None, 1f);
            mygame.spriteBatch.End();
        }

    }
}

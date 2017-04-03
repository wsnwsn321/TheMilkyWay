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
        int Score;
        Mario mario;
        Vector2 marioPosition;
        Vector2 textPosition;

        public ScoreSystem(Game1 game)
        {
            this.mygame = game;
            Score = 0;
            mario = mygame.level.mario;
            marioPosition = mario.position;
        }

        public void TotalScore(int singleScore)
        {
            Score += singleScore;
            textPosition.Y = mario.position.Y - 30;
            textPosition.X = mario.position.X;       
        }
        public void DrawEnemy()
        {
            TotalScore(100);
            String output = "100";
            Vector2 FontOrigin = mygame.font.MeasureString(output) / 2;
            mygame.spriteBatch.DrawString(mygame.font, output, textPosition, Color.White,
                0, FontOrigin, 3.0f, SpriteEffects.None, 0.5f);

        }

    }
}

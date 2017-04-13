using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.Sound.MarioSound;
using Microsoft.Xna.Framework.Media;
using Sprint6.Sound.BackgroundMusic;
using System.Diagnostics;
using Sprint6.SpriteFactories;

namespace Sprint6.ElementClasses
{
    public class MainCharacter
    {
        private Game1 myGame;
        public IState state { get; set; }

        public int marioAction { set; get; }
        public int marioState { set; get; }
        public Vector2 position { set; get; }
        public int gravity { get; set; }
        public bool jump { get; set; }
        public bool canMove { get; set; }
        public bool animated { get; set; }
        public int animation { get; set; }
        public bool isVisible { get; set; }

        public bool isScored { get; set; }
        public int score { get; set; }
        public int totalScore { get; set; }
        public Vector2 textPosition { get; set; }
        public int cow { get; set; }


        private int counter, scoreCounter;
  

        public MainCharacter(Game1 game, Vector2 position)
        {
            myGame = game;
            state = new FlyingState(this);
            state.Sprite = UFOSpriteFactory.Instance.CreateFlyingUFOSprite();
            this.position = position;
            canMove = true;
            scoreCounter = 0;
            gravity = GameConstants.Two*GameConstants.Two;
            animated = false;
            isVisible = true;
            isScored = false;
        }
        public void MarioIdle()
        {
        }
        public virtual void MarioChangeForm(int form)
        {

        }
        public void MainCharJump()
        {
        }

        public virtual void MainCharDraw()
        {
            if (isScored)
            {
                DrawScore();
            }            
        }
        public void MainCharUpdate()
        {
            position = new Vector2(position.X+5,position.Y);
        }

        public void UFODie()
        {
            MediaPlayer.Stop();
        }

        public void Attack()
        {

        }

        public void DrawScore()
        {
            Vector2 newPos;
            newPos.X = textPosition.X;
            newPos.Y = textPosition.Y;
            String output;
            output = "" + score;
           
            Vector2 FontOrigin = myGame.font.MeasureString(output) / GameConstants.Two;
            myGame.spriteBatch.Begin();

                if (scoreCounter <= GameConstants.Two* GameConstants.Ten)
                {
                    textPosition = new Vector2(newPos.X, newPos.Y - GameConstants.Three);
                    myGame.spriteBatch.DrawString(myGame.font, output, newPos, Color.White,
                0, FontOrigin, 1.0f, SpriteEffects.None, 1f);
                scoreCounter++;
                }
            else
            {
                scoreCounter = 0;
                isScored = false;
            }
               
            myGame.spriteBatch.End();
        }
    }
}

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Sprint6.Sound.MarioSound;
using Microsoft.Xna.Framework.Media;
using Sprint6.Sound.BackgroundMusic;
using System.Diagnostics;

namespace Sprint6.ElementClasses
{
    public class MainCharacter
    {
        private Game1 myGame;

        public IState state { set; get; }

        public bool IsInvincible { get; set; }
        public bool HasStarPower { get; set; }

        private bool reSetBGM;
        //state constant   
        public const int MARIO_DEAD = 1, MARIO_SMALL = 2, MARIO_BIG = 3, MARIO_FIRE = 4;
        //action constant
        public const int MARIO_RUN = 5, MARIO_JUMP = 6, MARIO_CROUCH = 7,MARIO_IDLE = 8;

        public const bool MARIO_LEFT = true;

        public int marioAction { set; get; }
        public int marioState { set; get; }
        private int prevMarioState { set; get; }
        public bool marioDirection { set; get; }
        public Vector2 position { set; get; }
        public int gravity { get; set; }
        public bool jump { get; set; }
        public bool bounce { get; set; }
        public bool canMove { get; set; }
        public bool animated { get; set; }
        public int animation { get; set; }
        public bool isVisible { get; set; }

        public bool isScored { get; set; }
        public bool isGreenMushroom { get; set; }
        public int score { get; set; }
        public int coin { get; set; }
        public int totalScore { get; set; }
        public Vector2 textPosition { get; set; }

        private int bounceCount=0;

        internal int InvincibilityTime;
        private int counter, starCounter, scoreCounter;
  

        public MainCharacter(Game1 game, Vector2 position)
        {
            myGame = game;
            marioState = MARIO_SMALL;
            prevMarioState = marioState;
            marioDirection = MARIO_LEFT;
            marioAction = MARIO_IDLE;
            this.position = position;
            IsInvincible = false;
            HasStarPower = false;
            canMove = true;
            state = new IdleState(this);
            InvincibilityTime = 0;
            starCounter = 0;
            scoreCounter = 0;
            gravity = GameConstants.Two*GameConstants.Two;
            bounce = false;
            animated = false;
            isVisible = true;
            isScored = false;
        }
        public MainCharacter(Game1 game, Vector2 position, int marioState, bool marioDirection)
        {
            myGame = game;
            this.marioState = marioState;
            this.marioDirection = marioDirection;
            marioAction = MARIO_IDLE;
            this.position = position;
            state = new IdleState(this);
            IsInvincible = false;
            InvincibilityTime = 0;
            gravity = GameConstants.Two * GameConstants.Two;
            bounce = false;
            animated = false;
            isVisible = true;
        }
        public void MarioIdle()
        {
            marioAction = MARIO_IDLE;
            state.Idle();
        }
        public virtual void MarioChangeForm(int form)
        {
            state.ChangeForm(form);
            if(prevMarioState == MARIO_FIRE && form == MARIO_BIG)
            {
                position = new Vector2(position.X, position.Y);
            } else if (form == MARIO_BIG)
            {
                position = new Vector2(position.X, position.Y - GameConstants.SquareWidth);
            } else if (form == MARIO_SMALL)
            {
                position = new Vector2(position.X, position.Y + GameConstants.SquareWidth);
            }

            marioState = form;
        }
        public void MarioJump()
        {
            
            marioAction = MARIO_JUMP;
            state.Jump();
          

        }

        public virtual void MarioDraw()
        {
            if (isScored)
            {
                DrawScore();
            }
            state.Draw(position);
            
        }
        public void MarioUpdate()
        {
            position = new Vector2(position.X+5,position.Y);
            state.Update();
        }

        public void MarioDie()
        {
            MediaPlayer.Stop();
            MainCharSoundManager.instance.playSound(MainCharSoundManager.MARIODIE);
            marioState = MARIO_DEAD;
            state.Die();
         
        }
        public void MarioGetHit()
        {
            if(marioState > MARIO_SMALL && !IsInvincible)
            {
                prevMarioState = marioState;
                marioState--;
                MarioChangeForm(marioState);
                IsInvincible = true;
                InvincibilityTime += GameConstants.Three;
            } else if (!IsInvincible)
            {
                MarioDie();
            }

        }
        public void GetStar()
        {
           
            HasStarPower = true;
            IsInvincible = true;
            BackgroundMusic.instanse.playSound(BackgroundMusic.STARMAN);
            reSetBGM = true;
            InvincibilityTime = GameConstants.Two* GameConstants.Ten;
        }
        public void Attack()
        {
            MainCharSoundManager.instance.playSound(MainCharSoundManager.FIREBALL);
            state.Attack();
        }

        public void GrowAnimationUpdate()
        {

            myGame.keyboardController.controllerMappings[Keys.BrowserHome].Execute();
            state.Update();
        }
        public void LifeScreenUpdate()
        {


        }

        public void DrawScore()
        {
            Vector2 newPos;
            newPos.X = textPosition.X;
            newPos.Y = textPosition.Y;
            String output;
            if (!isGreenMushroom)
            {
                  output = ""+score;
            }
            else
            {
                  output = "1UP";
            }
           
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
                isGreenMushroom = false;

            }
               
            myGame.spriteBatch.End();
        }
    }
}

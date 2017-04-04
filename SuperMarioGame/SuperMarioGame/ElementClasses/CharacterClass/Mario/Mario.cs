using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioGame.Sound.MarioSound;
namespace SuperMarioGame.ElementClasses
{
    public class Mario
    {
        private Game1 myGame;

        public IMarioState state { set; get; }

        public bool IsInvincible { get; set; }
        public bool HasStarPower { get; set; }

        //state constant   
        public const int MARIO_DEAD = 1, MARIO_SMALL = 2, MARIO_BIG = 3, MARIO_FIRE = 4;
        //action constant
        public const int MARIO_RUN = 5, MARIO_JUMP = 6, MARIO_CROUCH = 7,MARIO_IDLE = 8;

        public  const  bool MARIO_LEFT = true;

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
        public int score { get; set; }
        public int totalScore { get; set; }
        public Vector2 textPosition { get; set; }

        private int bounceCount=0;

        internal int InvincibilityTime;
        private int counter, starCounter, scoreCounter;

        public Mario(Game1 game, Vector2 position)
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
            state = new IdleMarioState(this);
            InvincibilityTime = 0;
            starCounter = 0;
            scoreCounter = 0;
            gravity = 4;
            bounce = false;
            animated = false;
            isVisible = true;
            isScored = false;
            //totalScore = 0;
        }
        public Mario(Game1 game, Vector2 position, int marioState, bool marioDirection)
        {
            myGame = game;
            this.marioState = marioState;
            this.marioDirection = marioDirection;
            marioAction = MARIO_IDLE;
            this.position = position;
            state = new IdleMarioState(this);
            IsInvincible = false;
            InvincibilityTime = 0;
            gravity = 4;
            bounce = false;
            animated = false;
            isVisible = true;
            //totalScore = 0;
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
                position = new Vector2(position.X, position.Y - 32);
            } else if (form == MARIO_SMALL)
            {
                position = new Vector2(position.X, position.Y + 32);
            }

            marioState = form;
        }
        public void MarioJump()
        {
           
            marioAction = MARIO_JUMP;
            state.Jump();
            
        }
        public void MarioCrouch()
        {
                marioAction = MARIO_CROUCH;
                state.Crouch();
        }
        public void MarioRun()
        {
            if (marioAction != MARIO_CROUCH)
            {
                state.Run();
                marioAction = MARIO_RUN;
            }
        }
        public virtual void MarioDraw()
        {
            //if (isVisible)
            {
                if (HasStarPower)
                {
                    starCounter++;
                    if (starCounter % 20 == 0)
                    {
                        state.marioSprite.tintColor = Color.White;
                    }
                    else if (starCounter % 20 == 10)
                    {
                        state.marioSprite.tintColor = Color.Brown;
                    }
                }
                if (isScored)
                {
                    DrawScore();
                }
                state.Draw(position);
            }
        }
        public void MarioUpdate()
        {
            if (canMove)
            {
                if (bounce)
                {
                    if (bounceCount < 10)
                    {
                        if (marioDirection == MARIO_LEFT)
                        {
                            if (marioAction == MARIO_RUN)
                                position = new Vector2(position.X, position.Y - 7);
                            else
                                position = new Vector2(position.X - 3, position.Y - 7);
                        }
                        else
                        {
                            if (marioAction == MARIO_RUN)
                                position = new Vector2(position.X, position.Y - 7);
                            else
                                position = new Vector2(position.X + 3, position.Y - 7);
                        }
                    }
                    if (bounceCount >= 10)
                    {
                        bounceCount = 0;
                        bounce = false;
                    }
                    bounceCount++;
                }
                if (position.Y > 480)
                {
                    MarioDie();
                }
                state.Update();
                counter++;
                if (InvincibilityTime > 0 && counter > 20)
                {
                    IsInvincible = true;
                    InvincibilityTime--;
                    counter = 0;
                }
                else if (InvincibilityTime == 0 && counter > 20)
                {
                    IsInvincible = false;
                    HasStarPower = false;
                    counter = 0;
                }
            }
        }
        public void MarioChangeDireciton()
        {
            state.ChangeDirection();
        }
        public void MarioDie()
        {
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
                InvincibilityTime += 3;
            } else if (!IsInvincible)
            {
                MarioDie();
            }

        }
        public void GetStar()
        {
            HasStarPower = true;
            IsInvincible = true;
            InvincibilityTime = 20;
        }
        public void Attack()
        {
            state.Attack();
        }
        public void FlagAnimationUpdate()
        {
            myGame.keyboardController.controllerMappings[Keys.P].Execute();
            state.Update();
        }
        public void PipeAnimationUpdate()
        {
            myGame.keyboardController.controllerMappings[Keys.O].Execute();
            state.Update();
        }

        public void DrawScore()
        {
            Vector2 newPos;
            newPos.X = textPosition.X;
            newPos.Y = textPosition.Y;
            String output = ""+score;
            Vector2 FontOrigin = myGame.font.MeasureString(output) / 2;
            myGame.spriteBatch.Begin();

                if (scoreCounter <= 20)
                {
                    textPosition = new Vector2(newPos.X, newPos.Y - 3);
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

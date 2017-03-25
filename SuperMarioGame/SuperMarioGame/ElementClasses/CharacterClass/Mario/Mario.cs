using System;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.ElementClasses
{
    public class Mario
    {
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
        public bool onTop { get; set; }
        private int accel = 20;

        public bool jump { get; set; }
        private int jumpCount = 0;

        internal int InvincibilityTime;
        private int counter, starCounter;

        public Mario(Vector2 position)
        {
            marioState = MARIO_SMALL;
            prevMarioState = marioState;
            marioDirection = MARIO_LEFT;
            marioAction = MARIO_IDLE;
            this.position = position;
            IsInvincible = false;
            HasStarPower = false;
            state = new IdleMarioState(this);
            InvincibilityTime = 0;
            starCounter = 0;
            gravity = 0;
            onTop = false;
        }
        public Mario(Vector2 position, int marioState, bool marioDirection)
        {
            this.marioState = marioState;
            this.marioDirection = marioDirection;
            marioAction = MARIO_IDLE;
            this.position = position;
            state = new IdleMarioState(this);
            IsInvincible = false;
            InvincibilityTime = 0;
            onTop = false;
            gravity = 0;
            DetermineGravity();
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
            if (true)
            {
                marioAction = MARIO_JUMP;
                //position = new Vector2(position.X, position.Y - gravity);
                state.Jump();
                jump = true;
            }
        }
        public void MarioCrouch()
        {
            if (marioState != MARIO_SMALL)
            {
                marioAction = MARIO_CROUCH;
                state.Crouch();
            }
        }
        public void MarioRun()
        {
            state.Run();
            marioAction = MARIO_RUN;
        }
        public virtual void MarioDraw()
        {

            if (HasStarPower)
            {
                starCounter++;
                if(starCounter % 20 == 0)
                {
                    state.marioSprite.tintColor = Color.White;
                }  else if (starCounter % 20 == 10) 
                {
                    state.marioSprite.tintColor = Color.Brown;
                }
            }
            state.Draw(position);
        }
        public void MarioUpdate()
        {
            if(position.Y > 480)
            {
                MarioDie();
            }
            if (jump)
            {
                if (jumpCount <= 35)
                {
                    if(jumpCount % 15 == 0)
                    accel -= 2;
                    if(accel < 0)
                    {
                        accel = 0;
                    }
                    position = new Vector2(position.X, position.Y - accel);
                }
                else
                {
                    jumpCount = 0;
                    accel = 10;
                    jump = false;
                }
                jumpCount++;
            }
            else
            {
                jumpCount = 0;
                accel = 10;
            }
            DetermineGravity();
            state.Update();
            counter++;
            if(InvincibilityTime > 0 && counter > 20)
            {
                IsInvincible = true;
                InvincibilityTime--;
                counter = 0;
            } else if (InvincibilityTime == 0 && counter > 20)
            {
                IsInvincible = false;
                HasStarPower = false;
                counter = 0;
            }
        }

        private void DetermineGravity()
        {
            if (!onTop)
            {
                gravity = 3;
            }
            else
            {
                gravity = 0;
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

    }
}

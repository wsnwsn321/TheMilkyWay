using Microsoft.Xna.Framework;
using SuperMarioGame.UpdateGeorge;
using SuperMarioGame.SpriteFactories;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.UpdateGeorge
{
    public class Mario
    {
        public ElementClasses.IMarioState state { set; get; }

        public bool IsInvincible { get; set; }
        private bool HasStarPower { get; set; }
        private IMarioSprite MarioSprite;
        //state constant   
        public const int MARIO_DEAD = 1, MARIO_SMALL = 2, MARIO_BIG = 3, MARIO_FIRE = 4;
        //action constant
        public const int MARIO_RUN = 5, MARIO_JUMP = 6, MARIO_CROUCH = 7,MARIO_IDLE = 8;
    
        public  const  bool MARIO_LEFT = true;

        
        public int marioAction { set; get; }
        public int marioState { set; get; }
        public bool marioDirection { set; get; }
        public Vector2 position { set; get; }


        public int InvincibilityTime;
        private int counter, starCounter;

        public Mario(Vector2 position)
        {
            //MarioStateVariable
            this.position = position;
            this.marioState = MARIO_SMALL;
            this.marioDirection = MARIO_LEFT;
            this.marioAction = MARIO_IDLE;
            this.MarioSprite = MarioSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();
            
            //MarioOtherVariable
            IsInvincible = false;
            HasStarPower = false;
            InvincibilityTime = 0;
            starCounter = 0;

        }
        public Mario(Vector2 position, int marioState, bool marioDirection)
        {
            //MarioStateVariable
            this.marioState = marioState;
            this.marioDirection = marioDirection;
            this.marioAction = MARIO_IDLE;
            this.position = position;
            MarioChangeForm(marioState);

            //MarioOtherVariable
            IsInvincible = false;
            HasStarPower = false;
            InvincibilityTime = 0;
            starCounter = 0;
        }
        public void MarioIdle()
        {

            state.Idle();
            if (marioDirection)
            {
                switch (marioState)
                {
                    case MARIO_SMALL:
                        MarioSprite = MarioSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();
                        break;
                    case MARIO_BIG:
                        MarioSprite = MarioSpriteFactory.Instance.CreateLeftIdleBigMarioSprite();
                        break;
                    case MARIO_FIRE:
                        MarioSprite = MarioSpriteFactory.Instance.CreateLeftIdleFireMarioSprite();
                        break;
                }
            }
            else
            {
                switch (marioState)
                {
                    case MARIO_SMALL:
                        MarioSprite = MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
                        break;
                    case MARIO_BIG:
                        MarioSprite = MarioSpriteFactory.Instance.CreateRightIdleBigMarioSprite();
                        break;
                    case MARIO_FIRE:
                        MarioSprite = MarioSpriteFactory.Instance.CreateRightIdleFireMarioSprite();
                        break;
                }
            }
        }
        public virtual void MarioChangeForm(int form)
        {
            state.ChangeForm(form);
            if (marioDirection)
            {
                switch (marioAction)
                {
                    case MARIO_IDLE:
                        
                        break;
                    case MARIO_JUMP:
                        break;
                    case MARIO_RUN:
                        break;
                    case MARIO_CROUCH:
                        break;
                }
            }
            else
            {
                switch (marioState)
                {
                    case MARIO_IDLE:

                        break;
                    case MARIO_JUMP:
                        break;
                    case MARIO_RUN:
                        break;
                    case MARIO_CROUCH:
                        break;
                }
            }
           
        }
        public void MarioJump()
        {
            state.Jump();
            if (marioDirection)
            {
                switch (marioState)
                {
                    case MARIO_SMALL:
                        break;
                    case MARIO_BIG:
                        break;
                    case MARIO_FIRE:
                        break;
                }
            }
            else
            {
                switch (marioState)
                {
                    case MARIO_SMALL:
                        break;
                    case MARIO_BIG:
                        break;
                    case MARIO_FIRE:
                        break;
                }
            }
        }
        public void MarioCrouch()
        {
            state.Crouch();
            if (marioDirection)
            {
                switch (marioState)
                {
                    case MARIO_SMALL:
                        break;
                    case MARIO_BIG:
                        break;
                    case MARIO_FIRE:
                        break;
                }
            }
            else
            {
                switch (marioState)
                {
                    case MARIO_SMALL:
                        break;
                    case MARIO_BIG:
                        break;
                    case MARIO_FIRE:
                        break;
                }
            }
        }
        public void MarioRun()
        {
            state.Run();
            if (marioDirection)
            {
                switch (marioState)
                {
                    case MARIO_SMALL:
                        break;
                    case MARIO_BIG:
                        break;
                    case MARIO_FIRE:
                        break;
                }
            }
            else
            {
                switch (marioState)
                {
                    case MARIO_SMALL:
                        break;
                    case MARIO_BIG:
                        break;
                    case MARIO_FIRE:
                        break;
                }
            }
        }
        public virtual void MarioDraw()
        {
            if(HasStarPower)
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
        public void MarioChangeDireciton()
        {
            state.ChangeDirection();
        
        }
        public void MarioDie()
        {
            state.Die();
            MarioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();
        }

        public void MarioGetHit()
        {
            if(marioState > MARIO_SMALL && !IsInvincible)
            {
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

    }
}

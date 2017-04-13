using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    class CrouchMarioState : IMarioState
    {
     

        private Mario mario;
        public IMarioSprite marioSprite { get; set; }
        public CrouchMarioState(Mario mario)
        {
            this.mario = mario;
            if (mario.marioDirection)
            {
                switch (mario.marioState)
                {
                    case Mario.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();
                        break;
                    case Mario.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftCrouchingBigMarioSprite();
                        break;
                    case Mario.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftCrouchingFireMarioSprite();
                        break;
                }
            }
            else
            {
                switch (mario.marioState)
                {
                    case Mario.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
                        break;
                    case Mario.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightCrouchingBigMarioSprite();
                        break;
                    case Mario.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightCrouchingFireMarioSprite();
                        break;
                }
            }



        }

        public void Crouch()
        {

        }

        public void Draw(Vector2 position)
        {
            marioSprite.Draw(position);
        }
        public void ChangeForm(int form)
        {
            mario.marioState = form;
            mario.state = new IdleMarioState( mario);
            mario.MarioIdle();
        }

        public void Idle()
        {
            mario.state = new IdleMarioState(mario);
            mario.MarioIdle();
        }

        public void Jump()
        {
            mario.state = new IdleMarioState( mario);
            mario.MarioIdle();
        }

        public void Run()
        {
            mario.state = new RunningMarioState( mario);
            mario.MarioRun();
        }

        public void Update()
        {
            marioSprite.Update();
        }
        public void ChangeDirection()
        {
            mario.marioDirection = !mario.marioDirection;
            mario.MarioCrouch();
        }
        public void Die()
        {
            mario.state = new DeadMarioState( mario);
            mario.MarioDie();
        }
        
        public void Attack()
        {
        }
    }
}

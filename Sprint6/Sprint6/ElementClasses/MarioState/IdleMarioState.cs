using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    class IdleMarioState : IMarioState
    {


        private MainCharacter mainCharacter;
        public IMarioSprite marioSprite { get; set; }
        public IdleMarioState(MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
        }

        public void Idle()
        {
            if (mainCharacter.marioDirection)
            {
                switch (mainCharacter.marioState)
                {
                    case MainCharacter.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();

                        break;
                    case MainCharacter.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleBigMarioSprite();

                        break;
                    case MainCharacter.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleFireMarioSprite();

                        break;
                }
            }
            else
            {
                switch (mainCharacter.marioState)
                {
                    case MainCharacter.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

                        break;
                    case MainCharacter.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleBigMarioSprite();

                        break;
                    case MainCharacter.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleFireMarioSprite();
                        break;
                }
            }
        }

        public void Crouch()
        {
            mainCharacter.state = new CrouchMarioState(mainCharacter);
            mainCharacter.MarioCrouch();
        }


        public void ChangeForm(int form)
        {
            mainCharacter.marioState = form;
            mainCharacter.state = new IdleMarioState( mainCharacter);
            mainCharacter.MarioIdle();
        }



        public void Jump()
        {
            mainCharacter.state = new JumpingMarioState( mainCharacter);
            mainCharacter.MarioJump();
        }

        public void Run()
        {
            mainCharacter.state = new RunningMarioState( mainCharacter);
            mainCharacter.MarioRun();
        }


        public void ChangeDirection()
        {
            mainCharacter.marioDirection = !mainCharacter.marioDirection;
            mainCharacter.MarioIdle();
        }
        //** update the position
        public void Update()
        {
            marioSprite.Update();
        }

        public void Draw(Vector2 position)
        {
            marioSprite.Draw(position);
        }

        public void Die()
        {
            mainCharacter.state = new DeadMarioState( mainCharacter);
            mainCharacter.MarioDie();
        }

        public void Attack()
        {
            if (!mainCharacter.marioDirection)
            {
                marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightAttackingFireMarioSprite();
            }
            else
            {
                marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftAttackingFireMarioSprite();
            }
        }
    }
}

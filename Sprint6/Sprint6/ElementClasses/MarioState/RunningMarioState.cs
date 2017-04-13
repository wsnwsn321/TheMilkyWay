using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    class RunningMarioState : IMarioState
    {
 
     
        private MainCharacter mainCharacter;
        public IMarioSprite marioSprite { get; set; }
        public RunningMarioState( MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
            if (mainCharacter.marioDirection)
            {
                switch (mainCharacter.marioState)
                {

                    case MainCharacter.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftRunningSmallMarioSprite();

                        break;
                    case MainCharacter.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftRunningBigMarioSprite();
                        break;
                    case MainCharacter.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftRunningFireMarioSprite();

                        break;
                }
            }
            else if (!mainCharacter.marioDirection)
            {
                switch (mainCharacter.marioState)
                {
                    case MainCharacter.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightRunningSmallMarioSprite();
                        break;
                    case MainCharacter.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightRunningBigMarioSprite();
                        break;
                    case MainCharacter.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightRunningFireMarioSprite();
                        break;
                }
            }

        }
        
        public void Run()
        {
        }
        public void Crouch()
        {
            mainCharacter.state = new CrouchMarioState( mainCharacter);
            mainCharacter.MarioCrouch();
        }


        public void ChangeForm(int form)
        {
            mainCharacter.marioState = form;
            mainCharacter.state = new IdleMarioState(mainCharacter);
            mainCharacter.MarioRun();
        }

        public void Idle()
        {
            mainCharacter.state = new IdleMarioState( mainCharacter);
            mainCharacter.MarioIdle();
        }

        public void Jump()
        {
            mainCharacter.state = new JumpingMarioState( mainCharacter);
            mainCharacter.MarioJump();
        }


        public void Update()
        {
            marioSprite.Update();
            //change position
            
        }

        public void Draw(Vector2 position)
        {
            marioSprite.Draw(position);

        }

        public void ChangeDirection()
        {
            mainCharacter.marioDirection = !mainCharacter.marioDirection;
            mainCharacter.MarioRun();
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

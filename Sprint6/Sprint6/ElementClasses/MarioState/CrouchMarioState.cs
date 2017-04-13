using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    class CrouchMarioState : IMarioState
    {
     

        private MainCharacter mainCharacter;
        public IMarioSprite marioSprite { get; set; }
        public CrouchMarioState(MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
            if (mainCharacter.marioDirection)
            {
                switch (mainCharacter.marioState)
                {
                    case MainCharacter.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();
                        break;
                    case MainCharacter.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftCrouchingBigMarioSprite();
                        break;
                    case MainCharacter.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftCrouchingFireMarioSprite();
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
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightCrouchingBigMarioSprite();
                        break;
                    case MainCharacter.MARIO_FIRE:
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
            mainCharacter.marioState = form;
            mainCharacter.state = new IdleMarioState( mainCharacter);
            mainCharacter.MarioIdle();
        }

        public void Idle()
        {
            mainCharacter.state = new IdleMarioState(mainCharacter);
            mainCharacter.MarioIdle();
        }

        public void Jump()
        {
            mainCharacter.state = new IdleMarioState( mainCharacter);
            mainCharacter.MarioIdle();
        }

        public void Run()
        {
            mainCharacter.state = new RunningMarioState( mainCharacter);
            mainCharacter.MarioRun();
        }

        public void Update()
        {
            marioSprite.Update();
        }
        public void ChangeDirection()
        {
            mainCharacter.marioDirection = !mainCharacter.marioDirection;
            mainCharacter.MarioCrouch();
        }
        public void Die()
        {
            mainCharacter.state = new DeadMarioState( mainCharacter);
            mainCharacter.MarioDie();
        }
        
        public void Attack()
        {
        }
    }
}

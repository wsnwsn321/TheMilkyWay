using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    class JumpingMarioState : IMarioState
    {

  
        private MainCharacter mainCharacter;
        public IMarioSprite marioSprite { get; set; }
        public JumpingMarioState(MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
            if (mainCharacter.marioDirection)
            {
                switch (mainCharacter.marioState)
                {
                    case MainCharacter.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingSmallMarioSprite();
                        break;
                    case MainCharacter.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingBigMarioSprite();
                        break;
                    case MainCharacter.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingFireMarioSprite();
                        break;
                }
            }
            else
            {
                switch (mainCharacter.marioState)
                {
                    case MainCharacter.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightJumpingSmallMarioSprite();
                        break;
                    case MainCharacter.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightJumpingBigMarioSprite();
                        break;
                    case MainCharacter.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightJumpingFireMarioSprite();
                        break;
                }
            }
        }

        public void Jump()
        {

        }

        public void Crouch()
        {
            mainCharacter.state = new IdleMarioState( mainCharacter);
            mainCharacter.MarioIdle();
        }

        public void Draw(Vector2 position)
        {
            marioSprite.Draw(new Vector2(position.X, position.Y));
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
            mainCharacter.MarioJump();
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

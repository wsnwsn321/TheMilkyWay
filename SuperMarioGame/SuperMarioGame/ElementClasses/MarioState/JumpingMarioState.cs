using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses
{
    class JumpingMarioState : IMarioState
    {

  
        private Mario mario;
        public ISprite marioSprite { get; set; }
        public JumpingMarioState(Mario mario)
        {
            this.mario = mario;
            if (mario.marioDirection)
            {
                switch (mario.marioState)
                {
                    case Mario.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingSmallMarioSprite();
                        break;
                    case Mario.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingBigMarioSprite();
                        break;
                    case Mario.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingFireMarioSprite();
                        break;
                }
            }
            else
            {
                switch (mario.marioState)
                {
                    case Mario.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightJumpingSmallMarioSprite();
                        break;
                    case Mario.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightJumpingBigMarioSprite();
                        break;
                    case Mario.MARIO_FIRE:
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
            mario.state = new IdleMarioState( mario);
            mario.MarioIdle();
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
            mario.MarioJump();
        }
        public void Die()
        {
            mario.state = new DeadMarioState( mario);
            mario.Die();
        }
    }
}

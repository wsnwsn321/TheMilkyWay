using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    class JumpingState : IState
    {

  
        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }
        public JumpingState(MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
            if (mainCharacter.marioDirection)
            {
                switch (mainCharacter.marioState)
                {
                    case MainCharacter.MARIO_SMALL:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateLeftJumpingSmallMarioSprite();
                        break;
                    case MainCharacter.MARIO_BIG:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateLeftJumpingBigMarioSprite();
                        break;
                    case MainCharacter.MARIO_FIRE:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateLeftJumpingFireMarioSprite();
                        break;
                }
            }
            else
            {
                switch (mainCharacter.marioState)
                {
                    case MainCharacter.MARIO_SMALL:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateRightJumpingSmallMarioSprite();
                        break;
                    case MainCharacter.MARIO_BIG:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateRightJumpingBigMarioSprite();
                        break;
                    case MainCharacter.MARIO_FIRE:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateRightJumpingFireMarioSprite();
                        break;
                }
            }
        }

        public void Jump()
        {

        }

        public void Crouch()
        {
            mainCharacter.state = new IdleState( mainCharacter);
            mainCharacter.MarioIdle();
        }

        public void Draw(Vector2 position)
        {
            Sprite.Draw(new Vector2(position.X, position.Y));
        }
        public void ChangeForm(int form)
        {
            mainCharacter.marioState = form;
            mainCharacter.state = new IdleState( mainCharacter);
            mainCharacter.MarioIdle();
        }

        public void Idle()
        {
            mainCharacter.state = new IdleState(mainCharacter);
            mainCharacter.MarioIdle();
        }

        public void Update()
        {
            Sprite.Update();
        }

        public void ChangeDirection()
        {
            mainCharacter.marioDirection = !mainCharacter.marioDirection;
            mainCharacter.MarioJump();
        }
        public void Die()
        {
            mainCharacter.state = new DeadState( mainCharacter);
            mainCharacter.MarioDie();
        }

        public void Attack()
        {
            if (!mainCharacter.marioDirection)
            {
                Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateRightAttackingFireMarioSprite();
            }
            else
            {
                Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateLeftAttackingFireMarioSprite();
            }
        }
    }
}

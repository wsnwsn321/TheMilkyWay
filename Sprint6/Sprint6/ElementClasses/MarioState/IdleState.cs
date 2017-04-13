using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    class IdleState : IState
    {


        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }
        public IdleState(MainCharacter mainCharacter)
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
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();

                        break;
                    case MainCharacter.MARIO_BIG:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateLeftIdleBigMarioSprite();

                        break;
                    case MainCharacter.MARIO_FIRE:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateLeftIdleFireMarioSprite();

                        break;
                }
            }
            else
            {
                switch (mainCharacter.marioState)
                {
                    case MainCharacter.MARIO_SMALL:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

                        break;
                    case MainCharacter.MARIO_BIG:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateRightIdleBigMarioSprite();

                        break;
                    case MainCharacter.MARIO_FIRE:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateRightIdleFireMarioSprite();
                        break;
                }
            }
        }


        public void ChangeForm(int form)
        {
            mainCharacter.marioState = form;
            mainCharacter.state = new IdleState( mainCharacter);
            mainCharacter.MarioIdle();
        }



        public void Jump()
        {
            mainCharacter.state = new JumpingState( mainCharacter);
            mainCharacter.MarioJump();
        }

        public void ChangeDirection()
        {
            mainCharacter.marioDirection = !mainCharacter.marioDirection;
            mainCharacter.MarioIdle();
        }
        //** update the position
        public void Update()
        {
            Sprite.Update();
        }

        public void Draw(Vector2 position)
        {
            Sprite.Draw(position);
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

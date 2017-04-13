using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    class RunningState : IState
    {
 
     
        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }
        public RunningState( MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
            if (mainCharacter.marioDirection)
            {
                switch (mainCharacter.marioState)
                {

                    case MainCharacter.MARIO_SMALL:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateLeftRunningSmallMarioSprite();

                        break;
                    case MainCharacter.MARIO_BIG:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateLeftRunningBigMarioSprite();
                        break;
                    case MainCharacter.MARIO_FIRE:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateLeftRunningFireMarioSprite();

                        break;
                }
            }
            else if (!mainCharacter.marioDirection)
            {
                switch (mainCharacter.marioState)
                {
                    case MainCharacter.MARIO_SMALL:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateRightRunningSmallMarioSprite();
                        break;
                    case MainCharacter.MARIO_BIG:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateRightRunningBigMarioSprite();
                        break;
                    case MainCharacter.MARIO_FIRE:
                        Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateRightRunningFireMarioSprite();
                        break;
                }
            }

        }
        
        public void Run()
        {
        }



        public void ChangeForm(int form)
        {
            mainCharacter.marioState = form;
            mainCharacter.state = new IdleState(mainCharacter);
        }

        public void Idle()
        {
            mainCharacter.state = new IdleState( mainCharacter);
            mainCharacter.MarioIdle();
        }

        public void Jump()
        {
            mainCharacter.state = new JumpingState( mainCharacter);
            mainCharacter.MarioJump();
        }


        public void Update()
        {
            Sprite.Update();
            //change position
            
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

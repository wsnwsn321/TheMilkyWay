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
            mainCharacter.MainCharJump();
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
            mainCharacter.UFODie();
        }

        public void Attack()
        {

        }
    }
}

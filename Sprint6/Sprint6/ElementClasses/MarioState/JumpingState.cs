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
            
        }

        public void Jump()
        {

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

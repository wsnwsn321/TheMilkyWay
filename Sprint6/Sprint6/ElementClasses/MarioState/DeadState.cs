using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    class DeadState : IState
    {
        private MainCharacter mainCharacter;
        public ISprite Sprite { get; set; }

        public DeadState(MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
            Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateDeadUFOSprite();


        }
        public void Idle()
        {
            Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateDeadUFOSprite();

        }
        public void ChangeForm(int form)
        {
            mainCharacter.marioState = form;
            mainCharacter.state = new IdleState( mainCharacter);
            mainCharacter.MarioIdle();
        }
        public void Jump()
        {
            Sprite = SpriteFactories.UFOSpriteFactory.Instance.CreateDeadUFOSprite();
        }

        public void Draw(Vector2 position)
        {

            Sprite.Draw(position);
        }
        public void Update()
        {
            Sprite.Update();
        }
        public void Die()
        {
        }

        public void Attack()
        {
        }
    }
}

using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    class DeadMarioState : IMarioState
    {
        private MainCharacter mainCharacter;
        public IMarioSprite marioSprite { get; set; }

        public DeadMarioState( MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
            marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();


        }
        public void Idle()
        {
            marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();

        }
        public void ChangeForm(int form)
        {
            mainCharacter.marioState = form;
            mainCharacter.state = new IdleMarioState( mainCharacter);
            mainCharacter.MarioIdle();
        }
        public void Jump()
        {
            marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();
        }
        public void Crouch()
        {
            marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();
        }
        public void Run()
        {
              marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();
        }
        public void Draw(Vector2 position)
        {

            marioSprite.Draw(position);
        }
        public void Update()
        {
            marioSprite.Update();
        }
        public void ChangeDirection()
        {
            marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();
        }
        public void Die()
        {
        }

        public void Attack()
        {
        }
    }
}

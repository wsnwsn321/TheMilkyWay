using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses
{
    class DeadMarioState : IMarioState
    {
        private Mario mario;
        public IMarioSprite marioSprite { get; set; }

        public DeadMarioState( Mario mario)
        {
            this.mario = mario;
            marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();


        }
        public void Idle()
        {
            marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();

        }
        public void ChangeForm(int form)
        {
            mario.marioState = form;
            mario.state = new IdleMarioState( mario);
            mario.MarioIdle();
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
    }
}

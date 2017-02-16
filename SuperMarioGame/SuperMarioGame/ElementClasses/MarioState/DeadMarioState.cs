using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.ElementClasses
{
    class DeadMarioState : IMarioState
    {
        private Mario mario;
        private Sprites.ISprite marioSprite;

        public DeadMarioState( Mario mario)
        {
            this.mario = mario;

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
        public void MarioEatShit()
        {
            marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();
        }
    }
}

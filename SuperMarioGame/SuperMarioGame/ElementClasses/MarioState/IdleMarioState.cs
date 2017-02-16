using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.ElementClasses
{
    class IdleMarioState : IMarioState
    {


        private Mario mario;
        private Sprites.ISprite marioSprite;
        public IdleMarioState(Mario mario)
        {
            this.mario = mario;
        }

        public void Idle()
        {
            if (mario.marioDirection)
            {
                switch (mario.marioState)
                {
                    case Mario.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();

                        break;
                    case Mario.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleBigMarioSprite();

                        break;
                    case Mario.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleFireMarioSprite();

                        break;
                }
            }
            else
            {
                switch (mario.marioState)
                {
                    case Mario.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();

                        break;
                    case Mario.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleBigMarioSprite();

                        break;
                    case Mario.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleFireMarioSprite();
                        break;
                }
            }
        }

        public void Crouch()
        {
            mario.state = new CrouchMarioState(mario);
            mario.MarioCrouch();
        }


        public void ChangeForm(int form)
        {
            mario.marioState = form;
            mario.state = new IdleMarioState( mario);
            mario.MarioIdle();
        }



        public void Jump()
        {
            mario.state = new JumpingMarioState( mario);
            mario.MarioJump();
        }

        public void Run()
        {
            mario.state = new RunningMarioState( mario);
            mario.MarioRun();
        }


        public void ChangeDirection()
        {
            mario.marioDirection = !mario.marioDirection;
            mario.MarioIdle();
        }
        //** update the position
        public void Update()
        {
            marioSprite.Update();
        }

        public void Draw(Vector2 position)
        {
            marioSprite.Draw(position);
        }

        public void MarioEatShit()
        {
            mario.state = new DeadMarioState( mario);
            mario.MarioEatShit();
        }
    }
}

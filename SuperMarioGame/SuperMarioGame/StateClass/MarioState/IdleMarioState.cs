using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.StateClass
{
    class IdleMarioState : IMarioState
    {

        private Vector2 position;
        private Mario mario;
        private Sprites.ISprite marioSprite;
        public IdleMarioState(Vector2 position, Mario mario)
        {
            this.mario = mario;
            this.position = new Vector2(position.X, position.Y);
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
            mario.state = new CrouchMarioState(position, mario);
            mario.MarioCrouch();
        }


        public void ChangeForm(int form)
        {
            mario.marioState = form;
            mario.state = new IdleMarioState(position, mario);
            mario.MarioIdle();
        }



        public void Jump()
        {
            mario.state = new JumpingMarioState(position, mario);
            mario.MarioJump();
        }

        public void Run()
        {
            mario.state = new RunningMarioState(position, mario);
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

        public void Draw()
        {
            marioSprite.Draw(position);
            }

        public void MarioEatShit()
        {
            marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();
        }
    }
}

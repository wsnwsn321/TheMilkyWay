using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.StateClass
{
    class JumpingMarioState : IMarioState
    {

        private Vector2 position;
        private Mario mario;
        private Sprites.ISprite marioSprite;
        public JumpingMarioState(Vector2 position, Mario mario)
        {
            this.mario = mario;
            this.position = position;
        }

        public void Jump()
        {
            if (mario.marioDirection)
            {
                switch (mario.marioState)
                {
                    case Mario.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingSmallMarioSprite();
                        break;
                    case Mario.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingBigMarioSprite();
                        break;
                    case Mario.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingFireMarioSprite();
                        break;
                }
            }
            else
            {
                switch (mario.marioState)
                {
                    case Mario.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightJumpingSmallMarioSprite();
                        break;
                    case Mario.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightJumpingBigMarioSprite();
                        break;
                    case Mario.MARIO_FIRE:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightJumpingFireMarioSprite();
                        break;
                }
            }
        }

        public void Crouch()
        {
            mario.state = new IdleMarioState(position, mario);
            mario.MarioIdle();
        }

        public void Draw()
        {
            marioSprite.Draw(position);
        }
        public void ChangeForm(int form)
        {
            mario.marioState = form;
            mario.state = new IdleMarioState(position, mario);
            mario.MarioIdle();
        }

        public void Idle()
        {
            mario.state = new IdleMarioState(position, mario);
            mario.MarioIdle();
        }
        public void Run()
        {
            mario.state = new RunningMarioState(position, mario);
            mario.MarioRun();
        }

        public void Update()
        {
            marioSprite.Update();
        }

        public void ChangeDirection()
        {
            mario.marioDirection = !mario.marioDirection;
            mario.MarioJump();
        }
        public void MarioEatShit()
        {
            marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateDeadSmallMarioSprite();
        }
    }
}

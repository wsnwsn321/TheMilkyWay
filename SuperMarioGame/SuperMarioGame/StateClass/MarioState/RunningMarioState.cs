using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.StateClass
{
    class RunningMarioState : IMarioState
    {
 
        private Vector2 position;
        private Mario mario;
        private Sprites.ISprite marioSprite;
        public RunningMarioState(Vector2 position, Mario mario)
        {
            this.mario = mario;
         
            this.position = position;
         
        }

        public void Run()
        {
            if (mario.marioDirection)
            {
                switch (mario.marioState)
                {
                    case Mario.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftRunningSmallMarioSprite();
                        break;
                    case Mario.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftRunningBigMarioSprite();
                        break;
                    case Mario.MARIO_FIRE:
                        //red mario;
                        //Draw();
                        break;
                }
            }
            else
            {
                switch (mario.marioState)
                {
                    case Mario.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightRunningSmallMarioSprite();
                        break;
                    case Mario.MARIO_BIG:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightRunningBigMarioSprite();
                        break;
                    case Mario.MARIO_FIRE:
                        //marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleBigRedMarioSprite();
                        //Draw();
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
            mario.MarioRun();
        }

        public void Idle()
        {
            mario.state = new IdleMarioState(position, mario);
            mario.MarioIdle();
        }

        public void Jump()
        {
            mario.state = new JumpingMarioState(position, mario);
            mario.MarioJump();
        }


        public void Update()
        {
            marioSprite.Update();
        }

        public void Draw()
        {
            marioSprite.Draw(position);

        }

        public void ChangeDirection()
        {
            mario.marioDirection = !mario.marioDirection;
            mario.MarioRun();
        }
    }
}

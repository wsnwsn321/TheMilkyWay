using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses
{
    class RunningMarioState : IMarioState
    {
 
     
        private Mario mario;
        public ISprite marioSprite { get; set; }
        public RunningMarioState( Mario mario)
        {
            this.mario = mario;
         
         
        }

        
        public void Run()
        {
            if (mario.marioDirection && mario.marioAction != Mario.MARIO_RUN)
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
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftRunningFireMarioSprite();

                        break;
                }
            }
            else if (!mario.marioDirection && mario.marioAction != Mario.MARIO_RUN)
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
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightRunningFireMarioSprite();
                        break;
                }
            }
        }
        public void Crouch()
        {
            mario.state = new CrouchMarioState( mario);
            mario.MarioCrouch();
        }


        public void ChangeForm(int form)
        {
            mario.marioState = form;
            mario.state = new IdleMarioState( mario);
            mario.MarioRun();
        }

        public void Idle()
        {
            mario.state = new IdleMarioState( mario);
            mario.MarioIdle();
        }

        public void Jump()
        {
            mario.state = new JumpingMarioState( mario);
            mario.MarioJump();
        }


        public void Update()
        {
            marioSprite.Update();
            //change position
            
        }

        public void Draw(Vector2 position)
        {
            marioSprite.Draw(position);

        }

        public void ChangeDirection()
        {
            mario.marioDirection = !mario.marioDirection;
            mario.MarioRun();
        }
        public void MarioEatShit()
        {
            mario.state = new DeadMarioState( mario);
            mario.MarioEatShit();
        }
    }
}

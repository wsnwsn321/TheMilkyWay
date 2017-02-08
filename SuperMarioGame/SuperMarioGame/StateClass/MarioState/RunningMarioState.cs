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
        // 1 : small mario 
        // 2 : big mario 
        // 3 : fire mario
        private int marioState;

        // true: left
        // false: right
        private Boolean direction;
        private Vector2 position;
        private Mario mario;
        private Sprites.ISprite marioSprite;
        public RunningMarioState(Vector2 position, Mario mario, int marioState, Boolean direction)
        {
            this.mario = mario;
            this.marioState = marioState;
            this.position = position;
            this.direction = direction;
        }

        public void Run()
        {
            if (direction)
            {
                switch (marioState)
                {
                    case 1:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftRunningSmallMarioSprite();
                        break;
                    case 2:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftRunningBigMarioSprite();
                        break;
                    case 3:
                        //red mario;
                        //Draw();
                        break;
                }
            }
            else
            {
                switch (marioState)
                {
                    case 1:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightRunningSmallMarioSprite();
                        break;
                    case 2:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightRunningBigMarioSprite();
                        break;
                    case 3:
                        //marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleBigRedMarioSprite();
                        //Draw();
                        break;
                }
            }
        }
        public void Crouch()
        {
            mario.state = new CrouchMarioState(position, mario, marioState, direction);
            mario.MarioCrouch();
        }

       
        public void ChangeForm(int form)
        {
            marioState = form;
            mario.state = new IdleMarioState(position, mario, marioState, direction);
            mario.MarioRun();
        }

        public void Idle()
        {
            mario.state = new IdleMarioState(position, mario, marioState, direction);
            mario.MarioIdle();
        }

        public void Jump()
        {
            mario.state = new JumpingMarioState(position, mario, marioState, direction);
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
            direction = !direction;
            mario.MarioRun();
        }
    }
}

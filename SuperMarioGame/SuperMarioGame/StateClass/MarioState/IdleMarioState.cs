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
        public IdleMarioState(Vector2 position, Mario mario,int marioState,Boolean direction )
        {
            this.mario = mario;
            this.marioState = marioState;
            this.position = new Vector2(position.X,position.Y);
            this.direction = direction;
        }

        public void Idle()
        {
            if (direction)
            {
                switch (marioState)
                {
                    case 1:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleSmallMarioSprite();
                        Draw();
                        break;
                    case 2:
                     //   marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleBigMarioSprite();
                        Draw();
                        break;
                    case 3:
                        //marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftIdleBigRedMarioSprite();
                        //Draw();
                        break;
                }
            }else
            {
                switch (marioState)
                {
                    case 1:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleSmallMarioSprite();
                        Draw();
                        break;
                    case 2:
                    //    marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightIdleBigMarioSprite();
                        Draw();
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
            marioState  = form;
            mario.state = new IdleMarioState(position, mario, marioState, direction);
            mario.MarioIdle();
        }

        

        public void Jump()
        {
            mario.state = new JumpingMarioState(position, mario, marioState, direction);
            mario.MarioJump();
        }

        public void Run()
        {
            mario.state = new RunningMarioState(position, mario, marioState, direction);
            mario.MarioRun();
        }


        public void ChangeDirection()
        {
            direction = !direction;
            mario.state     = new IdleMarioState(position, mario, marioState, direction);
            mario.MarioIdle();
        }
        //** update the position
        public void Update()
        {

        }

        public void Draw()
        {
            marioSprite.Draw(position);
        }
      
    }
}

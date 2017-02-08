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


        private int marioState;

        // true: left
        // false: right
        private Boolean direction;
        private Vector2 position;
        private Mario mario;
        private Sprites.ISprite marioSprite;
        public JumpingMarioState(Vector2 position, Mario mario, int marioState, Boolean direction)
        {
            this.mario = mario;
            this.marioState = marioState;
            this.position = position;
            this.direction = direction;
        }

        public void Jump()
        {
            if (direction)
            {
                switch (marioState)
                {
                    case Mario.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingSmallMarioSprite();
                        Update();
                        Draw();
                        break;
                    case Mario.MARIO_BIG:
                     //   marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateLeftJumpingBigMarioSprite();
                        Update();
                        Draw();
                        break;
                    case Mario.MARIO_FIRE:
                        //red mario;
                        //Draw();
                        break;
                }
            }
            else
            {
                switch (marioState)
                {
                    case Mario.MARIO_SMALL:
                        marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightJumpingSmallMarioSprite();
                        Update();
                        Draw();
                        break;
                    case Mario.MARIO_BIG:
                     //   marioSprite = SpriteFactories.MarioSpriteFactory.Instance.CreateRightJumpingBigMarioSprite();
                        Update();
                        Draw();
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
            mario.state = new CrouchMarioState(position, mario, marioState, direction);
            mario.MarioCrouch();
        }

        public void Draw()
        {
            marioSprite.Draw(position);
        }
        public void ChangeForm(int form)
        {
            marioState = form;
            mario.state = new IdleMarioState(position, mario, marioState, direction);
            mario.MarioIdle();
        }

        public void Idle()
        {
            mario.state = new IdleMarioState(position, mario, marioState, direction);
            mario.MarioIdle();
        }
        public void Run()
        {
            mario.state = new RunningMarioState(position, mario, marioState, direction);
            mario.MarioRun();
        }

        public void Update()
        { 
        }

        public void ChangeDirection()
        {

        }
    }
}

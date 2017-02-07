using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.StateClass
{
    class LeftMarioState : IMarioState
    {
        // 1 : small mario 
        // 2 : big mario 
        // 3 : fire mario
        private int marioState;
        // 1 : normal stand
        // 2 : run
        // 3 : crounch
        // 4 : jump
        // 5 : flag
        // 6 : dead 
        private int motionState;
        private Vector2 position;
        private Mario mario;
        private SpriteBatch sp;
        public LeftMarioState( Mario mario, int marioState, int motionState, Vector2 position, SpriteBatch sp)
        {
            this.mario = mario;
            this.marioState = marioState;
            this.motionState = motionState;
            this.position = position;
            this.sp = sp;
        }
        public void ChangeDirection()
        {
            mario.state = new RightMarioState(mario, marioState, motionState);
        }

        public void ChangeForm(int form)
        {
            switch (form)
            {
                case 2:
                        
                        break;
                case 3:
                        
                        break;
                default:
                        break;
            }
        }

        public void Crouch()
        {
             switch (marioState){
                case 1:
                     break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }


        public void Idle()
        {
            throw new NotImplementedException();
        }

        public void Jump()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

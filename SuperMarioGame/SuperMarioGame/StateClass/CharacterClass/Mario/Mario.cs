using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.StateClass
{
    public class Mario
    {
        public IMarioState state { set; get; }
        private int marioState;
        private Boolean marioDirection;
        public Mario(Vector2 position)
        {
            marioState = 1;
            marioDirection = true;
            state = new IdleMarioState(position,this,marioState,marioDirection);
            
        }
        public Mario(Vector2 position, int marioState, Boolean marioDirection)
        {
            this.marioState = marioState;
            this.marioDirection = marioDirection;
            Console.WriteLine(position.X);
            state = new IdleMarioState(position, this, marioState, marioDirection);
        }
        public void MarioIdle()
        {
            state.Idle();
        }
        public void MarioChangeForm(int form)
        {
            state.ChangeForm(form);
        }
        public void MarioJump()
        {
            state.Jump();
        }
        public void MarioCrouch()
        {
            state.Crouch();
        }
        public void MarioRun()
        {
            state.Run();
        }
        public void MarioDraw()
        {
           
            state.Draw();
        }
        public void MarioUpdate()
        {
            state.Update();
        }

    }
}

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
        public  const  int MARIO_SMALL = 1, MARIO_BIG = 2, MARIO_FIRE = 3;
        public  const  Boolean MARIO_LEFT = true;

        public int marioState { set; get; }
        public Boolean marioDirection { set; get; }
        public Vector2 position { set; get; }
    
        public Mario(Vector2 position)
        {
            marioState = MARIO_SMALL;
            marioDirection = MARIO_LEFT;
            this.position = position;
            state = new IdleMarioState(this.position, this);

        }
        public Mario(Vector2 position, int marioState, Boolean marioDirection)
        {
            this.marioState = marioState;
            this.marioDirection = marioDirection;
            Console.WriteLine(position.X);
            state = new IdleMarioState(position, this);
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
        public void MarioChangeDireciton()
        {
            state.ChangeDirection();
        }

    }
}

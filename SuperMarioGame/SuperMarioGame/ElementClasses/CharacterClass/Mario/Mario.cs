using System;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.ElementClasses
{
    public class Mario
    {
        public IMarioState state { set; get; }
        public const int MARIO_SMALL = 1, MARIO_BIG = 2, MARIO_FIRE = 3, MARIO_IDLE = 4,
            MARIO_RUN = 5, MARIO_JUMP = 6, MARIO_CROUCH = 7, MARIO_DEAD = 8;
        public  const  Boolean MARIO_LEFT = true;

        public int marioAction { set; get; }
        public int marioState { set; get; }
        public Boolean marioDirection { set; get; }
        public Vector2 position { set; get; }
    
        public Mario(Vector2 position)
        {
            marioState = MARIO_SMALL;
            marioDirection = MARIO_LEFT;
            marioAction = MARIO_IDLE;
            this.position = position;
            state = new IdleMarioState(this);

        }
        public Mario(Vector2 position, int marioState, Boolean marioDirection)
        {
            this.marioState = marioState;
            this.marioDirection = marioDirection;
            this.marioAction = MARIO_IDLE;
            this.position = position;
            state = new IdleMarioState(this);
        }
        public void MarioIdle()
        {
            marioAction = MARIO_IDLE;
            state.Idle();
        }
        public void MarioChangeForm(int form)
        {
            state.ChangeForm(form);
        }
        public void MarioJump()
        {
            marioAction = MARIO_JUMP;
            state.Jump();
        }
        public void MarioCrouch()
        {
            marioAction = MARIO_CROUCH;
            state.Crouch();
        }
        public void MarioRun()
        {
            state.Run();
            marioAction = MARIO_RUN; 
        }
        public void MarioDraw()
        {
            state.Draw(this.position);
        }
        public void MarioUpdate()
        {
            state.Update();
        }
        public void MarioChangeDireciton()
        {
            state.ChangeDirection();
        }
        public void MarioEatShit()
        {
            marioAction = MARIO_DEAD;
            state.MarioEatShit();
        }

    }
}

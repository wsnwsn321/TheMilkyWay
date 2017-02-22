using System;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.ElementClasses
{
    public class StarMario : Mario
    {
        public StarMario(Vector2 position) : base(position)
        {
            marioState = MARIO_SMALL;
            marioDirection = MARIO_LEFT;
            marioAction = MARIO_IDLE;
            this.position = position;
            this.IsInvincible = true;
            state = new IdleMarioState(this);
            InvincibilityTime = 0;

        }
        public StarMario(Vector2 position, int marioState, bool marioDirection) : base(position, marioState, marioDirection)
        {
            this.marioState = marioState;
            this.marioDirection = marioDirection;
            marioAction = MARIO_IDLE;
            this.position = position;
            state = new IdleMarioState(this);
            IsInvincible = true;
            InvincibilityTime = 0;
        }
        //public void MarioIdle()
        //{
        //    marioAction = MARIO_IDLE;
        //    state.Idle();
        //}
        public override void MarioChangeForm(int form)
        {

        }
        //public void MarioJump()
        //{
        //    marioAction = MARIO_JUMP;
        //    state.Jump();
        //}
        //public void MarioCrouch()
        //{
        //    marioAction = MARIO_CROUCH;
        //    state.Crouch();
        //}
        //public void MarioRun()
        //{
        //    state.Run();
        //    marioAction = MARIO_RUN; 
        //}
        public override void MarioDraw()
        {
            state.Draw(position);
        }
        //public void MarioUpdate()
        //{
        //    state.Update();
        //    counter++;
        //    if(this.InvincibilityTime > 0 && counter > 20)
        //    {
        //        this.IsInvincible = true;
        //        this.InvincibilityTime--;
        //        counter = 0;
        //    } else if (this.InvincibilityTime == 0 && counter > 20)
        //    {
        //        this.IsInvincible = false;
        //        counter = 0;
        //    }
        //}
        //public void MarioChangeDireciton()
        //{
        //    state.ChangeDirection();
        //}
        //public void MarioDie()
        //{
        //    marioState = MARIO_DEAD;
        //    state.Die();
        //}

        //public void MarioGetHit()
        //{
        //    if(marioState > MARIO_SMALL && !this.IsInvincible)
        //    {
        //        this.marioState--;
        //        this.MarioChangeForm(marioState);
        //        this.IsInvincible = true;
        //        this.InvincibilityTime += 3;
        //    } else if (!this.IsInvincible)
        //    {
        //        this.MarioDie();
        //    }

        //}

    }
}

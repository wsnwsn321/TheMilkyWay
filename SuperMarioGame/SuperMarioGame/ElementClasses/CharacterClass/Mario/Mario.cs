﻿using System;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.ElementClasses
{
    public class Mario
    {
        public IMarioState state { set; get; }

        public bool IsInvincible { get; set; }
        //state constant   
        public const int MARIO_DEAD = 1, MARIO_SMALL = 2, MARIO_BIG = 3, MARIO_FIRE = 4;
        //action constant
        public const int MARIO_RUN = 5, MARIO_JUMP = 6, MARIO_CROUCH = 7,MARIO_IDLE = 8;

        public  const  bool MARIO_LEFT = true;

        public int marioAction { set; get; }
        public int marioState { set; get; }
        public bool marioDirection { set; get; }
        public Vector2 position { set; get; }

        public int InvincibilityTime;
        private int counter;
    
        public Mario(Vector2 position)
        {
            marioState = MARIO_SMALL;
            marioDirection = MARIO_LEFT;
            marioAction = MARIO_IDLE;
            this.position = position;
            state = new IdleMarioState(this);
            InvincibilityTime = 0;

        }
        public Mario(Vector2 position, int marioState, bool marioDirection)
        {
            this.marioState = marioState;
            this.marioDirection = marioDirection;
            marioAction = MARIO_IDLE;
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
            marioState = form;
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
            state.Draw(position);
        }
        public void MarioUpdate()
        {
            state.Update();
            counter++;
            if(this.InvincibilityTime > 0 && counter > 10)
            {
                this.InvincibilityTime--;
                counter = 0;
            }
        }
        public void MarioChangeDireciton()
        {
            state.ChangeDirection();
        }
        public void MarioDie()
        {
            marioState = MARIO_DEAD;
            state.Die();
        }

        public void MarioGetHit()
        {
            if(!this.IsInvincible && this.marioState != MARIO_DEAD)
            {
                // The line below is risky, but works in our code.
                this.MarioChangeForm(this.marioState--);
                this.InvincibilityTime += 3;
            }
        }

    }
}

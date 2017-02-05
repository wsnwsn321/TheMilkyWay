using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.CharacterClass.Mario
{
    class Mario
    {
        public StateInterface.IMarioState state;
        public Mario()
        {
            state = new SpriteFactories.MarioSpriteFactory.
        }
        public void MarioIdle()
        {
            state.Idle();
        }
        public  void MarioChangeDirection()
        {
            state.ChangeDirection();
        }
        public void MarioChangeForm()
        {
            state.ChangeForm();
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

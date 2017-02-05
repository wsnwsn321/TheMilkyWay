using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.StateInterface
{
    public interface IMarioState
    {
        void Idle();
        void ChangeDirection();
        void ChangeForm();
        void Jump();
        void Crouch();
        void Run();
        void Draw();
        void Update();
    }
}

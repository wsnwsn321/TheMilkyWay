using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass
{
    public interface IMarioState
    {
        void Idle();
        void ChangeForm(int form);
        void Jump();
        void Crouch();
        void Run();
        void Draw();
        void Update();
    }
}

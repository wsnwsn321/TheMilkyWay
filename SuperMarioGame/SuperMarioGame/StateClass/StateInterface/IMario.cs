using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.StateInterface
{
    public interface IMario
    {
        void Idle();
        void ChangeDirection();
        void Jump();
        void Crounch();
        void Run();
        void Draw();
        void Update();
    }
}

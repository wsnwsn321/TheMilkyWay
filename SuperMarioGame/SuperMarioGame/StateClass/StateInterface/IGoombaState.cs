using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.StateClass.StateInterface
{
    public interface IGoombaState
    {

        void ChangeDirection();
        
        void BeStomped();

        void BeFilpped();

        void Update();

        void Draw();
    }
}

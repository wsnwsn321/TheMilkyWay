using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.ElementInterfaces
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

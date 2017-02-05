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
            state = new SpriteFactories.MarioSpriteFactory(this);
        }


    }
}

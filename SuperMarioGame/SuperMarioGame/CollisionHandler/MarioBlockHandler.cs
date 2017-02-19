using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.CollisionHandler
{
    class MarioBlockHandler
    {
        private static MarioBlockHandler instance = new MarioBlockHandler();


        public static MarioBlockHandler Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioBlockHandler()
        {
        }
    }
}

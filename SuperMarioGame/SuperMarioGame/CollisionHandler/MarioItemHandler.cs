using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.CollisionHandler
{
    class MarioItemHandler
    {
        private static MarioItemHandler instance = new MarioItemHandler();


        public static MarioItemHandler Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioItemHandler()
        {
        }
    }
}

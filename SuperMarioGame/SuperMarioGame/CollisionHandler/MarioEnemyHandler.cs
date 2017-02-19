using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.CollisionHandler
{
    class MarioEnemyHandler
    {
        private static MarioEnemyHandler instance = new MarioEnemyHandler();


        public static MarioEnemyHandler Instance
        {
            get
            {
                return instance;
            }
        }

        private MarioEnemyHandler()
        {
        }
    }
}

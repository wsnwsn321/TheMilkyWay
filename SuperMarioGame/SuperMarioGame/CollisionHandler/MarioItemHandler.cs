using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using Microsoft.Xna.Framework;

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
        public static void ItemHandler(Mario mario,  IItem item, int CollisionSide)
        {
            if (CollisionSide==1|| CollisionSide==2| CollisionSide==3|| CollisionSide==4)
            {
                    
                    if(item is ElementClasses.ItemClass.RedMushroom)
                    {
                        mario.state.ChangeForm(2);
                        
                    }
                if (item is ElementClasses.ItemClass.Flower)
                {
                    mario.state.ChangeForm(3);
                }
            }
        }
    }
}

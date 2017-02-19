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
                    
                    if(item is ElementClasses.ItemClass.RedMushroom)
                    {
                        
                        if(mario.marioState != ElementClasses.Mario.MARIO_BIG && !item.noD)
                    {
                            mario.state.ChangeForm(2);
                            item.noD = true;
                    }
                        
                    }


                if (item is ElementClasses.ItemClass.Flower)
                {
                    if (mario.marioState != ElementClasses.Mario.MARIO_FIRE && !item.noD)
                    {
                        mario.state.ChangeForm(3);
                        item.noD = true;
                }
                }
            
        }
    }
}

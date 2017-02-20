using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.ElementClasses.ItemClass;

namespace SuperMarioGame.CollisionHandler
{
    public static class MarioItemHandler
    {
        public static void ItemHandler(Mario mario,  IItem item, int CollisionSide)
        {
                    
            if(item is RedMushroom)
            {
                        
                if(mario.marioState != Mario.MARIO_BIG && item.isVisible && mario.marioState !=Mario.MARIO_DEAD)
                {
                        mario.state.ChangeForm(2);
                        item.isVisible = false;
                }
                        
            }


            if (item is Flower)
            {
                if (mario.marioState != Mario.MARIO_FIRE && item.isVisible && mario.marioState != Mario.MARIO_DEAD)
                {
                    mario.state.ChangeForm(3);
                    item.isVisible = false;
                }
            }

            if (item is Star)
            {
                    item.isVisible = false;
            }

            if (item is Coin)
            {
                item.isVisible = false;
            }
            if (item is GreenMushroom)
            {
                item.isVisible = false;
            }
        }
    }
}

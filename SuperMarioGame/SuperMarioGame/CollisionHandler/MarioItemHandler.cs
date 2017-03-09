using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.ElementClasses.ItemClass;
using Microsoft.Xna.Framework;

namespace SuperMarioGame.CollisionHandler
{
    public static class MarioItemHandler
    {
        public static void ItemHandler(Mario mario,  IItem item)
        {
                    
            if(item is RedMushroom)
            {
                        
                if(mario.marioState ==Mario.MARIO_SMALL && item.isVisible)
                {
                        mario.state.ChangeForm(Mario.MARIO_BIG);
                        mario.position = new Vector2(mario.position.X, mario.position.Y - 30);
                }
                item.isVisible = false;  
            }


            if (item is Flower)
            {
                if (mario.marioState != Mario.MARIO_FIRE && item.isVisible)
                {
                    if (mario.marioState == Mario.MARIO_SMALL)
                    {
                        mario.state.ChangeForm(Mario.MARIO_BIG);
                        mario.position = new Vector2(mario.position.X, mario.position.Y - 30);
                    }
                    else
                    {
                        mario.state.ChangeForm(Mario.MARIO_FIRE);  
                    }
                    
                }
                item.isVisible = false;
            }

            if (item is Star)
            {
                if (item.isVisible)
                {
                    item.isVisible = false;
                    mario.GetStar();
                }
            }

            if (item is Coin)
            {
                if (item.isVisible)
                {
                    item.isVisible = false;
                }
            }
            if (item is GreenMushroom)
            {
                if (item.isVisible)
                {
                    item.isVisible = false;
                }
            }
        }
    }
}

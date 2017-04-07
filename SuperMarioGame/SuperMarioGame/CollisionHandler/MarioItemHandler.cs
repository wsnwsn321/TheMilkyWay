﻿using SuperMarioGame.ElementClasses.ElementInterfaces;
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
                if (mario.marioState ==Mario.MARIO_SMALL && item.isVisible)
                {
                    mario.animated = true;
                    mario.animation = GameConstants.GrowAnimation;
                    //score part
                    mario.isScored = true;
                    mario.score = 1000;
                    mario.totalScore += mario.score;
                    Vector2 newP;
                    newP.X = mario.position.X + 12;
                    newP.Y = mario.position.Y - 3;
                    mario.textPosition = newP;
                }
                item.isVisible = false;  
            }


            if (item is Flower)
            {
               
                if (mario.marioState != Mario.MARIO_FIRE && item.isVisible)
                {
                    //score part
                    mario.isScored = true;
                    mario.score = 1000;
                    mario.totalScore += mario.score;
                    Vector2 newP;
                    newP.X = mario.position.X + 12;
                    newP.Y = mario.position.Y - 3;
                    mario.textPosition = newP;
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
                if(mario.marioState == Mario.MARIO_FIRE && item.isVisible)
                {
                    //score part
                    mario.isScored = true;
                    mario.score = 1000;
                    mario.totalScore += mario.score;
                    Vector2 newP;
                    newP.X = mario.position.X + 12;
                    newP.Y = mario.position.Y - 3;
                    mario.textPosition = newP;
                }
                item.isVisible = false;
            }

            if (item is Star)
            {
                if (item.isVisible)
                {
                    item.isVisible = false;
                    //score part
                    mario.isScored = true;
                    mario.score = 1000;
                    mario.totalScore += mario.score;
                    Vector2 newP;
                    newP.X = mario.position.X + 12;
                    newP.Y = mario.position.Y - 3;
                    mario.textPosition = newP;
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
                    //score part
                    mario.isScored = true;
                    mario.isGreenMushroom = true;
                    mario.score = 0;
                    mario.totalScore += mario.score;
                    Vector2 newP;
                    newP.X = mario.position.X + 12;
                    newP.Y = mario.position.Y - 3;
                    mario.textPosition = newP;
                   
                }
            }
        }
    }
}

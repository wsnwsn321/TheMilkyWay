using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.ElementClasses.ItemClass;
using Microsoft.Xna.Framework;
using SuperMarioGame.Sound.MarioSound;

namespace SuperMarioGame.CollisionHandler
{
    public static class MarioItemHandler
    {
        public static void ItemHandler(Mario mario,  IItem item)
        {
            int TWELVE = 12;
            int THIRTY = 30;
            int THREE = 3;
            int TEN = 10;
            if(item is RedMushroom)
            {
                if (mario.marioState ==Mario.MARIO_SMALL && item.isVisible)
                {
                    MarioSoundManager.instance.playSound(MarioSoundManager.POWERUP);
                    mario.animated = true;
                    mario.animation = GameConstants.GrowAnimation;
                    //score part
                    mario.isScored = true;
                    mario.score = 1000;
                    mario.totalScore += mario.score;
                    Vector2 newP;
                    newP.X = mario.position.X + TWELVE;
                    newP.Y = mario.position.Y -THREE;
                    mario.textPosition = newP;
                }
                item.isVisible = false;  
            }


            if (item is Flower && item.isVisible)
            {
                MarioSoundManager.instance.playSound(MarioSoundManager.POWERUP);
                if (mario.marioState != Mario.MARIO_FIRE && item.isVisible)
                {
                    //score part
                    mario.isScored = true;
                    mario.score = 1000;
                    mario.totalScore += mario.score;
                    Vector2 newP;
                    newP.X = mario.position.X + TWELVE;
                    newP.Y = mario.position.Y -THREE;
                    mario.textPosition = newP;
                    if (mario.marioState == Mario.MARIO_SMALL)
                    {
                        mario.state.ChangeForm(Mario.MARIO_BIG);
                        mario.position = new Vector2(mario.position.X, mario.position.Y - THIRTY);
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
                    newP.X = mario.position.X + TWELVE;
                    newP.Y = mario.position.Y -THREE;
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
                    newP.X = mario.position.X + TWELVE;
                    newP.Y = mario.position.Y -THREE;
                    mario.textPosition = newP;
                    mario.GetStar();
                }
            }

            if (item is Coin)
            {
                if (item.isVisible)
                {
                    MarioSoundManager.instance.playSound(MarioSoundManager.COIN);
                    mario.isScored = true;
                    mario.score = 200;
                    mario.coin += 1;
                    mario.totalScore += mario.score;
                    mario.textPosition = new Vector2(mario.position.X, mario.position.Y - TEN);
                    item.isVisible = false;
                }
            }
            if (item is GreenMushroom)
            {
                if (item.isVisible)
                {
                    MarioSoundManager.instance.playSound(MarioSoundManager.ONEUP);
                    item.isVisible = false;
                    //score part
                    mario.isScored = true;
                    mario.isGreenMushroom = true;
                    mario.score = 0;
                    mario.totalScore += mario.score;
                    Vector2 newP;
                    newP.X = mario.position.X + TWELVE;
                    newP.Y = mario.position.Y -THREE;
                    mario.textPosition = newP;
                   
                }
            }
        }
    }
}

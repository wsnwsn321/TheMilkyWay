using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses;
using Sprint6.ElementClasses.ItemClass;
using Microsoft.Xna.Framework;
using Sprint6.Sound.MarioSound;

namespace Sprint6.CollisionHandler
{
    public static class MainCharItemHandler
    {
        public static void ItemHandler(Game1 game, MainCharacter mainCharacter,  IItem item)
        {
            int TWELVE = 12;
            int THIRTY = 30;
            int THREE = 3;
            int TEN = 10;
            if(item is RedMushroom)
            {
                if (mainCharacter.marioState ==MainCharacter.MARIO_SMALL && item.isVisible)
                {
                    MainCharSoundManager.instance.playSound(MainCharSoundManager.POWERUP);
                    mainCharacter.animated = true;
                    mainCharacter.animation = GameConstants.GrowAnimation;
                    //score part
                    mainCharacter.isScored = true;
                    mainCharacter.score = 1000;
                    mainCharacter.totalScore += mainCharacter.score;
                    Vector2 newP;
                    newP.X = mainCharacter.position.X + TWELVE;
                    newP.Y = mainCharacter.position.Y -THREE;
                    mainCharacter.textPosition = newP;
                }
                item.isVisible = false;  
            }


            if (item is Flower && item.isVisible)
            {
                MainCharSoundManager.instance.playSound(MainCharSoundManager.POWERUP);
                if (mainCharacter.marioState != MainCharacter.MARIO_FIRE && item.isVisible)
                {
                    //score part
                    mainCharacter.isScored = true;
                    mainCharacter.score = 1000;
                    mainCharacter.totalScore += mainCharacter.score;
                    Vector2 newP;
                    newP.X = mainCharacter.position.X + TWELVE;
                    newP.Y = mainCharacter.position.Y -THREE;
                    mainCharacter.textPosition = newP;
                    if (mainCharacter.marioState == MainCharacter.MARIO_SMALL)
                    {
                        mainCharacter.state.ChangeForm(MainCharacter.MARIO_BIG);
                        mainCharacter.position = new Vector2(mainCharacter.position.X, mainCharacter.position.Y - THIRTY);
                    }
                    else
                    {
                        mainCharacter.state.ChangeForm(MainCharacter.MARIO_FIRE);
                    }
                    
                }
                if(mainCharacter.marioState == MainCharacter.MARIO_FIRE && item.isVisible)
                {
                    //score part
                    mainCharacter.isScored = true;
                    mainCharacter.score = 1000;
                    mainCharacter.totalScore += mainCharacter.score;
                    Vector2 newP;
                    newP.X = mainCharacter.position.X + TWELVE;
                    newP.Y = mainCharacter.position.Y -THREE;
                    mainCharacter.textPosition = newP;
                }
                item.isVisible = false;
            }

            if (item is Star)
            {
                if (item.isVisible)
                {
                    item.isVisible = false;
                    //score part
                    mainCharacter.isScored = true;
                    mainCharacter.score = 1000;
                    mainCharacter.totalScore += mainCharacter.score;
                    Vector2 newP;
                    newP.X = mainCharacter.position.X + TWELVE;
                    newP.Y = mainCharacter.position.Y -THREE;
                    mainCharacter.textPosition = newP;
                    mainCharacter.GetStar();
                }
            }

            if (item is Coin)
            {
                if (item.isVisible)
                {
                    MainCharSoundManager.instance.playSound(MainCharSoundManager.COIN);
                    mainCharacter.isScored = true;
                    mainCharacter.score = 200;
                    mainCharacter.coin += 1;
                    mainCharacter.totalScore += mainCharacter.score;
                    mainCharacter.textPosition = new Vector2(mainCharacter.position.X, mainCharacter.position.Y - TEN);
                    item.isVisible = false;
                }
            }
            if (item is GreenMushroom)
            {
                if (item.isVisible)
                {
                    game.lifeCount++;
                    MainCharSoundManager.instance.playSound(MainCharSoundManager.ONEUP);
                    item.isVisible = false;
                    //score part
                    mainCharacter.isScored = true;
                    mainCharacter.isGreenMushroom = true;
                    mainCharacter.score = 0;
                    mainCharacter.totalScore += mainCharacter.score;
                    Vector2 newP;
                    newP.X = mainCharacter.position.X + TWELVE;
                    newP.Y = mainCharacter.position.Y -THREE;
                    mainCharacter.textPosition = newP;
                   
                }
            }
        }
    }
}

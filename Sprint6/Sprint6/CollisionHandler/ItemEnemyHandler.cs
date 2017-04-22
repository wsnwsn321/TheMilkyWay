using TheMilkyWay.ElementClasses.ElementInterfaces;
using TheMilkyWay.ElementClasses;
using TheMilkyWay.Sprites.UFOSprite;
using TheMilkyWay.Sound.MarioSound;

namespace TheMilkyWay.CollisionHandler
{
    public static class ItemEnemyHandler
    {
        public static void EnemyHandler(IItem item, IEnemy enemy, int CollisionSide)
        {
            switch (CollisionSide)
            {
                case 1:
                    item.isVisible = false;
                    //MainCharSoundManager.instance.playSound(MainCharSoundManager.KICK);
                    break;
                case 2:
                    item.isVisible = false;
                    //MainCharSoundManager.instance.playSound(MainCharSoundManager.KICK);
                    break;
                case 3:
                    item.isVisible = false;
                   // MainCharSoundManager.instance.playSound(MainCharSoundManager.KICK);
                    break;
                case 4:
                    item.isVisible = false;
                  //  MainCharSoundManager.instance.playSound(MainCharSoundManager.KICK);
                    break;
            }
        }
    }
}


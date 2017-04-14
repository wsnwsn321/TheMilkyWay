using Sprint6.ElementClasses.ElementInterfaces;
using Sprint6.ElementClasses;
using Sprint6.Sprites.UFOSprite;
using Sprint6.Sound.MarioSound;

namespace Sprint6.CollisionHandler
{
    public static class ItemEnemyHandler
    {
        public static void EnemyHandler(IItem item, IEnemy enemy, int CollisionSide)
        {
            switch (CollisionSide)
            {
                case 1:
                    item.isVisible = false;
                    enemy.BeFlipped();
                    MainCharSoundManager.instance.playSound(MainCharSoundManager.KICK);
                    break;
                case 2:
                    item.isVisible = false;
                    enemy.BeFlipped();
                    MainCharSoundManager.instance.playSound(MainCharSoundManager.KICK);
                    break;
                case 3:
                    item.isVisible = false;
                    enemy.BeFlipped();
                    MainCharSoundManager.instance.playSound(MainCharSoundManager.KICK);
                    break;
                case 4:
                    item.isVisible = false;
                    enemy.BeFlipped();
                    MainCharSoundManager.instance.playSound(MainCharSoundManager.KICK);
                    break;
            }
        }
    }
}


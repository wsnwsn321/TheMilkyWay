using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.CollisionHandler
{
    public static class ItemEnemyHandler
    {
        public static void EnemyHandler(IItem item, IEnemy enemy, int CollisionSide)
        {
            if (!(enemy.enemySprite is GoombaStompedSprite) && !(enemy.enemySprite is KoopaStompedSprite) && item.itemSprite is FireballSprite)
            {
                switch (CollisionSide)
                {
                    case 1:
                        item.isVisible = false;
                        enemy.BeStomped();
                        break;
                    case 2:
                        item.isVisible = false;
                        enemy.BeStomped();
                        break;
                    case 3:
                        item.isVisible = false;
                        enemy.BeStomped();
                        break;
                    case 4:
                        item.isVisible = false;
                        enemy.BeStomped();
                        break;
                }
            }
        }
    }
}

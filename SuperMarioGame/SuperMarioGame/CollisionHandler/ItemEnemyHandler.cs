using SuperMarioGame.ElementClasses.ElementInterfaces;
using SuperMarioGame.ElementClasses;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.CollisionHandler
{
    public static class ItemEnemyHandler
    {
        public static void EnemyHandler(IItem item, IEnemy enemy, int CollisionSide)
        {
            if (item.isVisible && !(enemy.enemySprite is GoombaStompedSprite) && !(enemy.enemySprite is KoopaStompedSprite) && item.itemSprite is FireballSprite)
            {
                switch (CollisionSide)
                {
                    case 1:
                        item.isVisible = false;
                        enemy.BeFlipped();
                        
                        break;
                    case 2:
                        item.isVisible = false;
                        enemy.BeFlipped();
                        break;
                    case 3:
                        item.isVisible = false;
                        enemy.BeFlipped();
                        break;
                    case 4:
                        item.isVisible = false;
                        enemy.BeFlipped();
                        break;
                }
            }
        }
    }
}

using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ElementInterfaces
{
    public interface IEnemy
    {
        ISprite enemySprite { get; set; }
        Vector2 position { get; set; }
        void Draw();
        void Update();
        void EnemyIdle();
        void ChangeDirection();
       void BeStomped();



    }
}

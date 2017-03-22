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
        void BeFlipped();

        bool isVisible { get; set; }
        bool flip { get; set; }

        float gravity { get; set; }
        bool onTop { get; set; }
    }
}

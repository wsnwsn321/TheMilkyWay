using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ElementInterfaces
{
    public interface IEnemy
    {
        Vector2 position { get; set; }
        void Draw();
        void Update();
        ISprite enemySprite { get; set; }

    }
}

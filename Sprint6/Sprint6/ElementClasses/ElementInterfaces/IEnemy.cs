using Microsoft.Xna.Framework;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses.ElementInterfaces
{
    public interface IEnemy
    {
        ISprite enemySprite { get; set; }
        Vector2 position { get; set; }
        void Draw();
        void Update();
        bool isVisible { get; set; }
        float gravity { get; set; }
    }
}

using Microsoft.Xna.Framework;
using TheMilkyWay.Sprites;
using TheMilkyWay.Sprites.UFOSprite;

namespace TheMilkyWay.ElementClasses.ElementInterfaces
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

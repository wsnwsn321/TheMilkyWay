using Microsoft.Xna.Framework;
using TheMilkyWay.Sprites;
using TheMilkyWay.Sprites.UFOSprite;

namespace TheMilkyWay.ElementClasses.ElementInterfaces
{
    public interface IItem
    {
        Vector2 position { get; set; }
        void Draw();
        void Update();
        ISprite itemSprite { get; set; }
        bool isVisible { get; set; }
        int gravity { get; set; }

    }
}

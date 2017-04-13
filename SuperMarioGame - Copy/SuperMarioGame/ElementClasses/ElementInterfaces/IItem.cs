using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses.ElementInterfaces
{
    public interface IItem
    {
        Vector2 position { get; set; }
        void Draw();
        void Update();
        void ItemChangeDirection();
        ISprite itemSprite { get; set; }
        bool isVisible { get; set; }
        int gravity { get; set; }

    }
}

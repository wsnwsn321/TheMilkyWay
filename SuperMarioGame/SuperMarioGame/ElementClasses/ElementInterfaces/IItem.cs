using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ElementInterfaces
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

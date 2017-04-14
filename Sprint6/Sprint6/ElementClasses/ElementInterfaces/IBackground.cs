using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses.ElementInterfaces
{
    public interface IBackground
    {
        Vector2 position { get; set; }
        void Draw();
        void Update();
        ISprite backgroundSprite { get; set; }
    }
}

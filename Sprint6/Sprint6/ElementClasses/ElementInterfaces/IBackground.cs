using Microsoft.Xna.Framework;
using TheMilkyWay.Sprites;

namespace TheMilkyWay.ElementClasses.ElementInterfaces
{
    public interface IBackground
    {
        Vector2 position { get; set; }
        void Draw();
        void Update();
        ISprite backgroundSprite { get; set; }
    }
}

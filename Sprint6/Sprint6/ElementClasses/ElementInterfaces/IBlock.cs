using Microsoft.Xna.Framework;
using TheMilkyWay.Sprites;
using TheMilkyWay.Sprites.UFOSprite;

namespace TheMilkyWay.ElementClasses.ElementInterfaces
{
    public interface IBlock
    {
        Vector2 position { get; set; }
        void Draw();
        void Update();
        ISprite blockSprite { get; set; }
        bool isVisible { get; set; }
    }
}

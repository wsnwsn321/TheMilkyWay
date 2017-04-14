using Microsoft.Xna.Framework;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses.ElementInterfaces
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

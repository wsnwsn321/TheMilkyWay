using Microsoft.Xna.Framework;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses.ElementInterfaces
{
    public interface IBlock
    {
        Vector2 position { get; set; }
        int bumpCount { get; set; }
        void Draw();
        void Update();
        void Bump();
        ISprite blockSprite { get; set; }
        bool isVisible { get; set; }
        bool isBroken { get; set; }
        bool isBumped { get; set; }

    }
}

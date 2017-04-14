using Microsoft.Xna.Framework;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses.ElementInterfaces
{
    public interface IBackground
    {
        Vector2 position { get; set; }
        void Draw();
        void Update();
        ISprite backgroundSprite { get; set; }

        bool moveDown { get; set; }
    }
}

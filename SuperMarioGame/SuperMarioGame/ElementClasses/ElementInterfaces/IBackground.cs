using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ElementInterfaces
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

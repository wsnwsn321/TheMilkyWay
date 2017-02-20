using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses.ElementInterfaces
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

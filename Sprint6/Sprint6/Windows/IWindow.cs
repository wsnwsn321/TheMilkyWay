using Microsoft.Xna.Framework;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6
{
    public interface IWindow
    {
        Rectangle windowRect { get; set; }
        void Display();
        bool isVisible { get; set; }
    }
}

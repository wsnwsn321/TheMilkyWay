using Microsoft.Xna.Framework;
using TheMilkyWay.Sprites;
using TheMilkyWay.Sprites.UFOSprite;

namespace TheMilkyWay
{
    public interface IWindow
    {
        Rectangle windowRect { get; set; }
        void Display();
    }
}

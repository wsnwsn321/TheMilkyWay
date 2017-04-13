using Microsoft.Xna.Framework;

namespace Sprint6.Sprites
{
    public interface ISprite
    {
        void Update();

        void Draw(Vector2 location);

        Rectangle desRectangle { get; set; }
    }
}

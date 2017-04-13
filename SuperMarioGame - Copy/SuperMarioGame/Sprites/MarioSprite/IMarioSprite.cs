using Microsoft.Xna.Framework;

namespace Sprint6.Sprites
{
    public interface IMarioSprite
    {
        void Update();

        void Draw(Vector2 location);

        Rectangle desRectangle { get; set; }

        Color tintColor { get; set; }
    }
}

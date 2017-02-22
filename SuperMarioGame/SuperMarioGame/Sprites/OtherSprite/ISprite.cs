using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    public interface ISprite
    {
        void Update();

        void Draw(Vector2 location);

        Rectangle desRectangle { get; set; }
    }
}

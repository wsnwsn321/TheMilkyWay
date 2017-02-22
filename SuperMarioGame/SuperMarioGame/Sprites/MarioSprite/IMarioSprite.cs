using Microsoft.Xna.Framework;

namespace SuperMarioGame.Sprites
{
    public interface IMarioSprite
    {
        void Update();

        void Draw(Vector2 location);

        Rectangle desRectangle { get; set; }
        
        Color tintColor { get; set; }
    }
}

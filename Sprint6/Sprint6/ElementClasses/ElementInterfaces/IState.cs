using Microsoft.Xna.Framework;
using Sprint6.Sprites;
using Sprint6.Sprites.UFOSprite;

namespace Sprint6.ElementClasses
{
    public interface IState
    {
        void Draw(Vector2 Position);
        void Update();
        void Die();
        void Collect();
        bool beam { get; set; }
        bool bomb { get; set; }
        ISprite BeamSprite { get; set; }
        ISprite BombSprite { get; set; }
        ISprite Sprite { get; set; }
    }
}

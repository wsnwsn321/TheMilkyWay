using Microsoft.Xna.Framework;
using TheMilkyWay.Sprites;
using TheMilkyWay.Sprites.UFOSprite;

namespace TheMilkyWay.ElementClasses
{
    public interface IState
    {
        void Draw(Vector2 Position);
        void Update();
        void Die();
        void Collect();
        bool beam { get; set; }
        ISprite BeamSprite { get; set; }
        ISprite Sprite { get; set; }
    }
}

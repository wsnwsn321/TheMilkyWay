using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    public interface IState
    {
        void Idle();
        void ChangeForm(int form);
        void Jump();
        void Draw(Vector2 Position);
        void Update();
        void Die();
        void Attack();
        ISprite Sprite { get; set; }
    }
}

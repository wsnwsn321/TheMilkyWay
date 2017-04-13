using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    public interface IMarioState
    {
        void Idle();
        void ChangeForm(int form);
        void Jump();
        void Crouch();
        void Run();
        void Draw(Vector2 Position);
        void Update();
        void ChangeDirection();
        void Die();
        void Attack();
        IMarioSprite marioSprite { get; set; }
    }
}

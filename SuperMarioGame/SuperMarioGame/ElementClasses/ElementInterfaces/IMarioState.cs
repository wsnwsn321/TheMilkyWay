using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;

namespace SuperMarioGame.ElementClasses
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
        ISprite marioSprite { get; set; }
    }
}

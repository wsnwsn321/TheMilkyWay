﻿using Microsoft.Xna.Framework;
using Sprint6.Sprites;

namespace Sprint6.ElementClasses
{
    public interface IState
    {
        void Draw(Vector2 Position);
        void Update();
        void Die();
        ISprite Sprite { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyGame;

namespace Sprint6.Sprites
{
    public interface ISprite
    {
        Rectangle desRectangle { get; set; }
        int currentFrame { get; set; }
        List<Circle> circles { get; set; }
        void Update();
        void Draw(Vector2 pos);


    }
}

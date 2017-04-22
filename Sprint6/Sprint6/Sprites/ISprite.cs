using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyGame;
using System.Collections.ObjectModel;

namespace TheMilkyWay.Sprites
{
    public interface ISprite
    {
        Rectangle desRectangle { get; set; }
        int currentFrame { get; set; }
        bool canMove { get; set; }
        Collection<Circle> circles { get; }
        void Update();
        void Draw(Vector2 pos);


    }
}

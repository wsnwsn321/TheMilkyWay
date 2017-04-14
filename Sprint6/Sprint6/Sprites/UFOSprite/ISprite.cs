using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint6.Sprites.UFOSprite
{
    public interface ISprite
    {
        Rectangle desRectangle { get; set; }
        int currentFrame { get; set; }
        void Update();
        void Draw(Vector2 pos);


    }
}

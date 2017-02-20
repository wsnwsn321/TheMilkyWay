using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.ElementInterfaces
{
    public interface IItem
    {
        Vector2 position { get; set; }
        void Draw();
        void Update();
        ISprite itemSprite { get; set; }
        bool isVisible { get; set; }

    }
}

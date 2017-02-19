using Microsoft.Xna.Framework;
using SuperMarioGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGame.ElementClasses.ElementInterfaces
{
    public interface IBackground
    {
        Vector2 position { get; set; }
        void Draw();
        void Update();
        ISprite backgroundSprite { get; set; }

    }
}
